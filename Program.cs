using Serilog;
using Università.BLogic;
using Università.DataModel;

namespace Università
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility utility = new Utility();
            utility.GetSetApplicationParams();
            utility.GetSetApplicationParams();
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(Path.Combine(ConfigParams.AppFilePath, "SeriLogger.log")).CreateLogger();
            Log.Information("Esecuzione programma gestione Università");
            //Log.Error("Esempio errore");
            Start.menu();   
        }

               
    }
}
