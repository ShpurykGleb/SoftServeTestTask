using MediatR;
using SoftServeTestTask.BLL.Dto.Students;

namespace SoftServeTestTask.BLL.MediatR.Students.Queries
{
    public record GetStudentByIdQuery(int? Id) : IRequest<StudentShortDto>;
}
