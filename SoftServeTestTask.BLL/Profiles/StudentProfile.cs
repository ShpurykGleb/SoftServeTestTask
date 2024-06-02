using AutoMapper;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentShortDto>()
                 .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses))
                 .ReverseMap();

            CreateMap<Student, StudentCreateDto>().ReverseMap();

            CreateMap<Student, StudentWithoutCoursesDto>().ReverseMap();

            CreateMap<Student, EntityDto>().ReverseMap();
        }
    }
}
