using BarberShop.Core.Basemodel.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberShop.Domain.Entities.Products;
using BarberShop.Domain.Entities.DataPerson;
using BarberShop.Domain.Entities.Users;
using BarberShop.Domain.Entities.Barber;

namespace BarberShop.Domain.Entities.Booking
{
    public class Booking : BaseEntity
    {
        PersonData Client { get; set; }

        Barbers BarberChosen { get; set; }  //Barber Chosen By user
        Barbers BarberDid { get; set; } //Barber how did the job
        public DateTimeOffset? DateDid { get; set; } //Date execute the actions

        BarberSchedule TimeSchedule { get; set; }
        public DateTimeOffset? BookingDate { get; set; }

        [MaxLength(60)]
        public string Codigo { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(120)]
        public string Description { get; set; }

        public string ProductType { get; set; } = "SERVICIO";
        public string Status { get; set; } = "RESERVED";
        
    }
}
