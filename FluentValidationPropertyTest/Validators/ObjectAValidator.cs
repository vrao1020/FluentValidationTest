using FluentValidation;
using FluentValidationPropertyTest.Models;

namespace FluentValidationPropertyTest.Validators
{
    public class ObjectAValidator : AbstractValidator<ObjectA>
    {
        public ObjectAValidator()
        {
            RuleFor(obja => obja.Title).NotNull().WithMessage("Title cannot be null")
              .Length(1, 50);

            RuleFor(obja => obja.Message).NotNull().WithMessage("Message cannot be null")
                  .Length(1, 1000);
        }
    }
}
