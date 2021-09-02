using BarberShop.Core.Basemodel.BaseEntity;
using BarberShop.Domain.Entities.DataPerson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Entities.Users
{
    public class UserIdentity : BaseEntity
    {
        public PersonData persona { get; set; }
        [MaxLength(60)]
        public string username { get; set; }
        [MaxLength(60)]
        public string Password { get; set; }

        [MaxLength(10)]
        public int IsActive { get; set; }

        public string authkey { get; set; }

        [MaxLength(15)]
        public string RoleType { get; set; } = "USER";
    }
}
