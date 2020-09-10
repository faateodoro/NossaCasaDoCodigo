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
        public void DataHoraDaVendaDeveSerRegistrada()
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
    }
}
