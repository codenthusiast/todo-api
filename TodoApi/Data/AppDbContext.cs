using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Entities;

namespace TodoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Tasks).WithOne(t => t.User).OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
