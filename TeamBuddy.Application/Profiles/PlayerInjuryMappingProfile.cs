using AutoMapper;
using TeamBuddy.Application.DTOs.PlayerInjury;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class PlayerInjuryMappingProfile : Profile
    {
        public PlayerInjuryMappingProfile()
        {
            CreateMap<PlayerInjury, PlayerInjuryDto>().ReverseMap();
            CreateMap<PlayerInjury, CreatePlayerInjuryDto>().ReverseMap();
            CreateMap<PlayerInjury, UpdatePlayerInjuryDto>().ReverseMap();
        }
    }
}
