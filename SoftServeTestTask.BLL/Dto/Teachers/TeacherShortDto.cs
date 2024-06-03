using SoftServeTestTask.BLL.Dto.Courses;

namespace SoftServeTestTask.BLL.Dto.Teachers
{
    public record TeacherShortDto(
        int Age,
        int ExperienceYears,
        string FirstName,
        string SecondName,
        string ThirdName,
        string AcademicDegree,
        string Gender,
        ICollection<CourseShortDto> Courses);
}
