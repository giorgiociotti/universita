using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Università.BLogic;
using static Università.DataModels.MainEnumerators;

namespace Università.DataModels
{
    internal class Docente : Persona
    {
        [Required]
        [Key]
        [MinLength(5, ErrorMessage = "L'Id deve contenere 5 caratteri!"), MaxLength(5, ErrorMessage = "L'Id deve contenere 5 caratteri!")]
        internal string ID { get; set; }
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
        internal MainEnumerators.Facolta Facolta2 { get; set; }

        internal Docente()
        {
            ID = string.Empty;
            Nome = string.Empty;
            Cognome = string.Empty;
            Eta = 0;
            Address = string.Empty;
            Genere = MainEnumerators.Genere.None;
            Facolta= MainEnumerators.Facolta.None;
            Facolta2 = MainEnumerators.Facolta.None;
        }
        internal Docente(string id, string nome, string cognome, int eta, string address, MainEnumerators.Genere genere, MainEnumerators.Facolta facolta, MainEnumerators.Facolta facolta2)
        {
            ID = id;
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
            Address = address;
            Genere = genere;
            Facolta = facolta;
            Facolta2 = facolta2;
        }
        internal void Print()
        {
            Console.WriteLine($"Id: {ID,-7} Nome: {Nome,-10} Cognome: {Cognome,-15}Età: {Eta,-5}Indirizzo: {Address,-25}Genere: {Genere,-5}Facoltà: {Facolta,-8} Facoltà2: {Facolta2,-8}");

        }
        internal static class DocenteManager
        {            
            
            // Crea una nuova persona
            internal static void CreaDocente(Docente docente)
            {                
                
                Universita.Docenti.Add(docente);
                ObtainData.SalvaListaDocentiFile();
                ObtainData.OttieniListaDocentiFacolta(TrovaFacolta(docente));
            }

            

            // Aggiorna una persona esistente
            internal static void AggiornaDocenti(Docente docente)
            {
                int index = Universita.Docenti.FindIndex(p => p.ID == docente.ID);

                if (index != -1)
                {
                    Universita.Docenti[index] = docente;
                    ObtainData.SalvaListaDocentiFile();
                    ObtainData.OttieniListaDocentiFacolta(TrovaFacolta(docente));
                }
            }

            // Elimina una persona
            internal static void EliminaDocente(string id)
            {
                Docente docente = Universita.Docenti.Find(p => p.ID == id);
                ObtainData.RimuoviDaListaDocentiFacolta(TrovaFacolta(docente),docente);
                Universita.Docenti.RemoveAll(p => p.ID == id);
                ObtainData.SalvaListaDocentiFile();
            }
            
            internal static Facolta TrovaFacolta(Docente docente)
            {
                return Universita.Facolta[Universita.Facolta.FindIndex(f => f.Nome == docente.Facolta)];
            }

            internal static void PrintDocenti()
            {
                Console.WriteLine("Docenti:");
                foreach (var docente in Universita.Docenti)
                {
                    Console.WriteLine($"- {docente.ID}, {docente.Nome} {docente.Cognome}, {docente.Genere}, {docente.Eta}, {docente.Facolta}, {docente.Facolta2}, {docente.Address}");
                }
            }


        }
    }
}

