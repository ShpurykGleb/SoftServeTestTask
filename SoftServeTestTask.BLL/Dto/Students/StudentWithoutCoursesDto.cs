namespace SoftServeTestTask.BLL.Dto.Students
{
    public record StudentWithoutCoursesDto(
        int Id,
        int Age,
        string FirstName,
        string SecondName,
        string ThirdName,
        string Gender,
        string Group,
        decimal GPA); 
}
