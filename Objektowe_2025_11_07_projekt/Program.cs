using System.Collections.Specialized;

namespace Objektowe_2025_11_07_projekt
{
    internal class Program
    {


        static string ZwrocPomiedzy(string line, char start, char end)
        {
            int i = line.IndexOf(start);
            int j = line.IndexOf(end, i + 1);
            return line.Substring(i + 1, j - i - 1);
        }
        static string ZwrocOdPierwszego(string line, char start)
        {
            int i = line.IndexOf(start);
            return line.Substring(i + 1, line.Length - i - 1);
        }
        static string ZwrocPierwsze(string line, char end)
        {
            int j = line.IndexOf(end, 1);
            return line.Substring(0, j);
        }
        static void Main(string[] args)
        {
            Zaglowka katamaran=new();
            Sprzentwodny kajakmaly = new();
            Sprzentwodny kajakduzy = new();
            StreamReader sr = new StreamReader("sprzet.txt");
            string linia;
            while ((linia = sr.ReadLine()) != null)
            {
                string nazwa, wypornosc, cena, ileosob, ilesztuk, kaucjazwrotna;
                nazwa = ZwrocPierwsze(linia, ':');
                linia = ZwrocOdPierwszego(linia,':');
                Console.WriteLine(linia);

                wypornosc = ZwrocPierwsze(linia, ':');
                linia = ZwrocOdPierwszego(linia, ':');
                Console.WriteLine(linia);

                cena = ZwrocPierwsze(linia, ':');
                linia = ZwrocOdPierwszego(linia, ':');
                Console.WriteLine(linia);

                ileosob = ZwrocPierwsze(linia, ':');
                linia = ZwrocOdPierwszego(linia, ':');
                Console.WriteLine(linia);

                ilesztuk = ZwrocPierwsze(linia, ':');
                linia = ZwrocOdPierwszego(linia, ':');
                Console.WriteLine(linia);
                //jdcwgusyjxfegdysxjgfedrh
                kaucjazwrotna = ZwrocPierwsze(linia, ':'); ;
                Console.WriteLine(linia);

                if (nazwa == "katamaran")
                {
                    katamaran = new(int.Parse(wypornosc), float.Parse(cena), int.Parse(ileosob), int.Parse(ilesztuk), int.Parse(kaucjazwrotna));
                }
                if (nazwa == "kajakmaly")
                {
                    kajakmaly = new(int.Parse(wypornosc), float.Parse(cena), int.Parse(ileosob), int.Parse(ilesztuk), int.Parse(kaucjazwrotna));
                }
                if (nazwa == "kajakduzy")
                {
                    kajakduzy = new(int.Parse(wypornosc), float.Parse(cena), int.Parse(ileosob), int.Parse(ilesztuk), int.Parse(kaucjazwrotna));
                }
            }
            sr.Close();
            bool czykoniec = false;
            while (czykoniec == false)
            {


                Console.WriteLine("Typ pojazdu");
                string typ = Console.ReadLine();

                if (typ == "katamaran")
                {
                    string cozrobic;
                    do
                    {
                        Console.WriteLine("Co robisz?: Wynajmij 0, IleSztukWMagazynie 1, Odddajsprzet 2, NowySprzet 3, co innego wyjdź");
                        cozrobic = Console.ReadLine();
                        if (cozrobic == "0")
                        {
                            Console.WriteLine("ile klient płaci? wynajem na dziań kosztuje" + katamaran.CenaZadzien());
                            string placi = Console.ReadLine();

                            Console.WriteLine("czy ma patent? tak / nie");
                            string patent = Console.ReadLine();
                            bool patentbool = false;
                            if (patent == "tak")
                            {
                                patentbool = true;
                            }

                            Console.WriteLine("na ile dni wynajmuje");
                            string iledni = Console.ReadLine();

                            katamaran.WynajmijZagluwke(float.Parse(placi), patentbool, int.Parse(iledni));
                        }
                        if (cozrobic == "1")
                        {
                            katamaran.IleSztukWMagazynie();
                        }
                        if (cozrobic == "2")
                        {
                            string uszkodzony;
                            bool czyuszkodzony;
                            do
                            {
                                Console.WriteLine("czy uszkodzony? tak/nie");
                                uszkodzony = Console.ReadLine();
                            }
                            while (uszkodzony != "tak" || uszkodzony == "nie");
                            if (uszkodzony == "tak") { czyuszkodzony = true; }
                            else { czyuszkodzony = false; }
                            katamaran.Odddajsprzet(czyuszkodzony, 1);
                        }
                        if (cozrobic == "3")
                        {
                            katamaran.NowySprzet();
                        }
                    } while (cozrobic=="0" || cozrobic == "1" || cozrobic == "2" || cozrobic == "3");
                }
                else if (typ == "kajakmaly")
                {
                    string cozrobic;
                    do
                    {
                        Console.WriteLine("Co robisz?: Wynajmij 0, IleSztukWMagazynie 1, Odddajsprzet 2, NowySprzet 3, co innego wyjdź");
                        cozrobic = Console.ReadLine();
                        if (cozrobic == "0")
                        {
                            Console.WriteLine("ile klient płaci? wynajem na dziań kosztuje" + kajakmaly.CenaZadzien());
                            string placi = Console.ReadLine();

                            Console.WriteLine("ile sztuk?");
                            string ilesztuk = Console.ReadLine();

                            Console.WriteLine("na ile dni wynajmuje");
                            string iledni = Console.ReadLine();

                            kajakmaly.WynajmijPojazd(float.Parse(placi), int.Parse(ilesztuk), int.Parse(iledni));
                        }
                        if (cozrobic == "1")
                        {
                            kajakmaly.IleSztukWMagazynie();
                        }
                        if (cozrobic == "2")
                        {
                            string uszkodzony;
                            bool czyuszkodzony;
                            do
                            {
                                Console.WriteLine("czy uszkodzony? tak/nie");
                                uszkodzony = Console.ReadLine();
                            }
                            while (uszkodzony != "tak" || uszkodzony == "nie");
                            if (uszkodzony == "tak") { czyuszkodzony = true; }
                            else { czyuszkodzony = false; }
                            kajakmaly.Odddajsprzet(czyuszkodzony, 1);
                        }
                        if (cozrobic == "3")
                        {
                            kajakmaly.NowySprzet();
                        }
                    } while (cozrobic == "0" || cozrobic == "1" || cozrobic == "2" || cozrobic == "3");
                }
                else if (typ == "kajakduzy")
                {
                    string cozrobic;
                    do
                    {
                        Console.WriteLine("Co robisz?: Wynajmij 0, IleSztukWMagazynie 1, Odddajsprzet 2, NowySprzet 3, co innego wyjdź");
                        cozrobic = Console.ReadLine();
                        if (cozrobic == "0")
                        {
                            Console.WriteLine("ile klient płaci? wynajem na dziań kosztuje" + kajakduzy.CenaZadzien());
                            string placi = Console.ReadLine();

                            Console.WriteLine("ile sztuk?");
                            string ilesztuk = Console.ReadLine();

                            Console.WriteLine("na ile dni wynajmuje");
                            string iledni = Console.ReadLine();

                            kajakduzy.WynajmijPojazd(float.Parse(placi), int.Parse(ilesztuk), int.Parse(iledni));
                        }
                        if (cozrobic == "1")
                        {
                            kajakduzy.IleSztukWMagazynie();
                        }
                        if (cozrobic == "2")
                        {
                            string uszkodzony;
                            bool czyuszkodzony;
                            do
                            {
                                Console.WriteLine("czy uszkodzony? tak/nie");
                                uszkodzony = Console.ReadLine();
                            }
                            while (uszkodzony != "tak" || uszkodzony == "nie");
                            if (uszkodzony == "tak") { czyuszkodzony = true; }
                            else { czyuszkodzony = false; }
                            kajakduzy.Odddajsprzet(czyuszkodzony, 1);
                        }
                        if (cozrobic == "3")
                        {
                            kajakduzy.NowySprzet();
                        }
                    } while (cozrobic == "0" || cozrobic == "1" || cozrobic == "2" || cozrobic == "3");
                }



                StreamWriter sw = new StreamWriter("sprzet.txt");
                sw.Write("");
                sw.Close();
                katamaran.ZapiszDoPliku("katamaran", false);
                kajakmaly.ZapiszDoPliku("kajakmaly", false);
                kajakduzy.ZapiszDoPliku("kajakduzy", true);
                Console.WriteLine("Czy zakończyć pracę?");
                if (Console.ReadLine() == "tak")
                {
                    czykoniec = true;
                }
            }
            

        }
    }
}
