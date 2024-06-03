using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    public class RevokeHandler : IRequestHandler<RevokeCommand, ResponseDto>
    {
        private readonly ILogger<RevokeHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public RevokeHandler(ILogger<RevokeHandler> logger,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<ResponseDto> Handle(RevokeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                var message = "Invalid user name";
                _logger.LogError(message);
                return new ResponseDto(Status: "Error", Message: message);
            }

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return new ResponseDto(
                Status: "Success", 
                Message: "Revoked successfully"
                );
        }
    }
}
