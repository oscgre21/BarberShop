using BarberShop.BL.DTOs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BL.DTOs.Global
{
    public class UserCredentialsDto : BaseViewModel
    {
        public PersonDTO persona { get; set; }
        
        public string username { get; set; }
   
        public string Password { get; set; }

    
        public int IsActive { get; set; }
    }
}
