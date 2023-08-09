using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Restaurant_InventorySystem.Models;

namespace Restaurant_InventorySystem.Data;

public partial class InventorySystemContext : DbContext
{
    public InventorySystemContext()
    {
    }

    public InventorySystemContext(DbContextOptions<InventorySystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Etc> Etcs { get; set; }

    public virtual DbSet<Gf> Gfs { get; set; }

    public virtual DbSet<Jfc> Jfcs { get; set; }

    public virtual DbSet<Sysco> Syscos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=InventorySystem;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Etc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ETC__3214EC2708D5A5A1");

            entity.ToTable("ETC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.JfcId).HasColumnName("jfcID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Jfc).WithMany(p => p.Etcs)
                .HasForeignKey(d => d.JfcId)
                .HasConstraintName("FK__ETC__jfcID__35BCFE0A");
        });

        modelBuilder.Entity<Gf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GFS__3214EC275A25EAC5");

            entity.ToTable("GFS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jfc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JFC__3214EC279B598D77");

            entity.ToTable("JFC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SyscoId).HasColumnName("syscoID");

            entity.HasOne(d => d.Sysco).WithMany(p => p.Jfcs)
                .HasForeignKey(d => d.SyscoId)
                .HasConstraintName("FK__JFC__syscoID__32E0915F");
        });

        modelBuilder.Entity<Sysco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sysco__3214EC272C4BE923");

            entity.ToTable("Sysco");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GfsId).HasColumnName("gfsID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Gfs).WithMany(p => p.Syscos)
                .HasForeignKey(d => d.GfsId)
                .HasConstraintName("FK__Sysco__gfsID__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
