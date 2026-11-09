using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea_2.Dominio;
namespace Tarea_2.Controllers;
[ApiController]
[Route("api/productos-juliethflores")]
public class ProductosJuliethFloresController : ControllerBase
{

// Comentario Gitflow: cambio realizado desde feature3

    // Segundo cambio independiente de feature3

    private readonly Tarea_2Context _context;

    public ProductosJuliethFloresController(Tarea_2Context context)
    {
        _context = context;
    }

    // GET: listar todos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoJuliethFlores>>> Get()
    {
        return Ok(await _context.ProductosJuliethFlores
            .AsNoTracking().ToListAsync());
    }

    // GET: buscar por Id
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductoJuliethFlores>> GetPorId(int id)
    {
        var producto = await _context.ProductosJuliethFlores
            .FindAsync(id);

        if (producto == null)
            return NotFound();

        return Ok(producto);
    }

    // POST: registrar
    [HttpPost]
    public async Task<ActionResult<ProductoJuliethFlores>> Post(
        ProductoJuliethFlores producto)
    {
        _context.ProductosJuliethFlores.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPorId),
            new { id = producto.Id }, producto);
    }

    // PUT: modificar
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(
        int id, ProductoJuliethFlores producto)
    {
        if (id != producto.Id)
            return BadRequest("El Id no coincide.");

        var existente = await _context.ProductosJuliethFlores
            .FindAsync(id);

        if (existente == null)
            return NotFound();

        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Stock = producto.Stock;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: eliminar
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var producto = await _context.ProductosJuliethFlores
            .FindAsync(id);

        if (producto == null)
            return NotFound();

        _context.ProductosJuliethFlores.Remove(producto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
