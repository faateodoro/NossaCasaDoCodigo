using System;
using System.Collections.Generic;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class CategoriasDAO
    {
        public static ISet<Categoria> Categorias { get; private set; }

        public CategoriasDAO()
        {
            Categorias = new HashSet<Categoria>();
        }

        public static void Salvar(Categoria novaCategoria)
        {
            if (!Buscar(novaCategoria))
            {
                Categorias.Add(novaCategoria);
                Console.WriteLine($"Categoria {novaCategoria.Nome} criada com sucesso!");
                return;
            }
            throw new ArgumentException($"Categoria {novaCategoria.Nome} já existe!");
        }

        public static bool Buscar(Categoria novaCategoria)
        {
            return Categorias.Contains(novaCategoria);
        }
    }
}
