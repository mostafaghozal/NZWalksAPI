namespace NZWalkTutorial.DTO
{
    public class UpdateWalkReq
    {
        public string Name { get; set; }

        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkdifficulityId { get; set; }
    }
}
