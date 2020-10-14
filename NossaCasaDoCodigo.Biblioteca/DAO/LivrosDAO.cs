using System;
using System.Collections.Generic;
using System.Linq;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class LivrosDAO
    {
        private static IList<Livro> Livros { get; set; }

        public LivrosDAO()
        {
            Livros = new List<Livro>();
        }

        public static void Salvar(Livro novoLivro)
        {
            try
            {
                CategoriasDAO.Salvar(novoLivro.Categoria);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                AutoresDAO.Salvar(novoLivro.Autor);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            if (Livros.Contains(novoLivro))
                Console.WriteLine($"Impossível cadastrar. O livro {novoLivro.Titulo} já existe.");
            else
                Livros.Add(novoLivro);
        }

        public static List<Livro> BuscarTitulo(string busca)
        {
            return Livros
                .Where(l => l.Titulo.Contains(busca, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        public static IList<Livro> MostrarLivrosBuscados(string busca)
        {
            if (busca == null)
                throw new NullReferenceException("A busca não pode ser nula!");

            if (busca.Trim().Length < 2)
                throw new ArgumentException($"A busca deve ter ao menos dois caracteres. Quantidade infromada: {busca.Length}.");

            var livros = BuscarTitulo(busca);
            if (livros.Count > 0)
            {
                return livros;
            }
            else
                throw new ArgumentException($"\nBusca feita com o termo \"{busca}\" não trouxe resultados.");
        }
    }
}
