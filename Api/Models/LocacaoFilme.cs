namespace Api.Models
{
    public class LocacaoFilme
    {
        public int Id { get; set; }
        public Locacao Locacao { get; set; }
        public int LocacaoId { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }

        public LocacaoFilme(int LocacaoId, int FilmeId){
            this.LocacaoId = LocacaoId;
            this.FilmeId = FilmeId;
        }
        
    }
}