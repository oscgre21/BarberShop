using BarberShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.Services.JWTFactory
{
    public interface IJwtFactory
    {
        string GenerateToken(AppUser user);
    }
}
