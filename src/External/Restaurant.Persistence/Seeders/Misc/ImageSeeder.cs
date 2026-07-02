using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Seeders.Misc
{
    internal class ImageSeeder : IDataSeeder
    {
        public async Task SeedAsync(RestaurantDbContext context)
        {
            if (await context.Images.AnyAsync())
                return;

            var xlsxPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data", "RestaurantData.xlsx");

            if (!File.Exists(xlsxPath))
                throw new FileNotFoundException($"Seed data file not found: {xlsxPath}");

            var records = MiniExcel.Query<ImageExcelRecord>(xlsxPath, sheetName: "Images").ToList();

            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                foreach (var record in records)
                {
                    context.Images.Add(new Image(record.Id, record.AltText, record.Url, record.StoragePath, record.FileSize, record.ContentType, record.IsPrimary));
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            });
        }

        private class ImageExcelRecord
        {
            public Guid Id { get; set; }
            public string AltText { get; set; } = string.Empty;
            public string ContentType { get; set; } = string.Empty;
            public decimal FileSize { get; set; }
            public bool IsPrimary { get; set; }
            public string Url { get; set; } = string.Empty;
            public string StoragePath { get; set; } = string.Empty;
        }
    }
}
