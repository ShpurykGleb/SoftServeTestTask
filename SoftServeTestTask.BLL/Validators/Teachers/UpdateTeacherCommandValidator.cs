using FluentValidation;
using SoftServeTestTask.BLL.MediatR.Teachers.Commands;

namespace SoftServeTestTask.BLL.Validators.Teachers
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            RuleFor(command => command.Teacher.Age)
              .NotEmpty().WithMessage("Age is required.")
              .InclusiveBetween(18, 99).WithMessage("Age must be 18 or older.");

            RuleFor(command => command.Teacher.ExperienceYears)
                .NotEmpty().WithMessage("ExperienceYears is required.")
                .InclusiveBetween(0, 99).WithMessage("ExperienceYears must be 0 or greater.");

            RuleFor(command => command.Teacher.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(32).WithMessage("FirstName cannot exceed 32 characters.");

            RuleFor(command => command.Teacher.SecondName)
                .NotEmpty().WithMessage("SecondName is required.")
                .MaximumLength(32).WithMessage("SecondName cannot exceed 32 characters.");

            RuleFor(command => command.Teacher.ThirdName)
                .NotEmpty().WithMessage("ThirdName is required.")
                .MaximumLength(32).WithMessage("ThirdName cannot exceed 32 characters.");

            RuleFor(command => command.Teacher.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .MaximumLength(32).WithMessage("Gender cannot exceed 32 characters.");

            RuleFor(command => command.Teacher.AcademicDegree)
                .NotEmpty().WithMessage("AcademicDegree is required.")
                .MaximumLength(32).WithMessage("AcademicDegree cannot exceed 32 characters.");
        }
    }
}
