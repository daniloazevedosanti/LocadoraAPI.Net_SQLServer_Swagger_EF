using Api.Data;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class FilmeService : IFilme
    {
        private readonly Context _context;
        public FilmeService(Context _context)
        {
            this._context = _context;
        }

        public async Task<List<Filme>> Buscar(string param)
        {
            return await _context.Filmes.Where(c => c.Titulo.Contains(param)).ToListAsync();
        }

        public async Task<Filme> Cadastrar(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            var filmeObj = await _context.Filmes.FindAsync(filme.FilmesId);

            return filmeObj;
        }
    }
}
