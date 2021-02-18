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
    //Gets the details of the student.
    public class DetailsModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public DetailsModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Holds the student.
        public Student Student { get; set; }

        //Gets the details using a  lamda.
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
    }
}
