using MediatR;
using Microsoft.AspNetCore.Identity;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    internal class RevokeAllHandler : IRequestHandler<RevokeAllCommand, ResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RevokeAllHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto> Handle(RevokeAllCommand request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }

            return new ResponseDto(Status: "Success", Message: "All tokens revoked successfully.");
        }
    }
}
