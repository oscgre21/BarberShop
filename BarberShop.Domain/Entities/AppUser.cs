using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
