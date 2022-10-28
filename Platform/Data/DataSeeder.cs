using Platform.Models;

namespace Platform.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DataSeeder(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public void Seed()
        {
            if (!_applicationDbContext.Platforms.Any())
            {

                var platforms = new List<Platforms>(){
                    new Platforms(){
                        Name = "Sql Server",
                        Remarks = "Sql"
                    },
                    new Platforms(){
                        Name = "Docker",
                        Remarks = "Docker"
                    },
                    new Platforms(){
                        Name = "Dot Net",
                        Remarks = ".Net"
                    }
                };
                Console.WriteLine("-------> Seeding platform data");
                _applicationDbContext.Platforms.AddRange(platforms);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}