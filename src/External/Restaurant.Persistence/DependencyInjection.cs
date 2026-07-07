using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Services.Authentication;
using Restaurant.Application.Services.Catalog;
using Restaurant.Application.Services.Misc;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Production;
using Restaurant.Application.Services.Territory;
using Restaurant.Domain.Repositories.Catalog;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Domain.Repositories.Identity;
using Restaurant.Domain.Repositories.Misc;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Domain.Repositories.Territory;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Repositories.Catalog;
using Restaurant.Persistence.Repositories.Guest;
using Restaurant.Persistence.Repositories.Identity;
using Restaurant.Persistence.Repositories.Misc;
using Restaurant.Persistence.Repositories.Production;
using Restaurant.Persistence.Repositories.Territory;
using Restaurant.Persistence.Seeders;
using Restaurant.Persistence.Services.Authentication;
using Restaurant.Persistence.Services.Catalog;
using Restaurant.Persistence.Services.Misc;
using Restaurant.Persistence.Services.Persistence;
using Restaurant.Persistence.Services.Production;
using Restaurant.Persistence.Services.Territory;

namespace Restaurant.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // ── Database ─────────────────────────────────────────────────────
            services.AddDbContext<RestaurantDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("MyConnectString"),
                    sqlOptions => sqlOptions.MigrationsAssembly(
                        typeof(RestaurantDbContext).Assembly.FullName)));

            // ── Seeders ──────────────────────────────────────────────────────

            // Orchestrator seeder
            services.AddScoped<DatabaseSeeder>();

            // Auto-register all IDataSeeder implementations
            var seederTypes = typeof(DependencyInjection).Assembly.GetTypes()
                .Where(t => typeof(IDataSeeder).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in seederTypes)
            {
                services.AddScoped(type);
            }

            // ── Repositories ─────────────────────────────────────────────────
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IRestaurantTableRepository, RestaurantTableRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRecipeRespository, RecipeRepository>();

            // ── AutoMapper ───────────────────────────────────────────────────
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));


            // ── Service ──────────────────────────────────────────────────────
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IRestaurantTableService, RestaurantTableService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IRecipeService, RecipeService>();

            return services;
        }

        public static async Task InitialiseDatabaseAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var sp = scope.ServiceProvider;

            var context = sp.GetRequiredService<RestaurantDbContext>();
            await context.Database.MigrateAsync();

            var seeder = sp.GetRequiredService<DatabaseSeeder>();
            await seeder.SeedAllAsync();
        }
    }
}
