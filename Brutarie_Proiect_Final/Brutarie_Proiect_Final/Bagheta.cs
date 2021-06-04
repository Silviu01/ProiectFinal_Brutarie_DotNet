using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Bagheta
    {
        public int _cantInitialaBagheta;
        public int _pretBagheta;

        public int GetNewStockBagheta
        {
            get { return _cantInitialaBagheta; }
        }

        public int GetNewPriceBagheta
        {
            get { return _pretBagheta; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Bagheta(int getNewStockBagheta, int getNewPriceBagheta)
        {
            _cantInitialaBagheta = getNewStockBagheta;
            _pretBagheta = getNewPriceBagheta;
        }

        public static void AdaugaBagheta()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Bagheta' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Bagheta.json");
            Bagheta pBagheta = JsonSerializer.Deserialize<Bagheta>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Bagheta = pBagheta._cantInitialaBagheta + nrProduse;
            pBagheta._cantInitialaBagheta = stoc_nou_Bagheta;

            jsonString = JsonSerializer.Serialize(pBagheta);
            Console.WriteLine($"Noul stoc de 'Bagheta' este: {pBagheta.GetNewStockBagheta} bucati");
            File.WriteAllText("Inventar_Bagheta.json", jsonString);

        }

        public static void EliminaBagheta()
        {
            string jsonString = File.ReadAllText("Inventar_Bagheta.json");
            Bagheta pBagheta = JsonSerializer.Deserialize<Bagheta>(jsonString);

            bool q = true;

            while (q)
            {
                if (pBagheta.GetNewStockBagheta > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Bagheta' pe care doriti sa le scoateti din inventar:");
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

                    if (pBagheta.GetNewStockBagheta >= nrProduse)
                    {
                        int stoc_nou_Bagheta = pBagheta._cantInitialaBagheta - nrProduse;
                        pBagheta._cantInitialaBagheta = stoc_nou_Bagheta;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pBagheta.GetNewStockBagheta} produse care s-au putut elimina.");
                        int stoc_nou_Bagheta = pBagheta._cantInitialaBagheta - pBagheta._cantInitialaBagheta;
                        pBagheta._cantInitialaBagheta = stoc_nou_Bagheta;
                    }

                    jsonString = JsonSerializer.Serialize(pBagheta);
                    Console.WriteLine($"Noul stoc de 'Bagheta' este: {pBagheta.GetNewStockBagheta} bucati");
                    File.WriteAllText("Inventar_Bagheta.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeBagheta()
        {
            string jsonString = File.ReadAllText("Inventar_Bagheta.json");
            Bagheta pBagheta = JsonSerializer.Deserialize<Bagheta>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Bagheta' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pBagheta.GetNewStockBagheta > 0)
                {
                    pBagheta._pretBagheta = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pBagheta.GetNewStockBagheta >= nrProduse)
                    {
                        int stoc_nou_Bagheta = pBagheta._cantInitialaBagheta - nrProduse;
                        pBagheta._cantInitialaBagheta = stoc_nou_Bagheta;
                        Console.WriteLine($"Noul stoc de 'Bagheta' este: {pBagheta.GetNewStockBagheta} bucati");
                        Console.WriteLine($"Pret Bagheta / bucata: {pBagheta.GetNewPriceBagheta} RON");
                        Console.WriteLine($"Total: {pBagheta.GetNewPriceBagheta * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pBagheta.GetNewPriceBagheta * pBagheta._cantInitialaBagheta;

                        Console.WriteLine($"In stoc au fost doar {pBagheta.GetNewStockBagheta} produse care s-au putut vinde.");
                        int stoc_nou_Bagheta = pBagheta._cantInitialaBagheta - pBagheta._cantInitialaBagheta;
                        pBagheta._cantInitialaBagheta = stoc_nou_Bagheta;
                        Console.WriteLine($"Noul stoc de 'Bagheta' este: {pBagheta.GetNewStockBagheta} bucati");
                        Console.WriteLine($"Pret Bagheta / bucata: {pBagheta.GetNewPriceBagheta} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pBagheta);
                    File.WriteAllText("Inventar_Bagheta.json", jsonString);
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
