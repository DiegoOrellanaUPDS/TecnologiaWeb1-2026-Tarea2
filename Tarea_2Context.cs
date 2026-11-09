using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2;

public class Tarea_2Context : DbContext
{

    public DbSet<Tarea_2.Dominio.Persona> Persona { get; set; } = default!;
        public DbSet<Tarea_2.Dominio.ProductoYasmin> ProductoYasmin
        { get; set; } = default!;
    public DbSet<Tarea_2.Dominio.ProductoGersonCari> ProductosGersonCari{ get; set; } = default!;

    
    public DbSet<Tarea_2.Dominio.ProductoMihaelCalvetty> ProductoMihaelCalvetty { get; set; } = default!;
}

    public Tarea_2Context(DbContextOptions<Tarea_2Context> options)
        : base(options)
    {
    }

    public DbSet<Persona> Persona { get; set; } = default!;

    public DbSet<ProductoYasmin> ProductoYasmin { get; set; } = default!;

    public DbSet<ProductoCarlosMiranda> ProductoCarlosMiranda { get; set; } = default!;

    public DbSet<ProductoCarlosviza> ProductoCarlosviza { get; set; } = default!;

    public DbSet<YeymiRivera> ProductoYeymi { get; set; } = default!;

    public DbSet<ProductoJhefersonVelasco> ProductoJhefersonVelasco { get; set; } = default!;

    public DbSet<ProductoAdalidCallizaya> ProductosAdalidCallizaya { get; set; } = default!;
    public DbSet<ProductoJuliethFlores> ProductosJuliethFlores { get; set; } = default!;
}

