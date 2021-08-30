using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.BL.DTOs.Base
{
    public interface IBaseDto
    {
        Guid? Id { get; set; }
    }
}
