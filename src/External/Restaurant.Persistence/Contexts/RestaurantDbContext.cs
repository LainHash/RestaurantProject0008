using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Restaurant.Application.Services.Misc;
using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Entities.Inventory;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Enums;
using System.Reflection;
using System.Text.Json;

namespace Restaurant.Persistence.Contexts
{
    public class RestaurantDbContext : DbContext
    {
        private readonly AuditContext _auditContext;

        public RestaurantDbContext(
            DbContextOptions<RestaurantDbContext> options,
            AuditContext auditContext)
            : base(options)
        {
            _auditContext = auditContext;
        }

        // ── DbSets ──────────────────────────────────────────────────────────
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductStock> ProductStocks { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<ProductImage> ProductImages { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<IngredientStock> IngredientStocks { get; set; } = null!;

        public DbSet<Profile> Profiles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        public DbSet<Area> Areas { get; set; } = null!;
        public DbSet<RestaurantTable> RestaurantTables { get; set; } = null!;

        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
        public DbSet<RecipeStep> RecipeSteps { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<TemporaryContact> TemporaryContacts { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Wishlist> Wishlists { get; set; } = null!;
        public DbSet<WishlistItem> WishlistItems { get; set; } = null!;

        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<AuditLog> AuditLogs { get; set; } = null!;

        // ── Model building ──────────────────────────────────────────────────
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Auto-register all IEntityTypeConfiguration<T> classes in this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // ── Auto-set audit fields on SaveChanges ────────────────────────────
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            SetAuditFields();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            SetAuditFields();

            // ── Bước 1: Thu thập audit entries TRƯỚC khi lưu (cần OldValues) ──
            var auditEntries = BuildAuditEntries();

            // ── Bước 2: Lưu các entity chính ────────────────────────────────
            var result = await base.SaveChangesAsync(cancellationToken);

            // ── Bước 3: Lưu audit logs trong cùng transaction ───────────────
            if (auditEntries.Count > 0)
            {
                AuditLogs.AddRange(auditEntries);
                await base.SaveChangesAsync(cancellationToken);
            }

            return result;
        }

        private void SetAuditFields()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.MarkCreated(now);
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.MarkUpdated(now);
                }
            }
        }

        // ── Audit capture ────────────────────────────────────────────────────

        /// <summary>
        /// Thu thập danh sách audit entries từ ChangeTracker.
        /// Chỉ xử lý entity kế thừa <see cref="AuditableEntity"/>.
        /// Với Modified: chỉ ghi các property thực sự thay đổi (diff).
        /// </summary>
        private List<AuditLog> BuildAuditEntries()
        {
            var now = DateTime.UtcNow;
            var list = new List<AuditLog>();

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State is not (EntityState.Added or EntityState.Modified or EntityState.Deleted))
                    continue;

                var entityName = entry.Entity.GetType().Name;
                var action     = entry.State switch
                {
                    EntityState.Added    => AuditAction.Created,
                    EntityState.Modified => AuditAction.Updated,
                    EntityState.Deleted  => AuditAction.Deleted,
                    _                    => throw new InvalidOperationException()
                };

                string? oldValues = null;
                string? newValues = null;

                if (action == AuditAction.Created)
                {
                    // Lưu tất cả property có giá trị không null
                    var newDict = entry.Properties
                        .Where(p => p.CurrentValue is not null)
                        .ToDictionary(p => p.Metadata.Name, p => p.CurrentValue);
                    newValues = JsonSerializer.Serialize(newDict);
                }
                else if (action == AuditAction.Updated)
                {
                    // Chỉ lưu các property thực sự thay đổi (diff)
                    var oldDict = new Dictionary<string, object?>();
                    var newDict = new Dictionary<string, object?>();

                    foreach (var prop in entry.Properties)
                    {
                        var original = prop.OriginalValue;
                        var current  = prop.CurrentValue;

                        if (!Equals(original, current))
                        {
                            oldDict[prop.Metadata.Name] = original;
                            newDict[prop.Metadata.Name] = current;
                        }
                    }

                    if (oldDict.Count > 0)
                    {
                        oldValues = JsonSerializer.Serialize(oldDict);
                        newValues = JsonSerializer.Serialize(newDict);
                    }
                }
                else // Deleted
                {
                    var oldDict = entry.Properties
                        .Where(p => p.OriginalValue is not null)
                        .ToDictionary(p => p.Metadata.Name, p => p.OriginalValue);
                    oldValues = JsonSerializer.Serialize(oldDict);
                }

                // Entity.Id được set trong Entity() constructor bằng Guid.CreateVersion7()
                // nên luôn có giá trị — kể cả với Added state.
                var entityId = entry.Entity.Id.ToString();

                var log = AuditLog.Create(
                    entityName  : entityName,
                    entityId    : entityId,
                    action      : action,
                    oldValues   : oldValues,
                    newValues   : newValues,
                    actorId     : _auditContext.ActorId,
                    actorName   : _auditContext.ActorName,
                    ipAddress   : _auditContext.IpAddress,
                    occurredAt  : now);

                list.Add(log);
            }

            return list;
        }
    }
}
