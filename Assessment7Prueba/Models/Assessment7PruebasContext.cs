using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assessment7Prueba.Models;

public partial class Assessment7PruebasContext : DbContext
{
    public Assessment7PruebasContext()
    {
    }

    public Assessment7PruebasContext(DbContextOptions<Assessment7PruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }


        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("Server=DESKTOP-P804OHV;Database=Assessment7Pruebas;Trusted_Connection=True;Encrypt=False;");


    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.ToTable("Claim");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Claims)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Claim_Vehicle");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.Property(e => e.DriverLicense).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("Vehicle");

            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.OwnerId).HasColumnName("Owner_Id");
            entity.Property(e => e.Vin).HasMaxLength(50);
            entity.Property(e => e.Year).HasMaxLength(50);

            entity.HasOne(d => d.Owner).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_Owners");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
