using AutoMapper;
using MediatR;
using SoftServeTestTask.BLL.Dto.Teachers;
using SoftServeTestTask.BLL.MediatR.Teachers.Queries;
using SoftServeTestTask.DAL.Entities;
using SoftServeTestTask.DAL.Repositories;

namespace SoftServeTestTask.BLL.MediatR.Teachers.Handlers
{
    public class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQuery, TeacherShortDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public GetTeacherByIdHandler(IMapper mapper, IGenericRepository<Teacher> teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherShortDto> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new ArgumentNullException(nameof(request.Id), "Id can not be null.");
            }
            else if (request.Id < 1)
            {
                throw new ArgumentException(nameof(request.Id), "Id can not be less than 1.");
            }

            var findedTeacher = await _teacherRepository.GetByIdAsync(request.Id, t => t.Courses);

            if (findedTeacher == null)
            {
                throw new KeyNotFoundException($"Teacher with given id - {request.Id}, was not found.");
            }

            return _mapper.Map<TeacherShortDto>(findedTeacher);
        }
    }
}
