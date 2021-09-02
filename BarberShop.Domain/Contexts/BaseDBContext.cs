using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BarberShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Domain.Entities.Global;
using BarberShop.Domain.Entities.DataPerson;
using BarberShop.Domain.Entities.Users;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using Microsoft.Extensions.Logging;
using MySqlConnector.Logging;
using BarberShop.Domain.Entities.Barber;
using BarberShop.Domain.Entities.Booking;
using BarberShop.Domain.Entities.Products;

namespace BarberShop.Domain.Contexts
{ 
    public class BaseDBContext : BaseContext
    {

        public DbSet<PersonData> PersonData { get; set; }
        public DbSet<UserIdentity> Indentity { get; set; }
        public DbSet<BarberSchedule> BarberSchedule { get; set; }
        public DbSet<Barbers> Barbers { get; set; }
        public DbSet<BookingByProducts> BookingByProducts { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Booking> Booking { get; set; } 



        public BaseDBContext(DbContextOptions<BaseDBContext> options)
            : base(options)
        {
            // new ConsoleLoggerProvider(MySqlConnectorLogLevel.Info,true);

            //this.Database.Log = sql => Debug.Write(sql);
        }



        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
                .EnableSensitiveDataLogging();
        }*/

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
