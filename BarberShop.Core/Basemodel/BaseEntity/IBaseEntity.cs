using BarberShop.Core.Basemodel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.Core.Basemodel.BaseEntity
{
    public interface IBaseEntity : IBase
    {
        DateTimeOffset? CreatedAt { get; set; }
        DateTimeOffset? UpdatedAt{ get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
