using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppEventos.Models
{
    internal class Evento
    {
        public string NomeDoEvento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroDeParticipante { get; set; }
        public string LocalDoEvento { get; set; }
        public double CustoPorPaciente { get; set; }
        public int DuracaoDoEvento
        {
            get => DataTermino.Subtract(DataInicio).Days;

        }
        public double ValorTotal
        {
            get
            {
                double custo_total_do_evento = NumeroDeParticipante * CustoPorPaciente;

                double total = custo_total_do_evento * DuracaoDoEvento;

                return total;
            }
        }
    }
}
