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

            if (Livros.Contains(novoLivro) && Livros.Count > 0)
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
            if (busca.Trim().Length < 2)
                throw new ArgumentException($"A busca deve ter ao menos dois caracteres. Quantidade infromada: {busca.Length}.");

            if (busca == null)
                throw new NullReferenceException("A busca não pode ser nula!");

            var livros = BuscarTitulo(busca);
            if (livros.Count > 0)
            {
                return livros;
                //Console.WriteLine($"\nBusca feita com o termo \"{busca}\".");
                //int numero = 1;
                //foreach (var livro in livros)
                //{
                //    Console.WriteLine($"\n\nLivro número {numero}\n");
                //    Console.WriteLine($"Título: {livro.Titulo}");
                //    Console.WriteLine($"Autor: {livro.Autor.Nome}");
                //    Console.WriteLine($"Categoria: {livro.Categoria.Nome}");
                //    Console.WriteLine($"Resumo: {livro.Resumo}.");
                //    Console.WriteLine($"Sumario: {livro.Sumario}");
                //    Console.WriteLine($"ISBN: {livro.ISBN}");
                //    Console.WriteLine($"Edição: {livro.Edicao}");
                //    Console.WriteLine($"Páginas: {livro.Paginas}");
                //    Console.WriteLine($"Preço: R${livro.Preco}");

                //    numero++;
                //}
            }
            else
                throw new ArgumentException($"\nBusca feita com o termo \"{busca}\" não trouxe resultados.");
        }
    }
}
