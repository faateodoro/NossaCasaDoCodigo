using System;
using System.Text.RegularExpressions;

namespace NossaCasaDoCodigo.Biblioteca
{
    public class Autor
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome deve ser informado.");
                else
                    _nome = value; 
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            private set
            {
                _email = ValidaEmail(value);
            }
        }

        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A descrição não pode ser vazia.");
                else if (value.Length > 400)
                    throw new ArgumentException("A descrição não pode ter mais que 400 caracteres.");
                else
                    _descricao = value; 
            }
        }

        public string DataCadastro { get; }

        public Autor(string nome, string email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;

            DataCadastro = DateTime.Now.ToString();
        }

        private string ValidaEmail(string email)
        {
            Regex expressao = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!expressao.IsMatch(email))
                throw new ArgumentException("O formato do e-mail é inválido.");
            else
                return email;
        }
    }
}
