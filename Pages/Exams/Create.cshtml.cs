using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Certification_Core_Web_App.BusienssLayer;
using Online_Certification_Core_Web_App.Models;

namespace Online_Certification_Core_Web_App.Pages.Exams
{
    //Creates an exam.
    public class CreateModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public CreateModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Returns the create exam form.
        public IActionResult OnGet()
        {
        ViewData["CertificationId"] = new SelectList(_context.Certification, "Id", "Name");
        ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name");
            return Page();
        }

        //Binds the exam model.
        [BindProperty]
        public Exam Exam { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds an exam.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exam.Add(Exam);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
