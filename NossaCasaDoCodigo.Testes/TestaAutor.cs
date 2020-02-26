using NossaCasaDoCodigo.Biblioteca;
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
        [InlineData("Fabiano", "fabiano@gmail.com",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
            "Aliquam non condimentum tellus. Nulla vulputate enim et sodales vehicula. " +
            "Aenean vel scelerisque augue. Pellentesque luctus ornare tincidunt. " +
            "Vivamus ultrices est massa, quis luctus ex posuere et. " +
            "Duis commodo urna sed velit accumsan volutpat. " +
            "Vivamus eu nisl in orci mollis efficitur id at ex. Vivamus vel molestie urna. " +
            "Ut fringilla feugiat lacinia. Morbi cras amet.")]
        public void CampoDescricaoNaoPodeSerVazioOuNuloComMenosDeQuatrocentrosCaracteres
            (string nome, string email, string descricao)
        {
            Assert.Throws<ArgumentException>(() => new Autor(nome, email, descricao));
        }

        [Fact]
        public void MomentoDoCadastroEstaIncluso()
        {
            var autor = new Autor("Fabiano", "fabiano@gmail.com", "Um cara iniciando na carrera de TI.");
            Assert.False(string.IsNullOrEmpty(autor.DataCadastro));
        }
    }
}
