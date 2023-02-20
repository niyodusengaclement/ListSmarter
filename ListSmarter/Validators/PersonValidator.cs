using FluentValidation;
using ListSmarter.DTO;

namespace ListSmarter.Validators
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {

        public PersonValidator()
        {
            RuleFor(person => person.FirstName).NotEmpty();
            RuleFor(person => person.LastName).NotEmpty();
        }

    }
}
