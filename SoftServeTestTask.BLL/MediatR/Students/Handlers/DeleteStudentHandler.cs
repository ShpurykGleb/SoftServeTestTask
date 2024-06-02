using MediatR;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public DeleteStudentHandler(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new ArgumentNullException(nameof(request), "Id can not be null.");
            }
            else if (request.Id < 1)
            {
                throw new ArgumentException("Id can not ne less than 1.");
            }

            if(await _studentRepository.DeleteAsync(request.Id))
            {
                return await _studentRepository.SaveAsync();
            }

            return false;
        }
    }
}
