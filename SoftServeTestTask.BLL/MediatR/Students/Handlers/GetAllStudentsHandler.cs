using AutoMapper;
using MediatR;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.MediatR.Students.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentShortDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Student> _studentRepository;

        public GetAllStudentsHandler(IMapper mapper, IGenericRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentShortDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetAllAsync(c => c.Courses);

            return _mapper.Map<IEnumerable<StudentShortDto>>(students);
        }
    }
}
