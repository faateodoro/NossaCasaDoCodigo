using NossaCasaDoCodigo.Biblioteca.DAO;
using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossaCasaDoCodigo.Biblioteca
{
    public class CarrinhoDeCompra
    {
        private static IDictionary<Livro, int> Carrinho { get; set; }
        public DateTime DataHoraVenda { get; private set; }
        public CarrinhoDeCompra()
        {
            Carrinho = new Dictionary<Livro, int>();
        }

        public void AdicionaProduto(Livro livro, int quantidade)
        {
            if (quantidade < 1)
                throw new ArgumentException("Número inválido. Não pode ser 0 ou um número negativo.");

            if (livro == null)
            {
                throw new ArgumentNullException("Este livro não existe.");
            }

            if (Carrinho.ContainsKey(livro))
            {
                Carrinho.TryGetValue(livro, out int quantidadeAtual);
                Carrinho[livro] = quantidade + quantidadeAtual;
            }
            else
            {
                Carrinho.Add(livro, quantidade);
            }
        }

        public void FinalizarCompra()
        {
            CarrinhoEstaVazio();
            DataHoraVenda = DateTime.Now;
            MostrarLivrosNoCarrinho();
        }

        private void MostrarLivrosNoCarrinho()
        {
            decimal totalDaCompra = 0m;
            foreach (var item in Carrinho)
            {
                var subtotal = item.Key.Preco * item.Value;

                Console.WriteLine($"Título: {item.Key.Titulo}");
                Console.WriteLine($"Quantidade: {item.Value}");
                Console.WriteLine($"Preço unitário: R${item.Key.Preco}");
                Console.WriteLine($"Sub-total: R${subtotal}");
                Console.WriteLine("===========================================================");

                totalDaCompra += subtotal;
            }

            Console.WriteLine($"\nTotal da compra: R${totalDaCompra}");
            Console.WriteLine("\n===========================================================\n\n");
        }

        private void CarrinhoEstaVazio()
        {
            if (!Carrinho.Any())
            {
                throw new ArgumentNullException("O carrinho está vazio. A compra não pode ser finalizada.");
            }
        }
    }
}
