using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class ProdutosDAO
    {
        public static IDictionary<Livro, int> EstoqueProdutos { get; private set; }
        public ProdutosDAO()
        {
            EstoqueProdutos = new Dictionary<Livro, int>();
            CadastrarEstoque();
        }

        private static void CadastrarEstoque()
        {
            EstoqueProdutos.Add(LivrosHelpers.LIVRO1, 2);
            EstoqueProdutos.Add(LivrosHelpers.LIVRO2, 8);
            EstoqueProdutos.Add(LivrosHelpers.LIVRO3, 4);
            EstoqueProdutos.Add(LivrosHelpers.LIVRO4, 6);
            EstoqueProdutos.Add(LivrosHelpers.LIVRO5, 0);
        }

        public static void RemoverQuantidade(Livro livro, int quantidadeDecrementada)
        {
            NumeroEhValido(quantidadeDecrementada);

            var produto = EstoqueProdutos.Where(l => l.Key == livro);
            int quantidadeAtual;
            EstoqueProdutos.TryGetValue(livro, out quantidadeAtual);
            if (quantidadeAtual < quantidadeDecrementada)
            {
                throw new ArgumentException($"Estoque insuficiente. Temos apenas {quantidadeAtual} unidades disponíveis.");
            }
            EstoqueProdutos[livro] = (quantidadeAtual - quantidadeDecrementada);
        }

        public static Livro BuscarLivroPorTitulo(string titulo)
        {
            return EstoqueProdutos.Keys
                .Where(l => l.Titulo.Contains(titulo, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();
        }

        public static int BuscarQuantidadePorLivro(Livro livro)
        {
            int quantidade;
            EstoqueProdutos.TryGetValue(livro, out quantidade);
            return quantidade;
        }

        private static void NumeroEhValido(int quantidade)
        {
            if (quantidade < 1)
                throw new ArgumentException("Número inválido. Não pode ser 0 ou um número negativo.");
        }
    }
}