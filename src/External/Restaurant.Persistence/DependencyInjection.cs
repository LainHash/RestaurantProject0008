using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Services.Catalog;
using Restaurant.Application.Services.Persistence;
using Restaurant.Domain.Repositories.Catalog;
using Restaurant.Domain.Repositories.Misc;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Repositories.Catalog;
using Restaurant.Persistence.Repositories.Misc;
using Restaurant.Persistence.Seeders;
using Restaurant.Persistence.Services.Catalog;
using Restaurant.Persistence.Services.Persistence;

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

            // ── AutoMapper ───────────────────────────────────────────────────
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));


            // ── Service ──────────────────────────────────────────────────────
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IImageService, ImageService>();

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
