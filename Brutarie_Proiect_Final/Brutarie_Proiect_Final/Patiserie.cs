using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Proiect_Test_Brutarie
{
    class Patiserie
    {
        public static void AfiseazaStocPatiserie()
        {
            string jsonString_P = File.ReadAllText("Inventar_Pateu.json");
            Pateu pPateu = JsonSerializer.Deserialize<Pateu>(jsonString_P);
            Console.WriteLine($"\nStoc curent Pateu:{pPateu.GetNewStockPateu}");

            string jsonString_M = File.ReadAllText("Inventar_Merdenea.json");
            Merdenea pMerdenea = JsonSerializer.Deserialize<Merdenea>(jsonString_M);
            Console.WriteLine($"Stoc curent Merdenea:{pMerdenea.GetNewStockMerdenea}");

            string jsonString_Co = File.ReadAllText("Inventar_Covrig.json");
            Covrig pCovrig = JsonSerializer.Deserialize<Covrig>(jsonString_Co);
            Console.WriteLine($"Stoc curent Covrig:{pCovrig.GetNewStockCovrig}");

            string jsonString_C = File.ReadAllText("Inventar_Corn.json");
            Corn pCorn = JsonSerializer.Deserialize<Corn>(jsonString_C);
            Console.WriteLine($"Stoc curent Corn:{pCorn.GetNewStockCorn}");
        }

        string[] produsePatiserie = { "Pateu", "Merdenea", "Covrig", "Corn" };
        int _tipPatiserie;

        public Patiserie(ushort tipPatiserie)
        {
            _tipPatiserie = tipPatiserie;
        }
    }
}
