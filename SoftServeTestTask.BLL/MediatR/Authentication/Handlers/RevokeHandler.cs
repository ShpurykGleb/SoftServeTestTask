using MediatR;
using Microsoft.AspNetCore.Identity;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    public class RevokeHandler : IRequestHandler<RevokeCommand, ResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RevokeHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto> Handle(RevokeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return new ResponseDto(Status: "Error", Message: "Invalid user name");
            }

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return new ResponseDto(
                Status: "Error", 
                Message: "Invalid user name"
                );
        }
    }
}
