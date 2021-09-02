using BarberShop.BL.DTOs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BL.DTOs.Global
{
    public class PersonDTO : BaseViewModel
    {
       
        public string NameComplete { get; set; }
    
        public string Phone { get; set; }

 
        public string Email { get; set; }
    }
}
