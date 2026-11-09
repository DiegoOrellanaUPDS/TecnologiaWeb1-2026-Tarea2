using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2;

public class Tarea_2Context : DbContext
{
    public Tarea_2Context(DbContextOptions<Tarea_2Context> options)
        : base(options)
    {
    }

    public DbSet<ProductoJhefersonVelasco> ProductoJhefersonVelasco { get; set; } = default!;
    public DbSet<ProductoCarlosviza> ProductoCarlosviza { get; set; } = default!;
    public DbSet<YeymiRivera> ProductoYeymi { get; set; } = default!;
    public DbSet<Persona> Persona { get; set; } = default!;
    public DbSet<ProductoYasmin> ProductoYasmin { get; set; } = default!;
}