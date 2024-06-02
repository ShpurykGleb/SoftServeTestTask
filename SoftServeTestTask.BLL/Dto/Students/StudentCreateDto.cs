using SoftServeTestTask.BLL.Dto.Courses;

namespace SoftServeTestTask.BLL.Dto.Students
{
    public record StudentCreateDto(
        int Age,
        string FirstName,
        string SecondName,
        string ThirdName,
        string Gender,
        string Group,
        decimal GPA,      
        ICollection<EntityDto> Courses);   
}
