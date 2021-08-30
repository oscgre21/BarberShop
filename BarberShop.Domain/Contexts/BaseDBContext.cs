using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BarberShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Domain.Entities.Global; 

namespace BarberShop.Domain.Contexts
{
    public class BaseDBContext : BaseContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options)
            : base(options)
        {
        }

        public DbSet<Demo> Demo { get; set; }
     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*
            builder.Entity<Demo>()
                .HasIndex(x => x.Codigo)
                .IsUnique();*/
        }
    }
}
