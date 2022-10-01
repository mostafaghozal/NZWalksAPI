using AutoMapper;

namespace NZWalkTutorial.Profiles
{

    public class RegionsProfile:Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domains.Region, DTO.Region>().ReverseMap();
            
        }
    }
}
