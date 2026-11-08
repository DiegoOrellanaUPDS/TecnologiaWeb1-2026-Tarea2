using  System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Tarea_2.Dominio;
public class YeymiRivera{
    [Key]
    public int Id{set;get;}
    public string Nombre {get;set;}
    public decimal Precio {get;set;}
    public int Stock {get;set;}
}