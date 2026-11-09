using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    //Práctica feature2: modificación de Carlos Miranda
    public class ProductoCarlosMirandaController : ControllerBase
    {
        private readonly Tarea_2Context _context;

        public ProductoCarlosMirandaController(Tarea_2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoCarlosMiranda>>> GetProductos()
        {
            return await _context.ProductoCarlosMiranda
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoCarlosMiranda>> GetProducto(int id)
        {
            var producto = await _context.ProductoCarlosMiranda.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<ProductoCarlosMiranda>> PostProducto(ProductoCarlosMiranda producto)
        {
            producto.Id = 0;

            _context.ProductoCarlosMiranda.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProducto),
                new { id = producto.Id },
                producto
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductoCarlosMiranda producto)
        {
            if (id != producto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del producto.");
            }

            var productoExistente = await _context.ProductoCarlosMiranda.FindAsync(id);

            if (productoExistente == null)
            {
                return NotFound();
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.ProductoCarlosMiranda.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.ProductoCarlosMiranda.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}