using MediatR;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Handlers
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, bool>
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Course> _courseRepository;

        public UpdateTeacherHandler(IGenericRepository<Teacher> teacherRepository, IGenericRepository<Course> courseRepository)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            if (request.Teacher == null)
            {
                throw new ArgumentNullException(nameof(request), "Teacher can not be null.");
            }

            var existingTeacher = await _teacherRepository.GetByIdAsync(request.Teacher.Id);

            if (existingTeacher == null)
            {
                throw new KeyNotFoundException($"Teacher with given id - {request.Teacher.Id}, was not found.");
            }

            await UpdateTeacherAsync(existingTeacher, request.Teacher);

            if (await _teacherRepository.UpdateAsync(existingTeacher))
            {
                return await _teacherRepository.SaveAsync();
            }

            return false;
        }

        private async Task UpdateTeacherAsync(Teacher oldTeacher, TeacherWithIdDto updatedTeacher)
        {
            oldTeacher.Age = updatedTeacher.Age;
            oldTeacher.ExperienceYears = updatedTeacher.ExperienceYears;
            oldTeacher.FirstName = updatedTeacher.FirstName;
            oldTeacher.SecondName = updatedTeacher.SecondName;
            oldTeacher.ThirdName = updatedTeacher.ThirdName;
            oldTeacher.Gender = updatedTeacher.Gender;
            oldTeacher.AcademicDegree = updatedTeacher.AcademicDegree;

            var courses = new List<Course>();

            foreach (var course in updatedTeacher.Courses)
            {
                courses.Add(await _courseRepository.GetByIdAsync(course.Id));
            }

            oldTeacher.Courses = courses;
        }
    }
}
