using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemoWithAnnotations.Models;

public partial class IndigoAirlinesContext : DbContext
{
    public IndigoAirlinesContext()
    {
    }

    public IndigoAirlinesContext(DbContextOptions<IndigoAirlinesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VwPassengerDatum> VwPassengerData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.\\sqlexpress;Database=IndigoAirlines;Integrated security=true;Trust server certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Custid).HasName("PK__Customer__049D3E81CC8ACDC1");

            entity.ToTable("Customer");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.SeatNo).HasName("PK__Passenge__3116FB41BFA6B271");

            entity.ToTable("Passenger");

            entity.Property(e => e.SeatNo).ValueGeneratedNever();
            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeatType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StartingPoint)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__Users__CBA1B25785B1F910");

            entity.Property(e => e.Userid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userid");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<VwPassengerDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vw_PassengerData");

            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeatType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SourcePoint)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
