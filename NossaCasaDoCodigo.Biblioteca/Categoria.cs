using System;
using System.Collections.Generic;
using System.Text;

namespace NossaCasaDoCodigo.Biblioteca
{
    public class Categoria
    {
        public Categoria(string nome)
        {
            Nome = nome;
            DataCadastro = DateTime.Now.ToString();
        }

        public string DataCadastro { get; }

        private string _nome;
        public string Nome 
        {
            get
            {
                return _nome;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("O nome da categoria não pode ser vazio ou nulo.");
                _nome = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Categoria categoria = (Categoria) obj;

            return this.Nome == categoria.Nome;
        }

        public override int GetHashCode()
        {
            return Nome.GetHashCode();
        }
    }
}
