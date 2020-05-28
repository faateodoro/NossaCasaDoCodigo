using NossaCasaDoCodigo.Biblioteca;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossaCasaDoCodigo.Testes
{
    public static class TeoriasInvalidasHelper
    {
        public const string RESUMO_COM_MAIS_DE_500_CARACTERES =
            "Mussum Ipsum, cacilds vidis litro abertis. Sapien in monti palavris qui num " +
            "significa nadis i pareci latim. Tá deprimidis, eu conheço uma cachacis que pode alegrar " +
            "sua vidis. Suco de cevadiss deixa as pessoas mais interessantis. Nullam volutpat risus nec" +
            " leo commodo, ut interdum diam laoreet. Sed non consequat odio. " +
            "Quem manda na minha terra sou euzis! Mé faiz elementum girarzis, nisi eros vermeio." +
            "Suco de cevadiss, é um leite divinis, qui tem lupuliz, matis, aguis e fermentis. " +
            "Si num tem leite então bota uma pinga aí cumpadi!" +
            "Copo furadis é disculpa de bebadis, arcu quam euismod magna.";

        public static IEnumerable<object[]> TeoriasInvalidasISBN
        {
            get
            {
                return new[]
                {
                    new object[]{"Titulo Novo", RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "xxx-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{"Titulo Novo", RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "Um ISBN qualquer",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{"Titulo Novo", RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "",
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
                    new object[]{"", RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{null, RESUMO_COM_MAIS_DE_500_CARACTERES, "Teste", 20, "978-12-34567-89-0",
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
                    new object[]{"Titulo Novo", RESUMO_COM_MAIS_DE_500_CARACTERES, null, 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 },

                    new object[]{"Titulo Novo", RESUMO_COM_MAIS_DE_500_CARACTERES, "", 20, "978-12-34567-89-0",
                        new Autor("nome", "email@gmail.com", "minha descrição"),new Categoria("categoria"), 2.1, 50.95 }
                };
            }
        }
    }
}