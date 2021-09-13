using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BL.DTOs.Global
{
    public class ProductAndServicesDTO
    {
        public List<ProductsDTO> products { get; set; }
        public List<ProductsDTO> services { get; set; }
    }
}
