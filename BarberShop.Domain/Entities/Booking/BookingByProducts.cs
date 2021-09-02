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

namespace BarberShop.Domain.Entities.Booking
{
    public class BookingByProducts : BaseEntity
    {
        public Product Product { get; set; }
        public Booking Booking { get; set; }

        public string Status { get; set; } = "ADDED";
    }
}
