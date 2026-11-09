using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Models;

namespace Tarea_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoEmanuelKilibardaController : ControllerBase
    {
        private readonly Tarea_2Context _context;

        public ProductoEmanuelKilibardaController(Tarea_2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoEmanuelKilibarda>>> GetProductos()
        {
            return await _context.ProductoEmanuelKilibarda.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoEmanuelKilibarda>> GetProducto(int id)
        {
            var producto = await _context.ProductoEmanuelKilibarda.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<ProductoEmanuelKilibarda>> PostProducto(ProductoEmanuelKilibarda producto)
        {
            producto.Id = 0;

            _context.ProductoEmanuelKilibarda.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductoEmanuelKilibarda producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.ProductoEmanuelKilibarda.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.ProductoEmanuelKilibarda.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return _context.ProductoEmanuelKilibarda.Any(e => e.Id == id);
        }
    }
}
