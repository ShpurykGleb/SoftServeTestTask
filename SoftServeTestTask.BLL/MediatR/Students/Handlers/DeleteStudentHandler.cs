using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly ILogger<DeleteStudentHandler> _logger;
        private readonly IGenericRepository<Student> _studentRepository;

        public DeleteStudentHandler(ILogger<DeleteStudentHandler> logger, IGenericRepository<Student> studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                var message = "Id can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(request), message);
            }
            else if (request.Id < 1)
            {
                var message = "Id can not ne less than 1.";
                _logger.LogError(message);
                throw new ArgumentException(message);
            }

            if (await _studentRepository.DeleteAsync(request.Id))
            {
                return await _studentRepository.SaveAsync();
            }

            return false;
        }
    }
}
