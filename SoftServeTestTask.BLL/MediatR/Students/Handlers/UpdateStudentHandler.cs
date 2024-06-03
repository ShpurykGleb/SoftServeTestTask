using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly ILogger<UpdateStudentHandler> _logger;
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Course> _courseRepository;

        public UpdateStudentHandler(ILogger<UpdateStudentHandler> logger, IGenericRepository<Student> studentRepository, IGenericRepository<Course> courseRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            if (request.Student == null)
            {
                var message = "Student can not be null.";
                _logger.LogError(message);
                throw new ArgumentNullException(nameof(request), message);
            }

            var existingStudent = await _studentRepository.GetByIdAsync(request.Student.Id);

            if (existingStudent == null)
            {
                var message = $"Student with given id - {request.Student.Id}, was not found.";
                _logger.LogError(message);
                throw new KeyNotFoundException(message);
            }

            await UpdateStudent(existingStudent, request.Student);

            if (await _studentRepository.UpdateAsync(existingStudent))
            {
                return await _studentRepository.SaveAsync();
            }

            return true;
        }

        private async Task UpdateStudent(Student oldStudent, StudentWithIdDto updatedStudent)
        {
            oldStudent.Age = updatedStudent.Age;
            oldStudent.FirstName = updatedStudent.FirstName;
            oldStudent.SecondName = updatedStudent.SecondName;
            oldStudent.ThirdName = updatedStudent.ThirdName;
            oldStudent.Group = updatedStudent.Group;
            oldStudent.Gender = updatedStudent.Gender;
            oldStudent.GPA = updatedStudent.GPA;

            var courses = new List<Course>();

            foreach (var course in updatedStudent.Courses)
            {
                courses.Add(await _courseRepository.GetByIdAsync(course.Id));
            }

            oldStudent.Courses = courses;
        }
    }
}
