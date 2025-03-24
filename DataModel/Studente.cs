using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Università.BLogic;
using static Università.DataModels.MainEnumerators;

namespace Università.DataModels
{
    internal class Studente : Persona
    {
        [Required]
        [Key]
        [MinLength(5, ErrorMessage = "La matricola deve contenere 5 caratteri!"), MaxLength(5,ErrorMessage ="La matricola deve contenere 5 caratteri!")]
        internal string Matricola { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Il nome deve contenere almeno 2 caratteri!"), MaxLength(20, ErrorMessage = "Il nome deve contenere al massimo 20 caratteri!")]
        internal override string Nome { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Il cognome deve contenere almeno 2 caratteri!"), MaxLength(20, ErrorMessage = "Il cognome deve contenere al massimo 20 caratteri!")]
        internal override string Cognome { get; set; }
        [Required]
        [Range(18, 100, ErrorMessage = "L'età deve essere compresa tra 18 e 100 anni!")]
        internal override int Eta { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "L'indirizzo deve contenere almeno 5 caratteri!"), MaxLength(50, ErrorMessage = "L'indirizzo deve contenere al massimo 50 caratteri!")]
        internal override string Address { get; set; }
        [Required]
        internal override MainEnumerators.Genere Genere { get; set; }
        [Required]
        internal override List<EventoPlanning> Planning { get; set; } = [];
        internal override MainEnumerators.Facolta Facolta { get; set; }

        internal Studente(string matricola, string nome, string cognome, int eta, string address, MainEnumerators.Genere genere, MainEnumerators.Facolta facolta)
        {
            Matricola = matricola;
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
            Address = address;
            Genere = genere;
            Facolta = facolta;
        }
        internal Studente() 
        {
            Matricola = string.Empty;
            Nome = string.Empty;
            Cognome = string.Empty;
            Eta = 0;
            Address = string.Empty;
            Genere = MainEnumerators.Genere.None;
            Facolta = MainEnumerators.Facolta.None;
        }
        internal void Print()
        { 
            Console.WriteLine($"Matricola: {Matricola,-7} Nome: {Nome,-10} Cognome: {Cognome,-15}Età: {Eta,-5}Indirizzo: {Address,-25}Genere: {Genere,-5}Facoltà: {Facolta,-8}");
        }
        internal static bool InsertStudent(Studente studente)
        {
            bool result = false;

            try
            {
                Universita.Studenti.Add(studente);
                result = true;
                ObtainData.SalvaListaStudentiFile();
                ObtainData.OttieniListaStudentiFacolta(TrovaFacolta(studente));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            return result;
        }
        internal static Facolta TrovaFacolta(Studente studente)
        {
            return Universita.Facolta[Universita.Facolta.FindIndex(f => f.Nome == studente.Facolta)];
        }

        public static bool DeleteStudent(string matricola)
        {
            bool result = false;

            try
            {
                Studente? studente = Universita.Studenti.Find(e => e.Matricola == matricola);

                if (studente != null)
                {
                    ObtainData.RimuoviDaListaStudentiFacolta(TrovaFacolta(studente), studente);
                    Universita.Studenti.Remove(studente);
                    result = true;
                    ObtainData.SalvaListaStudentiFile();                    
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return result;
        }

        internal static void PrintStudents()
        {
            foreach (Studente studente in Universita.Studenti)
            {
                Console.WriteLine($"- {studente.Matricola}, {studente.Nome} {studente.Cognome}, {studente.Genere}, {studente.Eta}, {studente.Facolta}, {studente.Address}");
            }
        }

    }
}
