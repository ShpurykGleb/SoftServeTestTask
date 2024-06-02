using MediatR;
using SoftServeTestTask.BLL.Dto.Courses;

namespace SoftServeTestTask.BLL.MediatR.Courses.Commands
{
    public record UpdateCourseCommand(CourseUpdateDto Course) : IRequest<bool>;
}
