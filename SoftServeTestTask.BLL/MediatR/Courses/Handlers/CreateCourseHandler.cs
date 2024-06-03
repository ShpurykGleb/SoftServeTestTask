using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.MediatR.Courses.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Courses.Handlers
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCourseHandler> _logger;
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Student> _studentRepository;

        public CreateCourseHandler(
            IMapper mapper,
            ILogger<CreateCourseHandler> logger,
            IGenericRepository<Course> courseRepository,
            IGenericRepository<Teacher> teacherRepository,
            IGenericRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            if (request.Course == null)
            {
                var message = "Course can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(request), message);
            }

            var courseDto = request.Course;

            var createdCourse = _mapper.Map<Course>(courseDto);

            var teachers = new List<Teacher>();

            foreach (var teacher in courseDto.Teachers)
            {
                teachers.Add(await _teacherRepository.GetByIdAsync(teacher.Id));
            }

            createdCourse.Teachers = teachers;

            var students = new List<Student>();

            foreach (var student in courseDto.Students)
            {
                students.Add(await _studentRepository.GetByIdAsync(student.Id));
            }

            createdCourse.Students = students;

            if (await _courseRepository.AddAsync(createdCourse))
            {
                return await _courseRepository.SaveAsync();
            }

            return false;
        }
    }
}
