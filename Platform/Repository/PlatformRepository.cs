using Platform.Data;
using Platform.Models;

namespace Platform.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PlatformRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Platforms Add(Platforms platform)
        {
            _applicationDbContext.Platforms.Add(platform);
            _applicationDbContext.SaveChanges();
            return platform;
        }

        public void Delete(long id)
        {
            Platforms platform = this.Get(id);
            if (platform is null)
                throw new Exception("platform not found");

            _applicationDbContext.Platforms.Remove(platform);
            _applicationDbContext.SaveChanges();
            return;
        }

        public Platforms Edit(long id, Platforms platform)
        {
            Platforms platformFromDb = this.Get(id);
            if (platformFromDb is null)
                throw new Exception("platform not found");

            platformFromDb.Name = platform.Name;
            platformFromDb.Remarks = platform.Remarks;
            
            _applicationDbContext.SaveChanges();
            return platformFromDb;
        }

        public Platforms Get(long id)
        {
            return _applicationDbContext.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Platforms> GetAll()
        {
            return _applicationDbContext.Platforms.ToList();
        }
    }
}