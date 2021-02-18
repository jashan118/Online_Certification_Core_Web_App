using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Certification_Core_Web_App.BusienssLayer;
using Online_Certification_Core_Web_App.Models;

namespace Online_Certification_Core_Web_App.Pages.Exams
{
    //Updates the exam details 
    public class EditModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public EditModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the exam model.
        [BindProperty]
        public Exam Exam { get; set; }

        //Gets the exam details for edit using  lamda 
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exam =  _context.Exam
                .Include(e => e.Certification)
                .Include(e => e.Student).FirstOrDefault(m => m.Id == id);

            if (Exam == null)
            {
                return NotFound();
            }
           ViewData["CertificationId"] = new SelectList(_context.Certification, "Id", "Name");
           ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the exam.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Exam).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(Exam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks availability using lamda
        private bool ExamExists(int id)
        {
            return _context.Exam.Any(e => e.Id == id);
        }
    }
}
