using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{

    public interface IAutenticacao
    {

        Task<string> Autenticar(Usuario usuario);

        Task<Usuario> Cadastrar(Usuario usuario);
    }
}
