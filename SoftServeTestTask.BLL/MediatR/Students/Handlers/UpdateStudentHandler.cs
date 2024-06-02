using AutoMapper;
using MediatR;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Course> _courseRepository;

        public UpdateStudentHandler(IGenericRepository<Student> studentRepository, IGenericRepository<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            if (request.Student == null)
            {
                throw new ArgumentNullException(nameof(request), "Student can not be null.");
            }

            var existingStudent = await _studentRepository.GetByIdAsync(request.Student.Id);

            if (existingStudent == null)
            {
                throw new KeyNotFoundException($"Student with given id - {request.Student.Id}, was not found.");
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
