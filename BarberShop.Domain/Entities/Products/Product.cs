using BarberShop.Core.Basemodel.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        [MaxLength(60)]
        public string Codigo { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(120)]
        public string Description { get; set; }
        [MaxLength(20)]
        public string ProductType { get; set; } = "SERVICIO";
        public int Estatus { get; set; } = 1;
    }
}
