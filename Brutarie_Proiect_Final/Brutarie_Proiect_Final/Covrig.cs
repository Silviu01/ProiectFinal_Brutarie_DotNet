using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Covrig
    {
        public int _cantInitialaCovrig;
        public int _pretCovrig;

        public int GetNewStockCovrig
        {
            get { return _cantInitialaCovrig; }
        }

        public int GetNewPriceCovrig
        {
            get { return _pretCovrig; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Covrig(int getNewStockCovrig, int getNewPriceCovrig)
        {
            _cantInitialaCovrig = getNewStockCovrig;
            _pretCovrig = getNewPriceCovrig;
        }

        public static void AdaugaCovrig()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Covrig' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Covrig.json");
            Covrig pCovrig = JsonSerializer.Deserialize<Covrig>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Covrig = pCovrig._cantInitialaCovrig + nrProduse;
            pCovrig._cantInitialaCovrig = stoc_nou_Covrig;

            jsonString = JsonSerializer.Serialize(pCovrig);
            Console.WriteLine($"Noul stoc de 'Covrig' este: {pCovrig.GetNewStockCovrig} bucati");
            File.WriteAllText("Inventar_Covrig.json", jsonString);

        }

        public static void EliminaCovrig()
        {
            string jsonString = File.ReadAllText("Inventar_Covrig.json");
            Covrig pCovrig = JsonSerializer.Deserialize<Covrig>(jsonString);

            bool q = true;

            while (q)
            {
                if (pCovrig.GetNewStockCovrig > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Covrig' pe care doriti sa le scoateti din inventar:");
                    int nrProduse;
                    string s = Console.ReadLine();
                    bool result = int.TryParse(s, out nrProduse);

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pCovrig.GetNewStockCovrig >= nrProduse)
                    {
                        int stoc_nou_Covrig = pCovrig._cantInitialaCovrig - nrProduse;
                        pCovrig._cantInitialaCovrig = stoc_nou_Covrig;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pCovrig.GetNewStockCovrig} produse care s-au putut elimina.");
                        int stoc_nou_Covrig = pCovrig._cantInitialaCovrig - pCovrig._cantInitialaCovrig;
                        pCovrig._cantInitialaCovrig = stoc_nou_Covrig;
                    }

                    jsonString = JsonSerializer.Serialize(pCovrig);
                    Console.WriteLine($"Noul stoc de 'Covrig' este: {pCovrig.GetNewStockCovrig} bucati");
                    File.WriteAllText("Inventar_Covrig.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeCovrig()
        {
            string jsonString = File.ReadAllText("Inventar_Covrig.json");
            Covrig pCovrig = JsonSerializer.Deserialize<Covrig>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Covrig' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pCovrig.GetNewStockCovrig > 0)
                {
                    pCovrig._pretCovrig = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pCovrig.GetNewStockCovrig >= nrProduse)
                    {
                        int stoc_nou_Covrig = pCovrig._cantInitialaCovrig - nrProduse;
                        pCovrig._cantInitialaCovrig = stoc_nou_Covrig;
                        Console.WriteLine($"Noul stoc de 'Covrig' este: {pCovrig.GetNewStockCovrig} bucati");
                        Console.WriteLine($"Pret Covrig / bucata: {pCovrig.GetNewPriceCovrig} RON");
                        Console.WriteLine($"Total: {pCovrig.GetNewPriceCovrig * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pCovrig.GetNewPriceCovrig * pCovrig._cantInitialaCovrig;

                        Console.WriteLine($"In stoc au fost doar {pCovrig.GetNewStockCovrig} produse care s-au putut vinde.");
                        int stoc_nou_Covrig = pCovrig._cantInitialaCovrig - pCovrig._cantInitialaCovrig;
                        pCovrig._cantInitialaCovrig = stoc_nou_Covrig;
                        Console.WriteLine($"Noul stoc de 'Covrig' este: {pCovrig.GetNewStockCovrig} bucati");
                        Console.WriteLine($"Pret Covrig / bucata: {pCovrig.GetNewPriceCovrig} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pCovrig);
                    File.WriteAllText("Inventar_Covrig.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }
    }
}
