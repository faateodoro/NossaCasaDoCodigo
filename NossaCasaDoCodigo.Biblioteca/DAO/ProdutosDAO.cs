using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class ProdutosDAO
    {
        public static ISet<Livro> EstoqueProdutos { get; private set; }
        public ProdutosDAO()
        {
            EstoqueProdutos = new HashSet<Livro>();
            CadastrarEstoque();
        }

        private static void CadastrarEstoque()
        {
            EstoqueProdutos.Add(LivrosHelpers.LIVRO1);
            EstoqueProdutos.Add(LivrosHelpers.LIVRO2);
            EstoqueProdutos.Add(LivrosHelpers.LIVRO3);
            EstoqueProdutos.Add(LivrosHelpers.LIVRO4);
            EstoqueProdutos.Add(LivrosHelpers.LIVRO5);
        }
    }
}