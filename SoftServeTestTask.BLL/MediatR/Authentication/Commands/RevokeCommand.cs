using MediatR;
using SoftServeTestTask.BLL.Dto.Authentication;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Commands
{
    public record RevokeCommand(string Username) : IRequest<ResponseDto>;
}
