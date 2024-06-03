using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.MediatR.Students.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentShortDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetStudentByIdHandler> _logger;
        private readonly IGenericRepository<Student> _studentRepository;

        public GetStudentByIdHandler(IMapper mapper, ILogger<GetStudentByIdHandler> logger, IGenericRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public async Task<StudentShortDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
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

            var foundStudent = await _studentRepository.GetByIdAsync(request.Id, c => c.Courses);

            if (foundStudent == null)
            {
                var message = $"Student with given id - {request.Id}, was not found.";
                _logger.LogError(message);
                throw new KeyNotFoundException(message);
            }

            return _mapper.Map<StudentShortDto>(foundStudent);
        }
    }
}
