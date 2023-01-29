using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StoriesManagement.Models;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticleBase> Articles { get; set; }


    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticleBase>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Icon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Favorite_ID");

            entity.ToTable("Favorite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
