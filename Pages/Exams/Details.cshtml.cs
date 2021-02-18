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
    //Returns the exam details.
    public class DetailsModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public DetailsModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Exam details model
        public Exam Exam { get; set; }

        //Gets exam details using a lamda
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
    }
}
