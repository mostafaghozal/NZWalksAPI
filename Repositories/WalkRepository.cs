using Microsoft.EntityFrameworkCore;
using NZWalkTutorial.Data;
using NZWalkTutorial.DTO;
using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.Repositories
{

    public class WalkRepository : IWalkRepository
    {
        private readonly NZDbContext nZDbContext;

        public WalkRepository(NZDbContext nZDbContext)
        {
            this.nZDbContext = nZDbContext;
    }



  
        public async Task<Models.Domains.Walk> AddAsync(Models.Domains.Walk walk)
        {

            walk.Id = Guid.NewGuid();

            await nZDbContext.Walks.AddAsync(walk);
            await nZDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Models.Domains.Walk> DeleteAsync(Guid id)
        {
            var walk = await nZDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null) return null;
            else
            {
                nZDbContext.Walks.Remove(walk);
                await nZDbContext.SaveChangesAsync();
                return walk;

            }

        }

        public async Task<IEnumerable<Models.Domains.Walk>> GetAllAsync()
        {
       return await nZDbContext.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();
           
        }

        public Task<Models.Domains.Walk> GetAsync(Guid Id)
        {
            return nZDbContext.Walks.Include(x => x.Region).Include(x => x.WalkDifficulty).FirstOrDefaultAsync(x => x.Id==Id);   }

        public async Task<Models.Domains.Walk> UpdateAsync(Guid id, Models.Domains.Walk walk)
        {
            var existingwalk= await nZDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingwalk == null)
            { return null; }
            existingwalk.Name = walk.Name;
            existingwalk.Length = walk.Length;
            existingwalk.WalkDifficultyId = walk.WalkDifficultyId;
            existingwalk.RegionId = walk.RegionId;
            await nZDbContext.SaveChangesAsync();
            return existingwalk;
        }
    }
}
