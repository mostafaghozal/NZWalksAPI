using Microsoft.EntityFrameworkCore;
using NZWalkTutorial.Data;
using NZWalkTutorial.DTO;
using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.Repositories
{
    public class WalkDifficulityRepository : IWalkDifficulityRepository
    {
        private readonly NZDbContext nZDbContext;
        public WalkDifficulityRepository(NZDbContext nZDbContext)
        {
            this.nZDbContext=nZDbContext;
        }

        public async Task<Models.Domains.WalkDifficulity> AddAsync(Models.Domains.WalkDifficulity walkDifficulity)
        {
            walkDifficulity.Id = Guid.NewGuid();
            await nZDbContext.AddAsync(walkDifficulity);
            await nZDbContext.SaveChangesAsync();
            return walkDifficulity;
        }

        public async Task<Models.Domains.WalkDifficulity> DeleteAsync(Guid Id)
        {
            var walkdiff = await nZDbContext.WalkDifficulity.FirstOrDefaultAsync(x => x.Id == Id);
            if (walkdiff == null) return null;
            else
            {
                nZDbContext.WalkDifficulity.Remove(walkdiff);
                await nZDbContext.SaveChangesAsync();
                return walkdiff;

            }
        }

        public async Task<IEnumerable<Models.Domains.WalkDifficulity>> GetAllAsync()
        {
            return await nZDbContext.WalkDifficulity.ToListAsync();
        }

        public async Task<Models.Domains.WalkDifficulity> GetAsync(Guid id)
        {
            return await nZDbContext.WalkDifficulity.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Domains.WalkDifficulity> UpdateAsync(Guid Id, Models.Domains.WalkDifficulity walkDifficulity)
        {
            var existingwalkdiff = await nZDbContext.WalkDifficulity.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingwalkdiff == null)
            { return null; }
            existingwalkdiff.code = walkDifficulity.code;
           
            await nZDbContext.SaveChangesAsync();
            return existingwalkdiff;
        }
    }
}
