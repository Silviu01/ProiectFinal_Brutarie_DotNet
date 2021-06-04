using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Tort
    {
        public int _cantInitialaTort;
        public int _pretTort;

        public int GetNewStockTort
        {
            get { return _cantInitialaTort; }
        }

        public int GetNewPriceTort
        {
            get { return _pretTort; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Tort(int getNewStockTort, int getNewPriceTort)
        {
            _cantInitialaTort = getNewStockTort;
            _pretTort = getNewPriceTort;
        }

        public static void AdaugaTort()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Tort' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Tort.json");
            Tort pTort = JsonSerializer.Deserialize<Tort>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Tort = pTort._cantInitialaTort + nrProduse;
            pTort._cantInitialaTort = stoc_nou_Tort;

            jsonString = JsonSerializer.Serialize(pTort);
            Console.WriteLine($"Noul stoc de 'Tort' este: {pTort.GetNewStockTort} bucati");
            File.WriteAllText("Inventar_Tort.json", jsonString);

        }

        public static void EliminaTort()
        {
            string jsonString = File.ReadAllText("Inventar_Tort.json");
            Tort pTort = JsonSerializer.Deserialize<Tort>(jsonString);

            bool q = true;

            while (q)
            {
                if (pTort.GetNewStockTort > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Tort' pe care doriti sa le scoateti din inventar:");
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

                    if (pTort.GetNewStockTort >= nrProduse)
                    {
                        int stoc_nou_Tort = pTort._cantInitialaTort - nrProduse;
                        pTort._cantInitialaTort = stoc_nou_Tort;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pTort.GetNewStockTort} produse care s-au putut elimina.");
                        int stoc_nou_Tort = pTort._cantInitialaTort - pTort._cantInitialaTort;
                        pTort._cantInitialaTort = stoc_nou_Tort;
                    }

                    jsonString = JsonSerializer.Serialize(pTort);
                    Console.WriteLine($"Noul stoc de 'Tort' este: {pTort.GetNewStockTort} bucati");
                    File.WriteAllText("Inventar_Tort.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeTort()
        {
            string jsonString = File.ReadAllText("Inventar_Tort.json");
            Tort pTort = JsonSerializer.Deserialize<Tort>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Tort' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pTort.GetNewStockTort > 0)
                {
                    pTort._pretTort = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pTort.GetNewStockTort >= nrProduse)
                    {
                        int stoc_nou_Tort = pTort._cantInitialaTort - nrProduse;
                        pTort._cantInitialaTort = stoc_nou_Tort;
                        Console.WriteLine($"Noul stoc de 'Tort' este: {pTort.GetNewStockTort} bucati");
                        Console.WriteLine($"Pret Tort / bucata: {pTort.GetNewPriceTort} RON");
                        Console.WriteLine($"Total: {pTort.GetNewPriceTort * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pTort.GetNewPriceTort * pTort._cantInitialaTort;

                        Console.WriteLine($"In stoc au fost doar {pTort.GetNewStockTort} produse care s-au putut vinde.");
                        int stoc_nou_Tort = pTort._cantInitialaTort - pTort._cantInitialaTort;
                        pTort._cantInitialaTort = stoc_nou_Tort;
                        Console.WriteLine($"Noul stoc de 'Tort' este: {pTort.GetNewStockTort} bucati");
                        Console.WriteLine($"Pret Tort / bucata: {pTort.GetNewPriceTort} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pTort);
                    File.WriteAllText("Inventar_Tort.json", jsonString);
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

