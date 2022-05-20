﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Teknosol.Service.Order.Domain.OrderAggregate;

namespace Teknosol.Services.Order.Infrastructure
{
    public class OrderDbContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "ordering";

        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
        {
            
        }

        public DbSet<Service.Order.Domain.OrderAggregate.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service.Order.Domain.OrderAggregate.Order>().ToTable("Orders", DEFAULT_SCHEMA);
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems", DEFAULT_SCHEMA);
            modelBuilder.Entity<OrderItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Service.Order.Domain.OrderAggregate.Order>().OwnsOne(o => o.Address).WithOwner();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}