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

        public static void AfiseazaInventarCofetarie()
        {

            string jsonString_E = File.ReadAllText("Inventar_Ecler.json");
            Ecler pEcler = JsonSerializer.Deserialize<Ecler>(jsonString_E);
            int valEcler = pEcler.GetNewStockEcler * pEcler.GetNewPriceEcler;
            Console.WriteLine($"\nStoc curent Ecler:{pEcler.GetNewStockEcler} bucati");
            Console.WriteLine($"Valoare:{valEcler} RON");

            string jsonString_A = File.ReadAllText("Inventar_Amandina.json");
            Amandina pAmandina = JsonSerializer.Deserialize<Amandina>(jsonString_A);
            int valAmandina = pAmandina.GetNewStockAmandina * pAmandina.GetNewPriceAmandina;
            Console.WriteLine($"\nStoc curent Amandina:{pAmandina.GetNewStockAmandina} bucati");
            Console.WriteLine($"Valoare:{valAmandina} RON");

            string jsonString_S = File.ReadAllText("Inventar_Savarina.json");
            Savarina pSavarina = JsonSerializer.Deserialize<Savarina>(jsonString_S);
            int valSavarina = pSavarina.GetNewStockSavarina * pSavarina.GetNewPriceSavarina;
            Console.WriteLine($"\nStoc curent Savarina:{pSavarina.GetNewStockSavarina} bucati");
            Console.WriteLine($"Valoare:{valSavarina} RON");


            string jsonString_T = File.ReadAllText("Inventar_Tort.json");
            Tort pTort = JsonSerializer.Deserialize<Tort>(jsonString_T);                    
            int valTort = pTort.GetNewStockTort * pTort.GetNewPriceTort;
            Console.WriteLine($"\nStoc curent Tort:{pTort.GetNewStockTort} bucati");
            Console.WriteLine($"Valoare:{valTort} RON");

            Console.WriteLine($"\nStoc total produse Cofetarie:{pEcler.GetNewStockEcler + pAmandina.GetNewStockAmandina + pSavarina.GetNewStockSavarina + pTort.GetNewStockTort} bucati");
            Console.WriteLine($"Valoare totala produse Cofetarie:{valEcler + valAmandina + valSavarina + valTort} RON");
        }

        string[] produseCofetarie = { "Ecler", "Amandina", "Savarina", "Tort" };
        int _tipCofetarie;

        public Cofetarie(ushort tipCofetarie)
        {
            _tipCofetarie = tipCofetarie;
        }
    }
}
