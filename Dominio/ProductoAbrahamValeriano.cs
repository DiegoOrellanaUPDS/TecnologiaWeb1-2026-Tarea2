using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Tarea_2.Dominio;

public class ProductoAbrahamValeriano
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Precision(12, 2)]
    [Range(typeof(decimal), "0.01", "9999999999")]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}
