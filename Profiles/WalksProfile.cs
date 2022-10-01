using AutoMapper;


namespace NZWalkTutorial.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domains.Walk, DTO.Walk>().ReverseMap();
            CreateMap<Models.Domains.WalkDifficulity, DTO.WalkDifficulity>().ReverseMap();

        }

    }
}
