using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.Dto.Teachers;

namespace SoftServeTestTask.BLL.Dto.Courses
{
    public record CourseQueryDto(
        string Name,
        string Description,
        ICollection<TeacherWithoutCoursesDto> Teachers,
        ICollection<StudentWithoutCoursesDto> Students);
}
