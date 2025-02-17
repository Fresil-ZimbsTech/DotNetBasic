using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICRUD.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       if (!optionsBuilder.IsConfigured)
        {
            
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.ToTable("user_tbl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
