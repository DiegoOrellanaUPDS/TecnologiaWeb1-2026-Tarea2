using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers;

[ApiController]
[Route("api/ProductoYasmin")]
public class ProductoYasminController : ControllerBase
{
    private readonly Tarea_2Context _context;

// CONTROL DE VERSIONES cambio realizado por feature2-Yasmin.
    public ProductoYasminController(Tarea_2Context context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<ProductoYasmin>> Crear(
        [FromBody] ProductoYasminRequest datos)
    {
        var producto = new ProductoYasmin
        {
            Nombre = datos.Nombre.Trim(),
            Precio = datos.Precio,
            Stock = datos.Stock
        };

        _context.ProductoYasmin.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = producto.Id },
            producto
        );
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoYasmin>>> Listar()
    {
        var productos = await _context.ProductoYasmin
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .ToListAsync();

        return Ok(productos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductoYasmin>> ObtenerPorId(int id)
    {
        var producto = await _context.ProductoYasmin
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (producto == null)
            return NotFound("Producto no encontrado.");

        return Ok(producto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(
        int id,
        [FromBody] ProductoYasminRequest datos)
    {
        var producto = await _context.ProductoYasmin.FindAsync(id);

        if (producto == null)
            return NotFound("Producto no encontrado.");

        producto.Nombre = datos.Nombre.Trim();
        producto.Precio = datos.Precio;
        producto.Stock = datos.Stock;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var producto = await _context.ProductoYasmin.FindAsync(id);

        if (producto == null)
            return NotFound("Producto no encontrado.");

        _context.ProductoYasmin.Remove(producto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

public class ProductoYasminRequest
{
    [Required]
    [StringLength(120, MinimumLength = 2)]
    public string Nombre { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "9999999999.99",
    ParseLimitsInInvariantCulture = true)]
public decimal Precio { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}