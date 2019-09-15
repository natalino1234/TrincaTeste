using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class ChurrasParticipante
    {
        public int Id { get; set; }
        public int Id_churras { get; set; }
        public string Nome_participante { get; set; }
        public bool Pago { get; set; }

        public ChurrasParticipante(int id, int id_churras, string nome_participante, bool pago)
        {
            Id = id;
            Id_churras = id_churras;
            Nome_participante = nome_participante;
            Pago = pago;
        }

        public ChurrasParticipante(int id_churras, string nome_participante, bool pago)
        {
            Id_churras = id_churras;
            Nome_participante = nome_participante;
            Pago = pago;
        }
    }
}
