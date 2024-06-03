using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.MediatR.Courses.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Courses.Handlers
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ILogger<DeleteCourseHandler> _logger;
        private readonly IGenericRepository<Course> _courseRepository;

        public DeleteCourseHandler(ILogger<DeleteCourseHandler> logger, IGenericRepository<Course> courseRepository)
        {
            _logger = logger;
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                var message = "Id can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(request.Id), message);
            }
            else if (request.Id < 1)
            {
                var message = "Id can not be less than 1.";
                _logger.LogError(message);
                throw new ArgumentException(message);
            }

            if (await _courseRepository.DeleteAsync(request.Id))
            {
                return await _courseRepository.SaveAsync();
            }

            return false;
        }
    }
}
