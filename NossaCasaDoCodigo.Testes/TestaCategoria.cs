﻿using NossaCasaDoCodigo.Biblioteca;
using NossaCasaDoCodigo.Biblioteca.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NossaCasaDoCodigo.Testes
{
    public class TestaCategoria
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeDaCategoriaNaoPodeSerVazioOuNulo(string nome)
        {
            Assert.Throws<ArgumentNullException>(() => new Categoria(nome));
        }

        [Fact]
        public void NomeDaCategoriaDeveSerUnico()
        {
            CriaCategoriaDAO();

            var novaCategoria = new Categoria("Testes");

            Assert.Equal($"Falha ao salvar. A categoria {novaCategoria.Nome} já existe.",
                CategoriasDAO.SalvaCategoria(novaCategoria));
        }

        [Fact]
        public void CategoriaCriadaDeveMostrarMensagem()
        {
            CriaCategoriaDAO();

            var novaCategoria = new Categoria("Programação");

            Assert.Equal($"Categoria {novaCategoria.Nome} criada com sucesso!",
                CategoriasDAO.SalvaCategoria(novaCategoria));
        }

        [Fact]
        public void CategoriaCadastradaDeveTerMomentoDeCriação()
        {
            var categoria = new Categoria("Gestão");
            Assert.False(string.IsNullOrEmpty(categoria.DataCadastro));
        }
        
        private static void CriaCategoriaDAO()
        {
            new CategoriasDAO();
            CategoriasDAO.SalvaCategoria(new Categoria("Design"));
            CategoriasDAO.SalvaCategoria(new Categoria("Marketing Digital"));
            CategoriasDAO.SalvaCategoria(new Categoria("Testes"));
        }
    }
}