using NZWalkTutorial.Models.Domains;

namespace NZWalkTutorial.DTO
{
    public class AddRegionReq
    {

        public string Code { get; set; }

        public string Name { get; set; }

        public double Area { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }

        public double Population { get; set; }

    }
}
