using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Certification_Core_Web_App.BusienssLayer;
using Online_Certification_Core_Web_App.Models;

namespace Online_Certification_Core_Web_App.Pages.Exams
{
    //Deletes the exam
    public class DeleteModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public DeleteModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the exam 
        [BindProperty]
        public Exam Exam { get; set; }

        //Gets the exam for delete using lamda 
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exam = _context.Exam
                .Include(e => e.Certification)
                .Include(e => e.Student).FirstOrDefault(m => m.Id == id);

            if (Exam == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Remove the exam 
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exam = (from exam in _context.Exam
                    where exam.Id == id
                    select exam).FirstOrDefault();

            if (Exam != null)
            {
                _context.Exam.Remove(Exam);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
