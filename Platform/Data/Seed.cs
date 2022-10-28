using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Platform.Data
{
    public static class Seed
    {
        public static void SeedData(this IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            if (scopedFactory is not null)
            {
                using (var scope = scopedFactory.CreateScope())
                {

                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    try
                    {                        
                        context.Database.Migrate();
                        var service = scope.ServiceProvider.GetService<DataSeeder>();
                        if (service is not null)
                            service.Seed();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("------> Error occured------> {0}", e.Message);
                    }

                }
            }
        }
    }
}