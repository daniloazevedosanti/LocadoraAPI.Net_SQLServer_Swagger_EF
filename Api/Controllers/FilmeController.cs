using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FilmeController : ControllerBase
    {
        private readonly Context _context;
        private readonly IFilme FilmeService;

        public FilmeController(Context context, IFilme filmeService)
        {
            _context = context;
            FilmeService = filmeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        [HttpGet("godzilla/{param}")]
        public async Task<ActionResult<IEnumerable<Filme>>> Get(string param)
        {
            return await _context.Filmes.Where(c => c.Titulo.Contains(param)).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.FilmesId)
            {
                return BadRequest();
            }

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            var filmeObj = await _context.Filmes.Where(c => c.Titulo == filme.Titulo && c.Diretor.Equals(filme.Diretor)).FirstOrDefaultAsync();
            
            if(filmeObj != null)
                return NotFound(new { message = "Filme já cadastrado!" });

            var result = await FilmeService.Cadastrar(filme);

            return CreatedAtAction("GetFilme", new { id = result.FilmesId }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }
           
            if (FilmeUsed(id))
            {
                return NotFound(new { message = "Esse filme tem vinculo de locação, não pode ser excluído." });
            }
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.FilmesId == id);
        }

        private bool FilmeUsed(int id)
        {
            return _context.LocacaoesFilmes.Any(e => e.FilmeId == id);
        }
    
    }
}
