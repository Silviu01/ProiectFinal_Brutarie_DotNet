using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Franzela
    {

        public int _cantInitialaFranzela;
        public int _pretFranzela;

        public int GetNewStockFranzela
        {
            get { return _cantInitialaFranzela; }
        }

        public int GetNewPriceFranzela
        {
            get { return _pretFranzela; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Franzela(int getNewStockFranzela, int getNewPriceFranzela)
        {
            _cantInitialaFranzela = getNewStockFranzela;
            _pretFranzela = getNewPriceFranzela;
        }

        public static void AdaugaFranzela()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Franzela' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Franzela.json");
            Franzela pFranzela = JsonSerializer.Deserialize<Franzela>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_franzela = pFranzela._cantInitialaFranzela + nrProduse;
            pFranzela._cantInitialaFranzela = stoc_nou_franzela;

            jsonString = JsonSerializer.Serialize(pFranzela);
            Console.WriteLine($"Noul stoc de 'Franzela' este: {pFranzela.GetNewStockFranzela} bucati");
            File.WriteAllText("Inventar_Franzela.json", jsonString);

        }

        public static void EliminaFranzela()
        {
            string jsonString = File.ReadAllText("Inventar_Franzela.json");
            Franzela pFranzela = JsonSerializer.Deserialize<Franzela>(jsonString);

            bool q = true;

            while (q)
            {
                if (pFranzela.GetNewStockFranzela > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Franzela' pe care doriti sa le scoateti din inventar:");
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

                    if (pFranzela.GetNewStockFranzela >= nrProduse)
                    {
                        int stoc_nou_Franzela = pFranzela._cantInitialaFranzela - nrProduse;
                        pFranzela._cantInitialaFranzela = stoc_nou_Franzela;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pFranzela.GetNewStockFranzela} produse care s-au putut elimina.");
                        int stoc_nou_Franzela = pFranzela._cantInitialaFranzela - pFranzela._cantInitialaFranzela;
                        pFranzela._cantInitialaFranzela = stoc_nou_Franzela;
                    }

                    jsonString = JsonSerializer.Serialize(pFranzela);
                    Console.WriteLine($"Noul stoc de 'Franzela' este: {pFranzela.GetNewStockFranzela} bucati");
                    File.WriteAllText("Inventar_Franzela.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindeFranzela()
        {
            string jsonString = File.ReadAllText("Inventar_Franzela.json");
            Franzela pFranzela = JsonSerializer.Deserialize<Franzela>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Franzela' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pFranzela.GetNewStockFranzela > 0)
                {
                    pFranzela._pretFranzela = 2;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pFranzela.GetNewStockFranzela >= nrProduse)
                    {
                        int stoc_nou_Franzela = pFranzela._cantInitialaFranzela - nrProduse;
                        pFranzela._cantInitialaFranzela = stoc_nou_Franzela;
                        Console.WriteLine($"Noul stoc de 'Franzela' este: {pFranzela.GetNewStockFranzela} bucati");
                        Console.WriteLine($"Pret Franzela / bucata: {pFranzela.GetNewPriceFranzela} RON");
                        Console.WriteLine($"Total: {pFranzela.GetNewPriceFranzela * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pFranzela.GetNewPriceFranzela * pFranzela._cantInitialaFranzela;

                        Console.WriteLine($"In stoc au fost doar {pFranzela.GetNewStockFranzela} produse care s-au putut vinde.");
                        int stoc_nou_Franzela = pFranzela._cantInitialaFranzela - pFranzela._cantInitialaFranzela;
                        pFranzela._cantInitialaFranzela = stoc_nou_Franzela;
                        Console.WriteLine($"Noul stoc de 'Franzela' este: {pFranzela.GetNewStockFranzela} bucati");
                        Console.WriteLine($"Pret Franzela / bucata: {pFranzela.GetNewPriceFranzela} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pFranzela);
                    File.WriteAllText("Inventar_Franzela.json", jsonString);
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

