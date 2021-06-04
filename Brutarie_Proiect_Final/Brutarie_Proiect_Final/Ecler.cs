using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Ecler
    {
        public int _cantInitialaEcler;
        public int _pretEcler;

        public int GetNewStockEcler
        {
            get { return _cantInitialaEcler; }
        }

        public int GetNewPriceEcler
        {
            get { return _pretEcler; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Ecler(int getNewStockEcler, int getNewPriceEcler)
        {
            _cantInitialaEcler = getNewStockEcler;
            _pretEcler = getNewPriceEcler;
        }

        public static void AdaugaEcler()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Ecler' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Ecler.json");
            Ecler pEcler = JsonSerializer.Deserialize<Ecler>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Ecler = pEcler._cantInitialaEcler + nrProduse;
            pEcler._cantInitialaEcler = stoc_nou_Ecler;

            jsonString = JsonSerializer.Serialize(pEcler);
            Console.WriteLine($"Noul stoc de 'Ecler' este: {pEcler.GetNewStockEcler} bucati");
            File.WriteAllText("Inventar_Ecler.json", jsonString);

        }

        public static void EliminaEcler()
        {
            string jsonString = File.ReadAllText("Inventar_Ecler.json");
            Ecler pEcler = JsonSerializer.Deserialize<Ecler>(jsonString);

            bool q = true;

            while (q)
            {
                if (pEcler.GetNewStockEcler > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Ecler' pe care doriti sa le scoateti din inventar:");
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

                    if (pEcler.GetNewStockEcler >= nrProduse)
                    {
                        int stoc_nou_Ecler = pEcler._cantInitialaEcler - nrProduse;
                        pEcler._cantInitialaEcler = stoc_nou_Ecler;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pEcler.GetNewStockEcler} produse care s-au putut elimina.");
                        int stoc_nou_Ecler = pEcler._cantInitialaEcler - pEcler._cantInitialaEcler;
                        pEcler._cantInitialaEcler = stoc_nou_Ecler;
                    }

                    jsonString = JsonSerializer.Serialize(pEcler);
                    Console.WriteLine($"Noul stoc de 'Ecler' este: {pEcler.GetNewStockEcler} bucati");
                    File.WriteAllText("Inventar_Ecler.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeEcler()
        {
            string jsonString = File.ReadAllText("Inventar_Ecler.json");
            Ecler pEcler = JsonSerializer.Deserialize<Ecler>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Ecler' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pEcler.GetNewStockEcler > 0)
                {
                    pEcler._pretEcler = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pEcler.GetNewStockEcler >= nrProduse)
                    {
                        int stoc_nou_Ecler = pEcler._cantInitialaEcler - nrProduse;
                        pEcler._cantInitialaEcler = stoc_nou_Ecler;
                        Console.WriteLine($"Noul stoc de 'Ecler' este: {pEcler.GetNewStockEcler} bucati");
                        Console.WriteLine($"Pret Ecler / bucata: {pEcler.GetNewPriceEcler} RON");
                        Console.WriteLine($"Total: {pEcler.GetNewPriceEcler * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pEcler.GetNewPriceEcler * pEcler._cantInitialaEcler;

                        Console.WriteLine($"In stoc au fost doar {pEcler.GetNewStockEcler} produse care s-au putut vinde.");
                        int stoc_nou_Ecler = pEcler._cantInitialaEcler - pEcler._cantInitialaEcler;
                        pEcler._cantInitialaEcler = stoc_nou_Ecler;
                        Console.WriteLine($"Noul stoc de 'Ecler' este: {pEcler.GetNewStockEcler} bucati");
                        Console.WriteLine($"Pret Ecler / bucata: {pEcler.GetNewPriceEcler} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pEcler);
                    File.WriteAllText("Inventar_Ecler.json", jsonString);
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
