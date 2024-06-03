using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Courses;
using SoftServeTestTask.BLL.MediatR.Courses.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Courses.Handlers
{
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, CourseQueryDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetCourseByIdHandler> _logger;
        private readonly IGenericRepository<Course> _courseRepository;

        public GetCourseByIdHandler(IMapper mapper, ILogger<GetCourseByIdHandler> logger, IGenericRepository<Course> courseRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _courseRepository = courseRepository;
        }

        public async Task<CourseQueryDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                var message = "Id can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(request.Id), "Id can not be null.");
            }
            else if (request.Id < 1)
            {
                var message = "Id can not be less than 1.";
                _logger.LogError(message);
                throw new ArgumentException("Id can not be less than 1.");
            }

            var foundCourse = await _courseRepository.GetByIdAsync(request.Id, c => c.Teachers, c => c.Students);

            if (foundCourse == null)
            {
                var message = $"Course with given id - {request.Id}, was not found.";
                _logger.LogError(message);
                throw new KeyNotFoundException(message);
            }

            return _mapper.Map<CourseQueryDto>(foundCourse);
        }
    }
}
