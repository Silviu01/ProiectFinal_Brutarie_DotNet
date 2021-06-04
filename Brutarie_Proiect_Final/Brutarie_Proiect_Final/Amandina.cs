using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Amandina
    {
        public int _cantInitialaAmandina;
        public int _pretAmandina;

        public int GetNewStockAmandina
        {
            get { return _cantInitialaAmandina; }
        }

        public int GetNewPriceAmandina
        {
            get { return _pretAmandina; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Amandina(int getNewStockAmandina, int getNewPriceAmandina)
        {
            _cantInitialaAmandina = getNewStockAmandina;
            _pretAmandina = getNewPriceAmandina;
        }

        public static void AdaugaAmandina()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Amandina' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Amandina.json");
            Amandina pAmandina = JsonSerializer.Deserialize<Amandina>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Amandina = pAmandina._cantInitialaAmandina + nrProduse;
            pAmandina._cantInitialaAmandina = stoc_nou_Amandina;

            jsonString = JsonSerializer.Serialize(pAmandina);
            Console.WriteLine($"Noul stoc de 'Amandina' este: {pAmandina.GetNewStockAmandina} bucati");
            File.WriteAllText("Inventar_Amandina.json", jsonString);

        }

        public static void EliminaAmandina()
        {
            string jsonString = File.ReadAllText("Inventar_Amandina.json");
            Amandina pAmandina = JsonSerializer.Deserialize<Amandina>(jsonString);

            bool q = true;

            while (q)
            {
                if (pAmandina.GetNewStockAmandina > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Amandina' pe care doriti sa le scoateti din inventar:");
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

                    if (pAmandina.GetNewStockAmandina >= nrProduse)
                    {
                        int stoc_nou_Amandina = pAmandina._cantInitialaAmandina - nrProduse;
                        pAmandina._cantInitialaAmandina = stoc_nou_Amandina;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pAmandina.GetNewStockAmandina} produse care s-au putut elimina.");
                        int stoc_nou_Amandina = pAmandina._cantInitialaAmandina - pAmandina._cantInitialaAmandina;
                        pAmandina._cantInitialaAmandina = stoc_nou_Amandina;
                    }

                    jsonString = JsonSerializer.Serialize(pAmandina);
                    Console.WriteLine($"Noul stoc de 'Amandina' este: {pAmandina.GetNewStockAmandina} bucati");
                    File.WriteAllText("Inventar_Amandina.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeAmandina()
        {
            string jsonString = File.ReadAllText("Inventar_Amandina.json");
            Amandina pAmandina = JsonSerializer.Deserialize<Amandina>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Amandina' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pAmandina.GetNewStockAmandina > 0)
                {
                    pAmandina._pretAmandina = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pAmandina.GetNewStockAmandina >= nrProduse)
                    {
                        int stoc_nou_Amandina = pAmandina._cantInitialaAmandina - nrProduse;
                        pAmandina._cantInitialaAmandina = stoc_nou_Amandina;
                        Console.WriteLine($"Noul stoc de 'Amandina' este: {pAmandina.GetNewStockAmandina} bucati");
                        Console.WriteLine($"Pret Amandina / bucata: {pAmandina.GetNewPriceAmandina} RON");
                        Console.WriteLine($"Total: {pAmandina.GetNewPriceAmandina * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pAmandina.GetNewPriceAmandina * pAmandina._cantInitialaAmandina;

                        Console.WriteLine($"In stoc au fost doar {pAmandina.GetNewStockAmandina} produse care s-au putut vinde.");
                        int stoc_nou_Amandina = pAmandina._cantInitialaAmandina - pAmandina._cantInitialaAmandina;
                        pAmandina._cantInitialaAmandina = stoc_nou_Amandina;
                        Console.WriteLine($"Noul stoc de 'Amandina' este: {pAmandina.GetNewStockAmandina} bucati");
                        Console.WriteLine($"Pret Amandina / bucata: {pAmandina.GetNewPriceAmandina} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pAmandina);
                    File.WriteAllText("Inventar_Amandina.json", jsonString);
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

