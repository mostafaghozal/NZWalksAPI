using NZWalkTutorial.Models.Domains;


/// awel entry point lama add function hya l repo
namespace NZWalkTutorial.Repositories
{
    public interface IRegionRepository
    {
    Task  <IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid Id);
        Task<Region> AddAsync (Region region);
        Task<Region> DeleteAsync (Guid Id);
        Task<Region> UpdateAsync(Guid Id,Region region);

    }
}
