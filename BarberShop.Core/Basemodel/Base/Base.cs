using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.Core.Basemodel.Base
{
    public class Base : IBase
    {
        public virtual Guid Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
