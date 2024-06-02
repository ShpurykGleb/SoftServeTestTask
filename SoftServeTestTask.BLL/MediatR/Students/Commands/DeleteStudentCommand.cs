using MediatR;

namespace SoftServeTestTask.BLL.MediatR.Students.Commands
{
    public record DeleteStudentCommand(int? Id) : IRequest<bool>;
}
