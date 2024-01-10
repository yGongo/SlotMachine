using Eugenio.Malenchi._4i.LibSlotMachine;

namespace Malenchi.Eugenio._4i.CliSlotMachine
{
    internal partial class Program
    {
        SlotMachine slotMachine = new();
        int contatore1 = 0;
        int contatore2 = 0;
        int contatore3 = 0;
        bool blocca1 = false;
        bool blocca3 = false;
        bool blocca2 = false;

        private static void Main()
        {
            Program programma = new();
            programma.MainProgramma();
        }

        private void MainProgramma()
        {
            bool menu = true;

            Console.WriteLine(("SlotMachine"));

            while (menu)
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(($"\t {slotMachine.Ruota1} | {slotMachine.Ruota2} | {slotMachine.Ruota3}"));
                Console.ResetColor();

                Console.WriteLine($"\t Credito rimasto {slotMachine.Saldo}");
                Console.WriteLine($"\t Ultima vincita {slotMachine.UltimaVincita}");
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
                            slotMachine.GiraSlotMachine(blocca1, blocca2, blocca3);
                            Verifica();
                            Console.Clear();
                        }
                        catch (Exception e)
                        {
                            Console.Clear();

                            Console.WriteLine(e.Message);
                            Console.WriteLine("Vuoi ricominciare da capo? (s / n)");
                            switch (Console.ReadKey().KeyChar)
                            {
                                case 's':
                                    slotMachine = new SlotMachine();
                                    break;

                                case 'n':
                                    Console.Clear();
                                    Console.WriteLine(("Arrivederci"));
                                    Console.ReadKey();
                                    menu = false;
                                    break;

                                default:
                                    Console.WriteLine("Devi scegliere tra s (si) e n (no)");
                                    break;
                            }
                        }
                        break;

                    case '2':
                        if (blocca1 == false && !(blocca2 == true && blocca3 == true))
                            blocca1 = true;
                        else
                            blocca1 = false;

                        Console.WriteLine(" - Hai bloccato la prima lettera per 2 turni");
                        break;

                    case '3':
                        if (blocca2 == false && !(blocca1 == true && blocca3 == true))
                            blocca2 = true;
                        else
                            blocca2 = false;

                        Console.WriteLine(" - Hai bloccato la seconda lettera per 2 turni");
                        break;

                    case '4':
                        if (blocca3 == false && !(blocca1 == true && blocca2 == true))
                            blocca3 = true;
                        else
                            blocca3 = false;

                        Console.WriteLine(" - Hai bloccato la terza lettera per 2 turni");
                        break;

                }
            }
        }

        public void Verifica()
        {
            if (blocca1 == true)
                contatore1++;

            if (contatore1 == 2)
            {
                blocca1 = false;
                contatore1 = 0;
            }

            if (blocca2 == true)
                contatore2++;

            if (contatore2 == 2)
            {
                blocca2 = false;
                contatore2 = 0;
            }

            if (blocca3 == true)
                contatore3++;

            if (contatore3 == 2)
            {
                blocca3 = false;
                contatore3 = 0;
            }
        }
    }
}