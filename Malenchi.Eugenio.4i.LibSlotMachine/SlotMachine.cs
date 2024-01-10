namespace Eugenio.Malenchi._4i.LibSlotMachine
{
    public class SlotMachine
    {
        public int Saldo { get; set; }
        public int UltimaVincita { get; set; }
        public char Ruota1 { get; set; }
        public char Ruota2 { get; set; }
        public char Ruota3 { get; set; }

        private const int JACKPOT = 100;
        private const int VITTORIA_DIFFICILE = 50;

        public SlotMachine()
        {
            Saldo = 10;
            UltimaVincita = 0;
            Ruota1 = Ruota2 = Ruota3 = '-';
        }

        public void GiraSlotMachine()
        {
            if (Saldo == 0)
                throw new Exception("Hai finito il saldo a disposizione");

            Saldo--;

            Random r = new Random();

            Ruota1 = (char)r.Next(65, 91);
            Ruota2 = (char)r.Next(65, 91);
            Ruota3 = (char)r.Next(65, 91);

            if (JackPot())
                AggiungiVincita(JACKPOT);

            else if (VittoriaDifficile())
                AggiungiVincita(VITTORIA_DIFFICILE);

            else if (VittoriaSemplice())
                AggiungiVincita((int)Ruota1 - 64);

            else if (NessunaPerdita())
                AggiungiVincita(1);

            else
                UltimaVincita = 0;
        }

        public void GiraSlotMachine(bool blocca1, bool blocca2, bool blocca3)
        {
            if (Saldo == 0)
                throw new Exception("Hai finito il saldo a disposizione");

            Saldo--;

            Random r = new Random();

            if (!blocca1)
                Ruota1 = (char)r.Next(65, 91);

            if (!blocca2)
                Ruota2 = (char)r.Next(65, 91);

            if (!blocca3)
                Ruota3 = (char)r.Next(65, 91);

            if (JackPot())
                AggiungiVincita(JACKPOT);

            else if (VittoriaDifficile())
                AggiungiVincita(VITTORIA_DIFFICILE);

            else if (VittoriaSemplice())
                AggiungiVincita((int)Ruota1 - 64);

            else if (NessunaPerdita())
                AggiungiVincita(1);

            else
                UltimaVincita = 0;
        }

        private bool JackPot()
        {
            return (Ruota1 == 'Z' && Ruota2 == 'Z' && Ruota3 == 'Z');
        }

        private bool VittoriaDifficile()
        {
            return (Ruota2 == Ruota1 + 1 && Ruota3 == Ruota2 + 1);
        }

        private bool VittoriaSemplice()
        {
            return (Ruota1 == Ruota2 && Ruota2 == Ruota3);
        }

        private bool NessunaPerdita()
        {
            return (Ruota1 == Ruota2 || Ruota2 == Ruota3 || Ruota3 == Ruota1);
        }

        private void AggiungiVincita(int vincita)
        {
            Saldo += vincita;
            UltimaVincita = vincita;
        }
    }
}
