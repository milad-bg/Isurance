using Domain.Domain.Entities;
using Domain.Domain.Entities.File;
using Domain.Domain.Entities.Information;
using Domain.Domain.Entities.News;
using Domain.Domain.Entities.Projects;
using Domain.Domain.Entities.Tendor;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DataBaseDbcontext : IdentityDbContext<User>
    {
        public DataBaseDbcontext(DbContextOptions<DataBaseDbcontext> options) : base(options)
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<MediaEntity> MediaEntities { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<NewsCast> NewsCasts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tender> Tenders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NewsCast>()
                .Property(p => p.CreationDate)
                .IsRequired();
        }

    }
}
