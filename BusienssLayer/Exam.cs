using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Certification_Core_Web_App.BusienssLayer
{
    //The exam
    public class Exam
    {
        //Exam id
        public int Id { get; set; }

        //Certification id foriegn key
        public int CertificationId { get; set; }

        //Student id foriegn key
        public int StudentId { get; set; }

        //Reference to the certification.
        public Certification Certification { get; set; }

        //Referenece to the student.
        public Student Student  { get; set; }

        //Cetification marks.
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Marks { get; set; }




    }
}
