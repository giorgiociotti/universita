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
        internal Docente(string Id, string nome, string cognome, int eta, string address, MainEnumerators.Genere genere)
        {
            Id = Id;
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
            Address = address;
            Genere = genere;
        }
        internal Docente() { }
    }
}

