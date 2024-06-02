using AutoMapper;
using MediatR;
using SoftServeTestTask.BLL.Dto.Courses;
using SoftServeTestTask.BLL.MediatR.Courses.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Courses.Handlers
{
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, CourseQueryDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Course> _courseRepository;

        public GetCourseByIdHandler(IMapper mapper, IGenericRepository<Course> courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<CourseQueryDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new ArgumentNullException(nameof(request.Id), "Id can not be null.");
            }
            else if (request.Id < 1)
            {
                throw new ArgumentException("Id can not be less than 1.");
            }

            var findedCourse = await _courseRepository.GetByIdAsync(request.Id, c => c.Teachers, c => c.Students);

            if (findedCourse == null)
            {
                throw new KeyNotFoundException($"Course with given id - {request.Id}, was not found.");
            }

            return _mapper.Map<CourseQueryDto>(findedCourse);
        }
    }
}
