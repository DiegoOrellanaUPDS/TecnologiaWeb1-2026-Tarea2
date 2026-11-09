using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosMihaelCalvettyController : ControllerBase
    {
        private readonly Tarea_2Context _context;

        public ProductosMihaelCalvettyController(Tarea_2Context context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductoMihaelCalvetty>>> GetProductos()
        {
            try
            {
                return await _context.ProductoMihaelCalvetty.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los productos: {ex.Message}");
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoMihaelCalvetty>> GetProducto(int id)
        {
            try
            {
                ProductoMihaelCalvetty? producto = await _context.ProductoMihaelCalvetty.FirstOrDefaultAsync(i => i.Id == id);

                if (producto == null)
                {
                    return NotFound();
                }

                return producto;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el producto: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductoMihaelCalvetty>> PostProducto(ProductoMihaelCalvetty producto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(producto.Nombre)) return BadRequest("El nombre del producto no puede estar vacío.");
                if (producto.Precio < 0) return BadRequest("El precio del producto debe ser un valor positivo.");
                if (producto.Stock < 0) return BadRequest("El stock del producto no puede ser un valor negativo.");

                _context.ProductoMihaelCalvetty.Add(producto);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el producto: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id, ProductoMihaelCalvetty producto)
        {
            try
            {
                if (id != producto.Id)
                {
                    return BadRequest();
                }

                if (string.IsNullOrWhiteSpace(producto.Nombre)) return BadRequest("El nombre del producto no puede estar vacío.");
                if (producto.Precio < 0) return BadRequest("El precio del producto debe ser un valor positivo.");
                if (producto.Stock < 0) return BadRequest("El stock del producto no puede ser un valor negativo.");

                ProductoMihaelCalvetty? productoExistente = await _context.ProductoMihaelCalvetty.FirstOrDefaultAsync(i => i.Id == id);

                if (productoExistente == null) return NotFound();

                productoExistente.Nombre = producto.Nombre;
                productoExistente.Precio = producto.Precio;
                productoExistente.Stock = producto.Stock;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el producto: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            try
            {
                ProductoMihaelCalvetty? producto = await _context.ProductoMihaelCalvetty.FirstOrDefaultAsync(i => i.Id == id);

                if (producto == null) return NotFound();

                _context.ProductoMihaelCalvetty.Remove(producto);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el producto: {ex.Message}");
            }
        }
    }
}
