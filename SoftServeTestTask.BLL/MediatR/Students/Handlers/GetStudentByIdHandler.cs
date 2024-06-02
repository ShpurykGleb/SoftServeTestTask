using AutoMapper;
using MediatR;
using SoftServeTestTask.BLL.Dto.Students;
using SoftServeTestTask.BLL.MediatR.Students.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Students.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentShortDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Student> _studentRepository;

        public GetStudentByIdHandler(IMapper mapper, IGenericRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<StudentShortDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new ArgumentNullException(nameof(request), "Id can not be null.");
            }
            else if (request.Id < 1)
            {
                throw new ArgumentException("Id can not be less than 1.");
            }

            var findedStudent = await _studentRepository.GetByIdAsync(request.Id, c => c.Courses);

            if (findedStudent == null)
            {
                throw new KeyNotFoundException($"Student with given id - {request.Id}, was not found.");
            }

            return _mapper.Map<StudentShortDto>(findedStudent);
        }
    }
}
