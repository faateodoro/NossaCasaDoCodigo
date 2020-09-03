using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NossaCasaDoCodigo.Biblioteca
{
    public class Livro
    {
        #region Campos

        private string _titulo;

		public string Titulo
		{
			get
			{
				return _titulo;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Título não deve ser vazio ou nulo.");

				_titulo = value; 
			}
		}

		private string _resumo;

		public string Resumo
		{
			get
			{
				return _resumo;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("O resumo não pode ser vazio ou nulo");

				if (value.Length < 500)
					throw new ArgumentException("O resumo não pode ter menos de 500 caracteres");

				_resumo = value; 
			}
		}

		private string _sumario;

		public string Sumario
		{
			get 
			{
				return _sumario; 
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("O sumário não pode ser vazio ou nulo.");

				_sumario = value; 
			}
		}

		private int _paginas;

		public int Paginas
		{
			get
			{
				return _paginas; 
			}
			set
			{
				if (value < 1)
					throw new ArgumentException("O número de páginas não pode ser menor que 1.");

				_paginas = value; 
			}
		}

		private string _isbn;

		public string ISBN
		{
			get
			{
				return _isbn; 
			}
			set
			{
				if (!VerificaIsbn(value))
					throw new ArgumentException("O ISBN do livro não está dentro do padrão esperado.");

				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("O ISBN não pode ser vazio ou nulo");

				_isbn = value; 
			}
		}

		private bool VerificaIsbn(string value)
		{
			return Regex.IsMatch(value, @"978\-\d{2}\-\d{5}\-\d{2}\-\d");
		}

		private Autor _autor;

		public Autor Autor
		{
			get
			{
				return _autor; 
			}
			set
			{
				_autor = value; 
			}
		}

		private Categoria _categoria;

		public Categoria Categoria
		{
			get
			{
				return _categoria; 
			}
			set
			{
				_categoria = value; 
			}
		}

		private double _edicao;

		public double Edicao
		{
			get 
			{
				return _edicao; 
			}
			set 
			{
				if (value < 1)
					throw new ArgumentException("A edição deve ser ao menos 1.0 ou outro número positivo.");

				_edicao = value; 
			}
		}

		private decimal _preco;

		public decimal Preco
		{
			get 
			{
				return _preco; 
			}
			set 
			{
				if (value < 0)
					throw new ArgumentException("O preço deve ser R$0,00 ou qualquer outro valor positivo");

				_preco = value; 
			}
		}
		
		#endregion

		public Livro(string titulo, string resumo, string sumario, int paginas, string iSBN, 
			Autor autor, Categoria categoria, double edicao, decimal preco)
		{
			Titulo = titulo;
			Resumo = resumo;
			Sumario = sumario;
			Paginas = paginas;
			ISBN = iSBN;
			Autor = autor;
			Categoria = categoria;
			Edicao = edicao;
			Preco = preco;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}

			Livro livro = (Livro)obj;

			return this.Titulo == livro.Titulo;
		}

        public override int GetHashCode()
        {
            return Titulo.GetHashCode();
        }
    }
}
