using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Paine
    {

        public int _cantInitialaPaine;
        public int _pretPaine;

        public int GetNewStockPaine
        {
            get { return _cantInitialaPaine; }
        }

        public int GetNewPricePaine
        {
            get { return _pretPaine; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Paine(int getNewStockPaine, int getNewPricePaine)
        {
            _cantInitialaPaine = getNewStockPaine;
            _pretPaine = getNewPricePaine;
        }

        public static void AdaugaPaine()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Paine' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Paine.json");
            Paine pPaine = JsonSerializer.Deserialize<Paine>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_paine = pPaine._cantInitialaPaine + nrProduse;
            pPaine._cantInitialaPaine = stoc_nou_paine;

            jsonString = JsonSerializer.Serialize(pPaine);
            Console.WriteLine($"Noul stoc de 'Paine' este: {pPaine.GetNewStockPaine} bucati");
            File.WriteAllText("Inventar_Paine.json", jsonString);

        }

        public static void EliminaPaine()
        {
            string jsonString = File.ReadAllText("Inventar_Paine.json");
            Paine pPaine = JsonSerializer.Deserialize<Paine>(jsonString);

            bool q = true;

            while (q)
            {
                if (pPaine.GetNewStockPaine > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Paine' pe care doriti sa le scoateti din inventar:");
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

                    if (pPaine.GetNewStockPaine >= nrProduse)
                    {
                        int stoc_nou_paine = pPaine._cantInitialaPaine - nrProduse;
                        pPaine._cantInitialaPaine = stoc_nou_paine;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pPaine.GetNewStockPaine} produse care s-au putut elimina.");
                        int stoc_nou_paine = pPaine._cantInitialaPaine - pPaine._cantInitialaPaine;
                        pPaine._cantInitialaPaine = stoc_nou_paine;
                    }

                    jsonString = JsonSerializer.Serialize(pPaine);
                    Console.WriteLine($"Noul stoc de 'Paine' este: {pPaine.GetNewStockPaine} bucati");
                    File.WriteAllText("Inventar_Paine.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindePaine()
        {
            string jsonString = File.ReadAllText("Inventar_Paine.json");
            Paine pPaine = JsonSerializer.Deserialize<Paine>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Paine' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pPaine.GetNewStockPaine > 0)
                {
                    pPaine._pretPaine = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pPaine.GetNewStockPaine >= nrProduse)
                    {
                        int stoc_nou_paine = pPaine._cantInitialaPaine - nrProduse;
                        pPaine._cantInitialaPaine = stoc_nou_paine;
                        Console.WriteLine($"Noul stoc de 'Paine' este: {pPaine.GetNewStockPaine} bucati");
                        Console.WriteLine($"Pret Paine / bucata: {pPaine.GetNewPricePaine} RON");
                        Console.WriteLine($"Total: {pPaine.GetNewPricePaine * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pPaine.GetNewPricePaine * pPaine._cantInitialaPaine;

                        Console.WriteLine($"In stoc au fost doar {pPaine.GetNewStockPaine} produse care s-au putut vinde.");
                        int stoc_nou_paine = pPaine._cantInitialaPaine - pPaine._cantInitialaPaine;
                        pPaine._cantInitialaPaine = stoc_nou_paine;
                        Console.WriteLine($"Noul stoc de 'Paine' este: {pPaine.GetNewStockPaine} bucati");
                        Console.WriteLine($"Pret Paine / bucata: {pPaine.GetNewPricePaine} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pPaine);
                    File.WriteAllText("Inventar_Paine.json", jsonString);
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
