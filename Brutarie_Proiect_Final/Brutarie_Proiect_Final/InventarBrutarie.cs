using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brutarie_Proiect_Final
{
    class InventarBrutarie
    {
       public void Run()
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
                        Panificatie.ProcesarePanificatie();

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
