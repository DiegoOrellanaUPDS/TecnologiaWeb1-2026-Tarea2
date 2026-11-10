using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoMarcoAriasController : ControllerBase
    {
        private readonly Tarea_2Context _context;

    public ProductoMarcoAriasController(Tarea_2Context context)
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoMarcoArias>>> GetProductos()
    {
        return await _context.ProductoMarcoArias
            .AsNoTracking()
            .ToListAsync();
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoMarcoArias>> GetProducto(int id)
    {
        var producto = await _context.ProductoMarcoArias.FindAsync(id);

        if (producto == null)
            return NotFound("Producto no encontrado");

        return Ok(producto);
    }

   
    [HttpPost]
    public async Task<ActionResult<ProductoMarcoArias>> CrearProducto(
        ProductoMarcoArias producto)
    {
        producto.Id = 0;

        _context.ProductoMarcoArias.Add(producto);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetProducto),
            new { id = producto.Id },
            producto
        );
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProducto(
        int id,
        ProductoMarcoArias producto)
    {
        if (producto.Id != 0 && id != producto.Id)
            return BadRequest("Los identificadores no coinciden");

        var existente = await _context.ProductoMarcoArias.FindAsync(id);

        if (existente == null)
            return NotFound("Producto no encontrado");

        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Stock = producto.Stock;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        var producto = await _context.ProductoMarcoArias.FindAsync(id);

        if (producto == null)
            return NotFound("Producto no encontrado");

        _context.ProductoMarcoArias.Remove(producto);

        await _context.SaveChangesAsync();

        return NoContent();
    }
    }
    // Cambio de practica para demostrar revert en feature1.
 
}