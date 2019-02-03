using FluentValidation;
using FluentValidationPropertyTest.Models;
using FluentValidationPropertyTest.Services;
using FluentValidationPropertyTest.Validators.CustomValidator;

namespace FluentValidationPropertyTest.Validators
{
    public class ObjectBValidator : AbstractValidator<ObjectB>
    {
        public ObjectBValidator(IFileValidate fileValidate)
        {
            RuleFor(file => file.FileToUpload).SetValidator(new CustomFileValidator(fileValidate));
        }
    }
}
