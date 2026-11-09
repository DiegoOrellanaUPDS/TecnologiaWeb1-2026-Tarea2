using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers
{
    [ApiController]
    [Route("api/productoCarlosviza")]
    public class ProductoCarlosvizaController : ControllerBase
    {
        private readonly Tarea_2Context _db;

        public ProductoCarlosvizaController(Tarea_2Context db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoCarlosviza>>> Listar()
        {
            return await _db.ProductoCarlosviza.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoCarlosviza>> Obtener(int id)
        {
            var p = await _db.ProductoCarlosviza.FindAsync(id);
            if (p is null)
                return NotFound(new { mensaje = $"No existe el producto {id}" });
            return p;
        }

        [HttpPost]
        public async Task<ActionResult<ProductoCarlosviza>> Crear(ProductoCarlosviza producto)
        {
            producto.Id = 0;
            _db.ProductoCarlosviza.Add(producto);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Obtener), new { id = producto.Id }, producto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, ProductoCarlosviza producto)
        {
            if (id != producto.Id)
                return BadRequest(new { mensaje = "El id de la ruta no coincide con el del cuerpo" });

            var existente = await _db.ProductoCarlosviza.FindAsync(id);
            if (existente is null)
                return NotFound(new { mensaje = $"No existe el producto {id}" });

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;
            await _db.SaveChangesAsync();
            return NoContent();
        }
        //eliminar-feature3
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var p = await _db.ProductoCarlosviza.FindAsync(id);
            if (p is null)
                return NotFound(new { mensaje = $"No existe el producto {id}" });

            _db.ProductoCarlosviza.Remove(p);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}