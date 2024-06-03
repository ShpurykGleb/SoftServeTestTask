using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

public class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ILogger<CreateTeacherHandler> _logger;
    private readonly IGenericRepository<Teacher> _teacherRepository;
    private readonly IGenericRepository<Course> _courseRepository;

    public CreateTeacherHandler(IMapper mapper, ILogger<CreateTeacherHandler> logger, IGenericRepository<Teacher> teacherRepository, IGenericRepository<Course> courseRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _teacherRepository = teacherRepository;
        _courseRepository = courseRepository;
    }

    public async Task<bool> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        if (request.Teacher == null)
        {
            var message = "Teacher cannot be null.";
            _logger.LogError(message);
            throw new ArgumentNullException(nameof(request), message);
        }

        var teacherDto = request.Teacher;
        var createdTeacher = _mapper.Map<Teacher>(teacherDto);

        var courses = new List<Course>();

        foreach (var course in teacherDto.Courses)
        {
            courses.Add(await _courseRepository.GetByIdAsync(course.Id));
        }

        createdTeacher.Courses = courses;

        if (await _teacherRepository.AddAsync(createdTeacher))
        {
            return await _teacherRepository.SaveAsync();
        }

        return false;
    }
}
