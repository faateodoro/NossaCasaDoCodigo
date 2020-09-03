using System;
using System.Collections.Generic;
using System.Text;

namespace NossaCasaDoCodigo.Biblioteca.Helpers
{
    public class LivrosHelpers
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

        public static readonly Livro LIVRO1 = new Livro("PHP para baixinhos",
            RESUMO_COM_MAIS_DE_500_CARACTERES, "A arte de ser um sobrinho.", 20, "978-12-34567-89-0",
            new Autor("Rasmus", "rasmus@php.com", "Criador da linguagem PHP."),
            new Categoria("PHP"), 2.0, 35.50m);

        public static readonly Livro LIVRO2 = new Livro("Escrevi este livro e fiquei ryco!",
            RESUMO_COM_MAIS_DE_500_CARACTERES, "Este sumário é bem caro.", 20, "978-12-76543-89-0",
            new Autor("Ricardo Rico", "meuemailcaro@richmail.com", "Muito ryco!"),
            new Categoria("Coach Quântico"), 2.0, 35.50m);

        public static readonly Livro LIVRO3 = new Livro("Seja um coach quântico sem saber o significado de quântico.",
            RESUMO_COM_MAIS_DE_500_CARACTERES, "Sumário quântico", 20, "978-12-34567-09-8",
            new Autor("Enga Nador", "enga.nei@gmail.com", "Comecei enganando cedo."),
            new Categoria("Coach Quântico"), 2.0, 35.50m);

        public static readonly Livro LIVRO4 = new Livro("Seja um coach quântico sem saber o significado de quântico 2.",
            RESUMO_COM_MAIS_DE_500_CARACTERES, "Sumário quântico", 20, "978-12-34559-09-8",
            new Autor("Enga Nador", "enga.nei@gmail.com", "Comecei enganando cedo."), 
            new Categoria("Coach Quântico"), 2.0, 35.50m);

        public static readonly Livro LIVRO5 = new Livro("Quinto livro para testar",
            RESUMO_COM_MAIS_DE_500_CARACTERES, "A arte ser um bom teste", 20, "978-12-96321-89-0",
            new Autor("Carlos Testa", "testa@tudo.com", "Testes é com ele."),
            new Categoria("Testes unitários"), 2.0, 35.50m);
    }
}
