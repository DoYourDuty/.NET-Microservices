using PlatformService.Models;
using Microsoft.EntityFrameworkCore;


namespace PlatformService.Data
{
    public static class PrepDb
    {

        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicesScope?.ServiceProvider?.GetService<AppDbContext>()!, isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                System.Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    // throw;
                }
            }

            if (!context?.Platforms?.Any() ?? false)
            {
                Console.WriteLine("--> Seeding Data....");

                context?.Platforms?.AddRange(
                   new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                   new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                   new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
               );

                context?.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> we already have data");
            }
        }
    }
}