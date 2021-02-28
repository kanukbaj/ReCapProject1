﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class RentACarContext : DbContext
    {
        // Context sınıfı oluşturulup, projenin kullanacağı Db belirtildi.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(locldb)\mssqllocaldb;Database=RentACar;Trusted_Connection=true");
        }

        // Projedeki hangi class veri tabanındaki hangi tabloya bağlanacak onu belirliyoruz.
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
