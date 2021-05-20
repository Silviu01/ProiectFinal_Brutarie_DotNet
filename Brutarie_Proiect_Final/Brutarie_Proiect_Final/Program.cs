using System;

namespace Brutarie_Proiect_Final
{
    class Program
    {
        static void Main(string[] args)
        {

            bool q = true;

            while (q)
            {
                Meniu.AfiseazaMeniuPrincipal();
                int raspuns = int.Parse(Console.ReadLine());

                if (raspuns == 1 || raspuns == 2 || raspuns == 3 || raspuns == 4 || raspuns == 5)
                {

                    if (raspuns == 1)
                    {
                        Console.Clear();
                        Meniu.AfiseazaMeniuAdaugaProduseInStoc();

                        int raspuns2 = int.Parse(Console.ReadLine());
                        if (raspuns2 == 0)
                        {
                            Meniu.AfiseazaMeniuPrincipal();
                        }
                    }

                }
                else if (raspuns == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Optiunea nu corespunde cu nici un obiect din lista. Alege din nou:");
                }
            }






        }
    }
}
