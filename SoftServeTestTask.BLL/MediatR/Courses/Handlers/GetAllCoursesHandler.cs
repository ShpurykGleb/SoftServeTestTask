using AutoMapper;
using MediatR;
using SoftServeTestTask.BLL.Dto.Courses;
using SoftServeTestTask.BLL.MediatR.Courses.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Courses.Handlers
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseQueryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Course> _courseRepository;

        public GetAllCoursesHandler(IMapper mapper, IGenericRepository<Course> courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseQueryDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetAllAsync(c => c.Teachers, c => c.Students);

            return _mapper.Map<IEnumerable<CourseQueryDto>>(courses);
        }
    }
}
