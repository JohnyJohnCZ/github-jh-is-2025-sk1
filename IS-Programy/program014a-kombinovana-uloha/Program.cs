using System;
using System.Collections.Generic;

/*string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("**********************************");
    Console.WriteLine("******* Kombinovaná úloha *******");
    Console.WriteLine("**********************************");
    Console.WriteLine("********** Jan Honzíček **********");
    Console.WriteLine("**********************************");
    Console.WriteLine();
   /* 
    Console.Write("Zadejte počet generovaných čísel (celé číslo): ");
    int n;

    while (!int.TryParse(Console.ReadLine(), out n))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte znovu počet čísel: ");
    }

    Console.Write("Zadejte dolní mez (celé číslo): ");
    int lowerBound;

    while (!int.TryParse(Console.ReadLine(), out lowerBound))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte znovu dolní mez: ");
    }

    Console.Write("Zadejte horní mez (celé číslo): ");
    int upperBound;

    while (!int.TryParse(Console.ReadLine(), out upperBound))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte znovu horní mez: ");
    }

    Console.WriteLine();
    Console.WriteLine("================================================");
    Console.WriteLine("Zadané hodnoty:");
    Console.WriteLine("Počet čísel: {0}; Dolní mez: {1}; Horní mez: {2}", n, lowerBound, upperBound);
    Console.WriteLine("================================================");

    // Deklarace pole
    int[] Numbs = new int[n];

    //Random myRandNumb = new Random(50); // generování stejných čísel při stejném vstupu - hodí se pro testování
    Random myRandNumb = new Random();

    Console.WriteLine();
    Console.WriteLine("=============================================");
    Console.WriteLine("Pseudonáhodná čísla:");
    for (int i = 0; i < n ; i++)
    {
        Numbs[i] = myRandNumb.Next(lowerBound, upperBound+1);
        Console.Write("{0}; ", Numbs[i]);
    }

    
    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();



//Minimum a maximum
int min = Numbs[0];
int max = Numbs[0];
for (int i = 1; i < n; i++)
{
    if (Numbs[i] < min)
    {
        min = Numbs[i];
    }
    if (Numbs[i] > max)
    {
        max = Numbs[i];
    }
}

Console.WriteLine();
Console.WriteLine($"Minimum je: {min}; jeho pozice v poli je:");
for (int i = 0; i < n; i++)
{
    if (Numbs[i] == min)
    {
        Console.Write($" {i}");
    }
}
Console.WriteLine($"Maximum je: {max}; jeho pozice v poli je:");
for (int i = 0; i < n; i++)
{
    if (Numbs[i] == max)
    {
        Console.Write($" {i}");
    }
}
*/




static void Main()
    {
        // Počet čísel, která se budou náhodně generovat
        int pocetCisel = 15;

        // Dolní a horní mez pro generovaná náhodná čísla (včetně obou krajů)
        int dolniMez = 0;
        int horniMez = 10;

        // Pole (řada) celých čísel, do kterého se budou ukládat náhodně vygenerovaná čísla
        int[] vygenerovanaCisla = new int[pocetCisel];

        // Objekt, který umí generovat náhodná čísla
        Random generatorNahodnychCisel = new Random();

        // 1) Vygenerování náhodných čísel
        for (int index = 0; index < pocetCisel; index++)
        {
            // Vygeneruje náhodné číslo mezi dolniMez a horniMez (horní mez je nutné zadat +1)
            vygenerovanaCisla[index] = generatorNahodnychCisel.Next(dolniMez, horniMez + 1);
        }

        // Vypsání vygenerovaných čísel v jednom řádku, oddělených čárkou a mezerou
        Console.WriteLine("Náhodně vygenerovaná čísla jsou: " + string.Join(", ", vygenerovanaCisla));


        // 2) Hledání největšího (maximum) a nejmenšího (minimum) čísla a všech jejich pozic
        // Předpokládáme, že první prvek je zatím největší i nejmenší
        int nejvetsiCislo = vygenerovanaCisla[0];
        int nejmensiCislo = vygenerovanaCisla[0];

        // Seznamy (dynamická pole), kam se budou ukládat pozice (pořadí) výskytu maxima a minima
        List<int> poziceNejvetsiho = new List<int>();
        List<int> poziceNejmensiho = new List<int>();

        // Projde všechna čísla v poli
        for (int index = 0; index < pocetCisel; index++)
        {
            int aktualniCislo = vygenerovanaCisla[index];

            // Hledání největšího čísla
            if (aktualniCislo > nejvetsiCislo)
            {
                // Našli jsme nové větší číslo – přepíšeme hodnotu maxima
                nejvetsiCislo = aktualniCislo;
                // Vymažeme staré pozice a uložíme novou pozici (index + 1 kvůli lidskému číslování od 1)
                poziceNejvetsiho.Clear();
                poziceNejvetsiho.Add(index + 1);
            }
            else if (aktualniCislo == nejvetsiCislo)
            {
                // Našli jsme stejné maximum znovu – pouze přidáme další pozici
                poziceNejvetsiho.Add(index + 1);
            }

            // Hledání nejmenšího čísla
            if (aktualniCislo < nejmensiCislo)
            {
                nejmensiCislo = aktualniCislo;
                poziceNejmensiho.Clear();
                poziceNejmensiho.Add(index + 1);
            }
            else if (aktualniCislo == nejmensiCislo)
            {
                poziceNejmensiho.Add(index + 1);
            }
        }

        Console.WriteLine("-----");
        Console.WriteLine($"Maximum: {nejvetsiCislo}, všechny pozice maxima: {string.Join("; ", poziceNejvetsiho)}");
        Console.WriteLine($"Minimum: {nejmensiCislo}, všechny pozice minima: {string.Join("; ", poziceNejmensiho)}");


        // 3) Seřazení čísel pomocí algoritmu „Shaker sort“ (cocktail sort)
        //    Čísla budou seřazena od největšího k nejmenšímu
        SeradShakerSestupne(vygenerovanaCisla);

        Console.WriteLine("-----");
        Console.WriteLine("Pole po seřazení algoritmem Shaker sort:");
        Console.WriteLine(string.Join(", ", vygenerovanaCisla));


        // 4) Druhé, třetí a čtvrté největší číslo
        // Po seřazení sestupně (od největšího) platí:
        // 1. největší = na pozici 0
        // 2. největší = na pozici 1
        // 3. největší = na pozici 2
        // 4. největší = na pozici 3
        int druheNejvetsi = vygenerovanaCisla[1];
        int tretiNejvetsi = vygenerovanaCisla[2];
        int ctvrteNejvetsi = vygenerovanaCisla[3];

        Console.WriteLine("-----");
        Console.WriteLine("Druhé největší číslo: " + druheNejvetsi);
        Console.WriteLine("Třetí největší číslo: " + tretiNejvetsi);
        Console.WriteLine("Čtvrté největší číslo: " + ctvrteNejvetsi);


        // 5) Medián – prostřední hodnota po seřazení
        // Protože máme lichý počet čísel (15), medián je „prostřední prvek pole“
        // Index prostředního prvku je pocetCisel / 2 (např. 15 / 2 = 7, což je 8. prvek)
        int median = vygenerovanaCisla[pocetCisel / 2];

        Console.WriteLine("-----");
        Console.WriteLine("Medián generovaných čísel = " + median);


        // 6) Převod čtvrtého největšího čísla do binární soustavy (0 a 1)
        // Převod z desítkové soustavy do dvojkové se zde udělá vestavěnou funkcí
        string ctvrteNejvetsiBinarnne = Convert.ToString(ctvrteNejvetsi, 2);

        Console.WriteLine("-----");
        Console.WriteLine($"Čtvrté největší číslo převedené do binární soustavy: {ctvrteNejvetsi}(2) = {ctvrteNejvetsiBinarnne}");


        // 7) Vykreslení obrazce z hvězdiček
        // Výška obrazce = medián
        // Šířka obrazce = třetí největší číslo
        Console.WriteLine("-----");
        Console.WriteLine($"Obrazec – výška = medián ({median}) ; šířka = třetí největší číslo ({tretiNejvetsi})");
        VykresliObrazec(median, tretiNejvetsi);

        // Ukázka z příkladu: výška = 7 (medián = 7), šířka = 6
        Console.WriteLine("-----");
        Console.WriteLine("Ukázka pro medián = 7 a šířka = 6:");
        VykresliObrazec(7, 6);
    }

    // Funkce, která seřadí zadané pole int[] v sestupném pořadí pomocí algoritmu Shaker sort
    static void SeradShakerSestupne(int[] serazenaCisla)
    {
        // levý a pravý „okraj“, mezi kterými se právě třídí
        int levyOkraj = 0;
        int pravyOkraj = serazenaCisla.Length - 1;

        // Proměnná, která říká, jestli proběhla nějaká výměna (prohození) čísel
        bool dosloKVymene = true;

        // Dokud se levý okraj nepotká s pravým a při průchodu se stále něco mění, pokračujeme
        while (levyOkraj < pravyOkraj && dosloKVymene)
        {
            dosloKVymene = false;

            // Průchod zleva doprava – „bublání“ nejmenších čísel ke konci
            for (int index = levyOkraj; index < pravyOkraj; index++)
            {
                // Pokud je číslo vlevo menší než číslo vpravo, prohodíme je,
                // aby větší číslo bylo blíže začátku pole (sestupné řazení)
                if (serazenaCisla[index] < serazenaCisla[index + 1])
                {
                    int pomocna = serazenaCisla[index];
                    serazenaCisla[index] = serazenaCisla[index + 1];
                    serazenaCisla[index + 1] = pomocna;

                    dosloKVymene = true;
                }
            }

            // Posuneme pravý okraj o jedno místo doleva – poslední prvek už je na správné pozici
            pravyOkraj--;

            // Průchod zprava doleva – „bublání“ větších čísel k začátku
            for (int index = pravyOkraj; index > levyOkraj; index--)
            {
                if (serazenaCisla[index - 1] < serazenaCisla[index])
                {
                    int pomocna = serazenaCisla[index];
                    serazenaCisla[index] = serazenaCisla[index - 1];
                    serazenaCisla[index - 1] = pomocna;

                    dosloKVymene = true;
                }
            }

            // Posuneme levý okraj o jedno místo doprava
            levyOkraj++;
        }
    }

    // Funkce, která vykreslí obrazec z hvězdiček podle zadané výšky a šířky
    static void VykresliObrazec(int vyskaObrazce, int sirkaObrazce)
    {
        // Počet „úzkých“ řádků nahoře a dole (podle příkladu jsou vždy 2)
        int pocetUzkychRadku = 2;

        // Šířka úzkého řádku – budou v něm jen 2 hvězdičky
        int sirkaUzkehoRadku = 2;

        // Šířka „širokého“ řádku uprostřed je dána vstupní šířkou obrazce
        int sirkaSirokehoRadku = sirkaObrazce;

        // Pro každý řádek obrazce zjistíme, kolik hvězdiček má mít,
        // a ty pak vypíšeme
        for (int cisloRadku = 0; cisloRadku < vyskaObrazce; cisloRadku++)
        {
            int pocetHvezdicekVRadku;

            // Pokud jsme v horní části (první 2 řádky) nebo spodní části (poslední 2 řádky),
            // použijeme úzký řádek, jinak široký.
            if (cisloRadku < pocetUzkychRadku || cisloRadku >= vyskaObrazce - pocetUzkychRadku)
            {
                pocetHvezdicekVRadku = sirkaUzkehoRadku;
            }
            else
            {
                pocetHvezdicekVRadku = sirkaSirokehoRadku;
            }

            // Vykreslíme daný počet hvězdiček v jednom řádku
            for (int cisloHvezdicky = 0; cisloHvezdicky < pocetHvezdicekVRadku; cisloHvezdicky++)
            {
                Console.Write("* ");
            }

            // Přechod na nový řádek v konzoli
            Console.WriteLine();
        }
    }
