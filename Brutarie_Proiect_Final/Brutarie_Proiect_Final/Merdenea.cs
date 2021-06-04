using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Merdenea
    {
        public int _cantInitialaMerdenea;
        public int _pretMerdenea;

        public int GetNewStockMerdenea
        {
            get { return _cantInitialaMerdenea; }
        }

        public int GetNewPriceMerdenea
        {
            get { return _pretMerdenea; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Merdenea(int getNewStockMerdenea, int getNewPriceMerdenea)
        {
            _cantInitialaMerdenea = getNewStockMerdenea;
            _pretMerdenea = getNewPriceMerdenea;
        }

        public static void AdaugaMerdenea()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Merdenea' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Merdenea.json");
            Merdenea pMerdenea = JsonSerializer.Deserialize<Merdenea>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Merdenea = pMerdenea._cantInitialaMerdenea + nrProduse;
            pMerdenea._cantInitialaMerdenea = stoc_nou_Merdenea;

            jsonString = JsonSerializer.Serialize(pMerdenea);
            Console.WriteLine($"Noul stoc de 'Merdenea' este: {pMerdenea.GetNewStockMerdenea} bucati");
            File.WriteAllText("Inventar_Merdenea.json", jsonString);

        }

        public static void EliminaMerdenea()
        {
            string jsonString = File.ReadAllText("Inventar_Merdenea.json");
            Merdenea pMerdenea = JsonSerializer.Deserialize<Merdenea>(jsonString);

            bool q = true;

            while (q)
            {
                if (pMerdenea.GetNewStockMerdenea > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Merdenea' pe care doriti sa le scoateti din inventar:");
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

                    if (pMerdenea.GetNewStockMerdenea >= nrProduse)
                    {
                        int stoc_nou_Merdenea = pMerdenea._cantInitialaMerdenea - nrProduse;
                        pMerdenea._cantInitialaMerdenea = stoc_nou_Merdenea;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pMerdenea.GetNewStockMerdenea} produse care s-au putut elimina.");
                        int stoc_nou_Merdenea = pMerdenea._cantInitialaMerdenea - pMerdenea._cantInitialaMerdenea;
                        pMerdenea._cantInitialaMerdenea = stoc_nou_Merdenea;
                    }

                    jsonString = JsonSerializer.Serialize(pMerdenea);
                    Console.WriteLine($"Noul stoc de 'Merdenea' este: {pMerdenea.GetNewStockMerdenea} bucati");
                    File.WriteAllText("Inventar_Merdenea.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeMerdenea()
        {
            string jsonString = File.ReadAllText("Inventar_Merdenea.json");
            Merdenea pMerdenea = JsonSerializer.Deserialize<Merdenea>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Merdenea' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pMerdenea.GetNewStockMerdenea > 0)
                {
                    pMerdenea._pretMerdenea = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pMerdenea.GetNewStockMerdenea >= nrProduse)
                    {
                        int stoc_nou_Merdenea = pMerdenea._cantInitialaMerdenea - nrProduse;
                        pMerdenea._cantInitialaMerdenea = stoc_nou_Merdenea;
                        Console.WriteLine($"Noul stoc de 'Merdenea' este: {pMerdenea.GetNewStockMerdenea} bucati");
                        Console.WriteLine($"Pret Merdenea / bucata: {pMerdenea.GetNewPriceMerdenea} RON");
                        Console.WriteLine($"Total: {pMerdenea.GetNewPriceMerdenea * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pMerdenea.GetNewPriceMerdenea * pMerdenea._cantInitialaMerdenea;

                        Console.WriteLine($"In stoc au fost doar {pMerdenea.GetNewStockMerdenea} produse care s-au putut vinde.");
                        int stoc_nou_Merdenea = pMerdenea._cantInitialaMerdenea - pMerdenea._cantInitialaMerdenea;
                        pMerdenea._cantInitialaMerdenea = stoc_nou_Merdenea;
                        Console.WriteLine($"Noul stoc de 'Merdenea' este: {pMerdenea.GetNewStockMerdenea} bucati");
                        Console.WriteLine($"Pret Merdenea / bucata: {pMerdenea.GetNewPriceMerdenea} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pMerdenea);
                    File.WriteAllText("Inventar_Merdenea.json", jsonString);
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
