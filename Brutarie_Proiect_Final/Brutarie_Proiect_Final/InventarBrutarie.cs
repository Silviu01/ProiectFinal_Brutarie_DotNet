using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace Proiect_Test_Brutarie
{
    class InventarBrutarie
    {
        public void Run()
        {
            bool q = true;

            while (q)
            {
                Meniu.AfiseazaMeniuPrincipal();
                int input_1st_menu = int.Parse(Console.ReadLine());

                if (input_1st_menu == 1 || input_1st_menu == 2 || input_1st_menu == 3 || input_1st_menu == 4 || input_1st_menu == 5)
                {

                    if (input_1st_menu == 1)
                    {
                        Console.Clear();
                        Meniu.MeniuAdaugatiProduse();
                        Meniu.AfiseazaMeniuCategoriiProduse();

                        bool q2 = true;

                        while (q2)
                        {
                            int input_2nd_menu = int.Parse(Console.ReadLine());
                            if (input_2nd_menu == 0)
                            {
                                Meniu.AfiseazaMeniuPrincipal();
                            }
                            else if (input_2nd_menu == 1)
                            {
                                Console.Clear();
                                Panificatie.AfiseazaStocPanificatie();
                                Console.WriteLine("Alege produsul pe care doresti sa il adaugi in stoc:");
                                Meniu.ProcesarePanificatie();
                                int input_panificatie = int.Parse(Console.ReadLine());

                                if (input_panificatie == 0)
                                {
                                    Meniu.AfiseazaMeniuCategoriiProduse();
                                }
                                else if (input_panificatie == 1)
                                {
                                    Paine.AdaugaPaine();
                                    break;
                                }

                                else if (input_panificatie == 2)
                                {
                                    Franzela.AdaugaFranzela();
                                    break;
                                }
                                else if (input_panificatie == 3)
                                {
                                    Bagheta.AdaugaBagheta();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_panificatie = int.Parse(Console.ReadLine());
                                }
                            }
                            else if (input_2nd_menu == 2)
                            {
                                Console.Clear();
                                Patiserie.AfiseazaStocPatiserie();
                                Console.WriteLine("Alege produsul pe care doresti sa il adaugi in stoc:");
                                Meniu.ProcesarePatiserie();
                                int input_patiserie = int.Parse(Console.ReadLine());

                                if (input_patiserie == 0)
                                {
                                    Meniu.AfiseazaMeniuCategoriiProduse();
                                }
                                else if (input_patiserie == 1)
                                {
                                    Pateu.AdaugaPateu();
                                    break;
                                }

                                else if (input_patiserie == 2)
                                {
                                    Merdenea.AdaugaMerdenea();
                                    break;
                                }
                                else if (input_patiserie == 3)
                                {
                                    Covrig.AdaugaCovrig();
                                    break;
                                }
                                else if (input_patiserie == 4)
                                {
                                    Corn.AdaugaCorn();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_patiserie = int.Parse(Console.ReadLine());
                                }
                            }
                            else if (input_2nd_menu == 3)
                            {
                                Console.Clear();
                                Cofetarie.AfiseazaStocCofetarie();
                                Console.WriteLine("Alege produsul pe care doresti sa il adaugi in stoc:");
                                Meniu.ProcesareCofetarie();
                                int input_cofetarie = int.Parse(Console.ReadLine());

                                if (input_cofetarie == 0)
                                {
                                    Meniu.AfiseazaMeniuCategoriiProduse();
                                }
                                else if (input_cofetarie == 1)
                                {
                                    Ecler.AdaugaEcler();
                                    break;
                                }

                                else if (input_cofetarie == 2)
                                {
                                    Amandina.AdaugaAmandina();
                                    break;
                                }
                                else if (input_cofetarie == 3)
                                {
                                    Savarina.AdaugaSavarina();
                                    break;
                                }
                                else if (input_cofetarie == 4)
                                {
                                    Tort.AdaugaTort();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_cofetarie = int.Parse(Console.ReadLine());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Optiunea nu corespunde cu nici un obiect din lista. Alege din nou:");
                            }
                        }
                    }
                    else if (input_1st_menu == 2)
                    {
                        Console.Clear();
                        Meniu.MeniuVindetiProduse();
                        Meniu.AfiseazaMeniuCategoriiProduse();

                        bool q2 = true;

                        while (q2)
                        {
                            int input_2nd_menu = int.Parse(Console.ReadLine());
                            if (input_2nd_menu == 0)
                            {
                                Meniu.AfiseazaMeniuPrincipal();
                            }
                            else if (input_2nd_menu == 1)
                            {
                                Console.Clear();
                                Panificatie.AfiseazaStocPanificatie();
                                Console.WriteLine("Alege produsul pe care doresti sa il vinzi:");
                                Meniu.ProcesarePanificatie();
                                int input_panificatie = int.Parse(Console.ReadLine());

                                if (input_panificatie == 1)
                                {
                                    Paine.VindePaine();
                                    break;
                                }
                                else if (input_panificatie == 2)
                                {
                                    Franzela.VindeFranzela();
                                    break;
                                }
                                else if (input_panificatie == 3)
                                {
                                    Bagheta.VindeBagheta();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_panificatie = int.Parse(Console.ReadLine());
                                }
                            }
                            else if (input_2nd_menu == 2)
                            {
                                Console.Clear();
                                Patiserie.AfiseazaStocPatiserie();
                                Console.WriteLine("Alege produsul pe care doresti sa il vinzi:");
                                Meniu.ProcesarePatiserie();
                                int input_patiserie = int.Parse(Console.ReadLine());

                                if (input_patiserie == 1)
                                {
                                    Pateu.VindePateu();
                                    break;
                                }
                                else if (input_patiserie == 2)
                                {
                                    Merdenea.VindeMerdenea();
                                    break;
                                }
                                else if (input_patiserie == 3)
                                {
                                    Covrig.VindeCovrig();
                                    break;
                                }
                                else if (input_patiserie == 4)
                                {
                                    Corn.VindeCorn();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_patiserie = int.Parse(Console.ReadLine());
                                }
                            }
                            else if (input_2nd_menu == 3)
                            {
                                Console.Clear();
                                Cofetarie.AfiseazaStocCofetarie();
                                Console.WriteLine("Alege produsul pe care doresti sa il vinzi:");
                                Meniu.ProcesareCofetarie();
                                int input_cofetarie = int.Parse(Console.ReadLine());

                                if (input_cofetarie == 1)
                                {
                                    Ecler.VindeEcler();
                                    break;
                                }
                                else if (input_cofetarie == 2)
                                {
                                    Amandina.VindeAmandina();
                                    break;
                                }
                                else if (input_cofetarie == 3)
                                {
                                    Savarina.VindeSavarina();
                                    break;
                                }
                                else if (input_cofetarie == 4)
                                {
                                    Tort.VindeTort();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_cofetarie = int.Parse(Console.ReadLine());
                                }
                            }
                        }
                    }
                    else if (input_1st_menu == 3)
                    {
                        Console.Clear();
                        Meniu.MeniuEliminatiProduse();
                        Meniu.AfiseazaMeniuCategoriiProduse();

                        bool q2 = true;

                        while (q2)
                        {
                            int input_2nd_menu = int.Parse(Console.ReadLine());
                            if (input_2nd_menu == 0)
                            {
                                Meniu.AfiseazaMeniuPrincipal();
                            }
                            else if (input_2nd_menu == 1)
                            {
                                Console.Clear();
                                Panificatie.AfiseazaStocPanificatie();
                                Console.WriteLine("Alege produsul pe care doresti sa il elimini din stoc:");
                                Meniu.ProcesarePanificatie();
                                int input_panificatie = int.Parse(Console.ReadLine());

                                if (input_panificatie == 1)
                                {
                                    Paine.EliminaPaine();
                                    break;
                                }
                                else if (input_panificatie == 2)
                                {
                                    Franzela.EliminaFranzela();
                                    break;
                                }
                                else if (input_panificatie == 3)
                                {
                                    Bagheta.EliminaBagheta();
                                    break;
                                }
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_panificatie = int.Parse(Console.ReadLine());
                                }
                            }
                            else if (input_2nd_menu == 2)
                            {
                                Console.Clear();
                                Patiserie.AfiseazaStocPatiserie();
                                Console.WriteLine("Alege produsul pe care doresti sa il elimini din stoc:");
                                Meniu.ProcesarePatiserie();
                                int input_patiserie = int.Parse(Console.ReadLine());

                                if (input_patiserie == 1)
                                {
                                    Pateu.EliminaPateu();
                                    break;
                                }
                                else if (input_patiserie == 2)
                                {
                                    Merdenea.EliminaMerdenea();
                                    break;
                                }
                                else if (input_patiserie == 3)
                                {
                                    Covrig.EliminaCovrig();
                                    break;
                                }
                                else if (input_patiserie == 4)
                                {
                                    Corn.EliminaCorn();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_patiserie = int.Parse(Console.ReadLine());
                                }
                            }
                            else if (input_2nd_menu == 3)
                            {
                                Console.Clear();
                                Cofetarie.AfiseazaStocCofetarie();
                                Console.WriteLine("Alege produsul pe care doresti sa il elimini din stoc:");
                                Meniu.ProcesareCofetarie();
                                int input_cofetarie = int.Parse(Console.ReadLine());

                                if (input_cofetarie == 1)
                                {
                                    Ecler.EliminaEcler();
                                    break;
                                }
                                else if (input_cofetarie == 2)
                                {
                                    Amandina.EliminaAmandina();
                                    break;
                                }
                                else if (input_cofetarie == 3)
                                {
                                    Savarina.EliminaSavarina();
                                    break;
                                }
                                else if (input_cofetarie == 4)
                                {
                                    Tort.EliminaTort();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please select again!");
                                    input_cofetarie = int.Parse(Console.ReadLine());
                                }
                            }
                        }
                    }
                }
                else if (input_1st_menu == 0)
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

