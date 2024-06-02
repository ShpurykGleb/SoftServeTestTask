using MediatR;
using SoftServeTestTask.BLL.MediatR.Courses.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Courses.Handlers
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public DeleteCourseHandler(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new ArgumentNullException(nameof(request.Id), "Id can not be null.");
            }
            else if (request.Id < 1)
            {
                throw new ArgumentException("Id can not be less than 1.");
            }

            if (await _courseRepository.DeleteAsync(request.Id))
            {
                return await _courseRepository.SaveAsync();
            }

            return false;
        }
    }
}
