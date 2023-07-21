using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }

    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
}
