using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

public class Tarea_2Context(DbContextOptions<Tarea_2Context> options) : DbContext(options)
{
    public DbSet<Persona> Persona { get; set; } = default!;

    public DbSet<ProductoYasmin> ProductoYasmin { get; set; } = default!;

    public DbSet<ProductoCarlosviza> ProductoCarlosviza { get; set; } = default!;

    public DbSet<YeymiRivera> ProductoYeymi { get; set; } = default!;
    
    public DbSet<ProductoAdalidCallizaya> ProductosAdalidCallizaya { get; set; } = default!;
}