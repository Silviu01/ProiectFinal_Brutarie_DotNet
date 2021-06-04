using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Corn
    {
        public int _cantInitialaCorn;
        public int _pretCorn;

        public int GetNewStockCorn
        {
            get { return _cantInitialaCorn; }
        }

        public int GetNewPriceCorn
        {
            get { return _pretCorn; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Corn(int getNewStockCorn, int getNewPriceCorn)
        {
            _cantInitialaCorn = getNewStockCorn;
            _pretCorn = getNewPriceCorn;
        }

        public static void AdaugaCorn()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Corn' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Corn.json");
            Corn pCorn = JsonSerializer.Deserialize<Corn>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Corn = pCorn._cantInitialaCorn + nrProduse;
            pCorn._cantInitialaCorn = stoc_nou_Corn;

            jsonString = JsonSerializer.Serialize(pCorn);
            Console.WriteLine($"Noul stoc de 'Corn' este: {pCorn.GetNewStockCorn} bucati");
            File.WriteAllText("Inventar_Corn.json", jsonString);

        }

        public static void EliminaCorn()
        {
            string jsonString = File.ReadAllText("Inventar_Corn.json");
            Corn pCorn = JsonSerializer.Deserialize<Corn>(jsonString);

            bool q = true;

            while (q)
            {
                if (pCorn.GetNewStockCorn > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Corn' pe care doriti sa le scoateti din inventar:");
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

                    if (pCorn.GetNewStockCorn >= nrProduse)
                    {
                        int stoc_nou_Corn = pCorn._cantInitialaCorn - nrProduse;
                        pCorn._cantInitialaCorn = stoc_nou_Corn;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pCorn.GetNewStockCorn} produse care s-au putut elimina.");
                        int stoc_nou_Corn = pCorn._cantInitialaCorn - pCorn._cantInitialaCorn;
                        pCorn._cantInitialaCorn = stoc_nou_Corn;
                    }

                    jsonString = JsonSerializer.Serialize(pCorn);
                    Console.WriteLine($"Noul stoc de 'Corn' este: {pCorn.GetNewStockCorn} bucati");
                    File.WriteAllText("Inventar_Corn.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeCorn()
        {
            string jsonString = File.ReadAllText("Inventar_Corn.json");
            Corn pCorn = JsonSerializer.Deserialize<Corn>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Corn' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pCorn.GetNewStockCorn > 0)
                {
                    pCorn._pretCorn = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pCorn.GetNewStockCorn >= nrProduse)
                    {
                        int stoc_nou_Corn = pCorn._cantInitialaCorn - nrProduse;
                        pCorn._cantInitialaCorn = stoc_nou_Corn;
                        Console.WriteLine($"Noul stoc de 'Corn' este: {pCorn.GetNewStockCorn} bucati");
                        Console.WriteLine($"Pret Corn / bucata: {pCorn.GetNewPriceCorn} RON");
                        Console.WriteLine($"Total: {pCorn.GetNewPriceCorn * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pCorn.GetNewPriceCorn * pCorn._cantInitialaCorn;

                        Console.WriteLine($"In stoc au fost doar {pCorn.GetNewStockCorn} produse care s-au putut vinde.");
                        int stoc_nou_Corn = pCorn._cantInitialaCorn - pCorn._cantInitialaCorn;
                        pCorn._cantInitialaCorn = stoc_nou_Corn;
                        Console.WriteLine($"Noul stoc de 'Corn' este: {pCorn.GetNewStockCorn} bucati");
                        Console.WriteLine($"Pret Corn / bucata: {pCorn.GetNewPriceCorn} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pCorn);
                    File.WriteAllText("Inventar_Corn.json", jsonString);
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
