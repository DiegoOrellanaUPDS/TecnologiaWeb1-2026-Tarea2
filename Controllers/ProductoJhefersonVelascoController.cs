using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoJhefersonVelascoController : ControllerBase
{
    private readonly Tarea_2Context _context;

    public ProductoJhefersonVelascoController(Tarea_2Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoJhefersonVelasco>>> GetProductos()
    {
        return await _context.ProductoJhefersonVelasco.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<ProductoJhefersonVelasco>> PostProducto(ProductoJhefersonVelasco producto)
    {
        _context.ProductoJhefersonVelasco.Add(producto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProductos), new { id = producto.Id }, producto);
    }
}

// Comentario resuelto entre feature2 y feature3 por Jheferson
