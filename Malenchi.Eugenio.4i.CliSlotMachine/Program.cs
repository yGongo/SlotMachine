
using Malenchi.Eugenio._4i.LibSlotMachine;

namespace Malenchi.Eugenio._4i.CliSlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Book Of Rah!");
            SlotMachine s = new SlotMachine(10);
            Console.WriteLine(s.Credito);
        }
    }
}