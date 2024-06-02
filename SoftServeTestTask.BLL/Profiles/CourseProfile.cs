using AutoMapper;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.BLL.Dto.Courses;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseShortDto>().ReverseMap();

            CreateMap<Course, EntityDto>().ReverseMap();

            CreateMap<Course, CourseQueryDto>()
                 .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers))
                 .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                 .ReverseMap();

            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
        }
    }
}
