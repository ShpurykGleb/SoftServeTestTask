using SoftServeTestTask.BLL.Dto.Courses;

namespace SoftServeTestTask.BLL.Dto.Teachers
{
    public record TeacherCreateDto(
        int Age,
        int ExperienceYears,
        string FirstName,
        string SecondName,
        string ThirdName,       
        string Gender,
        string AcademicDegree,   
        ICollection<EntityDto> Courses);
}
