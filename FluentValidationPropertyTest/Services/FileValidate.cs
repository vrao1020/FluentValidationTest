using Microsoft.AspNetCore.Http;

namespace FluentValidationPropertyTest.Services
{
    public class FileValidate : IFileValidate
    {

        public (bool Valid, string ErrorMessage) ValidateFile(IFormFile fileToValidate)
        {
            return (false, $"Sample error message");
        }
    }
}
