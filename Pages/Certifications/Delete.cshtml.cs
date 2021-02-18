using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Certification_Core_Web_App.BusienssLayer;
using Online_Certification_Core_Web_App.Models;

namespace Online_Certification_Core_Web_App.Pages.Certifications
{
    //Removes the certification
    public class DeleteModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public DeleteModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the certification model.
        [BindProperty]
        public Certification Certification { get; set; }

        //Returns the certification for remove using a lamda
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Certification =_context.Certification.FirstOrDefault(m => m.Id == id);

            if (Certification == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the certification
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Certification = (from cert in _context.Certification
                             where cert.Id == id
                             select cert).FirstOrDefault();

            if (Certification != null)
            {
                _context.Certification.Remove(Certification);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
