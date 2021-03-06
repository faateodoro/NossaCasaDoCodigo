﻿using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.DAO;
using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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
            string iSBN, Autor autor, Categoria categoria, double edicao, decimal preco)
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
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, 35.50m);

            Assert.True(LivrosDAO.BuscarTitulo(novoLivro.Titulo).Any());
        }

        [Fact]
        public void ResumoDeveTerAoMenos500Caracteres()
        {
            Assert.Throws<ArgumentException>(() => new Livro("Titulo Novo", "Bem menos de 500 caracteres.",
                "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.1, 50.95m));
        }

        [Theory]
        [MemberData(nameof(TeoriasInvalidasResumo))]
        public void ResumoNaoPodeSerVazioOuNulo(string titulo, string resumo, string sumario, int paginas,
            string iSBN, Autor autor, Categoria categoria, double edicao, decimal preco)
        {
            Assert.Throws<ArgumentNullException>(() => new Livro(titulo, resumo, sumario, paginas,
                iSBN, autor, categoria, edicao, preco));
        }

        [Theory]
        [MemberData(nameof(TeoriasInvalidasSumario))]
        public void SumarioNaoPodeSerVazioOuNulo(string titulo, string resumo, string sumario, int paginas,
            string iSBN, Autor autor, Categoria categoria, double edicao, decimal preco)
        {
            Assert.Throws<ArgumentNullException>(() => new Livro(titulo, resumo, sumario, paginas,
                iSBN, autor, categoria, edicao, preco));
        }
        
        [Theory]
        [MemberData(nameof(TeoriasInvalidasISBN))]
        public void IsbnNaoPodeTerFormatoInvalido(string titulo, string resumo, string sumario, int paginas,
            string iSBN, Autor autor, Categoria categoria, double edicao, decimal preco)
        {
            Assert.Throws<ArgumentException>(() => new Livro(titulo, resumo, sumario, paginas,
                iSBN, autor, categoria, edicao, preco));
        }


        [Fact]
        public void EdicaoDeveSerUmNumeroMaiorOuIgualAUm()
        {
            Assert.Throws<ArgumentException>(() => new Livro("teste",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 0, 50.95m));
        }

        [Fact]
        public void PrecoDeveSerUmNumeroPositivoOuZero()
        {
            Assert.Throws<ArgumentException>(() => new Livro("teste",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, -12));
        }

        private void CriaLivrosDao()
        {
            new LivrosDAO();
            LivrosDAO.Salvar(new Livro("PHP para baixinhos",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, 35.50m));
            LivrosDAO.Salvar(new Livro("Escrevi este livro e fiquei rico!",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, 35.50m));
            LivrosDAO.Salvar(new Livro("Seja um coach quântico sem saber o significado de quântico.",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                new Autor("nome", "email@gmail.com", "minha descrição"), new Categoria("categoria"), 2.0, 35.50m));
        }
    }
}
