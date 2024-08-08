using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HortiFrutiAPI.Models;

[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Frutas = new Collection<Fruta>();
    }
    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public ICollection<Fruta>? Frutas { get; set; }
}