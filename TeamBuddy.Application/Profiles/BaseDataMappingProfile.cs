using AutoMapper;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Profiles
{
    public class BaseDataMappingProfile : Profile
    {
        public BaseDataMappingProfile()
        {
            CreateMap<BaseData, BaseDataDto>().ReverseMap();
            CreateMap<BaseData, CreateBaseDataDto>().ReverseMap();
            CreateMap<BaseData, UpdateBaseDataDto>().ReverseMap();
        }
    }
}
