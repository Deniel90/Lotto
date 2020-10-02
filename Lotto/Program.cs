﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Készíts programot, amely bekér öt számot 1 és 90 tartományból. 
            A számok nem ismétlődhetnek. A program írja ki, hogy az eddigi számhúzások alapján (minden héten megjátszotta) 
            hány darab kettes, hármas, négyes, vagy ötös találata lett volna.
            */

            List<int> szamok = new List<int>();
            Console.WriteLine("Lottósorsoláshoz kérek 5 különböző számot 1-90-ig");
            int db = 0;
            int szam;
            do
            {
                do
                {
                    Console.Write((db + 1) + " szám: ");
                } while (!Int32.TryParse(Console.ReadLine(), out szam) || (szam < 1 || szam > 90));

                if (!szamok.Contains(szam))
                {
                    db++;
                    szamok.Add(szam);
                }

            } while (szamok.Count < 5);

            //korábbi lottószámok beolvasása Osztály típusú listába
            List<KorabbiSzamok> korabbiszamok = new List<KorabbiSzamok>();
            StreamReader sr = new StreamReader("otos.csv");
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(';');
                korabbiszamok.Add(new KorabbiSzamok(int.Parse(temp[11]), int.Parse(temp[12]), int.Parse(temp[13]), int.Parse(temp[14]), int.Parse(temp[15])));
            }

            //saját lottószámok összevetése a korábbi számokkal
            int talalat;
            int kettes_talalat = 0;
            int harmas_talalat = 0;
            int negyes_talalat = 0;
            int otos_talalat = 0;

            //találatok keresése
            for (int i = 0; i < korabbiszamok.Count; i++)
            {
                talalat = 0;

                if (szamok.Contains(korabbiszamok[i].Szam1))
                {
                    talalat++;
                }
                if (szamok.Contains(korabbiszamok[i].Szam2))
                {
                    talalat++;
                }
                if (szamok.Contains(korabbiszamok[i].Szam3))
                {
                    talalat++;
                }
                if (szamok.Contains(korabbiszamok[i].Szam4))
                {
                    talalat++;
                }
                if (szamok.Contains(korabbiszamok[i].Szam5))
                {
                    talalat++;
                }

                //nyereményes találatok bejegyzése
                switch (talalat)
                {
                    case 5: otos_talalat++; break;
                    case 4: negyes_talalat++; break;
                    case 3: harmas_talalat++; break;
                    case 2: kettes_talalat++; break;
                    default: break;
                }

            }

            Console.ReadKey();

        }
    }
}
