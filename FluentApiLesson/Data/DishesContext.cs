using FluentApiLesson.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLesson.Data
{
    public class DishesContext : DbContext
    {
        public DishesContext()
        {
            Database.Migrate();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishesProducts> DishesProducts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ASTCMT002/MSSQL; Database = FluentAPILesson; Trusted_Connection = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().ToTable("Dishes").Property(dish => dish.Id).HasColumnName("ID");
            modelBuilder.Entity<Dish>().HasKey(dish => dish.Id).Property(dish => dish.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Product>().ToTable("Products").Property(product => product.Id).HasColumnName("ID");
            modelBuilder.Entity<Product>().HasKey(product => product.Id).Property(product => product.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            modelBuilder.Entity<DishesProducts>().ToTable("DishesProducts").Property(dp => dp.Id).HasColumnName("ID");
            modelBuilder.Entity<DishesProducts>().HasKey(DishesProducts => DishesProducts.Id);
            modelBuilder.Entity<DishesProducts>().HasOne(DishesProducts => DishesProducts.Dish).WithMany(dish => dish.DishesProducts);
            modelBuilder.Entity<DishesProducts>().HasOne(DishesProducts => DishesProducts.Product).WithMany(product => product.DishesProducts);

            base.OnModelCreating(modelBuilder);
        }
    }
}
