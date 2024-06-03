using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateStudentHandler> _logger;
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Course> _courseRepository;

        public CreateStudentHandler(IMapper mapper, ILogger<CreateStudentHandler> logger, IGenericRepository<Student> studentRepository, IGenericRepository<Course> courseRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (request.Student == null)
            {
                var message = "Student can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(request), message);
            }

            var studentDto = request.Student;
            var createdStudent = _mapper.Map<Student>(studentDto);

            var courses = new List<Course>();

            foreach (var course in studentDto.Courses)
            {
                courses.Add(await _courseRepository.GetByIdAsync(course.Id));
            }

            createdStudent.Courses = courses;

            if (await _studentRepository.AddAsync(createdStudent))
            {
                return await _studentRepository.SaveAsync();
            }

            return false;
        }
    }
}
