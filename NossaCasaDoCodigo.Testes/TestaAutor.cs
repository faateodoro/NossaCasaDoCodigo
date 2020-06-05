using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NossaCasaDoCodigo.Testes
{
    public class TestaAutor
    {
        [Theory]
        [InlineData("", "fabiano@gmail.com", "Um cara iniciando na carrera de TI.")]
        [InlineData(null, "fabiano@gmail.com", "Um cara iniciando na carrera de TI.")]
        public void CampoNomeNaoPodeSerVazioOuNulo(string nome, string email, string descricao)
        {
            Assert.Throws<ArgumentException>(() => new Autor(nome, email, descricao));
        }

        [Theory]
        [InlineData("Fabiano", "fabiano", "Um cara iniciando na carrera de TI.")]
        [InlineData("Fabiano", "fabiano@gmail", "Um cara iniciando na carrera de TI.")]
        [InlineData("Fabiano", "fabianogmail.com", "Um cara iniciando na carrera de TI.")]
        [InlineData("Fabiano", "", "Um cara iniciando na carrera de TI.")]
        public void CampoEmailDevePossuirFormatoValido(string nome, string email, string descricao)
        {
            Assert.Throws<ArgumentException>(() => new Autor(nome, email, descricao));
        }

        [Fact]
        public void CampoEmailnaoPodeSerNulo()
        {
            Assert.Throws<ArgumentNullException>(() => new Autor("Fabiano", null, "Um cara iniciando na carrera de TI."));
        }


        [Theory]
        [InlineData("Fabiano", "fabiano@gmail.com", "")]
        [InlineData("Fabiano", "fabiano@gmail.com", null)]
        
        public void CampoDescricaoNaoPodeSerVazioOuNulo(string nome, string email, string descricao)
        {
            Assert.Throws<ArgumentNullException>(() => new Autor(nome, email, descricao));
        }
        
        [Fact]
        public void CampoDescricaoNaoPodeTerMaisDeQuatrocentrosCaracteres()
        {
            Assert.Throws<ArgumentException>(() => new Autor
            ("Fabiano", 
            "fabiano@gmail.com",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
            "Aliquam non condimentum tellus. Nulla vulputate enim et sodales vehicula. " +
            "Aenean vel scelerisque augue. Pellentesque luctus ornare tincidunt. " +
            "Vivamus ultrices est massa, quis luctus ex posuere et. " +
            "Duis commodo urna sed velit accumsan volutpat. " +
            "Vivamus eu nisl in orci mollis efficitur id at ex. Vivamus vel molestie urna. " +
            "Ut fringilla feugiat lacinia. Morbi cras amet."));
        }

        [Fact]
        public void MomentoDoCadastroEstaIncluso()
        {
            var autor = new Autor("Fabiano", "fabiano@gmail.com", "Um cara iniciando na carrera de TI.");
            Assert.False(string.IsNullOrEmpty(autor.DataCadastro));
        }

        [Fact]
        public void TodasAsValidacoesEstaoFuncionandoAoInserirDadosValidos()
        {
            IList<Autor> autores = new List<Autor>
            {
                new Autor("Fabiano", "fabiano@gmail.com", "Um cara iniciando na carrera de TI."),
                new Autor("Ana", "ana@gmail.com", "Uma moça pensando em que carreira seguir."),
                new Autor("Clara", "clara@alura.com.br", "Uma menininha linda!")
            };

            Assert.Equal(3, autores.Count);
        }

        [Fact]
        public void EmailNaoDeveSerDuplicado()
        {
            new AutoresDAO();
            AutoresDAO.Salvar(new Autor("Fabiano", "fabianoteodoro@gmail.com", "Um cara iniciando na carrera de TI."));
            AutoresDAO.Salvar(new Autor("Ana", "anateodoro@gmail.com", "Uma moça pensando em que carreira seguir."));
            AutoresDAO.Salvar(new Autor("Clara", "clarateodoro@alura.com.br", "Uma menininha linda!"));

            Assert.Throws<ArgumentException>(() =>
                AutoresDAO.Salvar(
                    new Autor("Fabiano", "fabianoteodoro@gmail.com", "Um cara iniciando na carrera de TI.")));
        }
    }
}
