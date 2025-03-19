using CarritoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarritoApi.Persistence.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<CarritoProducto> CarritoProducto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarritoProducto>()
                .HasKey(cp => new { cp.CarritoId, cp.ProductoId }); 

            modelBuilder.Entity<CarritoProducto>()
                .HasOne(cp => cp.Carrito)
                .WithMany(c => c.CarritoProductos)
                .HasForeignKey(cp => cp.CarritoId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<CarritoProducto>()
                .HasOne(cp => cp.Producto)
                .WithMany(p => p.CarritoProductos)
                .HasForeignKey(cp => cp.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
