using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Proiect_Test_Brutarie
{
    class Panificatie
    {

        public static void AfiseazaStocPanificatie()
        {
            string jsonString_P = File.ReadAllText("Inventar_Paine.json");
            Paine pPaine = JsonSerializer.Deserialize<Paine>(jsonString_P);
            Console.WriteLine($"Stoc curent Paine:{pPaine.GetNewStockPaine}");

            string jsonString_F = File.ReadAllText("Inventar_Franzela.json");
            Franzela pFranzela = JsonSerializer.Deserialize<Franzela>(jsonString_F);
            Console.WriteLine($"Stoc curent Franzela:{pFranzela.GetNewStockFranzela}");

            string jsonString_B = File.ReadAllText("Inventar_Bagheta.json");
            Bagheta pBagheta = JsonSerializer.Deserialize<Bagheta>(jsonString_B);
            Console.WriteLine($"Stoc curent Bagheta:{pBagheta.GetNewStockBagheta}");
        }

        public static void AfiseazaInventarPanificatie()
        {
            string jsonString_P = File.ReadAllText("Inventar_Paine.json");
            Paine pPaine = JsonSerializer.Deserialize<Paine>(jsonString_P);
            string jsonString_F = File.ReadAllText("Inventar_Franzela.json");
            Franzela pFranzela = JsonSerializer.Deserialize<Franzela>(jsonString_F);
            string jsonString_B = File.ReadAllText("Inventar_Bagheta.json");
            Bagheta pBagheta = JsonSerializer.Deserialize<Bagheta>(jsonString_B);

            int valPaine = pPaine.GetNewStockPaine * pPaine.GetNewPricePaine;
            int valFranzela = pFranzela.GetNewStockFranzela * pFranzela.GetNewPriceFranzela;
            int valBagheta = pBagheta.GetNewStockBagheta * pBagheta.GetNewPriceBagheta;

            Console.WriteLine($"\nStoc curent Paine:{pPaine.GetNewStockPaine} bucati");
            Console.WriteLine($"Valoare:{valPaine} RON");
            Console.WriteLine($"\nStoc curent Franzela:{pFranzela.GetNewStockFranzela} bucati");
            Console.WriteLine($"Valoare:{valFranzela} RON");
            Console.WriteLine($"\nStoc curent Bagheta:{pBagheta.GetNewStockBagheta} bucati");
            Console.WriteLine($"Valoare:{valBagheta} RON");
            Console.WriteLine($"\nStoc total produse Panificatie:{pPaine.GetNewStockPaine + pFranzela.GetNewStockFranzela + pBagheta.GetNewStockBagheta} bucati");
            Console.WriteLine($"Valoare totala produse Panificatie:{valPaine + valFranzela + valBagheta} RON");
        }

        string[] produsePanificatie = { "Paine", "Franzela", "Bagheta" };
        int _tipPanificatie;

        public Panificatie(ushort tipPanificatie)
        {
            _tipPanificatie = tipPanificatie;
        }

    }
}
