using EmployeeRegistrationApp.Enities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Country_Mst
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country_Mst");
                entity.HasKey(c => c.CountryId);
                entity.Property(c => c.CountryName)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            // State_Mst
            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State_Mst");
                entity.HasKey(s => s.StateId);
                entity.Property(s => s.StateName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasOne(s => s.Country)
                      .WithMany(c => c.States)
                      .HasForeignKey(s => s.CountryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Employee_Mst
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee_Mst");

                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeName)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(e => e.Age)
                      .IsRequired();

                entity.Property(e => e.MobileNum)
                      .IsRequired()
                      .HasMaxLength(10);

                entity.HasIndex(e => e.MobileNum)
                      .IsUnique();

                entity.Property(e => e.Pincode)
                      .IsRequired()
                      .HasMaxLength(6);

                entity.Property(e => e.DOB)
                      .HasColumnType("datetime");

                entity.Property(e => e.AddressLine1)
                      .IsRequired()
                      .HasMaxLength(250);

                entity.Property(e => e.AddressLine2)
                      .HasMaxLength(250);

                entity.HasOne(e => e.State)
                      .WithMany()
                      .HasForeignKey(e => e.StateId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Country)
                      .WithMany()
                      .HasForeignKey(e => e.CountryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
