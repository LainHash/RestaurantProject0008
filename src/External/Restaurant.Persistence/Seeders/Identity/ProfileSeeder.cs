using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Seeders.Identity
{
    internal class ProfileSeeder : IDataSeeder
    {
        public async Task SeedAsync(RestaurantDbContext context)
        {
            if (await context.Profiles.AnyAsync())
                return;

            var xlsxPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data", "RestaurantData.xlsx");

            if (!File.Exists(xlsxPath))
                throw new FileNotFoundException($"Seed data file not found: {xlsxPath}");

            var records = MiniExcel.Query<ProfileExcelRecord>(xlsxPath, sheetName: "Profile").ToList();

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var record in records)
                {
                    context.Profiles
                    .Add(new Profile(record.Id, record.FirstName, record.LastName, DateOnly.FromDateTime(record.DOB), record.Gender, record.Address, record.City, record.Country, record.Phone, record.CitizenCardId));
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            });
        }

        private class ProfileExcelRecord
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public DateTime DOB { get; set; }
            public bool Gender { get; set; }
            public string Address { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            public string Country { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string CitizenCardId { get; set; } = string.Empty;
        }
    }
}
