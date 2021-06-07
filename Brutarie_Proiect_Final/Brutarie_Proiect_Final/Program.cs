using System;

namespace Proiect_Test_Brutarie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            InventarBrutarie brutarie = new InventarBrutarie();
            brutarie.Run();

            

        }
    }
}

