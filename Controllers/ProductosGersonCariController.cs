using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers;
//nskjdnfjksndfn
[ApiController]
[Route("api/[controller]")]
public class ProductosGersonCariController : ControllerBase
{
    private readonly Tarea_2Context _context;

    public ProductosGersonCariController(Tarea_2Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoGersonCari>>> GetProductos()
    {
        return await _context.ProductosGersonCari.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoGersonCari>> GetProducto(int id)
    {
        var producto = await _context.ProductosGersonCari.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return producto;
    }

    [HttpPost]
    public async Task<ActionResult<ProductoGersonCari>> PostProducto(ProductoGersonCari producto)
    {
        _context.ProductosGersonCari.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, ProductoGersonCari producto)
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
            if (!_context.ProductosGersonCari.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var producto = await _context.ProductosGersonCari.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }

        _context.ProductosGersonCari.Remove(producto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}