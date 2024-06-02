using SoftServeTestTask.BLL.Dto.Courses;

namespace SoftServeTestTask.BLL.Dto.Students
{
    public record StudentShortDto(
        int Age,
        string FirstName,
        string SecondName,
        string ThirdName,
        string Gender,    
        string Group,
        decimal GPA,
        ICollection<CourseShortDto> Courses);
}
