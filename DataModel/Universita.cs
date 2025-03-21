using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModel
{
    internal class Universita
    {
        internal List<Facolta> Facolta { get; set; } = new List<Facolta>();
        internal List<Docente> Docenti { get; set; } = new List<Docente>();
        internal List<Studente> Studenti { get; set; } = new List<Studente>();
        internal string Nome { get; set; }
    }
}
