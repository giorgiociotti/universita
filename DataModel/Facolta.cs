using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModel
{

    internal class Facolta
    {
        internal bool Lab { get; set; }
        internal string Nome { get; set; }
        internal string Tipo { get; set; }
        internal DateTime Orario { get; set; }

        internal List<Esame> Esami { get; set; } = new List<Esame>();
        internal List<Studente> Studenti { get; set; } = new List<Studente>();
    }
}

