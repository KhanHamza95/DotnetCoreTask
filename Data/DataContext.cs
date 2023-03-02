using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dependency_injection_sample.Models;
namespace Dependency_injection_sample.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.id).UseIdentityColumn();
            modelBuilder.Entity<Role>().Property(r => r.roleId).UseIdentityColumn();
            modelBuilder.Entity<Role>()
            .HasMany(r => r.users)
            .WithOne();
        }
    }
}