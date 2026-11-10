
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers;

[Route("api/[controller]")]
[ApiController]

// Controlador encargado de gestionar el CRUD de productos de DiegoHoyos.
public class ProductoDiegoHoyosController : ControllerBase
{
    private readonly Tarea_2Context _context;

    public ProductoDiegoHoyosController(Tarea_2Context context)
    {
        _context = context;
    }

    // GET: api/ProductoDiegoHoyos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDiegoHoyos>>> GetProductos()
    {
        var productos = await _context.ProductoDiegoHoyos.ToListAsync();

        return Ok(productos);
    }

    // GET: api/ProductoDiegoHoyos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDiegoHoyos>> GetProducto(int id)
    {
        var producto = await _context.ProductoDiegoHoyos.FindAsync(id);

        if (producto == null)
        {
            return NotFound("Producto no encontrado.");
        }

        return Ok(producto);
    }

    // POST: api/ProductoDiegoHoyos
    [HttpPost]
    public async Task<ActionResult<ProductoDiegoHoyos>> PostProducto(
        ProductoDiegoHoyos producto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        producto.Id = 0;

        _context.ProductoDiegoHoyos.Add(producto);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetProducto),
            new { id = producto.Id },
            producto
        );
    }

    // PUT: api/ProductoDiegoHoyos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(
        int id,
        ProductoDiegoHoyos producto)
    {
        if (id != producto.Id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del producto.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existe = await _context.ProductoDiegoHoyos
            .AnyAsync(p => p.Id == id);

        if (!existe)
        {
            return NotFound("Producto no encontrado.");
        }

        _context.Entry(producto).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/ProductoDiegoHoyos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var producto = await _context.ProductoDiegoHoyos.FindAsync(id);

        if (producto == null)
        {
            return NotFound("Producto no encontrado.");
        }

        _context.ProductoDiegoHoyos.Remove(producto);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
