using AutoMapper;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class PlayerMatchPerformanceMappingProfile : Profile
    {
        public PlayerMatchPerformanceMappingProfile()
        {
            CreateMap<PlayerMatchPerformance, PlayerMatchPerformanceDto>().ReverseMap();
            CreateMap<PlayerMatchPerformance, CreatePlayerMatchPerformanceDto>().ReverseMap();
            CreateMap<PlayerMatchPerformance, UpdatePlayerMatchPerformanceDto>().ReverseMap();
        }
    }
}
