using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brutarie_Proiect_Final
{
    class Meniu
    {
        public static void AfiseazaMeniuPrincipal()
        {
            Console.WriteLine("Alege numarul corespunzator uneia dintre optiunile de mai jos:");
            Console.WriteLine("\n1.Adaugă produse în stoc");
            Console.WriteLine("2.Vinde produse");
            Console.WriteLine("3.Elimină produse din stoc");
            Console.WriteLine("4.Înregistrează comenzi");
            Console.WriteLine("5.Afisează stoc si vânzări");
            Console.WriteLine("0.Închidere program");
        }


        public static void AfiseazaMeniuAdaugaProduseInStoc()
        {
            Console.WriteLine("Doriti sa adaugati:");
            Console.WriteLine("1.Panificatie");
            Console.WriteLine("2.Patiserie");
            Console.WriteLine("3.Cofetarie");
            Console.WriteLine("0.Revenire la ecranul anterior");

        }

    }
}
