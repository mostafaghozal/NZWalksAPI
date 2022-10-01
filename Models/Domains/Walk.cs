namespace NZWalkTutorial.Models.Domains
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double Length { get; set; }

        //navigation 
        public Region Region { get; set; }
        public WalkDifficulity WalkDifficulty { get; set; }
        public Guid RegionId { get; internal set; }
        public Guid WalkDifficultyId { get; internal set; }
    }
}
