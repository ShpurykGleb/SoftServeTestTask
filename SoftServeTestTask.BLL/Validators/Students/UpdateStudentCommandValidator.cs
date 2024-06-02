using FluentValidation;
using SoftServeTestTask.BLL.MediatR.Students.Commands;

namespace SoftServeTestTask.BLL.Validators.Students
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(command => command.Student.Age).NotEmpty().WithMessage("Age is required.");
            RuleFor(command => command.Student.FirstName).NotEmpty().WithMessage("First name is required.")
                                      .MaximumLength(32).WithMessage("First name must not exceed 32 characters.");
            RuleFor(command => command.Student.SecondName).NotEmpty().WithMessage("Second name is required.")
                                       .MaximumLength(32).WithMessage("Second name must not exceed 32 characters.");
            RuleFor(command => command.Student.ThirdName).NotEmpty().WithMessage("Third name is required.")
                                      .MaximumLength(32).WithMessage("Third name must not exceed 32 characters.");
            RuleFor(command => command.Student.Gender).NotEmpty().WithMessage("Gender is required.")
                                   .MaximumLength(32).WithMessage("Gender must not exceed 32 characters.");
            RuleFor(command => command.Student.GPA).NotEmpty().WithMessage("GPA is required.");
            RuleFor(command => command.Student.Group).NotEmpty().WithMessage("Group is required.")
                                  .MaximumLength(32).WithMessage("Group must not exceed 32 characters.");
        }
    }
}
