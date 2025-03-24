using Serilog;
using Università.BLogic;
using Università.DataModels;

namespace Università
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility utility = new();
            utility.GetSetApplicationParams();
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(Path.Combine(ConfigParams.AppFilePath, "SeriLogger.log")).CreateLogger();
            Log.Information("Esecuzione programma gestione Università");
            ObtainData.PopolaListe();           
            //Log.Error("Esempio errore");
            //Start.Menu();
            MenuInterattivo.Iniziamo();
            return;



            //Universita.Studenti.Add(new Studente("az001","Mario","Cornuto",20,"Via dei corni", MainEnumerators.Genere.Maschio));
            Universita.Studenti.Add(ObtainData.OttieniStudente());
            Console.WriteLine("Visualizzazione tutti studenti");
            ObtainData.SalvaListaStudentiFile();
            Universita.Studenti.Clear();
            ObtainData.OttieniListaStudenteFile();

            foreach (Studente studente in Universita.Studenti)
            {
                studente.Print();
            }

        }
    }
}
