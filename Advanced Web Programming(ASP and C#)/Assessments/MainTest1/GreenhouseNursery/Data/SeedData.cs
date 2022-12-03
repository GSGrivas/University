using GreenhouseNursery.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GreenhouseNursery.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryName = "Herbs" }, //1
                    new Category { CategoryName = "Shrubs" }, //2
                    new Category { CategoryName = "Trees" },  //3
                    new Category { CategoryName = "Climbers" }, //4
                    new Category { CategoryName = "Creepers" } //5
                    );
            }
            if (!context.Plants.Any())
            {
                context.Plants.AddRange(
                    new Plant { PlantCommonName = "Mint", PlantScientificName = "Mentha", PlantWaterNeed = 3, PlantPrice = 34.99m, PlantDateAdded = DateTime.Parse("2019-02-01"), CategoryId = 1},
                    new Plant { PlantCommonName = "Basil", PlantScientificName = "Cimum basilicum", PlantWaterNeed = 4, PlantPrice = 34.99m, PlantDateAdded = DateTime.Parse("2019-02-01"), CategoryId = 1 },
                    new Plant { PlantCommonName = "Parsley", PlantScientificName = "Petroselinum crispum", PlantWaterNeed = 3, PlantPrice = 34.99m, PlantDateAdded = DateTime.Parse("2019-02-01"), CategoryId = 1 },
                    new Plant { PlantCommonName = "Spekboom", PlantScientificName = "Portulacaria Afra", PlantWaterNeed = 1, PlantPrice = 75.99m, PlantDateAdded = DateTime.Parse("2021-02-01"), CategoryId = 3 },
                    new Plant { PlantCommonName = "Lavender Tree", PlantScientificName = "Heteropysix natalensis", PlantWaterNeed = 3, PlantPrice = 349.99m, PlantDateAdded = DateTime.Parse("2021-02-01"), CategoryId = 3 },
                    new Plant { PlantCommonName = "False Olive", PlantScientificName = "Buddleja saligna", PlantWaterNeed = 2, PlantPrice =250.00m, PlantDateAdded = DateTime.Parse("2021-04-01"), CategoryId = 3 },
                    new Plant { PlantCommonName = "African Iris", PlantScientificName = "Dietes iridioides", PlantWaterNeed = 1, PlantPrice = 65.50m, PlantDateAdded = DateTime.Parse("2020-04-01"), CategoryId = 2 },
                    new Plant { PlantCommonName = "Hibiscus", PlantScientificName = "Hibiscus", PlantWaterNeed = 4, PlantPrice = 175.99m, PlantDateAdded = DateTime.Parse("2019-02-01"), CategoryId = 2 }
                    );
            }

            context.SaveChanges();
        }
    }
}
