using System.ComponentModel.DataAnnotations;
namespace Priori.francesco._5h.ECommerce.Models;


public class Utenti
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    
}
