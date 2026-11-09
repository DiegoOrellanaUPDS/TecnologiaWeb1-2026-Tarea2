using System.ComponentModel.DataAnnotations;

namespace Tarea_2.Dominio;

public class YeymiRivera
{
    [Key]
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}