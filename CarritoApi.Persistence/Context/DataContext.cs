using CarritoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarritoApi.Persistence.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Usuario - Carrito (Uno a Muchos)
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Usuario)
                .WithMany() // Un usuario puede tener muchos carritos
                .HasForeignKey(c => c.UsuarioId);

            // Relación Carrito - Producto (Uno a Muchos)
            modelBuilder.Entity<Producto>()
                .HasOne<Carrito>()
                .WithMany(c => c.Productos) // Un carrito puede tener muchos productos
                .HasForeignKey(p => p.CarritoId)
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina un carrito, se eliminan sus productos
        }
    }
}
