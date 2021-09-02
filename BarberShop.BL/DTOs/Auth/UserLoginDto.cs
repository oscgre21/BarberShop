using BarberShop.BL.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BL.DTOs.Auth
{
    
    public class UserLoginDto : BaseEntityDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
