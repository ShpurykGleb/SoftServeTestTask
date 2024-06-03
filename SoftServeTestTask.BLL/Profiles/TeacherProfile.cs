using AutoMapper;
using SoftServeTestTask.BLL.Dto;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherShortDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses))
                .ReverseMap();

            CreateMap<Teacher, TeacherCreateDto>()
                .ReverseMap();

            CreateMap<Teacher, TeacherWithIdDto>().ReverseMap();

            CreateMap<Teacher, TeacherWithoutCoursesDto>().ReverseMap();

            CreateMap<Teacher, EntityDto>().ReverseMap();
        }
    }
}
