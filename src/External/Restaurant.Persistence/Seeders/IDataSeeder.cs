using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Seeders
{
    internal interface IDataSeeder
    {
        Task SeedAsync(RestaurantDbContext context);
    }
}
