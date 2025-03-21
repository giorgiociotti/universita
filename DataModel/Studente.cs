using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.DataModel
{
    internal class Studente : Persona
    {
        public string Matricola { get; set; }
        public override string Nome { get; set; }
        public override string Cognome { get; set; }
        public override int Eta { get; set; }
        public override string Address { get; set; }
        public override MainEnumerators.Genere Genere { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        internal Studente(string matricola, string nome, string cognome, int eta, string address, MainEnumerators.Genere genere)
        {
            Matricola = matricola;
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
            Address = address;
            Genere = genere;
        }
        internal Studente()
        {
            Matricola = string.Empty;
            Nome = string.Empty;
            Cognome = string.Empty;
            Eta = 0;
            Address = string.Empty;
            Genere = MainEnumerators.Genere.None;
        }

        internal static List<Studente> studenti = new List<Studente>();

        internal static void CreateStudente(Studente studente)
        {
            studenti.Add(studente);
        }

        internal static Studente ReadStudente(string matricola)
        {
            return studenti.FirstOrDefault(s => s.Matricola == matricola);

        }

        /*internal static void UpdateStudente(string matricola, Studente updatedStudente)
        {
            var studente = studenti.FirstOrDefault(s => s.Matricola == matricola);
            if (studente != null)
            {
                studente.Nome = updatedStudente.Nome;
                studente.Cognome = updatedStudente.Cognome;
                studente.Eta = updatedStudente.Eta;
                studente.Address = updatedStudente.Address;
            }
        }*/

        internal static void DeleteStudente(string matricola)
        {
            var studente = studenti.FirstOrDefault(s => s.Matricola == matricola);
            if (studente != null)
            {
                studenti.Remove(studente);
            }
        }
    }
}
