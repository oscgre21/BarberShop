using System;
namespace BarberShop.Domain.Entities.Model
{
    public class DTFilterQueryModel
    {
        public int limit { get; set; }
        public int page { get; set; }
        public string query { get; set; }
        public bool valid { get; set; }
    }
}
