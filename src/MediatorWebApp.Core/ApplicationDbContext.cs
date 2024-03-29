﻿
using Microsoft.EntityFrameworkCore;
namespace MediatorWebApp.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}