﻿using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<ProductTransaction> ProductTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //builder relationships 
            modelBuilder.Entity<ProductInventory>()
                .HasKey(pi => new { pi.ProductId, pi.InventoryId });

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Inventory)
                .WithMany(i => i.ProductInventories)
                .HasForeignKey(pi => pi.InventoryId);


            //seeding data
            modelBuilder.Entity<Inventory>().HasData(
               new Inventory { InventoryId= 1,InventoryName= "Motor de gasolina", Price=1000, Quantity=1},
               new Inventory { InventoryId=2, InventoryName= "Carcasa", Price=400, Quantity= 1},
               new Inventory { InventoryId= 3, InventoryName= "Llantas",Price=100, Quantity=1},
               new Inventory { InventoryId = 4, InventoryName = "Asientos", Price = 50, Quantity = 5 },
               new Inventory { InventoryId = 5, InventoryName = "Motor Eléctrico", Price = 800, Quantity = 2 },
               new Inventory { InventoryId = 6, InventoryName = "Bateria", Price = 400, Quantity = 5 }
               );

            modelBuilder.Entity<Product>().HasData(
               new Product { ProductId = 1, ProductName = "Coche de Gasolina", Price = 20000, Quantity = 1 },
               new Product { ProductId = 2, ProductName = "Coche Eléctrico", Price = 15000, Quantity = 1 }
             
               );

            modelBuilder.Entity<ProductInventory>().HasData(
               new ProductInventory { ProductId = 1, InventoryId = 1, InventoryQuantity = 1 }, //engine
               new ProductInventory { ProductId = 1, InventoryId = 2, InventoryQuantity = 1 }, //body
               new ProductInventory { ProductId = 1, InventoryId = 3, InventoryQuantity = 4 }, //4 wheels
               new ProductInventory { ProductId = 1, InventoryId = 4, InventoryQuantity = 5 }  //5 seats

               );

            modelBuilder.Entity<ProductInventory>().HasData(
               new ProductInventory { ProductId = 2, InventoryId = 5, InventoryQuantity = 1 }, //engine
               new ProductInventory { ProductId = 2, InventoryId = 2, InventoryQuantity = 1 }, //body
               new ProductInventory { ProductId = 2, InventoryId = 3, InventoryQuantity = 4 }, //4 wheels
               new ProductInventory { ProductId = 2, InventoryId = 4, InventoryQuantity = 5 },  //5 seats
               new ProductInventory { ProductId = 2, InventoryId = 6, InventoryQuantity = 1 }  //battery

               );
        }
    }
}
