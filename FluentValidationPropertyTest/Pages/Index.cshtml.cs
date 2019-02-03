using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidationPropertyTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FluentValidationPropertyTest.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ObjectA ObjA { get; set; }

        [BindProperty]
        public ObjectB ObjB { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {          
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }
    }
}
