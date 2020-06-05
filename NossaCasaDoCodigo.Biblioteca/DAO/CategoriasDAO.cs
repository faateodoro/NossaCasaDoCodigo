using System;
using System.Collections.Generic;
using System.Text;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class CategoriasDAO
    {
        private static IList<Categoria> Categorias { get; set; }

        public CategoriasDAO()
        {
            Categorias = new List<Categoria>();
        }

        public static string Salvar(Categoria novaCategoria)
        {
            if (Categorias.Contains(novaCategoria))
            {
                return $"Falha ao salvar. A categoria {novaCategoria.Nome} já existe.";
            }

            Categorias.Add(novaCategoria);
            return $"Categoria {novaCategoria.Nome} criada com sucesso!";
        }
    }
}
