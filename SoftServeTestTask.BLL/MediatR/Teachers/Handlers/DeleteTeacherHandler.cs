using MediatR;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Handlers
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public DeleteTeacherHandler(IGenericRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new ArgumentNullException(nameof(request), "Id can not be null.");
            }
            else if (request.Id < 1)
            {
                throw new ArgumentException("Id can not be less than 1.");
            }

            if (await _teacherRepository.DeleteAsync(request.Id))
            {
                return await _teacherRepository.SaveAsync();
            }

            return false;
        }
    }
}
