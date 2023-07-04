using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O nome do cinema é obrigaório.")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
}
