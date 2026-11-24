
using System;
using System.IO;
using Inventario.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Datos;

public class InventarioContext : DbContext
{
    public DbSet<Producto> Productos => Set<Producto>();

    public DbSet<Categoria> Categorias => Set<Categoria>();

    public static string RutaBaseDatos
    {
        get
        {
            string carpeta = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                ),
                "InventarioADSO"
            );

            Directory.CreateDirectory(carpeta);

            return Path.Combine(carpeta, "inventario.db");
        }
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={RutaBaseDatos}");
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>()
            .HasKey(p => p.Codigo);

        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId)
            .IsRequired(false);
    }
}
