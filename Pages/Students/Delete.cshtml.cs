using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Certification_Core_Web_App.BusienssLayer;
using Online_Certification_Core_Web_App.Models;

namespace Online_Certification_Core_Web_App.Pages.Students
{
    //Deletes the student.
    public class DeleteModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public DeleteModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the student.
        [BindProperty]
        public Student Student { get; set; }

        //Returns  the student using a lamda
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = _context.Student.FirstOrDefault(m => m.Id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the student uses a linq query to select the student.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = (from student in _context.Student
                       where student.Id == id
                       select student).FirstOrDefault();


            if (Student != null)
            {
                _context.Student.Remove(Student);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
