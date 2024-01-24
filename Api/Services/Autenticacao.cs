using Api.Data;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Services
{
    public class Autenticacao : IAutenticacao
    {
        private Context _context;

        public Autenticacao(Context _context)
        {
            this._context = _context;
        }

        public async Task<string> Autenticar(Usuario usuario)
        {

            var token = TokenService.GenerateToken(usuario);

            return Task.FromResult(token).Result;
        }

        public async Task<Usuario> Cadastrar(Usuario usuario)
        {

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var usuarioSalvo = await _context.Usuarios.FirstOrDefaultAsync(q => q.Email.ToUpper() == usuario.Email.ToUpper() && q.Senha == usuario.Senha);
            return usuarioSalvo;


        }
    }
}
