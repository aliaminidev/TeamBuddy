using AutoMapper;
using TeamBuddy.Application.DTOs.TrainingSession;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class TrainingSessionMappingProfile : Profile
    {
        public TrainingSessionMappingProfile()
        {
            CreateMap<TrainingSession, TrainingSessionDto>().ReverseMap();
            CreateMap<TrainingSession, CreateTrainingSessionDto>().ReverseMap();
            CreateMap<TrainingSession, UpdateTrainingSessionDto>().ReverseMap();
        }
    }
}
