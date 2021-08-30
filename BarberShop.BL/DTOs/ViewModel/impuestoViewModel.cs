using System;
namespace BarberShop.BL.DTOs.ViewModel
{
    public class impuestoViewModel : BaseViewModel
    {
        public string impuestoid { get; set; }
        public string descripcion { get; set; }
        public double tasa { get; set; }
    }
}
