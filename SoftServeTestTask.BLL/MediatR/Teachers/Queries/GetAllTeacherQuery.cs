using MediatR;
using SoftServeTestTask.BLL.Dto.Teachers;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Queries
{
    public record GetAllTeacherQuery() : IRequest<IEnumerable<TeacherQueryDto>>;
}
