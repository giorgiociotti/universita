using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Università.BLogic
{
    internal class Start
    {
        internal static void menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Iniziale ===");
                Console.WriteLine("1. Esplora le facoltà");
                Console.WriteLine("2. Menu Studente");
                Console.WriteLine("3. Menu Docente");
                Console.WriteLine("4. Esci");
                Console.Write("Seleziona un'opzione: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        EsploraFacolta();
                        break;
                    case "2":
                        MenuStudente();
                        break;
                    case "3":
                        MenuDocente();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opzione non valida. Premi un tasto per riprovare...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void EsploraFacolta()
        {
            Console.Clear();
            Console.WriteLine("=== Esplora le Facoltà ===");
            Console.WriteLine("1. Facoltà di Informatica");
            Console.WriteLine("2. Facoltà di Ingegneria");
            Console.WriteLine("3. Facoltà di Economia");
            Console.WriteLine("4. Torna al menu principale");
            Console.Write("Scegli una facoltà: ");
            Console.ReadLine();
        }

        private static void MenuStudente()
        {
            Console.Clear();
            Console.WriteLine("=== Menu Studente ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Iscrizione");
            Console.WriteLine("3. Torna al menu principale");
            Console.ReadLine();

        }

        private static void MenuDocente()
        {
            Console.Clear();
            Console.WriteLine("=== Menu Docente ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Pubblica un esame");
            Console.WriteLine("3. Controlla il tuo orario");
            Console.WriteLine("4. Prenota un'aula");
            Console.WriteLine("5. Torna al menu principale");
            Console.ReadLine();

        }
    }
}
