using FluentValidation;
using validation.Entities;

namespace validation.Validator
{
    public class UserValidators : AbstractValidator<User>
    {
        public UserValidators() 
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Error");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Error");
        }
    }
}
