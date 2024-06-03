using MediatR;
using SoftServeTestTask.BLL.Dto.Teachers;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Queries
{
    public record GetTeacherByIdQuery(int? Id) : IRequest<TeacherShortDto>;
}
