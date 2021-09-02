using BarberShop.Core.Basemodel.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Entities.DataPerson
{
    public class PersonData : BaseEntity
    {
        [MaxLength(120)]
        public string NameComplete { get; set; }
        [MaxLength(60)]
        public string Phone { get; set; }

        [MaxLength(60)]
        public string Email { get; set; }
    }
}
