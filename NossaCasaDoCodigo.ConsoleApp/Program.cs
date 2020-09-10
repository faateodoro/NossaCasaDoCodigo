using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.DAO;
using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;

namespace NossaCasaDoCodigo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new AutoresDAO();
            new CategoriasDAO();
            new LivrosDAO();
            new ProdutosDAO();

            CadastrarAutoresDao();
            CadastrarCategoriasDao();
            CadastrarLivrosDao();

            Cabecalho();
            BuscaLivros();

            Console.Clear();

            CarrinhoDeCompra carrinho = new CarrinhoDeCompra();

            carrinho.AdicionaProduto(LivrosHelpers.LIVRO1, 1);
            carrinho.AdicionaProduto(LivrosHelpers.LIVRO1, 1);
            carrinho.AdicionaProduto(LivrosHelpers.LIVRO4, 4);
            carrinho.FinalizarCompra();

            Console.WriteLine("\nAté mais!");
        }

        private static void BuscaLivros()
        {
            var confirmacao = "S";

            while (confirmacao.ToUpper() == "S")
            {
                Console.Write("\n\nDigite ao menos duas letras para buscar um livro pelo título: ");
                string busca = Console.ReadLine();

                if (busca.Length <= 2)
                    Console.WriteLine($"A busca deve ter ao menos dois caracteres. Quantidade infromada: {busca.Length}.");
                else
                {
                    var livros = LivrosDAO.BuscarTitulo(busca);
                    if (livros.Count > 0)
                    {
                        Console.WriteLine($"\nBusca feita com o termo \"{busca}\".");
                        int numero = 1;
                        foreach (var livro in livros)
                        {
                            Console.WriteLine($"\n\nLivro número {numero}\n");
                            Console.WriteLine($"Título: {livro.Titulo}");
                            Console.WriteLine($"Autor: {livro.Autor.Nome}");
                            Console.WriteLine($"Categoria: {livro.Categoria.Nome}");
                            Console.WriteLine($"Resumo: {livro.Resumo}.");
                            Console.WriteLine($"Sumario: {livro.Sumario}");
                            Console.WriteLine($"ISBN: {livro.ISBN}");
                            Console.WriteLine($"Edição: {livro.Edicao}");
                            Console.WriteLine($"Páginas: {livro.Paginas}");
                            Console.WriteLine($"Preço: R${livro.Preco}");

                            numero++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nBusca feita com o termo \"{busca}\" não trouxe resultados.");
                    }
                }

                Console.WriteLine("\n\nDeseja fazer outra busca? (S/N): ");
                confirmacao = Console.ReadLine();
            }
        }

        private static void Cabecalho()
        {
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("------------------------- Nossa Casa Do Código ------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        private static void CadastrarAutoresDao()
        {
            AutoresDAO.Salvar(new Autor("Rasmus", "rasmus@php.com", "Criador da linguagem PHP."));
            AutoresDAO.Salvar(new Autor("Ricardo Rico", "meuemailcaro@richmail.com", "Muito ryco!"));
            AutoresDAO.Salvar(new Autor("Enga Nador", "enga.nei@gmail.com", "Comecei enganando cedo."));
        }

        private static void CadastrarCategoriasDao()
        {
            CategoriasDAO.Salvar(new Categoria("PHP"));
            CategoriasDAO.Salvar(new Categoria("Coach Quântico"));
        }

        private static void CadastrarLivrosDao()
        {
            LivrosDAO.Salvar(new Livro("PHP para baixinhos",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "A arte de ser um sobrinho.", 20, "978-12-34567-89-0",
                new Autor("Rasmus", "rasmus@php.com", "Criador da linguagem PHP."), new Categoria("PHP"), 2.0, 35.50m));

            LivrosDAO.Salvar(new Livro("Escrevi este livro e fiquei ryco!",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Este é sumário é bem caro.", 20, "978-12-76543-89-0",
                new Autor("Ricardo Rico", "meuemailcaro@richmail.com", "Muito ryco!"), new Categoria("Coach Quântico"), 2.0, 35.50m));

            LivrosDAO.Salvar(new Livro("Seja um coach quântico sem saber o significado de quântico.",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Sumário quântico", 20, "978-12-34567-09-8",
                new Autor("Enga Nador", "enga.nei@gmail.com", "Comecei enganando cedo."), new Categoria("Coach Quântico"), 2.0, 35.50m));

            LivrosDAO.Salvar(new Livro("Seja um coach quântico sem saber o significado de quântico 2.",
                LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Sumário quântico", 20, "978-12-34559-09-8",
                new Autor("Enga Nador", "enga.nei@gmail.com", "Comecei enganando cedo."), new Categoria("Coach Quântico"), 2.0, 35.50m));
        }
    }
}
