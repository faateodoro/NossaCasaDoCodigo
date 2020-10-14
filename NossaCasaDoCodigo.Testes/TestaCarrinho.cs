using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NossaCasaDoCodigo.Testes
{
    public class TestaCarrinho
    {
        private static CarrinhoDeCompra Carrinho = new CarrinhoDeCompra();
        [Fact]
        public void DeveTerAoMenosUmLivroParaFecharOCarrinho()
        {
            var CarrinhoZerado = new CarrinhoDeCompra();
            Assert.Throws<ArgumentNullException>(() => CarrinhoZerado.FinalizarCompra());
        }

        [Fact]
        public void ValorDeDataHoraDaVendaDeveSerRegistrada()
        {
            Carrinho.AdicionaProduto(LivrosHelpers.LIVRO1, 1);
            Carrinho.FinalizarCompra();

            Assert.Equal(DateTime.Today, Carrinho.DataHoraVenda.Date);
        }

        [Fact]
        public void OLivroDeveSerCadastradoNoEstoqueParaFazerParteDeUmaVenda()
        {
            Assert.Throws<ArgumentNullException>(() => Carrinho.AdicionaProduto(null, 1));
        }

        [Theory]
        [MemberData(nameof(LivroObjeto))]
        [MemberData(nameof(LivroObjeto))]
        public void QuantidadeDeLivrosVendidasDeveSerMaiorQueZero(string titulo, string resumo, string sumario, int paginas,
            string iSBN, Autor autor, Categoria categoria, double edicao, decimal preco, int quantidade)
        {
            Assert.Throws<ArgumentException>(() => Carrinho.AdicionaProduto(new Livro(titulo, resumo, sumario, paginas,
            iSBN, autor, categoria, edicao, preco), quantidade));
        }

        public static IEnumerable<object[]> LivroObjeto
        {
            get
            {
                return new[]
                {
                    new object[]{"Titulo Novo", LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95, 0 },

                    new object[]{"Titulo Novo", LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95, -8 }
                };
            }
        }
    }
}
