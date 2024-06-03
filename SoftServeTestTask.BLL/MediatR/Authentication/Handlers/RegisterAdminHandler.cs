using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SoftServeTestTask.BLL.Dto.Authentication;
using SoftServeTestTask.BLL.MediatR.Authentication.Commands;
using SoftServeTestTask.DAL.Entities;


namespace SoftServeTestTask.BLL.MediatR.Authentication.Handlers
{
    public class RegisterAdminHandler : IRequestHandler<RegisterAdminCommand, ResponseDto>
    {
        private readonly ILogger<RegisterAdminHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterAdminHandler(ILogger<RegisterAdminHandler> logger,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ResponseDto> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var model = request.RegisterModel;

            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                var message = "User already exists!";
                _logger.LogError(message);
                return new ResponseDto(Status: "Error", Message: message);
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

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            return new ResponseDto(Status: "Success", Message: "User created successfully!");
        }
    }
}
