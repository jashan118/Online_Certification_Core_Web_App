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
    //Returns all exam details.
    public class IndexModel : PageModel
    {
        private readonly Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext _context;

        public IndexModel(Online_Certification_Core_Web_App.Models.Online_Certification_Core_Web_AppDataContext context)
        {
            _context = context;
        }


        //Exam list.

        public IList<Exam> Exam { get;set; }

        //Get all exams using a lamda.
        public void  OnGet()
        {
            Exam =_context.Exam
                .Include(e => e.Certification)
                .Include(e => e.Student).ToList();
        }
    }
}
