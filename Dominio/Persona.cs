using System.ComponentModel.DataAnnotations;

namespace Tarea_2.Dominio;

public class Persona
{
    [Key]
    public int Id { get; set; }
    public required string Nombre { get; set; }
}