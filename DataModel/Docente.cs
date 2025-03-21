using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModel
{
    internal class Docente : Persona
    {
        public string Id { get; set; }
        public override string Nome { get; set; }
        public override string Cognome { get; set; }
        public override int Eta { get; set; }
        public override string Address { get; set; }
        public override MainEnumerators.Genere Genere { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        internal Docente()
        {
            Id = string.Empty;
            Nome = string.Empty;
            Cognome = string.Empty;
            Eta = 0;
            Address = string.Empty;
            Genere = MainEnumerators.Genere.None;
        }
        internal Docente(string id, string nome, string cognome, int eta, string address, MainEnumerators.Genere genere)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
            Address = address;
            Genere = genere;
        }

    }
}

