using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.DAO;
using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;
using Xunit;

namespace NossaCasaDoCodigo.Testes
{
    public class TestaVisualizacaoLivros
    {
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        public void BuscaDeveTerAoMenosDoisCaracteres(string busca) =>
            Assert.Throws<ArgumentException>(() => LivrosDAO.MostrarLivrosBuscados(busca));

        [Fact]
        public void BuscaNaoDeveSerNula() =>
            Assert.Throws<NullReferenceException>(() => LivrosDAO.MostrarLivrosBuscados(null));

        [Fact]
        public void BuscaComOTermoCoachRetornaDoisLivros()
        {
            new LivrosDAO();
            CadastrarAutoresDao();
            CadastrarCategoriasDao();
            CadastrarLivrosDao();

            var livros = LivrosDAO.MostrarLivrosBuscados("Coach");

            Assert.True(livros.Count == 2);
        }

        private static void CadastrarAutoresDao()
        {
            new AutoresDAO();
            AutoresDAO.Salvar(new Autor("Rasmus", "rasmus@php.com", "Criador da linguagem PHP."));
            AutoresDAO.Salvar(new Autor("Ricardo Rico", "meuemailcaro@richmail.com", "Muito ryco!"));
            AutoresDAO.Salvar(new Autor("Enga Nador", "enga.nei@gmail.com", "Comecei enganando cedo."));
        }

        private static void CadastrarCategoriasDao()
        {
            new CategoriasDAO();
            CategoriasDAO.Salvar(new Categoria("PHP"));
            CategoriasDAO.Salvar(new Categoria("Coach Quântico"));
        }

        private static void CadastrarLivrosDao()
        {
            LivrosDAO.Salvar(new Livro("PHP para baixinhos",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "A arte de ser um sobrinho.", 20, "978-12-34567-89-0",
                new Autor("Rasmus", "rasmus@php.com", "Criador da linguagem PHP."), new Categoria("PHP"), 2.0, 35.50m));

            LivrosDAO.Salvar(new Livro("Escrevi este livro e fiquei ryco!",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Este é sumário é bem caro.", 20, "978-12-76543-89-0",
                new Autor("Ricardo Rico", "meuemailcaro@richmail.com", "Muito ryco!"), new Categoria("Coach Quântico"), 2.0, 35.50m));

            LivrosDAO.Salvar(new Livro("Seja um coach quântico sem saber o significado de quântico.",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Sumário quântico", 20, "978-12-34567-09-8",
                new Autor("Enga Nador", "enga.nei@gmail.com", "Comecei enganando cedo."), new Categoria("Coach Quântico"), 2.0, 35.50m));

            LivrosDAO.Salvar(new Livro("Seja um coach quântico sem saber o significado de quântico 2.",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Sumário quântico", 20, "978-12-34559-09-8",
                new Autor("Enga Nador", "enga.nei@gmail.com", "Comecei enganando cedo."), new Categoria("Coach Quântico"), 2.0, 35.50m));
        }
    }
}
