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
            docente.ID = Console.ReadLine();
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
            Console.WriteLine("Inserisci la facoltà 1.Ingegneria 2.Medicina 3.Lettere 4.Economia 5.Scienze");
            docente.Facolta = (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), Console.ReadLine());
            Console.WriteLine("Inserisci la seconda facoltà 0.Nessuna 1.Ingegneria 2.Medicina 3.Lettere 4.Economia 5.Scienze");
            docente.Facolta2 = (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), Console.ReadLine());
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
            Console.WriteLine("Inserisci la facoltà 1.Ingegneria 2.Medicina 3.Lettere 4.Economia 5.Scienze");
            studente.Facolta = (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), Console.ReadLine());
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
                        Genere = (MainEnumerators.Genere)Enum.Parse(typeof(MainEnumerators.Genere), fields[5]),
                        Facolta = (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), fields[6])
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
                        ID = fields[0],
                        Nome = fields[1],
                        Cognome = fields[2],
                        Eta = Convert.ToInt32(fields[3]),
                        Address = fields[4],
                        Genere = (MainEnumerators.Genere)Enum.Parse(typeof(MainEnumerators.Genere), fields[5]),
                        Facolta = (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), fields[6]),
                        Facolta2 = (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), fields[7])

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
                    stringsStudenti.Add(se.Matricola + ";" + se.Nome + ";" + se.Cognome + ";" + se.Eta + ";" + se.Address + ";" + se.Genere+ ";" + se.Facolta);                    
                }

                File.WriteAllLines(ConfigParams.StudentiFileName, stringsStudenti);
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
                    stringsDocenti.Add(se.ID + ";" + se.Nome + ";" + se.Cognome + ";" + se.Eta + ";" + se.Address + ";" + se.Genere + ";" + se.Facolta + ";" + se.Facolta2);
                }
                File.WriteAllLines(ConfigParams.DocentiFileName, stringsDocenti);
            }
            catch (Exception ex)
            {
                Log.Error("Errore scrittura file docenti. Errore: " + ex.Message);
            }
        }

        internal static void OttiniListaFacoltaFile()
        {
            try
            {
                string[] stringsFacolta = File.ReadAllLines(ConfigParams.FacoltaFileName);
                Universita.Facolta.Clear();
                foreach (string se in stringsFacolta)
                {
                    string[] fields = se.Split(';');
                    Universita.Facolta.Add(new Facolta
                    (
                        (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), fields[0]),
                        (MainEnumerators.TipoCorso)Enum.Parse(typeof(MainEnumerators.TipoCorso), fields[1]),
                        TimeOnly.Parse(fields[2]),
                        TimeOnly.Parse(fields[3])
                    ));
                }
            }
            catch (Exception ex)
            {
                Log.Error("Errore lettura file facolta. Errore: " + ex.Message);
            }
        }

        internal static void OttieniListaStudentiFacolta(Facolta facolta)
        {
            
            foreach (var item in Universita.Studenti)
            {
                if (item.Facolta == facolta.Nome)
                    facolta.Studenti.Add(item);
            }
        }

        internal static void OttieniListaDocentiFacolta(Facolta facolta)
        {
            foreach (var item in Universita.Docenti)
            {
                if (item.Facolta == facolta.Nome || item.Facolta2 == facolta.Nome)
                    facolta.Docenti.Add(item);
            }
        }

        internal static void RimuoviDaListaStudentiFacolta(Facolta facolta, Studente studente)
        {
            foreach (var item in Universita.Studenti)
            {
                if (item.Matricola == studente.Matricola)
                    facolta.Studenti.Remove(item);
            }
        }

        internal static void RimuoviDaListaDocentiFacolta(Facolta facolta, Docente docente)
        {
            foreach (var item in Universita.Docenti)
            {
                if (item.ID == docente.ID)
                    facolta.Docenti.Remove(item);
            }
        }

        internal static void OttieniCalendarioFile()
        {
            try
            {
                string[] stringsCalendario = File.ReadAllLines(ConfigParams.CalendarioFileName);
                foreach (var calendari in Universita.Facolta)
                {
                    calendari.Calendario.Clear();
                    foreach (string se in stringsCalendario)
                    {
                        string[] fields = se.Split(';');
                        calendari.Calendario.Add(new EventoPlanning
                        {
                            Facolta = Universita.Facolta[Universita.Facolta.FindIndex(f => f.Nome == (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), fields[0]))],
                            NomeAula = fields[1],
                            Attivita = (MainEnumerators.TipoAttivita)Enum.Parse(typeof(MainEnumerators.TipoAttivita), fields[2]),
                            DataOra = DateTime.Parse(fields[3])
                        });
                    }
                }                
            }
            catch (Exception ex)
            {
                Log.Error("Errore lettura file calendario. Errore: " + ex.Message);
            }
        }

        internal static void SalvaCalendarioFile(Facolta facolta)
        {
            try
            {
                string[] stringsCalendario = File.ReadAllLines(ConfigParams.CalendarioFileName);
                List<EventoPlanning> listAppoggio = [];
                foreach (string s in stringsCalendario)
                {
                    string[] fields = s.Split(';');
                    listAppoggio.Add(new EventoPlanning
                    {
                        Facolta = Universita.Facolta[Universita.Facolta.FindIndex(f => f.Nome == (MainEnumerators.Facolta)Enum.Parse(typeof(MainEnumerators.Facolta), fields[0]))],
                        NomeAula = fields[1],
                        Attivita = (MainEnumerators.TipoAttivita)Enum.Parse(typeof(MainEnumerators.TipoAttivita), fields[2]),
                        DataOra = DateTime.Parse(fields[3])                        
                    });
                }
                List<string> stringhePulite = [];
                foreach (EventoPlanning se in facolta.Calendario)
                {
                    if (listAppoggio.Any(ep => ep.Facolta.Nome == se.Facolta.Nome &&
                                ep.NomeAula == se.NomeAula &&
                                ep.Attivita == se.Attivita &&
                                ep.DataOra == se.DataOra))
                        continue;
                    stringhePulite.Add(se.Facolta.Nome + ";" + se.NomeAula + ";" + se.Attivita + ";" + se.DataOra);
                }
                File.AppendAllLines(ConfigParams.CalendarioFileName, stringhePulite);
            }
            catch (Exception ex)
            {
                Log.Error("Errore scrittura file calendario. Errore: " + ex.Message);
            }
        }

        //Popola le liste all'avvio
        internal static void PopolaListe()
        {
            OttieniListaStudenteFile();
            OttieniListaDocenteFile();
            OttiniListaFacoltaFile();
            OttieniCalendarioFile();
        }
    }
}
