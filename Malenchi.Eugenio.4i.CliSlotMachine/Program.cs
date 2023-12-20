
using Malenchi.Eugenio._4i.LibSlotMachine;

namespace Malenchi.Eugenio._4i.CliSlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SlotMachine s = new SlotMachine(10);
            bool menu = true;
            while (menu)
            {
                Console.WriteLine();
                Console.WriteLine(($"\t {s.Roll0} | {s.Roll1} | {s.Roll2}"));
                Console.ResetColor();

                Console.WriteLine($"\t Credito rimasto {s.Credito}");
                Console.WriteLine($"\t Ultima vincita {s.LastWin}");
                Console.WriteLine();

                Console.WriteLine("1- Gira la Ruota");

                Console.WriteLine("2- Blocca la prima lettera");
                Console.WriteLine("3- Blocca la seconda lettera");
                Console.WriteLine("4- Blocca la terza lettera");
                Console.WriteLine();

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        try
                        {
                            s.Spin();
                            //Checker();
                            Console.Clear();
                        }
                        catch (Exception e)
                        {
                            Console.Clear();

                            Console.WriteLine(e.Message);
                            Console.WriteLine("Vuoi ricominciare da capo? (y / n)");
                            switch (Console.ReadKey().KeyChar)
                            {
                                case 'y':
                                    s = new SlotMachine(10);
                                    break;

                                case 'n':
                                    Console.Clear();
                                    Console.WriteLine(("Arrivederci"));
                                    Console.ReadKey();
                                    menu = false;
                                    break;

                                default:
                                    Console.WriteLine("Devi scegliere tra y (si) e n (no)");
                                    break;
                            }
                        }
                        break;

                    case '2':
                        if (s.Roll0 == ' ' && !(s.Roll1 == ' ' && s.Roll2 == ' '))
                            s.Roll0 = 'X';
                        else
                            s.Roll0 = ' ';

                        Console.WriteLine(" - Hai bloccato la prima lettera per 2 turni");
                        break;

                    case '3':
                        if (s.Roll1 == ' ' && !(s.Roll0 == ' ' && s.Roll2 == ' '))
                            s.Roll1 = 'X';
                        else
                            s.Roll1 = ' ';

                        Console.WriteLine(" - Hai bloccato la seconda lettera per 2 turni");
                        break;

                    case '4':
                        if (s.Roll2 == ' ' && !(s.Roll0 == ' ' && s.Roll1 == ' '))
                            s.Roll2 = 'X';
                        else
                            s.Roll2 = ' ';

                        Console.WriteLine(" - Hai bloccato la terza lettera per 2 turni");
                        break;
                }

            }

        }
    }
}