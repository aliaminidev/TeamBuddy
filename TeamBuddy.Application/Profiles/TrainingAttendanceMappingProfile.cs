using AutoMapper;
using TeamBuddy.Application.DTOs.TrainingAttendance;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class TrainingAttendanceMappingProfile : Profile
    {
        public TrainingAttendanceMappingProfile()
        {
            CreateMap<TrainingAttendance, TrainingAttendanceDto>().ReverseMap();
            CreateMap<TrainingAttendance, CreateTrainingAttendanceDto>().ReverseMap();
            CreateMap<TrainingAttendance, UpdateTrainingAttendanceDto>().ReverseMap();
        }
    }
}
