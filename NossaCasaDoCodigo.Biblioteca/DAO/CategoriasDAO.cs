using System;
using System.Collections.Generic;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class CategoriasDAO
    {
        public static IList<Categoria> Categorias { get; private set; }

        public CategoriasDAO()
        {
            Categorias = new List<Categoria>();
        }

        public static void Salvar(Categoria novaCategoria)
        {
            if (!Buscar(novaCategoria))
            {
                Categorias.Add(novaCategoria);
                Console.WriteLine($"Categoria {novaCategoria.Nome} criada com sucesso!");
            }
            else
            {
                throw new ArgumentException($"Categoria {novaCategoria.Nome} já existe!");
            }
        }

        public static bool Buscar(Categoria novaCategoria)
        {
            return Categorias.Contains(novaCategoria);
        }
    }
}
