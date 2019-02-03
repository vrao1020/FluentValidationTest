using FluentValidation.Validators;
using FluentValidationPropertyTest.Services;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FluentValidationPropertyTest.Validators.CustomValidator
{
    public class CustomFileValidator: AsyncValidatorBase
    {
        private IFileValidate _fileValidate;

        public CustomFileValidator(IFileValidate fileValidate) : base("{ErrorMessage}")
        {
            _fileValidate = fileValidate;
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var fileToValidate = context.PropertyValue as IFormFile;

            var (Valid, ErrorMessage) = _fileValidate.ValidateFile(fileToValidate);

            if (!Valid)
            {
                context.MessageFormatter.AppendArgument("ErrorMessage", ErrorMessage);
                return false;
            }

            return true;
        }
    }
}
