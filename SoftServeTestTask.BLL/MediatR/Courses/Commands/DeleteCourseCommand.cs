using MediatR;

namespace SoftServeTestTask.BLL.MediatR.Courses.Commands
{
    public record DeleteCourseCommand(int? Id) : IRequest<bool>;
}
