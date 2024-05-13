using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domains;

namespace Bl;

public partial class Portfolio1Context : IdentityDbContext<ApplicationUser>
{
    public Portfolio1Context()
    {
    }

    public Portfolio1Context(DbContextOptions<Portfolio1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAbout> TbAbouts { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbHome> TbHomes { get; set; }

    public virtual DbSet<TbMessage> TbMessages { get; set; }

    public virtual DbSet<TbProject> TbProjects { get; set; }

    public virtual DbSet<TbService> TbServices { get; set; }

    public virtual DbSet<TbSkill> TbSkills { get; set; }

    public virtual DbSet<TbInformation> TbInformations { get; set; }

    public virtual DbSet<VwProject> VwProjects { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<TbAbout>(entity =>
        {
            entity.ToTable("TbAbout");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("TbCategory");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TbHome>(entity =>
        {
            entity.ToTable("TbHome");

            entity.Property(e => e.Major).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TbMessage>(entity =>
        {
            entity.ToTable("TbMessage");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Subject).HasMaxLength(50);
        });

        modelBuilder.Entity<TbProject>(entity =>
        {
            entity.HasKey(e => e.ProjectId);

            entity.ToTable("TbProject");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.ProjectName).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.TbProjects)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbProject_TbCategory");
        });

        modelBuilder.Entity<TbService>(entity =>
        {
            entity.HasKey(e => e.ServiceId);

            entity.ToTable("TbService");

            entity.Property(e => e.ServiceName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbSkill>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ImageName).HasColumnType("nvarchar(MAX)");

        });

        modelBuilder.Entity<TbInformation>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.firstName).HasMaxLength(50);
            entity.Property(e => e.secondName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.Property(e => e.Linkedin).HasMaxLength(500);
            entity.Property(e => e.Github).HasMaxLength(500);
            entity.Property(e => e.Twitter).HasMaxLength(500);
        });


        modelBuilder.Entity<VwProject>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwProjects");
            
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.ProjectName).HasMaxLength(50);
            entity.Property(e => e.ImageName).HasMaxLength(200);
            entity.Property(e => e.Description).HasColumnType("nvarchar(MAX)");
            entity.Property(e => e.Link).HasColumnType("nvarchar(MAX)");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
