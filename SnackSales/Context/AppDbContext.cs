﻿using Microsoft.EntityFrameworkCore;
using SnackSales.Models;

namespace SnackSales.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<OrderItem?> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

	}
}
