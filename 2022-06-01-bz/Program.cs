using System;
using System.Collections.Generic;
using System.IO;

namespace _2022_06_01_bz
{
    class Program
    {        
        static List<FagyiClass> lista_Fagyi = new List<FagyiClass>();
        static string fajlnev = "fagyi.txt";


        static void Beker()
        {
            string benev = "a";
            while (benev != "")
            {
                Console.Clear();
                Console.WriteLine("==========   A D A T O K   B E K É R É S E   ==========");
                Console.WriteLine("Kérem a vásárló nevét (Üres jelre kilép)!");
                benev = Console.ReadLine();
                if (benev == "")
                {
                    Console.WriteLine("Visszalépés főmenübe...");
                    // Console.ReadKey();
                }
                else
                {
                    FagyiClass fagyi = new FagyiClass();
                    fagyi.nev = benev;
                    Console.WriteLine("Kérem a gombócok számát (max 10)!");
                    fagyi.gomboc = Convert.ToInt32(Console.ReadLine());
                    if (fagyi.gomboc > 10 )
                    {
                        Console.WriteLine("Túl sok gombócot adtál meg, így 10-et kapsz csak! :P :D");
                        fagyi.gomboc = 10;
                        //Console.WriteLine("Billentyűre tovább...");
                        //Console.ReadKey();
                    }

                    
                    string benem = "";
                    int van = 0;
                    do
                    {
                        Console.WriteLine("Kérem a vásárló nemét (férfi vagy nő)!");
                        benem = Console.ReadLine();
                        if (benem == "férfi" || benem == "nő")
                        {
                            Console.WriteLine(benem);
                            van = 1;

                        }
                    }
                    while (van != 1);
                    fagyi.nem = benem;
                    lista_Fagyi.Add(fagyi);
                }
            }

            // Lista kiiratása
            Console.WriteLine("Lista elemeinek kiiratása: ");
            foreach (FagyiClass a in lista_Fagyi)
            {
                Console.WriteLine(a.nev + "\t" + Convert.ToString(a.gomboc) + "\t" + a.nem);
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void ForditottLista()
        {
            Console.Clear();
            Console.WriteLine("==========   F O R D Í T O T T   L I S T A   K I I R A T Á S A   ==========");
            for (int i = lista_Fagyi.Count-1; i >= 0; i--)
            {
                Console.WriteLine(lista_Fagyi[i].nev + "\t" + Convert.ToString(lista_Fagyi[i].gomboc) + "\t" + lista_Fagyi[i].nem);
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void Fajlbair()
        {
            Console.Clear();
            Console.WriteLine("\n==========   F Á J L B A   Í R Á S   ==========");
            StreamWriter kiir = new StreamWriter(fajlnev);
            // Lista kiiratása
            Console.WriteLine("Lista elemeinek kiírása fájlba... ");
            foreach (FagyiClass a in lista_Fagyi)
            {
                kiir.WriteLine(a.nev + "\t" + Convert.ToString(a.gomboc) + "\t" + a.nem);
            }
            kiir.Flush();
            kiir.Close();

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }
        static void Fajlbolbe()
        {
            Console.Clear();
            Console.WriteLine("\n==========   F Á J L B Ó L   B E O L V A S Á S   ==========");
            StreamReader beolvas = new StreamReader(fajlnev);
            // Lista beolvasása
            Console.WriteLine("Lista elemeinek beolvasása fájlból... ");
            // IDE JÖN A BEOLVASÁS
            string s = beolvas.ReadLine();
            while (s != null)
            {
                Console.WriteLine(s);
                s = beolvas.ReadLine();
            }
            // BEOLVASÁS VÉGE
            beolvas.Close();

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void Fomenu()
        {
            Console.Clear();
            Console.WriteLine("==========   F Ő M E N Ű   ==========");
            Console.WriteLine("1., Adatok bekérése");
            Console.WriteLine("2., Fordított lista");
            Console.WriteLine("8., Fájlba írás");
            Console.WriteLine("9., Fájlból betöltés");
            Console.WriteLine("0., Kilépés");
            string menupont = Console.ReadLine();
            switch (Convert.ToInt32(menupont))
            {
                case 1:
                    Beker();
                    break;
                case 2:
                    ForditottLista();
                    break;
                case 8:
                    Fajlbair();
                    break;
                case 9:
                    Fajlbolbe();
                    break;
                case 0:
                    return;
                default:
                    return;
            }
        }

        static void Main(string[] args)
        {
            Fomenu();
        }
    }
}

// fordított lista
// legtöbb nő
// legtöbb férfi