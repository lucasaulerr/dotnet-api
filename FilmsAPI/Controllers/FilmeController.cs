﻿using AutoMapper;
using FilmsAPI.Data;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Busca uma lista de filmes do banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    /// <summary>
    /// Busca um filme específico do banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja concluída com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) 
            return NotFound();

        // Converte Filme em ReadFilmeDto para possibilitar o retorno de propriedades pro usuário que não façam parte do objeto Filme
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    /// <summary>
    /// Altera um filme no banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para alteração de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody]UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) 
            return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }

    /// <summary>
    /// Altera um campo específico de um filme no banco de dados
    /// </summary>
    /// <param name="patch">Objeto com os campos necessários para alteração de um campo específico de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a alteração seja feita com sucesso</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) 
            return NotFound();

        // Aplicação das mudanças recebidas por parâmetro conforme o modelo e validação do modelo
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState); 
        if(!TryValidateModel(filmeParaAtualizar)) 
            return ValidationProblem(ModelState);

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();

        return NoContent();
    }

    /// <summary>
    /// Deleta um filme do banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a exclusão seja feita com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null)
            return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}
