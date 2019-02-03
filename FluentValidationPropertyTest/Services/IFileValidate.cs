using Microsoft.AspNetCore.Http;

namespace FluentValidationPropertyTest.Services
{
    public interface IFileValidate
    {
        (bool Valid, string ErrorMessage) ValidateFile(IFormFile fileToValidate);
    }
}
