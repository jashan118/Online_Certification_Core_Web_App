using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Certification_Core_Web_App.BusienssLayer;
using Online_Certification_Core_Web_App.Models;

namespace Online_Certification_Core_Web_App.Pages.Students
{
    //Create student.
    public class CreateModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public CreateModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Retuns a student form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds student model.
        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds a student.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
