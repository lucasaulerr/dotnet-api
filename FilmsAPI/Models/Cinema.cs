using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do cinema é obrigaório.")]
    public string Nome { get; set; }   
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}
