using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Filme
    {
        [Key]
        public int FilmesId { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public int Estoque { get; set; }

        public Filme() { }

        public void Atualizar(string Nome, string Diretor)
        {
            this.Titulo = Nome;
            this.Diretor = Diretor;
        }
    }

}
