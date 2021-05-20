using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brutarie_Proiect_Final
{
    class Panificatie
    {
        public static void ProcesarePanificatie()
        {
            Console.Clear();
            Meniu.AfiseazaMeniuAdaugaProduseInStoc();

            bool q2 = true;

            while (q2)
            {
                int raspuns2 = int.Parse(Console.ReadLine());
                if (raspuns2 == 0)
                {
                    Meniu.AfiseazaMeniuPrincipal();
                }
                else if (raspuns2 == 1)
                {
                    Console.WriteLine("Paine Franzela Bagheta");
                }
                else if (raspuns2 == 2)
                {
                    Console.WriteLine("Pateu Merdenea Covrig Corn");
                }
                else if (raspuns2 == 3)
                {
                    Console.WriteLine("Ecler Amandina Savarina Tort");
                }
                else
                {
                    Console.WriteLine("Optiunea nu corespunde cu nici un obiect din lista. Alege din nou:");
                }
            }
        }
    }
}
