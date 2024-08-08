using AutoMapper;
using TeamBuddy.Application.DTOs.Match;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<Match, CreateMatchDto>().ReverseMap();
            CreateMap<Match, UpdateMatchDto>().ReverseMap();
        }
    }
}
