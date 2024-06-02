using MediatR;
using SoftServeTestTask.BLL.Dto.Courses;

namespace SoftServeTestTask.BLL.MediatR.Courses.Queries
{
    public record GetAllCoursesQuery() : IRequest<IEnumerable<CourseQueryDto>>;
}
