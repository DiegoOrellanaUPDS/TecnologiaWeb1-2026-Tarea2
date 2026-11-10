using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2;

public class Tarea_2Context : DbContext
{
    // Constructor del contexto
    public Tarea_2Context(DbContextOptions<Tarea_2Context> options)
        : base(options)
    {
    }

    // Modelos registrados en la base de datos
    public DbSet<Persona> Persona { get; set; } = default!;

    public DbSet<ProductoYasmin> ProductoYasmin { get; set; } = default!;

    public DbSet<ProductoGersonCari> ProductosGersonCari { get; set; } = default!;

    public DbSet<ProductoMihaelCalvetty> ProductoMihaelCalvetty { get; set; } = default!;

    public DbSet<ProductoCarlosMiranda> ProductoCarlosMiranda { get; set; } = default!;

    public DbSet<ProductoCarlosviza> ProductoCarlosviza { get; set; } = default!;

    public DbSet<YeymiRivera> ProductoYeymi { get; set; } = default!;

    public DbSet<ProductoJhefersonVelasco> ProductoJhefersonVelasco { get; set; } = default!;


    public DbSet<ProductoAdalidCallizaya> ProductosAdalidCallizaya { get; set; } = default!;

    public DbSet<ProductoJuliethFlores> ProductosJuliethFlores { get; set; } = default!;

    public DbSet<ProductoAbrahamValeriano> ProductoAbrahamValeriano { get; set; } = default!;
    public DbSet<ProductoMaxCaceres> ProductoMaxCaceres { get; set; } = default!;
    public DbSet<Tarea_2.Models.ProductoEmanuelKilibarda> ProductoEmanuelKilibarda { get; set; } = default!;

   // Cambio temporal feature3 para provocar conflicto
}
