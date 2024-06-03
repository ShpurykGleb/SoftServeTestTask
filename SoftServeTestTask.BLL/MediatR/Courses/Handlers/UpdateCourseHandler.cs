using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Courses;
using SoftServeTestTask.BLL.MediatR.Courses.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Courses.Handlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ILogger<UpdateCourseHandler> _logger;
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Student> _studentRepository;

        public UpdateCourseHandler(
            ILogger<UpdateCourseHandler> logger, 
            IGenericRepository<Course> courseRepository, 
            IGenericRepository<Teacher> teacherRepository, 
            IGenericRepository<Student> studentRepository)
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var courseDto = request.Course;

            if (courseDto == null)
            {
                var message = "Course can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(request.Course), message);
            }
            else if (courseDto.Id < 1)
            {
                var message = "Id of course can not be less than 1.";
                _logger.LogError(message);
                throw new ArgumentException(message);
            }

            var existingCourse = await _courseRepository.GetByIdAsync(courseDto.Id);

            if (existingCourse == null)
            {
                var message = $"Course with given id - {courseDto.Id}, was not found.";
                _logger.LogError(message);
                throw new KeyNotFoundException(message);
            }

            await UpdateCourse(existingCourse, courseDto);

            if (await _courseRepository.UpdateAsync(existingCourse))
            {
                return await _courseRepository.SaveAsync();
            }

            return false;
        }


        private async Task UpdateCourse(Course oldCourse, CourseUpdateDto updatedCourse)
        {
            oldCourse.Name = updatedCourse.Name;
            oldCourse.Description = updatedCourse.Description;

            var teachers = new List<Teacher>();

            foreach (var teacher in updatedCourse.Teachers)
            {
                teachers.Add(await _teacherRepository.GetByIdAsync(teacher.Id));
            }

            oldCourse.Teachers = teachers;

            var students = new List<Student>();

            foreach (var student in updatedCourse.Students)
            {
                students.Add(await _studentRepository.GetByIdAsync(student.Id));
            }

            oldCourse.Students = students;
        }
    }
}
