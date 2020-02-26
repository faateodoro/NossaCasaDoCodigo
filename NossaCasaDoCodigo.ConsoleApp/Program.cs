using NossaCasaDoCodigo.Biblioteca;
using System;
using System.Collections.Generic;

namespace NossaCasaDoCodigo.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IList<Autor> autores = new List<Autor>();

            autores.Add(new Autor("Fabiano", "fabiano@gmail.com", "Um cara iniciando na carrera de TI."));
            autores.Add(new Autor("Ana", "ana@gmail.com", "Uma moça pensando em que carreira seguir."));
            autores.Add(new Autor("Clara", "clara@alura.com.br", "Uma menininha linda!"));

            foreach (var autor in autores)
            {
                Console.WriteLine($"Nome: {autor.Nome}");
                Console.WriteLine($"Email: {autor.Email}");
                Console.WriteLine($"Descrição: {autor.Descricao}");
                Console.WriteLine($"Cadastro desde: {string.Format(autor.DataCadastro, "dd/MM/yyyy HH:ii:ss")}");

                Console.WriteLine("\n=================================================\n\n");
            }
            
            Console.ReadKey();
        }
    }
}
