using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Savarina
    {
        public int _cantInitialaSavarina;
        public int _pretSavarina;

        public int GetNewStockSavarina
        {
            get { return _cantInitialaSavarina; }
        }

        public int GetNewPriceSavarina
        {
            get { return _pretSavarina; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Savarina(int getNewStockSavarina, int getNewPriceSavarina)
        {
            _cantInitialaSavarina = getNewStockSavarina;
            _pretSavarina = getNewPriceSavarina;
        }

        public static void AdaugaSavarina()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Savarina' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Savarina.json");
            Savarina pSavarina = JsonSerializer.Deserialize<Savarina>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Savarina = pSavarina._cantInitialaSavarina + nrProduse;
            pSavarina._cantInitialaSavarina = stoc_nou_Savarina;

            jsonString = JsonSerializer.Serialize(pSavarina);
            Console.WriteLine($"Noul stoc de 'Savarina' este: {pSavarina.GetNewStockSavarina} bucati");
            File.WriteAllText("Inventar_Savarina.json", jsonString);

        }

        public static void EliminaSavarina()
        {
            string jsonString = File.ReadAllText("Inventar_Savarina.json");
            Savarina pSavarina = JsonSerializer.Deserialize<Savarina>(jsonString);

            bool q = true;

            while (q)
            {
                if (pSavarina.GetNewStockSavarina > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Savarina' pe care doriti sa le scoateti din inventar:");
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

                    if (pSavarina.GetNewStockSavarina >= nrProduse)
                    {
                        int stoc_nou_Savarina = pSavarina._cantInitialaSavarina - nrProduse;
                        pSavarina._cantInitialaSavarina = stoc_nou_Savarina;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pSavarina.GetNewStockSavarina} produse care s-au putut elimina.");
                        int stoc_nou_Savarina = pSavarina._cantInitialaSavarina - pSavarina._cantInitialaSavarina;
                        pSavarina._cantInitialaSavarina = stoc_nou_Savarina;
                    }

                    jsonString = JsonSerializer.Serialize(pSavarina);
                    Console.WriteLine($"Noul stoc de 'Savarina' este: {pSavarina.GetNewStockSavarina} bucati");
                    File.WriteAllText("Inventar_Savarina.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeSavarina()
        {
            string jsonString = File.ReadAllText("Inventar_Savarina.json");
            Savarina pSavarina = JsonSerializer.Deserialize<Savarina>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Savarina' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pSavarina.GetNewStockSavarina > 0)
                {
                    pSavarina._pretSavarina = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pSavarina.GetNewStockSavarina >= nrProduse)
                    {
                        int stoc_nou_Savarina = pSavarina._cantInitialaSavarina - nrProduse;
                        pSavarina._cantInitialaSavarina = stoc_nou_Savarina;
                        Console.WriteLine($"Noul stoc de 'Savarina' este: {pSavarina.GetNewStockSavarina} bucati");
                        Console.WriteLine($"Pret Savarina / bucata: {pSavarina.GetNewPriceSavarina} RON");
                        Console.WriteLine($"Total: {pSavarina.GetNewPriceSavarina * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pSavarina.GetNewPriceSavarina * pSavarina._cantInitialaSavarina;

                        Console.WriteLine($"In stoc au fost doar {pSavarina.GetNewStockSavarina} produse care s-au putut vinde.");
                        int stoc_nou_Savarina = pSavarina._cantInitialaSavarina - pSavarina._cantInitialaSavarina;
                        pSavarina._cantInitialaSavarina = stoc_nou_Savarina;
                        Console.WriteLine($"Noul stoc de 'Savarina' este: {pSavarina.GetNewStockSavarina} bucati");
                        Console.WriteLine($"Pret Savarina / bucata: {pSavarina.GetNewPriceSavarina} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pSavarina);
                    File.WriteAllText("Inventar_Savarina.json", jsonString);
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
