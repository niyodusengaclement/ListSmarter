using FluentValidation;
using ListSmarter.DTO;

namespace ListSmarter.Validators
{
    public class TaskValidator : AbstractValidator<TaskDto>
    {

        public TaskValidator()
        {
            RuleFor(task => task.Description).NotEmpty();
            RuleFor(task => task.Title).NotEmpty();
            RuleFor(task => task.Status).IsInEnum();
        }

    }
}
