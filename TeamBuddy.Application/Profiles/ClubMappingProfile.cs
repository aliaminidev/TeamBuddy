using AutoMapper;
using TeamBuddy.Application.DTOs.Club;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class ClubMappingProfile : Profile
    {
        public ClubMappingProfile()
        {
            CreateMap<Club, ClubDto>().ReverseMap();
            CreateMap<Club, CreateClubDto>().ReverseMap();
            CreateMap<Club, UpdateClubDto>().ReverseMap();
        }
    }
}
