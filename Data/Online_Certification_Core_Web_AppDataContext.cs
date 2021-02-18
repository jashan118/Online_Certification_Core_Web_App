using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Certification_Core_Web_App.BusienssLayer;

namespace Online_Certification_Core_Web_App.Models
{
    //Connects the business layer object the database using the entity framework.
    public class Online_Certification_Core_Web_AppDataContext : DbContext
    {
        public Online_Certification_Core_Web_AppDataContext (DbContextOptions<Online_Certification_Core_Web_AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Certification_Core_Web_App.BusienssLayer.Certification> Certification { get; set; }

        public DbSet<Online_Certification_Core_Web_App.BusienssLayer.Exam> Exam { get; set; }

        public DbSet<Online_Certification_Core_Web_App.BusienssLayer.Student> Student { get; set; }
    }
}
