using Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IFilme
    {
        Task<Filme> Cadastrar(Filme filme);

        Task<List<Filme>> Buscar(string param);
    }
}
