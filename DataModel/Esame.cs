using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModel
{
    internal class Esame
    {
        internal int ID { get; set; }
        internal Docente Docente { get; set; }
        internal Facolta Facolta { get; set; }
        internal string NomeEsame { get; set; }
        internal DateTime Data { get; set; }
    }

}
