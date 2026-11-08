using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Tarea_2.Dominio;

public class ProductoYasmin
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(120, MinimumLength = 2)]
    public string Nombre { get; set; } = string.Empty;

    [Precision(12, 2)]
    [Range(typeof(decimal), "0.01", "9999999999.99",
    ParseLimitsInInvariantCulture = true)]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue)]
    // feature3-Yasmin: segundo cambio independiente de practica.
    public int Stock { get; set; }}