using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Handlers
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly ILogger<DeleteTeacherHandler> _logger;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public DeleteTeacherHandler(ILogger<DeleteTeacherHandler> logger, IGenericRepository<Teacher> teacherRepository)
        {
            _logger = logger;
            _teacherRepository = teacherRepository;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                var message = "Id can not be null.";
                _logger.LogError(message);    
                throw new ArgumentNullException(nameof(request), message);
            }
            else if (request.Id < 1)
            {
                var message = "Id can not be null.";
                _logger.LogError(message);
                throw new ArgumentException(message);
            }

            if (await _teacherRepository.DeleteAsync(request.Id))
            {
                return await _teacherRepository.SaveAsync();
            }

            return false;
        }
    }
}
