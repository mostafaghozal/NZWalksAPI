using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.Repositories
{
    public interface IWalkRepository
    {
        public Task<IEnumerable<Walk>> GetAllAsync();
        public Task<Walk> GetAsync(Guid id);
        public Task<Walk> AddAsync(Walk walk);
        public Task<Walk> UpdateAsync(Guid id,Walk walk);
        public Task<Walk> DeleteAsync(Guid id);


    }
}
