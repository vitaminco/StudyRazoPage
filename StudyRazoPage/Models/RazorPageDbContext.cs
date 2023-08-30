﻿using Microsoft.EntityFrameworkCore;

namespace StudyRazoPage.Models
{
    public class RazorPageDbContext : DbContext
    {
        public DbSet<AppCategory> AppCategories { get; set; }
        public DbSet<AppOrder> AppOrders { get; set; }
        public DbSet<AppOrderDetal> AppOrderDetals { get; set; }
        public DbSet<AppProduct> AppProducts { get; set; }
        public DbSet<AppProductImage> AppProductImages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public RazorPageDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connection = "Server=DESKTOP-9SAS8HE\\VITAMINCO;Database=RazorPage;Trusted_Connection=True;Encrypt=False";
        //    optionsBuilder.UseSqlServer(connection);
        //}
    }
}
