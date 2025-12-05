using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektowe_2025_11_07_projekt
{
    public class Sprzentwodny
    {
        protected int wypornosc;
        protected float cenawynajmunadzien;
        protected int maxliczbaosobnapojazd;
        protected int ilesztukwmagazynie;
        protected int nailedniwynajmuje;
        protected float kaucjazwrotna;
        public Sprzentwodny() { }
        public Sprzentwodny(int wypornosc, float cenawynajmunadzien, int maxliczbaosob, int ilesztukwmagazynie, float kaucjazwrotna)
        {
            this.wypornosc = wypornosc;
            this.cenawynajmunadzien = cenawynajmunadzien;
            this.maxliczbaosobnapojazd = maxliczbaosob;
            this.ilesztukwmagazynie = ilesztukwmagazynie;
            this.kaucjazwrotna = kaucjazwrotna;
        }
        public void WynajmijPojazd(float ileplaci, int ilesztukwynajmuje, int nailedniwynajmuje)
        {
            if (ilesztukwmagazynie >= ilesztukwynajmuje)
            {
                float cena = ((cenawynajmunadzien * nailedniwynajmuje) + kaucjazwrotna) * ilesztukwynajmuje;
                if (ileplaci >= cena)
                {

                    ilesztukwmagazynie = ilesztukwmagazynie-ilesztukwynajmuje;
                    Console.WriteLine(ileplaci - cena + " reszty");
                }
                else
                {
                    Console.WriteLine("Za mała kwota, potrzebne jest " + cena + " by wynająć " + ilesztukwynajmuje);
                }
            }
            else
            {
                Console.WriteLine("nie ma tyle sztuk w magazynie jest" + ilesztukwmagazynie);
            }
        }
        public void IleSztukWMagazynie()
        {

            Console.WriteLine("W magazynie jest: "+ilesztukwmagazynie+" sztuk");

        }
        public void Odddajsprzet(bool czyuszkodzony, int ilesztukwynajmuje)
        {
            if (czyuszkodzony == false)
            {
                if (ilesztukwmagazynie >= 1)
                {
                    ilesztukwmagazynie += ilesztukwynajmuje;
                    Console.WriteLine(ilesztukwmagazynie + " Sztuk w magazynie należy oddać " + kaucjazwrotna+" zł");
                }
            }
            else
            {
                Console.WriteLine("nie oddawaj kaucji zwrotnej, jak wyjdzie z naprawy użyj 'SprzentNaprawiony'");
            }
        }
        public void NowySprzet()
        {
            ilesztukwmagazynie++;
        }
        public float CenaZadzien()
        {
            return cenawynajmunadzien;
        }
        public float KaucjaZwrotna()
        {
            return kaucjazwrotna;
        }
        public void ZapiszDoPliku(string nazwaobiektu, bool czyostatni)
        {
            string zapis =nazwaobiektu+":"+wypornosc.ToString()+":"+cenawynajmunadzien.ToString()+":"+ maxliczbaosobnapojazd.ToString() + ":" + ilesztukwmagazynie.ToString() + ":" + kaucjazwrotna.ToString()+":";
            if (czyostatni == false) { zapis +="\n"; }
            File.AppendAllText("sprzet.txt", zapis);
        }
    }
    public class Zaglowka : Sprzentwodny
    {
        protected bool czymapatent;
        public Zaglowka(int wypornosc, float cenawynajmunadzien, int maxliczbaosob, int ilesztukwmagazynie, float kaucjazwrotna) : base(wypornosc, cenawynajmunadzien, maxliczbaosob, ilesztukwmagazynie, kaucjazwrotna)
        {
            this.wypornosc = wypornosc;
            this.cenawynajmunadzien = cenawynajmunadzien;
            this.maxliczbaosobnapojazd = maxliczbaosob;
            this.ilesztukwmagazynie = ilesztukwmagazynie;
            this.kaucjazwrotna = kaucjazwrotna;
        }
        public Zaglowka()
        {

        }
        public void WynajmijZagluwke(float ileplaci, bool czymapatent, int nailedniwynajmuje)
        {
            float cena = (cenawynajmunadzien * nailedniwynajmuje) + kaucjazwrotna;
            if (czymapatent == true)
            {
                if (ilesztukwmagazynie >= 1)
                {
                    if (ileplaci >= cena)
                    {
                        Console.Write(ileplaci - cena);
                        Console.WriteLine(" reszty");
                        ilesztukwmagazynie--;
                    }
                    else { Console.Write("klient płaci za mało potrzebne jest"); Console.WriteLine((cenawynajmunadzien * nailedniwynajmuje) + kaucjazwrotna); }
                }
                else { Console.WriteLine("nie ma w magazynie"); }
            }
            else { Console.WriteLine("Bez patentu nie wynajmujemy"); }
        }
    }
    /*
    public class Kajak : Sprzentwodny
    {
        public Kajak(int wypornosc, float cenawynajmunadzien, int maxliczbaosobnapojazd, int ilesztukwmagazynie, float kaucjazwrotna) : base(wypornosc, cenawynajmunadzien, maxliczbaosobnapojazd, ilesztukwmagazynie, kaucjazwrotna)
        {
            this.wypornosc = wypornosc;
            this.cenawynajmunadzien = cenawynajmunadzien;
            this.maxliczbaosobnapojazd = maxliczbaosobnapojazd;
            this.ilesztukwmagazynie = ilesztukwmagazynie;
            this.kaucjazwrotna = kaucjazwrotna;
        }
    }*/
}
