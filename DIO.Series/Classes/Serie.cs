using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private int Id { get; set; }
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id,Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            //O comando Enviroment.NewLine quebra uma linha independente do SO que esteja rodando.
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;            
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + Excluido;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}
