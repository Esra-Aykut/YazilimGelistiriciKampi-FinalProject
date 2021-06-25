using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
      public class NorthwindContext : DbContext
    {
        // 1) Hangi veritabanıyla çalışacağım? => override on.. yaz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB ; Database=Northwind ; Trusted_Connection=true");
            // @ kullanımı: "\" algılansın diye.
            // @ aksi durumda: şöyle kullanmalı"..\\.."
        }

        // 2)  <class> - tablo eşleştirmesi
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //public DbSet<Personel> Employess { get; set; } -> buna benzer isimlendirmelerde ModelBuilder kullan
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().ToTable("Employees");
            modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID");
            modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");
            modelBuilder.Entity<Personel>().Property(p => p.SurName).HasColumnName("LastName");
        }


    }
}
