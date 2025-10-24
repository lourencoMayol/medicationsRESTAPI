using Application.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("Medications");
                entity.HasKey(m => m.MedId);

                entity.Property(m => m.MedId)
                      .ValueGeneratedOnAdd(); // auto increment Id

                entity.Property(m => m.Name)
                      .IsRequired();

                entity.Property(m => m.Quantity)
                      .IsRequired();

                entity.Property(m => m.CreationDate)
                      .IsRequired();
            });
        }
    }
}
