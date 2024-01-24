using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Locacao
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DataLocacao { get; set; }
        public virtual LocacaoFilme LocacaoFilme { get; set; }
    }
}