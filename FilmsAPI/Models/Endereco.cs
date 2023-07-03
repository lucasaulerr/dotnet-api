﻿using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Logradouro { get; set; }

    [Required]
    public int Numero { get; set; }

    [Required]
    public string Cidade { get; set; }

    [Required]
    public string Bairro { get; set; }
}
