using AutoMapper;
using FilmsAPI.Data;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    public FilmeContext _context { get; set; }
    public IMapper _mapper { get; set; }

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorID), new {id = cinema.Id}, cinema);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorID (int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(el => el.Id == id);
        if (cinema == null) return NotFound();

        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperaCinemas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema (int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(el => el.Id == id);
        if (cinema == null) return NotFound();

        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCinema (int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(el => el.Id == id);
        if (cinema == null) return NotFound();

        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();

        return NoContent();
    }
}
