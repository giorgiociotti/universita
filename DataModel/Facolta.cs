using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModels
{
    internal class Facolta
    {
        internal MainEnumerators.Facolta Nome{ get; set; }
        internal MainEnumerators.TipoCorso Tipo { get; set; }
        internal DateTime Orario { get; set; }
        internal bool Lab {  get; set; }
        internal List<Esame> Esami { get; set; } = [];
        

        internal Facolta(MainEnumerators.Facolta nome, MainEnumerators.TipoCorso tipo, DateTime orario, bool lab)
        {
            Nome = nome;
            Tipo = tipo;
            Orario = orario;
            Lab = lab;
        }
        internal Facolta()
        {
            Nome = MainEnumerators.Facolta.None;
            Tipo = MainEnumerators.TipoCorso.None;
            Orario = DateTime.MinValue;
            Lab = false;
        }
    }
}
