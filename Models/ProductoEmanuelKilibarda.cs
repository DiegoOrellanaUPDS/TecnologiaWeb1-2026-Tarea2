using System.ComponentModel.DataAnnotations;

namespace Tarea_2.Models
{
    public class ProductoEmanuelKilibarda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
}
