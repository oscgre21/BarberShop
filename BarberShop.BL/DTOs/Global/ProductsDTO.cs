using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberShop.BL.DTOs.Base;

namespace BarberShop.BL.DTOs.Global
{
    public class ProductsDTO : BaseEntityDto
    {
       
        public string Codigo { get; set; }
       
        public string Name { get; set; }
   
        public string Description { get; set; }
   
        public string ProductType { get; set; } = "SERVICIO";
        public int Estatus { get; set; } = 1;
        public string Image { get; set; }
        public string Color { get; set; }
    }
}
