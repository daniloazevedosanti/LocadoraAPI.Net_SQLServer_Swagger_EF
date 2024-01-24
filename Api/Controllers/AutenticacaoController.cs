using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacao Autenticacao;
        private readonly Context _context;

        public AutenticacaoController(IAutenticacao Autenticacao, Context context)
        {
            this.Autenticacao = Autenticacao;
            _context = context;
        }


        [HttpPost("usuarios/usuario")]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody]Usuario login)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Email.ToUpper() == login.Email.ToUpper() && q.Senha == login.Senha);

            if (usuario == null)
                return NotFound(new { message = "Usuário/senha inválidos" });

            var token = await Autenticacao.Autenticar(usuario);
            
            usuario.Senha = "";

            return new
            {
                auth = true,
                usuario = usuario,
                token = token
            };
        }

        [HttpPost("usuarios/cadastrar")]
        public async Task<ActionResult<dynamic>> Cadastrar([FromBody] Usuario login)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Email.ToUpper() == login.Email.ToUpper() && q.Senha == login.Senha);

            if (usuario != null)
                return NotFound(new { message = "Usuário já existe" });
            
            var usuarioSalvo = await Autenticacao.Cadastrar(login);

            usuarioSalvo.Senha = "";

            return Created("usuarios/cadastrar", usuarioSalvo);
         
        }


    }
}
