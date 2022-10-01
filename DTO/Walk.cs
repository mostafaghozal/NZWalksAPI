
namespace NZWalkTutorial.DTO
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double Length { get; set; }


        public Guid RegionId { get; set; }
        public Guid WalkdifficulityId { get; set; } 
        //navigation 
        public Region Region { get; set; }
        public WalkDifficulity WalkDifficulty { get; set; }


    }
}
