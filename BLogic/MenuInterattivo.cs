using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Università.DataModels;
using static Università.DataModels.Docente;

namespace Università.BLogic
{
    internal static class MenuInterattivo
    {

        internal static void Iniziamo()
        {
            bool continua = true;
            while (continua)
            {
                Console.Clear();
                Console.WriteLine("====== Menu Iniziale ======");
                Console.WriteLine("1) Esplora la facoltà");
                Console.WriteLine("2) Menu studente");
                Console.WriteLine("3) Menu docente");
                Console.WriteLine("4) Esci");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        EsploraUni();
                        break;
                    case "2":
                        MenuStudente();
                        break;
                    case "3":
                        MenuDocente();
                        break;
                    case "4":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
        }

        private static void EsploraUni()
        {
            Console.Clear();
            Console.WriteLine("====== Esplora Università ======");
            if (Universita.Facolta== null || Universita.Facolta.Count == 0)
            {
                Console.WriteLine("Nessuna facolta presente");
            }
            else
            {
                foreach (var facolta in Universita.Facolta)
                {
                    Console.WriteLine($"Facolta : {facolta.Nome} Tipo:{facolta.Tipo} Laboratorio? {facolta.Lab} Orari: {facolta.OrarioApertura}-{facolta.OrarioChiusura}");

                    if (facolta.Docenti == null || facolta.Docenti.Count == 0)
                        Console.WriteLine("Nessun docente registrato");
                    else
                    {
                        Console.WriteLine("Docenti:");
                        foreach (var docente in facolta.Docenti)
                        {
                            Console.WriteLine($"- {docente.ID}, {docente.Nome} {docente.Cognome}, {docente.Genere}, {docente.Eta}, {docente.Facolta}, {docente.Facolta2}, {docente.Address}");
                        }
                    }

                    if (facolta.Studenti == null || facolta.Studenti.Count == 0)
                        Console.WriteLine("Nessuno studente registrato nella facolta");
                    else
                    {
                        Console.WriteLine("\nStudenti: ");
                        foreach (var studente in facolta.Studenti)
                        {
                            Console.WriteLine($"- {studente.Matricola}, {studente.Nome} {studente.Cognome}, {studente.Genere}, {studente.Eta}, {studente.Facolta}, {studente.Address}");
                        }
                    }

                    Console.WriteLine("--------------------------------------------------------------------");
                }
            }
            
            
            //foreach (var facolta in Universita.Facolta)
            //{
            //    Console.WriteLine($"Facoltà: {facolta.Nome}");
            //    Console.WriteLine("Docenti:");
            //    foreach (var docente in facolta.Docenti)
            //    {
            //        Console.WriteLine($"- {docente.Nome} {docente.Cognome}");
            //    }

            //    Console.WriteLine("Studenti:");
            //    foreach (var studente in facolta.Studenti)
            //    {
            //        Console.WriteLine($"- {studente.Nome} {studente.Cognome}");
            //    }

            //    Console.WriteLine();
            //}

            Console.WriteLine("Premi un tasto per tornare al menu principale...");
            Console.ReadKey();
        }
        

        //private static void IscrizioneCorso()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Inserire matricola dello studente");
        //    string matricola = Console.ReadLine();

        //    Studente studente = Universita.Studenti.FirstOrDefault(s => s.Matricola == matricola);

        //    if (studente == null)
        //    {
        //        Console.WriteLine("Studente non trovato");
        //        Console.ReadKey();
        //        return;
        //    }

        //    Console.WriteLine($"Inserisci il nome del corso");
        //    string corso = Console.ReadLine();

        //    studente.IscrizioneCorso(corso);

        //    Console.WriteLine($"Studente {studente.Nome} iscritto al corso di {corso}");
        //    Console.ReadKey();
        //}
        

        private static void MenuStudente()
        {
            
            bool continua = true;

            while (continua)
            {
                Console.Clear();
                Console.WriteLine("====== Menu Studente ======");
                Console.WriteLine("1) Iscriviti");                
                Console.WriteLine("5) Torna al menu principale");

                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":                        
                        Studente.InsertStudent(ObtainData.OttieniStudente());
                        break;                    
                    case "5":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
        }

        /*  **************************  */

        private static void MenuDocente()
        {
            bool continua = true;
            while (continua)
            {
                Console.Clear();
                Console.WriteLine("====== Menu Docente ======");
                Console.WriteLine("1) Crea Profilo Docente");
                Console.WriteLine("3) Pubblica un esame");
                Console.WriteLine("4) Controlla il tuo planning orario");
                Console.WriteLine("5) Prenota un aula");
                Console.WriteLine("6) Visualizza tutti i studenti");
                Console.WriteLine("7) Visualizza tutti i professori");
                Console.WriteLine("8) Torna al menu Principale");

                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        DocenteManager.CreaDocente(ObtainData.OttieniDocente());
                        break;                    
                    case "3":
                        PubblicaEsame();
                        break;
                    case "4":
                        PlanningDocente();
                        break;
                    case "5":
                        PrenotaAula();
                        break;
                    case "6":
                        Studente.PrintStudents();
                        Console.ReadLine();
                        break;
                    case "7":
                        DocenteManager.PrintDocenti();
                        Console.ReadLine();
                        break;
                    case "8":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
        }        

        internal static void PubblicaEsame()
        {
            Console.Clear();
            Console.WriteLine("====== Pubblica Esame ======");

            Console.WriteLine("Inserisci il nome del corso ");
            string nomeCorso = Console.ReadLine();

            Console.WriteLine("Inserisci la data prevista per l'esame in formato (gg/mm/aaaa)");
            DateTime dateEsame;

            while (!DateTime.TryParse(Console.ReadLine(), out dateEsame))
            {
                Console.WriteLine("Formato data non valido, formato corretto : (gg/mm/aaaa)");
            }

            Console.WriteLine($"Esame di {nomeCorso} pubblicato per il {dateEsame.ToShortDateString()}!");
            Console.ReadKey();
        }

        internal static void PlanningDocente()
        {
            Console.Clear();
            Console.WriteLine("=========== Planning Docente ===========");

            Console.WriteLine("inserisci il tuo nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome");
            string cognome = Console.ReadLine();


            Docente docente = Universita.Docenti.FirstOrDefault(d => d.Nome == nome && d.Cognome == cognome);

            if (docente == null)
            {
                Console.WriteLine("Docente non trovato ");
                Console.ReadKey();
                return;
            }

            bool continua = true;
            while (continua)
            {
                Console.Clear();
                Console.WriteLine($"=== Planning di {docente.Nome} {docente.Cognome} ===");
                Console.WriteLine("1) Aggiungi un evento al planning");
                Console.WriteLine("2) Visualizza il planning");
                Console.WriteLine("3) Torna al menu precedente");


                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        AggiungiEvento(docente);
                        break;
                    case "2":
                        VisualizzaPlanning(docente);
                        break;
                    case "3":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            }
        }

        internal static void AggiungiEvento(Docente docente)
        {
            
            Console.Clear();
            Console.WriteLine("=========== Aggiungi Evento ==========");

            Console.WriteLine("Inserisci una facoltà");
            MainEnumerators.Facolta facoltaStr = (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), Console.ReadLine());
            Facolta facolta = Universita.Facolta.Find(f => f.Nome == facoltaStr);

            Console.WriteLine("Inserisci nome aula");
            string aula = Console.ReadLine();

            Console.WriteLine("Inserisci nome attività");
            MainEnumerators.TipoAttivita attivita = (MainEnumerators.TipoAttivita)Enum.Parse(typeof(MainEnumerators.TipoAttivita), Console.ReadLine());

            Console.WriteLine("Inserisci la data e l'ora dell'evento (gg/mm/aaaa hh:mm:ss)");
            DateTime dataOra;

            while (!DateTime.TryParse(Console.ReadLine(), out dataOra))
            {
                Console.WriteLine("Formato data non valido, formato corretto :");
            }
            

            facolta.Calendario.Add(new EventoPlanning(facolta,aula,attivita,dataOra));
            ObtainData.SalvaCalendarioFile(facolta);
        }

        internal static void VisualizzaPlanning(Docente docente)
        {
            Console.Clear();
            Console.WriteLine($"Panning di {docente.Nome} {docente.Cognome}");

            if (docente.Planning.Count == 0)
            {
                Console.WriteLine("Nessun Planning dispobibile");
            }
            else
            {
                foreach (var evento in docente.Planning.OrderBy(e => e.DataOra))
                {
                    Console.WriteLine(evento);
                }
            }

            Console.WriteLine("\nPremi un tasto per tornare indietro");
            Console.ReadKey();
        }

        internal static void PrenotaAula()
        {
            Console.Clear();
            Console.WriteLine("====== Prenota un'Aula ======");
            Console.WriteLine("Aule disponibili:");
            foreach (var facolta in Universita.Facolta)
            {
                Console.WriteLine("Aule facoltà di " +facolta.Nome+":");                
                foreach (var item in facolta.Aule)
                {
                    Console.Write(item+"   ");
                    
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("Inserisci il nome dell'aula: ");
            string aula = Console.ReadLine();

            Console.WriteLine("Inserisci la data della prenotazione dell'aula (gg/mm/aaaa): ");
            DateTime datePrenotazione;

            while (!DateTime.TryParse(Console.ReadLine(), out datePrenotazione))
            {
                Console.WriteLine("Formato data della prenotazione dell'aula non valido ");
            }

            Console.WriteLine($"Hai prenotato l'aula {aula} il {datePrenotazione.ToShortDateString()}");
            Console.ReadKey();
        }
    }
}