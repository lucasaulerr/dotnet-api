using AutoMapper;
using FilmsAPI.Data;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{

    public FilmeContext _context;
    public IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

        _context.Enderecos.Add(endereco);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { id = endereco.Id }, endereco);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEnderecoPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(el => el.Id == id);
        if (endereco == null) return NotFound();

        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperaEnderecos([FromQuery] int skip=0, [FromQuery] int take=10)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take));
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(el => el.Id == id);
        if (endereco == null) return NotFound();

        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(el => el.Id == id);
        if (endereco == null) return NotFound();

        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();

        return NoContent();
    }
}
