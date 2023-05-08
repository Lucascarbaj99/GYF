using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Market.Context;

public partial class MarketContext : DbContext
{
    public MarketContext()
    {
    }

    public MarketContext(DbContextOptions<MarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Market;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC27098CAFF3");

            entity.ToTable("Producto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
