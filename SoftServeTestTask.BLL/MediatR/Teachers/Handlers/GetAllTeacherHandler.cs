using AutoMapper;
using MediatR;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.BLL.MediatR.Teachers.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Handlers
{
    public class GetAllTeacherHandler : IRequestHandler<GetAllTeacherQuery, IEnumerable<TeacherQueryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public GetAllTeacherHandler(IMapper mapper, IGenericRepository<Teacher> teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<TeacherQueryDto>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            var existingTeachers = await _teacherRepository.GetAllAsync(t => t.Courses);

            return _mapper.Map<IEnumerable<TeacherQueryDto>>(existingTeachers);
        }
    }
}
