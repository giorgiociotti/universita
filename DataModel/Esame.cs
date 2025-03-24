using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModels
{
    internal class Esame
    {
        internal int ID { get; set; }
        internal Docente Docente { get; set; }
        internal Facolta Facolta { get; set; }
        internal string NomeEsame { get; set; }
        internal DateTime Data { get; set; }
        internal List<Studente> Studenti { get; set; } = [];

        public Esame(int iD, Docente docente, Facolta facolta, string nomeEsame, DateTime data)
        {
            ID = iD;
            Docente = docente;
            Facolta = facolta;
            NomeEsame = nomeEsame;
            Data = data;
        }
    }
}
