using Microsoft.EntityFrameworkCore;

public class Tarea_2Context(DbContextOptions<Tarea_2Context> options) : DbContext(options)
{
    public DbSet<Tarea_2.Dominio.Persona> Persona { get; set; } = default!;
}
