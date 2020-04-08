using System;
using System.Collections.Generic;
using System.Text;

namespace NossaCasaDoCodigo.Biblioteca
{
    public class AutoresDAO
    {
        public AutoresDAO()
        {
        }

        public static IList<Autor> Autores { get; set; }

        public static bool SalvaAutor(Autor novoAutor)
        {
            if (Autores == null)
            {
                Autores = new List<Autor>();
            }

            if (Autores.Count > 0)
            {
                foreach (var autor in Autores)
                {
                    if (novoAutor.Email == autor.Email)
                    {
                        throw new ArgumentException("Email já existente!");
                    }
                }
            }

            Autores.Add(new Autor(novoAutor.Nome, novoAutor.Email, novoAutor.Descricao));
            return true;
        }
    }
}
