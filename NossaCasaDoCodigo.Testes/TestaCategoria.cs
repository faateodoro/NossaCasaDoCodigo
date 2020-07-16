using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace NossaCasaDoCodigo.Testes
{
    public class TestaCategoria
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeDaCategoriaNaoPodeSerVazioOuNulo(string nome)
        {
            Assert.Throws<ArgumentNullException>(() => new Categoria(nome));
        }

        [Fact]
        public void NomeDaCategoriaDeveSerUnico()
        {
            CriaCategoriaDAO();

            Assert.Throws<ArgumentException>(() => CategoriasDAO.Salvar(new Categoria("Testes")));
        }

        [Fact]
        public void CategoriaCadastradaDeveTerMomentoDeCriação()
        {
            var categoria = new Categoria("Gestão");
            Assert.False(string.IsNullOrEmpty(categoria.DataCadastro));
        }
        
        private static void CriaCategoriaDAO()
        {
            new CategoriasDAO();
            CategoriasDAO.Salvar(new Categoria("Design"));
            CategoriasDAO.Salvar(new Categoria("Marketing Digital"));
            CategoriasDAO.Salvar(new Categoria("Testes"));
        }
    }
}
