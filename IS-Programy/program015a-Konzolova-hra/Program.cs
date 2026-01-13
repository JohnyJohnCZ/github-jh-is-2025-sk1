// Načteme knihovnu pro práci s různými formáty čísel (např. čárka vs. tečka)
using System.Globalization;

namespace Matematikator
{
    class Program
    {
        // Struktura představující "obtížnost" — tedy sadu pravidel pro generování příkladů
        struct Obtiznost
        {
            public string DostupneOperatory; // řetězec s dostupnými operátory, např. "+-*"
            public int[] MaximalniHodnota;   // pole maximálních hodnot číslic pro jednotlivé operace
        }

        // Vytvoření tří úrovní obtížnosti hry
        static Obtiznost[] obtiznostiHry =
        [
            // Obtížnost 1: pouze sčítání a odčítání, max číslo 20
            new Obtiznost {DostupneOperatory = "+-", MaximalniHodnota = [20, 20]},

            // Obtížnost 2: přidána násobilka, vyšší čísla
            new Obtiznost {DostupneOperatory = "+-*", MaximalniHodnota = [500, 500, 20]},

            // Obtížnost 3: přidáno dělení, ještě vyšší čísla
            new Obtiznost {DostupneOperatory = "+-*/", MaximalniHodnota = [1000, 1000, 20, 200]}
        ];

        // Funkce pro vygenerování náhodného matematického příkladu podle zvolené obtížnosti
        static void GenerujPriklad(int indexObtiznosti)
        {
            // Vybereme obtížnost podle indexu (0 = snadná, 1 = střední, 2 = těžká)
            Obtiznost obtiznost = obtiznostiHry[indexObtiznosti];

            // Vytvoříme nový generátor náhodných čísel
            Random random = new Random();

            // Zjistíme, kolik operátorů je v této obtížnosti k dispozici
            int pocetDostupnychOperatoru = obtiznost.DostupneOperatory.Length;

            // Náhodně vybereme jeden z operátorů
            int vybranyIndexOperatoru = random.Next(pocetDostupnychOperatoru);
            char vybranyOperator = obtiznost.DostupneOperatory[vybranyIndexOperatoru];

            // Každý operátor má vlastní maximální hodnotu, použijeme pro tento konkrétní operátor
            int maximalniHodnota = obtiznost.MaximalniHodnota[vybranyIndexOperatoru];

            // Náhodně vygenerujeme dvě čísla (operandy)
            int prvniOperand = random.Next(maximalniHodnota + 1); // +1, protože horní mez je exkluzivní
            int druhyOperand = random.Next(maximalniHodnota + 1);

            double spravnyVysledek = 0.0; // Sem uložíme správný výsledek příkladu

            // Spočítáme správný výsledek podle zvoleného operátoru
            switch (vybranyOperator)
            {
                case '+':
                    spravnyVysledek = prvniOperand + druhyOperand;
                    break;
                case '-':
                    spravnyVysledek = prvniOperand - druhyOperand;
                    break;
                case '*':
                    spravnyVysledek = prvniOperand * druhyOperand;
                    break;
                case '/':
                    spravnyVysledek = (double)prvniOperand / druhyOperand; // přetypování na double pro dělení
                    break;
            }
            
            double zadanaOdpoved; // zde bude uživatelova odpověď
            bool zodpovezeno;     // označuje, zda se nám podařilo odpověď převést na číslo

            // Smyčka -> dokud uživatel nezadá platné číslo
            do
            {
                Console.WriteLine();
                Console.WriteLine("Řešení příkladu:");
                Console.Write($"{prvniOperand} {vybranyOperator} {druhyOperand} = ");

                // Načte vstup od uživatele, nahradí případnou čárku za tečku a převede na číslo (double)
                zodpovezeno = double.TryParse(
                    Console.ReadLine().Replace(',', '.'),      // nahradí čárku tečkou
                    CultureInfo.InvariantCulture,              // používá univerzální formát čísel
                    out zadanaOdpoved                         // uložení výsledku do proměnné
                );

                // Pokud zadání nebylo číslo, ohlásí chybu
                if (!zodpovezeno)
                {
                    Console.WriteLine("Neplatný vstup!");
                }

            } while (zodpovezeno == false); // opakuj dokud není platné číslo

            // Porovnání výsledků s tolerancí 0.01 (kvůli desetinným chybám)
            if (Math.Abs(zadanaOdpoved - spravnyVysledek) < 0.01)
            {
                Console.WriteLine("Správně!"); // Uživatel odpověděl téměř přesně
            } 
            else
            {
                // {spravnyVysledek:F2} = zobrazí číslo se dvěma desetinnými místy
                Console.WriteLine($"Špatně. Správný výsledek je {spravnyVysledek:F2}");
            }
        }

        // Hlavní metoda — vstupní bod programu
        static void Main(string[] args)
        {
            // Úvodní obrazovka
            Console.WriteLine("*********************************");
            Console.WriteLine("*** Vítejte v matematikátoru! ***");
            Console.WriteLine("*********************************");
            Console.WriteLine("****** Autor: Jan Honzíček ******");
            Console.WriteLine("*********************************");
            Console.WriteLine();

            int vybranaObtiznost; // proměnná, do které se ukládá uživatelská volba obtížnosti

            // Hlavní smyčka menu — běží, dokud uživatel nezvolí 0 (Konec)
            do
            {
                // Nabídka obtížností
                Console.WriteLine("Vyberte obtížnost:");
                Console.WriteLine("1 - Snadná (+ -)");
                Console.WriteLine("2 - Střední (+ - *)");
                Console.WriteLine("3 - Těžká (+ - * /)");
                Console.WriteLine("0 - Konec");
                Console.WriteLine();

                // Čtení vstupu od uživatele
                Console.Write("Zadejte volbu: ");

                bool parsed = int.TryParse(Console.ReadLine(), out vybranaObtiznost);

                // Pokud nebylo zadáno číslo
                if (!parsed)
                {
                    Console.WriteLine("Neplatný vstup v menu.");
                    vybranaObtiznost = -1; // nastavíme neplatnou volbu
                }

                // Podle volby spustíme odpovídající část programu
                switch(vybranaObtiznost)
                {
                    case 1:
                        Console.WriteLine("Vybrali jste snadnou obtížnost.");
                        GenerujPriklad(0); // zavolá generátor pro index 0 (snadná)
                        break;
                    case 2:
                        Console.WriteLine("Vybrali jste střední obtížnost.");
                        GenerujPriklad(1);
                        break;
                    case 3:
                        Console.WriteLine("Vybrali jste těžkou obtížnost.");
                        GenerujPriklad(2);
                        break;
                    case 0:
                        Console.WriteLine("Konec programu.");
                        break;
                    default:
                        Console.WriteLine("Špatná volba! Zvolte 0-3.");
                        break;
                }

                Console.WriteLine(); // prázdný řádek pro přehlednost v konzoli

            } while (vybranaObtiznost != 0); // program běží, dokud nezvolíš Konec (0)
        }
    }
}
