using MediatR;
using SoftServeTestTask.BLL.Dto.Students;

namespace SoftServeTestTask.BLL.MediatR.Students.Commands
{
    public record UpdateStudentCommand(StudentWithIdDto Student) : IRequest<bool>; 
}
