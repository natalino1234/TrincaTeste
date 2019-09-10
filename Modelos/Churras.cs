using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Churras
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public double ValorParticipante { get; set; }
        public bool BebidaNoValor { get; set; }

        public Churras(int id, string nome, DateTime data, double valorParticipante, bool bebidaNoValor)
        {
            Id = id;
            Nome = nome;
            Data = data;
            ValorParticipante = valorParticipante;
            BebidaNoValor = bebidaNoValor;
        }
    }
}
