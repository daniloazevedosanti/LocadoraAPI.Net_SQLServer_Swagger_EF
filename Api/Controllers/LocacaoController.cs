using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("")]
    [ApiController]
    [Authorize]
    public class LocacaoController : ControllerBase
    {
        private readonly Context _context;

        public LocacaoController(Context context)
        {
            _context = context;
        }

        [HttpGet("godzillas")]
        public async Task<ActionResult<IEnumerable<Locacao>>> GetFilmes()
        {
            return await _context.Locacoes.Include(q => q.LocacaoFilme).ThenInclude(q => q.Filme).ToListAsync();
        }

        [HttpGet("locadora/godzilla/{param}")]
        public async Task<ActionResult<IEnumerable<Filme>>> GetLocadoraFilmes(string param)
        {
            return await _context.Filmes.Where(c => c.Titulo.Contains(param)).ToListAsync();
        }

        [HttpGet("godzilla/{id}")]
        public async Task<ActionResult<Locacao>> GetLocacao(int id)
        {
            var locacao = await _context.Locacoes.FindAsync(id);

            if (locacao == null)
            {
                return NotFound();
            }

            return locacao;
        }

        [HttpPost("godzilla")]
        public async Task<ActionResult<Locacao>> PostLocacao([FromQuery] int filmesId, string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Email.ToUpper() == email.ToUpper());
            if(usuario == null)
                return BadRequest();

            var filme = await _context.Filmes.FindAsync(filmesId);
            var locacao = new Locacao();

            if (filme.Estoque > 0)
            {
                filme.Estoque--;

                locacao.DataLocacao = DateTime.Now;
                locacao.Email = usuario.Email;

                LocacaoFilme locacaoFilme = new LocacaoFilme(locacao.Id, filmesId);

                locacao.LocacaoFilme = locacaoFilme;
                locacao.LocacaoFilme.Filme = filme;

                _context.Locacoes.Add(locacao);
                await _context.SaveChangesAsync();

                // Atualizando contexto filmes descriscimo de estoque
                _context.Entry(filme).State = EntityState.Modified;               
                await _context.SaveChangesAsync();

                // Atualizando contexto LocacaoFilmes por relação de tabelas Locacao e Filme
                _context.Entry(locacaoFilme).State = EntityState.Modified;               
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLocacao", new { id = locacao.Id }, locacao);
            }

            return BadRequest();
        }
    }
}
