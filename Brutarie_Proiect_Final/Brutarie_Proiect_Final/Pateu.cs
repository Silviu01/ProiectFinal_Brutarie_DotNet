using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Proiect_Test_Brutarie
{
    class Pateu
    {
        public int _cantInitialaPateu;
        public int _pretPateu;

        public int GetNewStockPateu
        {
            get { return _cantInitialaPateu; }
        }

        public int GetNewPricePateu
        {
            get { return _pretPateu; }
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Pateu(int getNewStockPateu, int getNewPricePateu)
        {
            _cantInitialaPateu = getNewStockPateu;
            _pretPateu = getNewPricePateu;
        }

        public static void AdaugaPateu()
        {

            Console.WriteLine("Introduceti numarul de produse de tip 'Pateu' pe care doriti sa le adaugati in inventar:");
            int nrProduse;
            string s = Console.ReadLine();
            bool result = int.TryParse(s, out nrProduse);

            while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
            {
                Console.WriteLine("Introduceti din nou un numar valabil:");
                s = Console.ReadLine();
                result = int.TryParse(s, out nrProduse);
            }

            string jsonString = File.ReadAllText("Inventar_Pateu.json");
            Pateu pPateu = JsonSerializer.Deserialize<Pateu>(jsonString);

            Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

            int stoc_nou_Pateu = pPateu._cantInitialaPateu + nrProduse;
            pPateu._cantInitialaPateu = stoc_nou_Pateu;

            jsonString = JsonSerializer.Serialize(pPateu);
            Console.WriteLine($"Noul stoc de 'Pateu' este: {pPateu.GetNewStockPateu} bucati");
            File.WriteAllText("Inventar_Pateu.json", jsonString);

        }

        public static void EliminaPateu()
        {
            string jsonString = File.ReadAllText("Inventar_Pateu.json");
            Pateu pPateu = JsonSerializer.Deserialize<Pateu>(jsonString);

            bool q = true;

            while (q)
            {
                if (pPateu.GetNewStockPateu > 0)
                {

                    Console.WriteLine("Introduceti numarul de produse de tip 'Pateu' pe care doriti sa le scoateti din inventar:");
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

                    if (pPateu.GetNewStockPateu >= nrProduse)
                    {
                        int stoc_nou_Pateu = pPateu._cantInitialaPateu - nrProduse;
                        pPateu._cantInitialaPateu = stoc_nou_Pateu;
                    }
                    else
                    {
                        Console.WriteLine($"In stoc au fost doar {pPateu.GetNewStockPateu} produse care s-au putut elimina.");
                        int stoc_nou_Pateu = pPateu._cantInitialaPateu - pPateu._cantInitialaPateu;
                        pPateu._cantInitialaPateu = stoc_nou_Pateu;
                    }

                    jsonString = JsonSerializer.Serialize(pPateu);
                    Console.WriteLine($"Noul stoc de 'Pateu' este: {pPateu.GetNewStockPateu} bucati");
                    File.WriteAllText("Inventar_Pateu.json", jsonString);
                    break;
                }
                else
                {
                    Console.WriteLine("Produsul ales nu exista in stoc.");
                    break;
                }
            }
        }

        public static void VindePateu()
        {
            string jsonString = File.ReadAllText("Inventar_Pateu.json");
            Pateu pPateu = JsonSerializer.Deserialize<Pateu>(jsonString);

            bool q = true;

            while (q)
            {

                Console.WriteLine("Introduceti numarul de produse de tip 'Pateu' pe care doriti sa le vindeti:");
                int nrProduse;
                string s = Console.ReadLine();
                bool result = int.TryParse(s, out nrProduse);

                if (pPateu.GetNewStockPateu > 0)
                {
                    pPateu._pretPateu = 3;

                    while (result == false || nrProduse < 0 || nrProduse % 1 != 0)
                    {
                        Console.WriteLine("Introduceti din nou un numar valabil:");
                        s = Console.ReadLine();
                        result = int.TryParse(s, out nrProduse);
                    }

                    Console.WriteLine("Numarul produselor introduse este: " + nrProduse + " bucati");

                    if (pPateu.GetNewStockPateu >= nrProduse)
                    {
                        int stoc_nou_Pateu = pPateu._cantInitialaPateu - nrProduse;
                        pPateu._cantInitialaPateu = stoc_nou_Pateu;
                        Console.WriteLine($"Noul stoc de 'Pateu' este: {pPateu.GetNewStockPateu} bucati");
                        Console.WriteLine($"Pret Pateu / bucata: {pPateu.GetNewPricePateu} RON");
                        Console.WriteLine($"Total: {pPateu.GetNewPricePateu * nrProduse} RON");
                    }
                    else
                    {
                        int pretTotal = pPateu.GetNewPricePateu * pPateu._cantInitialaPateu;

                        Console.WriteLine($"In stoc au fost doar {pPateu.GetNewStockPateu} produse care s-au putut vinde.");
                        int stoc_nou_Pateu = pPateu._cantInitialaPateu - pPateu._cantInitialaPateu;
                        pPateu._cantInitialaPateu = stoc_nou_Pateu;
                        Console.WriteLine($"Noul stoc de 'Pateu' este: {pPateu.GetNewStockPateu} bucati");
                        Console.WriteLine($"Pret Pateu / bucata: {pPateu.GetNewPricePateu} RON");
                        Console.WriteLine($"Total: {pretTotal} RON");
                    }

                    jsonString = JsonSerializer.Serialize(pPateu);
                    File.WriteAllText("Inventar_Pateu.json", jsonString);
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
