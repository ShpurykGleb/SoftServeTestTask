using MediatR;
using SoftServeTestTask.BLL.Dto.Courses;

namespace SoftServeTestTask.BLL.MediatR.Courses.Queries
{
    public record GetCourseByIdQuery(int? Id) : IRequest<CourseQueryDto>;
}
