using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion.Entidades;

namespace Aseguradora.Repositorios;
public class AseguradoraContext : DbContext
{
    #nullable disable
    public DbSet<Titular> Titulares { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Poliza> Polizas { get; set; }
    public DbSet<Siniestro> Siniestros { get; set; }
    public DbSet<Tercero> Terceros { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder
    optionsBuilder)
    {
        // Ruta personalizada donde deseas crear el archivo SQLite, x defecto se crea el archivo en el mismo lugar q ejecutas program.cs (Aseguradora.UI)
        string dbPath = @"..\Aseguradora.Repositorios\Aseguradora.sqlite"; 
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //la relacion de cada vehiculo con el titular la hace automaticamente (no se xq)
        // modelBuilder.Entity<Vehiculo>()
        //     .HasOne<Titular>()
        //     .WithMany()
        //     .HasForeignKey(v => v.TitularId);

        modelBuilder.Entity<Poliza>()
            .HasOne<Vehiculo>()
            .WithMany()
            .HasForeignKey(p => p.VehiculoId);

        modelBuilder.Entity<Siniestro>()
            .HasOne<Poliza>()
            .WithMany()
            .HasForeignKey(s => s.PolizaId);

        modelBuilder.Entity<Tercero>()
            .HasOne<Siniestro>()
            .WithMany()
            .HasForeignKey(t => t.SiniestroId);
    }
}