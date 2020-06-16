using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class LivrosDAO
    {
        private static IList<Livro> Livros { get; set; }

        public LivrosDAO()
        {
            Livros = new List<Livro>();
        }

        public static string Salvar(Livro novoLivro)
        {
            if (Livros.Contains(novoLivro))
            {
                return $"Impossível cadastrar. O livro {novoLivro.Titulo} já existe.";
            }

            Livros.Add(novoLivro);
            return $"O livro {novoLivro.Titulo} foi cadastrado com sucesso!";
        }

        public static List<Livro> BuscarTitulo(string busca)
        {
            return Livros
                .Where(l => l.Titulo.Contains(busca, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }
    }
}
