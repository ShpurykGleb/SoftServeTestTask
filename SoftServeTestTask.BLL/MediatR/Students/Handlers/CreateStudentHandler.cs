using AutoMapper;
using MediatR;
using SoftServeTestTask.BLL.MediatR.Students.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Course> _courseRepository;

        public CreateStudentHandler(IMapper mapper, IGenericRepository<Student> studentRepository, IGenericRepository<Course> courseRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (request.Student == null)
            {
                throw new ArgumentNullException(nameof(request), "Student can not be null.");
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
