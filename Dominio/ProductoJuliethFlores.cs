using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea_2.Dominio;

public class ProductoJuliethFlores
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "999999999.99",
        ParseLimitsInInvariantCulture = true,
        ErrorMessage = "El precio debe ser mayor que cero.")]
    [Column(TypeName = "numeric(12,2)")]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue,
        ErrorMessage = "El stock no puede ser negativo.")]
    public int Stock { get; set; }
}