using MediatR;
using SoftServeTestTask.BLL.Dto.Teachers;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Commands
{
    public record CreateTeacherCommand(TeacherCreateDto Teacher) : IRequest<bool>;
}
