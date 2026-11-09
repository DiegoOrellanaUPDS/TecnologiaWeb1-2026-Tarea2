
 // Controlador CRUD de ProductoAdalidCallizaya - Linea base
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoAdalidCallizayaController : ControllerBase
    {
        private readonly Tarea_2Context _context;

        public ProductoAdalidCallizayaController(Tarea_2Context context)
        {
            _context = context;
        }

        // GET: listar todos los productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoAdalidCallizaya>>> GetAll()
        {
            var productos = await _context.ProductosAdalidCallizaya.ToListAsync();
            return Ok(productos);
        }

        // GET: buscar producto por Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(new { mensaje = "El Id debe ser mayor a cero." });

            var producto = await _context.ProductosAdalidCallizaya.FindAsync(id);

            if (producto == null)
                return NotFound(new { mensaje = "Producto no encontrado." });

            return Ok(producto);
        }

        // POST: registrar un producto
        [HttpPost]
        public async Task<IActionResult> Create(ProductoAdalidCallizaya producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre) ||
                producto.Precio <= 0 || producto.Stock < 0)
            {
                return BadRequest(new { mensaje = "Los datos del producto no son validos." });
            }

            producto.Nombre = producto.Nombre.Trim();

            _context.ProductosAdalidCallizaya.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        // PUT: actualizar un producto
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProductoAdalidCallizaya producto)
        {
            if (id <= 0)
                return BadRequest(new { mensaje = "El Id no es valido." });

            if (producto.Id != 0 && producto.Id != id)
                return BadRequest(new { mensaje = "Los identificadores no coinciden." });

            if (string.IsNullOrWhiteSpace(producto.Nombre) ||
                producto.Precio <= 0 || producto.Stock < 0)
            {
                return BadRequest(new { mensaje = "Los datos del producto no son validos." });
            }

            var existente = await _context.ProductosAdalidCallizaya.FindAsync(id);

            if (existente == null)
                return NotFound(new { mensaje = "Producto no encontrado." });

            existente.Nombre = producto.Nombre.Trim();
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;

            await _context.SaveChangesAsync();

            return Ok(existente);
        }

        // DELETE: eliminar un producto
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(new { mensaje = "El Id no es valido." });

            var existente = await _context.ProductosAdalidCallizaya.FindAsync(id);

            if (existente == null)
                return NotFound(new { mensaje = "Producto no encontrado." });

            _context.ProductosAdalidCallizaya.Remove(existente);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Producto eliminado correctamente." });
        }
    }
}
