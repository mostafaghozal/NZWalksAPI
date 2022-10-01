using Microsoft.EntityFrameworkCore;
using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.Data
{
    public class NZDbContext : DbContext
    {
        public NZDbContext(DbContextOptions<NZDbContext> options):base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulity> WalkDifficulity { get; set; }


    }
}
