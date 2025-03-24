using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        internal Docente()
        {
            ID = string.Empty;
            Nome = string.Empty;
            Cognome = string.Empty;
            Eta = 0;
            Address = string.Empty;
            Genere = MainEnumerators.Genere.None;
        }
        internal Docente(string id, string nome, string cognome, int eta, string address, MainEnumerators.Genere genere)
        {
            ID = id;
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
            Address = address;
            Genere = genere;
        }
        internal void Print()
        {
            Console.WriteLine($"Id: {ID,-7} Nome: {Nome,-10} Cognome: {Cognome,-15}Età: {Eta,-5}Indirizzo: {Address,-25}Genere: {Genere,-5}");

        }
        public class DocenteManager
        {
            private readonly string _filePath;
            private List<Docente> _docenti; // Mantieni i dati in memoria

            public string ID { get; private set; }

            public DocenteManager(string filePath)
            {
                _filePath = filePath;
                _docenti = LeggiDocenti(); // Carica i dati all'avvio
            }
            // Crea una nuova persona
            internal void CreaDocente(Docente docente)
            {
                int nuovoID = OttieniNuovoId();
                docente.ID = nuovoID.ToString(); // Convertito int a string
                _docenti.Add(docente);
                SovrascriviFile();
            }

            // Legge tutte le persone
            internal List<Docente> LeggiDocenti()
            {
                List<Docente> docenti = new List<Docente>();

                if (File.Exists(_filePath))
                {
                    using (StreamReader sr = new StreamReader(_filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 5)
                            {
                                Docente docente = new()
                                {
                                    ID = parts[0],
                                    Nome = parts[1],
                                    Cognome = parts[2],
                                    Eta = int.TryParse(parts[3], out int eta) ? eta : 0,
                                    Address = parts[4]
                                };
                                docenti.Add(docente);
                            }
                        }
                    }
                }

                return docenti;
            }

            // Aggiorna una persona esistente
            internal void AggiornaDocenti(Docente docente)
            {
                int index = _docenti.FindIndex(p => p.ID == docente.ID);

                if (index != -1)
                {
                    _docenti[index] = docente;
                    SovrascriviFile();
                }
            }

            // Elimina una persona
            public void EliminaDocente(string id)
            {
                _docenti.RemoveAll(p => p.ID == id);
                SovrascriviFile();
            }

            // Metodi di supporto
            private int OttieniNuovoId()
            {
                if (_docenti.Count == 0)
                {
                    return 1;
                }
                else
                {
                    return _docenti.Max(p => int.Parse(p.ID)) + 1;
                }
            }

            private void SovrascriviFile()
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    foreach (Docente docente in _docenti)
                    {
                        sw.WriteLine($"{docente.ID},{docente.Nome},{docente.Cognome},{docente.Eta},{docente.Address}");
                    }
                }
            }
        }
    }
}

