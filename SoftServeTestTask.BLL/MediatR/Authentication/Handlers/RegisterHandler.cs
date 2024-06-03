using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, ResponseDto>
    {
        private readonly ILogger<RegisterHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterHandler(ILogger<RegisterHandler> logger,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<ResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var model = request.RegisterModel;

            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                var message = "User already exists!";
                _logger.LogError(message);
                return new ResponseDto(
                    Status: "Error",
                    Message: message);
            }

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var message = "User creation failed! Please check user details and try again.";
                _logger.LogError(message);
                return new ResponseDto(Status: "Error", Message: message);
            }

            return new ResponseDto(Status: "Success", Message: "User created successfully!");
        }
    }
}
