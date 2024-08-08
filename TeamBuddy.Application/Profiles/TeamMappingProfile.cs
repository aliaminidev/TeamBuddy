using AutoMapper;
using TeamBuddy.Application.DTOs.Team;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();
        }
    }
}
