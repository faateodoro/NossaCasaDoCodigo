using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.DAO;
using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Extensions;

namespace NossaCasaDoCodigo.Testes
{
    public class TestaLivro
    {
        public static IEnumerable<object[]> TeoriasInvalidasISBN = TeoriasInvalidasHelper.TeoriasInvalidasISBN;
        public static IEnumerable<object[]> TeoriasInvalidasTitulo = TeoriasInvalidasHelper.TeoriasInvalidasTitulo;
        public static IEnumerable<object[]> TeoriasInvalidasResumo = TeoriasInvalidasHelper.TeoriasInvalidasResumo;
        public static IEnumerable<object[]> TeoriasInvalidasSumario = TeoriasInvalidasHelper.TeoriasInvalidasSumario;

        [Theory]
        [MemberData(nameof(TeoriasInvalidasTitulo))]
        public void TituloNaoPodeSerVazioOuNulo(string titulo, string resumo, string sumario, int paginas,
            string iSBN, Autor autor, Categoria categoria, double edicao, double preco)
        {
            Assert.Throws<ArgumentNullException>(() => new Livro(titulo, resumo, sumario, paginas,
                iSBN, autor, categoria, edicao, preco));
        }

        [Fact]
        public void TituloNaoPodeSerDuplicado()
        {
            CriaLivrosDao();

            var novoLivro = new Livro("PHP para baixinhos",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, 35.50);

            Assert.Equal($"Impossível cadastrar. O livro {novoLivro.Titulo} já existe.", LivrosDAO.Salvar(novoLivro));
        }

        [Fact]
        public void ResumoDeveTerAoMenos500Caracteres()
        {
            Assert.Throws<ArgumentException>(() => new Livro("Titulo Novo", "Bem menos de 500 caracteres.",
                null, 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.1, 50.95));
        }

        [Theory]
        [MemberData(nameof(TeoriasInvalidasResumo))]
        public void ResumoNaoPodeSerVazioOuNulo(string titulo, string resumo, string sumario, int paginas,
            string iSBN, Autor autor, Categoria categoria, double edicao, double preco)
        {
            Assert.Throws<ArgumentNullException>(() => new Livro(titulo, resumo, sumario, paginas,
                iSBN, autor, categoria, edicao, preco));
        }

        [Theory]
        [MemberData(nameof(TeoriasInvalidasSumario))]
        public void SumarioNaoPodeSerVazioOuNulo(string titulo, string resumo, string sumario, int paginas,
            string iSBN, Autor autor, Categoria categoria, double edicao, double preco)
        {
            Assert.Throws<ArgumentNullException>(() => new Livro(titulo, resumo, sumario, paginas,
                iSBN, autor, categoria, edicao, preco));
        }
        
        [Theory]
        [MemberData(nameof(TeoriasInvalidasISBN))]
        public void IsbnNaoPodeTerFormatoInvalido(string titulo, string resumo, string sumario, int paginas,
            string iSBN, Autor autor, Categoria categoria, double edicao, double preco)
        {
            Assert.Throws<ArgumentException>(() => new Livro(titulo, resumo, sumario, paginas,
                iSBN, autor, categoria, edicao, preco));
        }


        [Fact]
        public void EdicaoDeveSerUmNumeroMaiorOuIgualAUm()
        {
            Assert.Throws<ArgumentException>(() => new Livro("teste",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 0, 50.95));
        }

        [Fact]
        public void PrecoDeveSerUmNumeroPositivoOuZero()
        {
            Assert.Throws<ArgumentException>(() => new Livro("teste",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, -12));
        }

        [Fact]
        public void EmCasoDeSucessoDeveSerRetornadaUmaMensagemDeSucesso()
        {
            CriaLivrosDao();

            var novoLivro = new Livro("Evoluindo na plataforma .Net",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("Fabiano Teodoro", "faateodoro@gmail.com", "Sem ideias para a descrição."), 
                new Categoria("Programação"), 2.0, 35.50);

            Assert.Equal($"O livro {novoLivro.Titulo} foi cadastrado com sucesso!", LivrosDAO.Salvar(novoLivro));
        }

        private void CriaLivrosDao()
        {
            new LivrosDAO();
            LivrosDAO.Salvar(new Livro("PHP para baixinhos",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, 35.50));
            LivrosDAO.Salvar(new Livro("Escrevi este livro e fiquei rico!",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, 35.50));
            LivrosDAO.Salvar(new Livro("Seja um coach quântico sem saber o significado de quântico.",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, 35.50));
        }
    }
}
