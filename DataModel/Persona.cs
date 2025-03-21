using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModel
{
    internal abstract class Persona
    {
        public abstract string Nome { get; set; }
        public abstract string Cognome { get; set; }
        public abstract int Eta { get; set; }
        public abstract string Address { get; set; }

        public abstract MainEnumerators.Genere Genere { get; set; }
    }
}
