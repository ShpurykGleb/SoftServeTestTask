using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    internal class RevokeAllHandler : IRequestHandler<RevokeAllCommand, ResponseDto>
    {
        private readonly ILogger<RevokeAllHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public RevokeAllHandler(ILogger<RevokeAllHandler> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
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

            var message = "All tokens revoked successfully.";
            _logger.LogInformation(message);
            return new ResponseDto(Status: "Success", Message: message);
        }
    }
}
