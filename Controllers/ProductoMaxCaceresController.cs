using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //linea independiente feature 3

   // linea identificable f2 
    public class ProductoMaxCaceresController : ControllerBase
    {
        private readonly Tarea_2Context _context;

        public ProductoMaxCaceresController(Tarea_2Context context)
        {
            _context = context;
        }

        //Obtiene la lista completa de productos registrados.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoMaxCaceres>>> GetProductos()
        {
            return await _context.ProductoMaxCaceres
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoMaxCaceres>> GetProducto(int id)
        {
            var producto = await _context.ProductoMaxCaceres.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<ProductoMaxCaceres>> PostProducto(ProductoMaxCaceres producto)
        {
            producto.Id = 0;

            _context.ProductoMaxCaceres.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProducto),
                new { id = producto.Id },
                producto
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, ProductoMaxCaceres producto)
        {
            if (id != producto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del producto.");
            }

            var productoExistente = await _context.ProductoMaxCaceres.FindAsync(id);

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
            var producto = await _context.ProductoMaxCaceres.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.ProductoMaxCaceres.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}