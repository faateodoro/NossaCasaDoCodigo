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
                _nome = ValidaNome(value);
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
                _descricao = ValidaDescricao(value);
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

        #region Validações
        private string ValidaNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome deve ser informado.");

            return nome;
        }

        private string ValidaDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentNullException("A descrição não pode ser vazia.");
            
            if (descricao.Length > 400)
                throw new ArgumentException("A descrição não pode ter mais que 400 caracteres.");

            return descricao;
        }

        private string ValidaEmail(string email)
        {
            Regex expressao = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!expressao.IsMatch(email))
                throw new ArgumentException("O formato do e-mail é inválido.");
                
            return email;
        }
        #endregion
    }
}
