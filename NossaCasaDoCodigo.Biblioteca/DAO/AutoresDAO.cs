using System;
using System.Collections.Generic;
using System.Text;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class AutoresDAO
    {
        public AutoresDAO()
        {
            Autores = new List<Autor>();
        }

        private static IList<Autor> Autores { get; set; }

        public static void Salvar(Autor novoAutor)
        {
            if (Autores.Contains(novoAutor))
            {
                throw new ArgumentException("Email já existente!");
            }
            Autores.Add(new Autor(novoAutor.Nome, novoAutor.Email, novoAutor.Descricao));
        }
    }
}
