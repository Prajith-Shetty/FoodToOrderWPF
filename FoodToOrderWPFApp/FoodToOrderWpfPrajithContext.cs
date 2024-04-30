using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderWPFApp;

public partial class FoodToOrderWpfPrajithContext : DbContext
{
    public FoodToOrderWpfPrajithContext()
    {
    }

    public FoodToOrderWpfPrajithContext(DbContextOptions<FoodToOrderWpfPrajithContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_WPF_Prajith;User=sa;Password=sa@1234;TrustServerCertificate = True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
