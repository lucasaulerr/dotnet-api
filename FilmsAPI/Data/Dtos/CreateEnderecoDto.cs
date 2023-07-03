using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Dtos;

public class CreateEnderecoDto
{
    [Required]
    public string Logradouro { get; set; }

    [Required]
    public int Numero { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public string Bairro { get; set; }
}
