using AutoMapper;
using FilmsAPI.Data;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers
{
    public class SessaoController : ControllerBase
    {
        public FilmeContext _context { get; set; }
        public IMapper _mapper { get; set; }

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessao.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorID), new { id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorID(int id)
        {
            var sessao = _context.Sessao.FirstOrDefault(el => el.Id == id);
            if (sessao == null) return NotFound();

            var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return Ok(sessaoDto);
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> RecuperaSessoes([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessao.Skip(skip).Take(take).ToList());
        }

    }
}
