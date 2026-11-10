using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosJuniorCardozoController : ControllerBase
    {
        private readonly Tarea_2Context _context;

        public ProductosJuniorCardozoController(Tarea_2Context context)
        {
            _context = context;
        }

        // GET: api/ProductosJuniorCardozo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoJuniorCardozo>>> GetProductos()
        {
            return await _context.ProductosJuniorCardozo
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/ProductosJuniorCardozo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoJuniorCardozo>> GetProducto(int id)
        {
            if (id <= 0)
                return BadRequest("El identificador debe ser mayor a cero.");

            var producto = await _context.ProductosJuniorCardozo.FindAsync(id);

            if (producto == null)
                return NotFound("Producto no encontrado.");

            return Ok(producto);
        }

        // POST: api/ProductosJuniorCardozo
        [HttpPost]
        public async Task<ActionResult<ProductoJuniorCardozo>> PostProducto(
            ProductoJuniorCardozo producto)
        {
            producto.Id = 0;

            _context.ProductosJuniorCardozo.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProducto),
                new { id = producto.Id },
                producto
            );
        }

        // PUT: api/ProductosJuniorCardozo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(
            int id,
            ProductoJuniorCardozo producto)
        {
            if (id <= 0)
                return BadRequest("El identificador debe ser mayor a cero.");

            if (id != producto.Id)
                return BadRequest("El ID de la URL no coincide con el ID del producto.");

            var productoExistente = await _context.ProductosJuniorCardozo.FindAsync(id);

            if (productoExistente == null)
                return NotFound("Producto no encontrado.");

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ProductosJuniorCardozo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            if (id <= 0)
                return BadRequest("El identificador debe ser mayor a cero.");

            var producto = await _context.ProductosJuniorCardozo.FindAsync(id);

            if (producto == null)
                return NotFound("Producto no encontrado.");

            _context.ProductosJuniorCardozo.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
