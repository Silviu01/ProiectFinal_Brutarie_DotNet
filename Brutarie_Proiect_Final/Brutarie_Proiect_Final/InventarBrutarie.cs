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
                                Console.Clear();
                                Panificatie.ProcesarePanificatie();
                                int raspuns3 = int.Parse(Console.ReadLine());                                
                                
                                while (true)
                                {
                                    if (raspuns3 == 1)
                                    {
                                        //doar pt verificare functionalitate
                                        Console.WriteLine("ai introdus 1");
                                        break;
                                    }
                                    else if (raspuns3 == 2)
                                    {
                                        //doar pt verificare functionalitate
                                        Console.WriteLine("ai introdus 2");
                                        break;
                                    }
                                    else if (raspuns3 == 3)
                                    {
                                        //doar pt verificare functionalitate
                                        Console.WriteLine("ai introdus 3");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input, please select again!");
                                        raspuns3 = int.Parse(Console.ReadLine());
                                    }                                    
                                }

                            }
                            else if (raspuns2 == 2)
                            {
                                Console.Clear();
                                Patiserie.ProcesarePatiserie();
                            }
                            else if (raspuns2 == 3)
                            {
                                Console.Clear();
                                Cofetarie.ProcesareCofetarie();
                            }
                            else
                            {
                                Console.WriteLine("Optiunea nu corespunde cu nici un obiect din lista. Alege din nou:");
                            }

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
