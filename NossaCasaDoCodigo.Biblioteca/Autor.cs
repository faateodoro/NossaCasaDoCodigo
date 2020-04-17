using System;
using System.Text.RegularExpressions;

namespace NossaCasaDoCodigo.Biblioteca
{
    public class Autor
    {
        #region Campos
        private string _nome;

        public string Nome
        {
            get { return _nome; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome deve ser informado.");

                _nome = value;
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }

            private set
            {
                if (!ValidaEmail(value))
                    throw new ArgumentException("O formato do e-mail é inválido.");

                _email = value;
            }
        }

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("A descrição não pode ser vazia.");

                if (value.Length > 400)
                    throw new ArgumentException("A descrição não pode ter mais que 400 caracteres.");

                _descricao = value;
            }
        }

        public string DataCadastro { get; }
        #endregion

        public Autor(string nome, string email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;

            DataCadastro = DateTime.Now.ToString();
        }
        
        private bool ValidaEmail(string email)
        {
            Regex expressao = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            return expressao.IsMatch(email);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Autor autor = (Autor)obj;

            return this.Email == autor.Email ;
        }
    }
}
