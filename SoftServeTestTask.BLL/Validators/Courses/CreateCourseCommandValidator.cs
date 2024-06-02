using FluentValidation;
using SoftServeTestTask.BLL.MediatR.Courses.Commands;

namespace SoftServeTestTask.BLL.Validators.Courses
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(command => command.Course.Name)
               .NotEmpty().WithMessage("Course name can not be empty.")
               .MaximumLength(32).WithMessage("Course name must not exceed 32 characters.");

            RuleFor(command => command.Course.Description)
                .NotEmpty().WithMessage("Course description can not be empty.")
                .MaximumLength(256).WithMessage("Course description must not exceed 256 characters.");
        }
    }
}
