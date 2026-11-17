using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WPFApp.Models;

namespace WPFApp.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.211.55.2;Initial Catalog=DemoExam;Persist Security Info=True;User ID=sa;Password=ALEX1219!;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_100_CI_AI_KS_SC_UTF8");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.IdOrder).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Orders).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderProducts).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderProducts).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.OrderProducts).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Products).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdSubcategoryNavigation).WithMany(p => p.Products).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Stocks).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.Stocks).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
