using MediatR;
using SoftServeTestTask.BLL.Dto.Courses;

namespace SoftServeTestTask.BLL.MediatR.Courses.Commands
{
    public record CreateCourseCommand(CourseCreateDto Course) : IRequest<bool>;
}
