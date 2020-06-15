using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebDockerDemo.Model.Entities;

namespace WebDockerDemo.Dal
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 初始化数据
            modelBuilder.Entity<User>().HasData(new User
            {
                ID = Guid.NewGuid(),
                UserName = "Admin",
                Password = "Admin"
            });
        }
    }
}