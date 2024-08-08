using AutoMapper;
using TeamBuddy.Application.DTOs.TeamMember;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class TeamMemberMappingProfile : Profile
    {
        public TeamMemberMappingProfile()
        {
            CreateMap<TeamMember, TeamMemberDto>().ReverseMap();
            CreateMap<TeamMember, CreateTeamMemberDto>().ReverseMap();
            CreateMap<TeamMember, UpdateTeamMemberDto>().ReverseMap();
        }
    }
}
