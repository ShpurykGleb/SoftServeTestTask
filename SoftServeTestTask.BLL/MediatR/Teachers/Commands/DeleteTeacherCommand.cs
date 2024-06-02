using MediatR;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Commands
{
    public record DeleteTeacherCommand(int? Id) : IRequest<bool>;
}
