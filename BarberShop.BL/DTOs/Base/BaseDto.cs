using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.BL.DTOs.Base
{
    public class BaseDto : IBaseDto
    {
        public virtual Guid? Id { get; set; }
    }
}
