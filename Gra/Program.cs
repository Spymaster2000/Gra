using System;
using System.Diagnostics.SymbolStore;

namespace Gra_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------");
            Console.Write("Kliknij \"Enter\" aby zacząć gre: ");
            Console.ReadLine(); // Rozpoczęcie Gry

            string Imię; // zmienna odpowiadająca za imię



            while (true)
            {
                Console.WriteLine("------------------------------------------");
                Console.Write("Wpisz nazwe swojej postaci: ");
                Imię = Console.ReadLine(); // zmienna odpowiadająca za imię postaci

                if (Imię != string.Empty) // Program sprawdza czy Imie jest wpisane
                {
                    break;
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Nie wpisałeś imienia swojej postaci");
            }

            Console.WriteLine("------------------------------------------");

            Random random = new Random(); // tworzymy obiekt typu random 

            int[] StatystykiPostaci = { 100, 5 }; // Statystyki postaci na miejscu 0 jest ilość Hp a na 1 ilość Ad
            int AdPotwora; // Ad potwora
            int HpPotwora; // hp potwora
            int ZabitePotwory = 0; //ilość zabitych potworów
            int Kolejność = 0; // flaga informująca która pętla jest wykorzystywana 
            Console.WriteLine("Twoje imię to \"{0}\"", Imię);
            Console.WriteLine("------------------------------------------");

            while (StatystykiPostaci[0] > 0) // Program sprawdza czy postać żyje 
            {
                Console.WriteLine($"Obecnie posiadasz {StatystykiPostaci[0]} Hp, a twoje obrażenia są równe {StatystykiPostaci[1]} AD");
                Console.WriteLine("------------------------------------------");

                string atak;

                if (Kolejność == 0) // sprawdza czy petla jest odtważana poraz pierwszy 
                {
                    AdPotwora = random.Next(2, 11); // losowanie Ad potwora
                    HpPotwora = random.Next(15, 20); // losowanie HP potwora
                    Console.WriteLine("Natrafiłeś na potwora");
                    Console.WriteLine("-------");

                }
                else
                {
                    AdPotwora = random.Next(5, 11);
                    HpPotwora = random.Next(15, 20);
                    Console.WriteLine("Natrafiłeś na kolejnego potwora");
                    Console.WriteLine("-------");
                }

                Kolejność = 0; // zeruje kolejność w celu ponownego sprawdzenia w kodzie niżej 
                while (HpPotwora > 0 && StatystykiPostaci[0] > 0) // walka z poworem, program sprawdza czy postać i potwór żyje 
                {

                    if (Kolejność == 0) // sprawdza kolejność
                    {
                        Console.Write("Wpisz \"W\" aby go zaatakować: ");
                        atak = Console.ReadLine().ToUpper();
                    }
                    else
                    {
                        Console.Write("Wpisz \"W\" aby go zaatakować ponowinie: ");
                        atak = Console.ReadLine().ToUpper();
                    }

                    if (atak == "W") // odpowiada za atak 
                    {
                        HpPotwora -= StatystykiPostaci[1];
                        StatystykiPostaci[0] -= AdPotwora;

                        if (HpPotwora <= 0)
                        {
                            HpPotwora = 0;
                        }
                        else if (StatystykiPostaci[0] <= 0)
                        {
                            StatystykiPostaci[0] = 0;
                        }

                        Kolejność = 1;
                        Console.WriteLine("-------");
                        Console.WriteLine($"Udało ci się udeżyć potwora obecnie posiada {HpPotwora} Hp lecz ty też oberwałeś twoje Hp jest równe {StatystykiPostaci[0]}");
                        Console.WriteLine("-------");
                    }
                    else
                    {
                        StatystykiPostaci[0] -= AdPotwora;

                        if (HpPotwora <= 0)
                        {
                            HpPotwora = 0;
                        }
                        else if (StatystykiPostaci[0] <= 0)
                        {
                            StatystykiPostaci[0] = 0;
                        }

                        Kolejność = 1;
                        Console.WriteLine("-------");
                        Console.WriteLine($"Niestety nie udało ci się zaatakować potwora lecz on już tak twoje Hp jest równe {StatystykiPostaci[0]}");
                        Console.WriteLine("-------");
                    }
                }

                Kolejność = 0;

                if (HpPotwora <= 0) // sprawdza czy potwór żyje potwor oraz postać
                {
                    ZabitePotwory += 1;
                    Kolejność = 1;
                    Console.WriteLine($"Brawo udało ci się pokonać {ZabitePotwory} potwora");
                    Console.WriteLine("------------------------------------------");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Niestety zginołeś lecz udało ci się zabić {ZabitePotwory} Potworóy");


        }
    }
}

