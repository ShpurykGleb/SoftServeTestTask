using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.BLL.MediatR.Teachers.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Handlers
{
    public class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQuery, TeacherShortDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetTeacherByIdHandler> _logger;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public GetTeacherByIdHandler(IMapper mapper, ILogger<GetTeacherByIdHandler> logger, IGenericRepository<Teacher> teacherRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherShortDto> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
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
                throw new ArgumentException(nameof(request.Id), message);
            }

            var foundTeacher = await _teacherRepository.GetByIdAsync(request.Id, t => t.Courses);

            if (foundTeacher == null)
            {
                var message = $"Teacher with given id - {request.Id}, was not found.";
                _logger.LogError(message);
                throw new KeyNotFoundException(message);
            }

            return _mapper.Map<TeacherShortDto>(foundTeacher);
        }
    }
}
