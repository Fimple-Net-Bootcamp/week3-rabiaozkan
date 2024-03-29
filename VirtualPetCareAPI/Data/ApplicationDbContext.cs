﻿using Microsoft.EntityFrameworkCore;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}
