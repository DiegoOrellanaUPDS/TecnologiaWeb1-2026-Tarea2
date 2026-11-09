using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers;

[ApiController]
[Route("api/productos-abraham-valeriano")]
public class ProductoAbrahamValerianoController : ControllerBase
{
    private readonly Tarea_2Context _context;

    public ProductoAbrahamValerianoController(Tarea_2Context context)
    {
        _context = context;
    }

    // GET: Listar todos los productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoAbrahamValeriano>>> GetProductos()
    {
        return await _context.ProductoAbrahamValeriano
            .AsNoTracking()
            .ToListAsync();
    }

    // GET: Buscar producto por Id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoAbrahamValeriano>> GetProducto(int id)
    {
        var producto = await _context.ProductoAbrahamValeriano.FindAsync(id);

        if (producto == null)
            return NotFound("Producto no encontrado");

        return Ok(producto);
    }

    // POST: Registrar producto
    [HttpPost]
    public async Task<ActionResult<ProductoAbrahamValeriano>> CrearProducto(
        ProductoAbrahamValeriano producto)
    {
        producto.Id = 0;

        _context.ProductoAbrahamValeriano.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetProducto),
            new { id = producto.Id },
            producto
        );
    }

    // PUT: Actualizar producto
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProducto(
        int id, ProductoAbrahamValeriano producto)
    {
        if (producto.Id != 0 && id != producto.Id)
            return BadRequest("Los identificadores no coinciden");

        var existente = await _context.ProductoAbrahamValeriano.FindAsync(id);

        if (existente == null)
            return NotFound("Producto no encontrado");

        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Stock = producto.Stock;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: Eliminar producto - segunda prueba de feature3
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        var producto = await _context.ProductoAbrahamValeriano.FindAsync(id);

        if (producto == null)
            return NotFound("Producto no encontrado");

        _context.ProductoAbrahamValeriano.Remove(producto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
