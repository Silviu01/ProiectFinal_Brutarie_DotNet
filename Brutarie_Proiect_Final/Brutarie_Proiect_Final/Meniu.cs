using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Test_Brutarie
{
    class Meniu
    {
        public static void AfiseazaMeniuPrincipal()
        {
            Console.WriteLine("Alege numarul corespunzator uneia dintre optiunile de mai jos:");
            Console.WriteLine("\n1.Adaugă produse în stoc");
            Console.WriteLine("2.Vinde produse");
            Console.WriteLine("3.Elimină produse din stoc");
            Console.WriteLine("4.Înregistrează comenzi // Work in Progress");
            Console.WriteLine("5.Afisează stoc si vânzări // Work in Progress");
            Console.WriteLine("0.Închidere program");
        }

        public static void MeniuAdaugatiProduse()
        {
            Console.WriteLine("Doriti sa adaugati:");
        }

        public static void MeniuEliminatiProduse()
        {
            Console.WriteLine("Doriti sa eliminati:");
        }

        public static void MeniuVindetiProduse()
        {
            Console.WriteLine("Doriti sa vindeti:");
        }

        public static void AfiseazaMeniuCategoriiProduse()
        {
            Console.WriteLine("1.Panificatie");
            Console.WriteLine("2.Patiserie");
            Console.WriteLine("3.Cofetarie");
            Console.WriteLine("0.Revenire la ecranul principal");

        }

        public static void ProcesarePanificatie()
        {
            Console.WriteLine("1.Paine");
            Console.WriteLine("2.Franzela");
            Console.WriteLine("3.Bagheta");
            Console.WriteLine("0.Revenire la ecranul anterior");
        }

        public static void ProcesarePatiserie()
        {
            Console.WriteLine("1.Pateu");
            Console.WriteLine("2.Merdenea");
            Console.WriteLine("3.Covrig");
            Console.WriteLine("4.Corn");
            Console.WriteLine("0.Revenire la ecranul anterior");
        }

        public static void ProcesareCofetarie()
        {
            Console.WriteLine("1.Ecler");
            Console.WriteLine("2.Amandina");
            Console.WriteLine("3.Savarina");
            Console.WriteLine("4.Tort");
            Console.WriteLine("0.Revenire la ecranul anterior");
        }

    }
}
