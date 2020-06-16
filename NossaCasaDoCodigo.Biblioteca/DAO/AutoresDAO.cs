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

        public static string Salvar(Autor novoAutor)
        {
            if (Autores.Contains(novoAutor))
            {
                return $"Falha ao salvar. O email {novoAutor.Email} já existe.";
            }

            Autores.Add(new Autor(novoAutor.Nome, novoAutor.Email, novoAutor.Descricao));
            return $"Autor {novoAutor.Nome} foi cadastrado com sucesso!";
        }
    }
}
