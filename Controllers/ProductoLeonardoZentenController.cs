using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers
{
    // Implementar el CRUD completo para Producto - Creado por LeonardoZenteno
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaLeonardoZentenController :  ControllerBase
    {
        private readonly Tarea_2Context _context;
        public PersonaLeonardoZentenController(Tarea_2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoLeonardoZenteno>>> Listar()
        {
            return await _context.ProductoLeonardoZentenos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoLeonardoZenteno>> Obtener(int id)
        {
            var producto = await _context.ProductoLeonardoZentenos.FindAsync(id);
            if (producto is null)
                return NotFound(new { mensaje = $"No existe el producto {id}" });
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoLeonardoZenteno>> Crear(ProductoLeonardoZenteno newProducto)
        {
            newProducto.Id = 0;
            _context.ProductoLeonardoZentenos.Add(newProducto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Obtener), new { id = newProducto.Id }, newProducto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, ProductoLeonardoZenteno producto)
        {
            if (id != producto.Id)
                return BadRequest(new { mensaje = "El id de la ruta no coincide con el del cuerpo" });

            var existente = await _context.ProductoLeonardoZentenos.FindAsync(id);
            if (existente is null)
                return NotFound(new { mensaje = $"No existe el producto {id}" });

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var p = await _context.ProductoLeonardoZentenos.FindAsync(id);
            if (p is null)
                return NotFound(new { mensaje = $"No existe el producto {id}" });

            _context.ProductoLeonardoZentenos.Remove(p);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
