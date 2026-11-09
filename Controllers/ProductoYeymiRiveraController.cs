using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tarea_2.Dominio;

namespace Tarea_2.Controllers;
//Controldor de Yeymi
//Comentario de feature 3

[ApiController]
[Route("api/ProductoYeymi")]
public class ProductoYeymiRiveraController : ControllerBase
{
    private readonly Tarea_2Context _context;
    public ProductoYeymiRiveraController(Tarea_2Context context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<ActionResult> Crear(
        string nombre, int stock, decimal precio
    )
    {
        if(nombre==null||stock==0||precio==0){return NotFound("Datos invalidos");}
        var producto = new YeymiRivera
        {
            Nombre=nombre,
            Stock=stock,
            Precio=precio
        };

        _context.ProductoYeymi.Add(producto);
        await _context.SaveChangesAsync();

        return Ok("Producto Creado "+new{ 
            Nombre=producto.Nombre,
            Precio=producto.Precio,
            Stock=producto.Stock
        });
    }

    [HttpGet]
    public async Task<ActionResult> Listar()
    {
        var productos = await _context.ProductoYeymi
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .ToListAsync();

        return Ok(productos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> ObtenerPorId(int id)
    {
        var producto = await ( from p in _context.ProductoYeymi 
        where id==p.Id 
        select p).FirstOrDefaultAsync();

        if (producto == null)
            return NotFound("Producto no encontrado.");

        return Ok(producto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(
        int id, string nombre, int stock, decimal precio
        )
    {
         var producto = await ( from p in _context.ProductoYeymi 
        where id==p.Id 
        select p).FirstOrDefaultAsync();

        if (producto == null)
            return NotFound("Producto no encontrado.");

        producto.Nombre = nombre;
        producto.Precio = precio;
        producto.Stock = stock;

        await _context.SaveChangesAsync();

        return Ok("Producto actualizado correctamente");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar(int id)
    {
         var producto = await ( from p in _context.ProductoYeymi 
        where id==p.Id 
        select p).FirstOrDefaultAsync();

        if (producto == null)
            return NotFound("Producto no encontrado.");

        _context.ProductoYeymi.Remove(producto);
        await _context.SaveChangesAsync();

        return Ok("Producto Borrado");
    }
}

