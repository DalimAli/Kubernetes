using Platform.Models;

namespace Platform.Repository
{
    public interface IPlatformRepository
    {
         public void Delete(long id);
         public Platforms Get(long id);
         public IEnumerable<Platforms> GetAll();
         public Platforms Add(Platforms platform);
         public Platforms Edit(long id,Platforms platform);
    }
}