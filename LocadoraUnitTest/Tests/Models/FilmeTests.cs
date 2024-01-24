using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraUnitTest.Tests.Models
{
    [TestClass]
    public class FilmeTests
    {
        private Filme? filme;

        [TestInitialize]
        public void Init()
        {
            filme = new Filme()
            {
                Titulo = "A Vingança de Godzilla",
                Diretor = "Ishirō Honda",
                Estoque = 4
            };

        }


        [TestMethod]
        public void RecebendoIdIndevido()
        {
            Assert.IsFalse(filme?.FilmesId != 0);
        }

        [TestMethod]
        public void NomeInvalido()
        {
            Assert.IsFalse(string.IsNullOrEmpty(filme?.Titulo));
        }

    }
}
