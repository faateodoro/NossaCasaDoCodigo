using NossaCasaDoCodigo.Biblioteca;
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
        public void DataHoraDaVendaDeveSerRegistrada()
        {
            Carrinho.AdicionaProduto("PHP para Baixinhos", 1);
            Carrinho.FinalizarCompra();

            Assert.Equal(DateTime.Today, Carrinho.DataHoraVenda.Date);
        }

        [Fact]
        public void ParaUmaVendaValidaQuantidadeEmEstoqueDeveSerMaiorQueZero()
        {
            // Este livro foi adicionado com quantidade 0 em ProdutosDAO.EstoqueProdutos
            Assert.Throws<ArgumentException>(() => Carrinho.AdicionaProduto("Quinto livro para testar", 1));
        }

        [Fact]
        public void OLivroDeveSerCadastradoNoEstoqueParaFazerParteDeUmaVenda()
        {
            Assert.Throws<ArgumentNullException>(() => Carrinho.AdicionaProduto("Este livro no ecziste!", 1));
        }
    }
}
