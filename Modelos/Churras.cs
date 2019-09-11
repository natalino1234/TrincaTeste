using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Churras
    {
        public int Id { get; set; }
        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Observacoes { get; set; }
        public DateTime Data { get; set; }
        public double ValorParticipante { get; set; }
        public bool BebidaIncluida { get; set; }
        public List<ChurrasParticipante> participantes { get; set; }

        public Churras(int id, int id_usuario, string nome, string observacoes, DateTime data, double valorParticipante, bool bebidaIncluida)
        {
            Id = id;
            Id_usuario = id_usuario;
            Nome = nome;
            Observacoes = observacoes;
            Data = data;
            ValorParticipante = valorParticipante;
            BebidaIncluida = bebidaIncluida;
        }
        public Churras(string nome, string observacoes, DateTime data, double valorParticipante, bool bebidaIncluida)
        {
            Nome = nome;
            Observacoes = observacoes;
            Data = data;
            ValorParticipante = valorParticipante;
            BebidaIncluida = bebidaIncluida;
        }
    }
}
