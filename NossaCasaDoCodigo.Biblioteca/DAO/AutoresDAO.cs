using System;
using System.Collections.Generic;

namespace NossaCasaDoCodigo.Biblioteca.DAO
{
    public class AutoresDAO
    {
        public AutoresDAO()
        {
            Autores = new HashSet<Autor>();
        }

        public static ISet<Autor> Autores { get; private set; }


        public static void Salvar(Autor novoAutor)
        {
            if (Autores.Contains(novoAutor))
                throw new ArgumentException($"Autor {novoAutor.Nome} já existe!");
            
            Autores.Add(novoAutor);
            Console.WriteLine($"Autor {novoAutor.Nome} foi cadastrado com sucesso!");
        }
    }
}
