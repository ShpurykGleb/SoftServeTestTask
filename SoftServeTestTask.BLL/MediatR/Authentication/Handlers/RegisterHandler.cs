using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.DAL.Entities;

namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, ResponseDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var model = request.RegisterModel;

            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return new ResponseDto(
                    Status: "Error",
                    Message: "User already exists!");
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
                return new ResponseDto(Status: "Error", Message: "User creation failed! Please check user details and try again.");
            }

            return new ResponseDto(Status: "Success", Message: "User created successfully!");
        }
    }
}
