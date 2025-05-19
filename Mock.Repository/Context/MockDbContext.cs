using Microsoft.EntityFrameworkCore;
using Mock.Domain.Entities;
using Mock.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Repository.Context
{
    public class MockDbContext : DbContext
    {
        public MockDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<VideoGame> VideoGame => Set<VideoGame>();
        public DbSet<Publisher> Publisher => Set<Publisher>();
        public DbSet<Genre> Genre => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            modelBuilder.ApplyConfiguration(new VideoGameConfigurations());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
        }

    }
}
