using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

public class Tarea_2Context(DbContextOptions<Tarea_2Context> options) : DbContext(options)
{
    public DbSet<Tarea_2.Dominio.Persona> Persona { get; set; } = default!;
        public DbSet<Tarea_2.Dominio.ProductoYasmin> ProductoYasmin
        { get; set; } = default!;
        public DbSet<YeymiRivera> ProductoYeymi {get;set;}=default!;
}
