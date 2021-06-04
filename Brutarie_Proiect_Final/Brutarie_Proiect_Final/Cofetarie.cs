using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Proiect_Test_Brutarie
{
    class Cofetarie
    {
        public static void AfiseazaStocCofetarie()
        {
            string jsonString_E = File.ReadAllText("Inventar_Ecler.json");
            Ecler pEcler = JsonSerializer.Deserialize<Ecler>(jsonString_E);
            Console.WriteLine($"\nStoc curent Ecler:{pEcler.GetNewStockEcler}");

            string jsonString_A = File.ReadAllText("Inventar_Amandina.json");
            Amandina pAmandina = JsonSerializer.Deserialize<Amandina>(jsonString_A);
            Console.WriteLine($"Stoc curent Amandina:{pAmandina.GetNewStockAmandina}");

            string jsonString_S = File.ReadAllText("Inventar_Savarina.json");
            Savarina pSavarina = JsonSerializer.Deserialize<Savarina>(jsonString_S);
            Console.WriteLine($"Stoc curent Savarina:{pSavarina.GetNewStockSavarina}");

            string jsonString_T = File.ReadAllText("Inventar_Tort.json");
            Tort pTort = JsonSerializer.Deserialize<Tort>(jsonString_T);
            Console.WriteLine($"Stoc curent Tort:{pTort.GetNewStockTort}");
        }

        string[] produseCofetarie = { "Ecler", "Amandina", "Savarina", "Tort" };
        int _tipCofetarie;

        public Cofetarie(ushort tipCofetarie)
        {
            _tipCofetarie = tipCofetarie;
        }
    }
}
