using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModels
{
    internal class EventoPlanning
    {
        internal Facolta Facolta { get; set; }
        internal string NomeAula { get; set; }
        internal MainEnumerators.TipoAttivita Attivita  { get; set; }
        internal DateTime DataOra { get; set; }

        public EventoPlanning(Facolta facolta, string nomeAula, MainEnumerators.TipoAttivita attivita, DateTime dataOra)
        {
            Facolta = facolta;
            NomeAula = nomeAula;
            Attivita = attivita;
            DataOra = dataOra;
        }

        public EventoPlanning()
        {
        }

        internal string Stampa()
        {
            return $"{Facolta} - Aula: {NomeAula} - {Attivita} - {DataOra}";
        }

    }
}
