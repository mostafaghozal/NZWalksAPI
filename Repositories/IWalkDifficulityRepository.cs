using NZWalkTutorial;

namespace NZWalkTutorial.Repositories
{
    public interface IWalkDifficulityRepository
    {
        Task<IEnumerable<Models.Domains.WalkDifficulity>> GetAllAsync();
        Task<Models.Domains.WalkDifficulity> GetAsync(Guid id);
        Task<Models.Domains.WalkDifficulity> AddAsync (Models.Domains.WalkDifficulity walkDifficulity);

        public Task<Models.Domains.WalkDifficulity> UpdateAsync(Guid id, Models.Domains.WalkDifficulity walkDifficulity);
        public Task<Models.Domains.WalkDifficulity> DeleteAsync(Guid id);

    }
}
