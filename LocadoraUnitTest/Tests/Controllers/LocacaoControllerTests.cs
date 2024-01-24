using Api.Controllers;
using Api.Data;
using Api.Models;
using Api.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LocadoraUnitTest.Tests.Controllers
{
    [TestClass]
    public class LocacaoControllerTests
    {
        private readonly Context _context;
        private Mock<IFilme> _mockFilmeService;
        private FilmeController _filmeController;

        [TestInitialize]
        public void Setup()
        {
            _mockFilmeService = new Mock<IFilme>();
            _filmeController = new FilmeController(_context, _mockFilmeService.Object);
        }

        [DataTestMethod]
        public void GetReturns()
        {
            // arrange
            var filme = new Filme()
            {
                Titulo = "Titulo Godzilla teste",
                Diretor = "Desconhecido",
                Estoque = 3

            };

            _mockFilmeService.Setup(x => x.Buscar(filme.Titulo)).ReturnsAsync(new List<Filme>());

            // act
            var result = _filmeController.Get(filme.Titulo);

            // assert
            Assert.AreNotEqual(filme, result);

        }

    }
}
