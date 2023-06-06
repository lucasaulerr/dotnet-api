using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Dtos;

public class ReadFilmeDto
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HorarioConsulta { get; set; } = DateTime.Now;
}
