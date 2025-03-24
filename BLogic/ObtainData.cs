using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Università.DataModels;

namespace Università.BLogic
{
    internal static class ObtainData
    {        
        //Ottiene da tastiera i dati di un docente
        internal static Docente OttieniDocente()
        {
            Docente docente = new Docente();
            Console.WriteLine("Inserisci l'ID del docente:");
            docente.Id = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del docente:");
            docente.Nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del docente:");
            docente.Cognome = Console.ReadLine();
            Console.WriteLine("Inserisci l'età del docente:");
            docente.Eta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci l'indirizzo del docente:");
            docente.Address = Console.ReadLine();
            Console.WriteLine("Inserisci il genere 1.Maschio 2.Femmina 3.Altro:");
            docente.Genere = (MainEnumerators.Genere)Enum.Parse(typeof(MainEnumerators.Genere), Console.ReadLine());
            return docente;
        }
        //Ottiene da tastiera i dati di uno studente
        internal static Studente OttieniStudente()
        {
            Studente studente = new Studente();
            Console.WriteLine("Inserisci la matricola dello studente:");
            studente.Matricola = Console.ReadLine();
            Console.WriteLine("Inserisci il nome dello studente:");
            studente.Nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome dello studente:");
            studente.Cognome = Console.ReadLine();
            Console.WriteLine("Inserisci l'età dello studente:");
            studente.Eta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci l'indirizzo dello studente:");
            studente.Address = Console.ReadLine();
            Console.WriteLine("Inserisci il genere 1.Maschio 2.Femmina 3.Altro:");
            studente.Genere = (MainEnumerators.Genere)Enum.Parse(typeof(MainEnumerators.Genere), Console.ReadLine());
            return studente;
        }

        //Ottiene lista studenti da file
        internal static void OttieniListaStudenteFile()
        {
            
            try
            {
                string[] stringsStudenti = File.ReadAllLines(ConfigParams.StudentiFileName);
                Universita.Studenti.Clear();
                foreach (string se in stringsStudenti)
                {
                    string[] fields = se.Split(';');
                    Universita.Studenti.Add(new Studente
                    {
                        Matricola = fields[0],
                        Nome = fields[1],
                        Cognome = fields[2],
                        Eta = Convert.ToInt32(fields[3]),
                        Address = fields[4],
                        Genere = (MainEnumerators.Genere)Enum.Parse(typeof(MainEnumerators.Genere), fields[5])
                    });
                }
            }
            catch (Exception ex)
            {

                Log.Error("Errore lettura file studenti. Errore: "+ex.Message);
            }
        }

        //Ottiene lista docenti da file
        internal static void OttieniListaDocenteFile()
        {
            try
            {
                string[] stringsDocenti = File.ReadAllLines(ConfigParams.DocentiFileName);
                Universita.Docenti.Clear();
                foreach (string se in stringsDocenti)
                {
                    string[] fields = se.Split(';');
                    Universita.Docenti.Add(new Docente
                    {
                        Id = fields[0],
                        Nome = fields[1],
                        Cognome = fields[2],
                        Eta = Convert.ToInt32(fields[3]),
                        Address = fields[4],
                        Genere = (MainEnumerators.Genere)Enum.Parse(typeof(MainEnumerators.Genere), fields[5])
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error("Errore lettura file docenti. Errore: " + ex.Message);
            }
        }

        //Salva lista studenti su file
        internal static void SalvaListaStudentiFile()
        {
            try
            {
                List<string> stringsStudenti = new List<string>();
                foreach (Studente se in Universita.Studenti)
                {
                    stringsStudenti.Add(se.Matricola + ";" + se.Nome + ";" + se.Cognome + ";" + se.Eta + ";" + se.Address + ";" + se.Genere);                    
                }

                File.AppendAllLines(ConfigParams.StudentiFileName, stringsStudenti);
            }
            catch (Exception ex)
            {
                Log.Error("Errore scrittura file studenti. Errore: " + ex.Message);
            }
        }

        //Salva lista docenti su file
        internal static void SalvaListaDocentiFile()
        {
            try
            {
                List<string> stringsDocenti = new List<string>();
                foreach (Docente se in Universita.Docenti)
                {
                    stringsDocenti.Add(se.Id + ";" + se.Nome + ";" + se.Cognome + ";" + se.Eta + ";" + se.Address + ";" + se.Genere);
                }
                File.AppendAllLines(ConfigParams.DocentiFileName, stringsDocenti);
            }
            catch (Exception ex)
            {
                Log.Error("Errore scrittura file docenti. Errore: " + ex.Message);
            }
        }
    }
}
