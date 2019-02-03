using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FluentValidationPropertyTest.Models
{
    public class ObjectB
    {
        [Display(Name = "Image To Upload")]
        public IFormFile FileToUpload { get; set; }
    }
}
