namespace SoftServeTestTask.BLL.Dto.Teachers
{
    public record TeacherWithoutCoursesDto(
        int Id,
        int Age,
        int ExperienceYears,
        string FirstName,
        string SecondName,
        string ThirdName,
        string AcademicDegree,
        string Gender);   
}
