using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossaCasaDoCodigo.Testes
{
    public static class TeoriasInvalidasHelper
    {
        public static IEnumerable<object[]> TeoriasInvalidasISBN
        {
            get
            {
                return new[]
                {
                    new object[]{"Titulo Novo", LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "xxx-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{"Titulo Novo", LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "Um ISBN qualquer",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{"Titulo Novo", LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 }
                };
            }
        }

        public static IEnumerable<object[]> TeoriasInvalidasTitulo
        {
            get
            {
                return new[]
                {
                    new object[]{"", LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{null, LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 }
                };
            }
        }

        public static IEnumerable<object[]> TeoriasInvalidasResumo
        {
            get
            {
                return new[]
                {
                    new object[]{"Titulo Novo", null, "Teste", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{"Titulo Novo", "", "Teste", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 }
                };
            }
        }

        public static IEnumerable<object[]> TeoriasInvalidasSumario
        {
            get
            {
                return new[]
                {
                    new object[]{"Titulo Novo", LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, null, 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{"Titulo Novo", LivrosHelpers.RESUMO_COM_MAIS_DE_500_CARACTERES, "", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 }
                };
            }
        }
    }
}