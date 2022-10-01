using Microsoft.EntityFrameworkCore;
using NZWalkTutorial.Data;
using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZDbContext nZDbContext;

    public RegionRepository(NZDbContext nZDbContext)
        {
            this.nZDbContext = nZDbContext;
    }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
           await nZDbContext.AddAsync(region);
            await nZDbContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
var region = await   nZDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if(region == null) return null;
            else
            { nZDbContext.Regions.Remove(region);
                await nZDbContext.SaveChangesAsync();
                return region;
            
            }
        
    }

    //async to avoid waiting for other function on api , more responsive
    public async Task <IEnumerable<Region>> GetAllAsync()
        {
          return await nZDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid Id)
        {
            return await nZDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);        }

        public async Task<Region> UpdateAsync(Guid Id, Region region)

        {
            var existingregion = await nZDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if(existingregion == null)
            { return null;  }
            existingregion.Code = region.Code;
            existingregion.Name = region.Name;  
            existingregion.Area= region.Area;
            existingregion.Long=region.Long;
            existingregion.Lat = region.Lat;
            existingregion.Population = region.Population;
           await nZDbContext.SaveChangesAsync();
            return existingregion;
        }
    }
}
