using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea_2.Dominio
{
    public class ProductoMaxCaceres
    {
        [Key]
        public int Id { get; set; }

        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}