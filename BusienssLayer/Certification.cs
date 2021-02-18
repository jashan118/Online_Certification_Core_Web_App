using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Certification_Core_Web_App.BusienssLayer
{
    //The certificatin information.
    public class Certification
    {
         //certification id 
        public int Id { get; set; }

        //Certification name.
        public string Name { get; set; }

        //Awarding organisation.
        public string Organisation { get; set; }

        //Teh price of the certification.
        public decimal Price { get; set; }

    }
}
