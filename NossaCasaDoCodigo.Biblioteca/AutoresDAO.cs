using System;
using System.Collections.Generic;
using System.Text;

namespace NossaCasaDoCodigo.Biblioteca
{
    public class AutoresDAO
    {
        public AutoresDAO()
        {
            Autores = new List<Autor>();
        }

        private static IList<Autor> Autores { get; set; }

        public static void SalvaAutor(Autor novoAutor)
        {
            if(ComparaEmail(novoAutor.Email))
                Autores.Add(new Autor(novoAutor.Nome, novoAutor.Email, novoAutor.Descricao));
        }

        private static bool ComparaEmail(string email)
        {
            if (Autores.Count > 0)
            {
                foreach (var autor in Autores)
                {
                    if (email == autor.Email)
                    {
                        throw new ArgumentException("Email já existente!");
                    }
                }
            }
            return true;
        }
    }
}
