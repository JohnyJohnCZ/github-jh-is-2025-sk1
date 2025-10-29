// Vstup programu: Nahraje potřebné knihovny
// V C# obvykle: using System;

// Hlavní smyčka programu; díky ní se může program opakovat, pokud uživatel chce
string again = "a";
while (again == "a") // Tělo programu se opakuje, dokud uživatel zadá 'a'
{
    // Vymaže předchozí obsah konzole pro nové vykreslení
    Console.Clear();

    // Vypíše úvodní nadpis a popis, co program dělá
    Console.WriteLine("*******************************************");
    Console.WriteLine("********** Tři obrazce pod sebou **********");
    Console.WriteLine("*******************************************");
    Console.WriteLine("*** Z (4) / N (6) / Kosočtverec (16) ***");
    Console.WriteLine("*******************************************\n");

    // Zjistí od uživatele velikost obrazců – musí to být liché číslo a aspoň 3
    Console.WriteLine("Zadejte lichou velikost obrazců (nejméně 3):");
    int size;
    // Cyklus se točí, dokud není číslo validní (celé, liché, větší/rovno 3)
    while (!int.TryParse(Console.ReadLine(), out size) || size < 3 || size % 2 == 0)
    {
        Console.WriteLine("Zadejte prosím celé liché číslo větší nebo rovno 3:");
    }

    // ************************* Obrazec 1: Z (č. 4) *************************
    // Vytvoří oddělovací čáru nad obrazcem
    Console.WriteLine(new string('=', size * 3));
    // Pro každý řádek od 0 do velikosti - 1
    for (int i = 0; i < size; i++)
    {
        // Pro každý sloupec od 0 do velikosti - 1
        for (int j = 0; j < size; j++)
        {
            // Pokud jde o horní nebo dolní řádek (i == 0 nebo i == poslední)
            if (i == 0 || i == size - 1)
                Console.Write(" * ");
            // Pokud je součet pořadí řádku a sloupce na dané diagonále (úhlopříčka)
            else if (i + j == size - 1)
                Console.Write(" * ");
            // Jinak se vypíší mezery
            else
                Console.Write("   ");
        }
        // Po každém řádku nový řádek
        Console.WriteLine();
    }
    // Oddělovací čára pod prvním obrazcem
    Console.WriteLine(new string('=', size * 3));

    // ************************* Obrazec 2: N (č. 6) *************************
    // Pro každý řádek od 0 do velikosti - 1
    for (int i = 0; i < size; i++)
    {
        // Pro každý sloupec od 0 do velikosti - 1
        for (int j = 0; j < size; j++)
        {
            // Levý kraj, pravý kraj, úhlopříčka z levého horního rohu
            if (j == 0 || j == size - 1 || i == j)
                Console.Write(" * ");
            else
                Console.Write("   ");
        }
        // Nový řádek po vypsání jednoho řádku
        Console.WriteLine();
    }
    // Oddělovací čára pod druhým obrazcem
    Console.WriteLine(new string('=', size * 3));

    // ************* Obrazec 3: Kosočtverec (č. 16) podle zadání *************
    // Určíme index středu (na liché velikosti je to size / 2)
    int mid = size / 2;
    // Pro každý řádek od 0 do velikosti - 1
    for (int i = 0; i < size; i++)
    {
        // Vypočet absolutní vzdálenosti řádku od středu
        int dist = Math.Abs(mid - i);
        // Pro každý sloupec
        for (int j = 0; j < size; j++)
        {
            // Pokud je sloupec mezi dist a size-dist-1 (tedy viditelná oblast kosočtverce)
            if (j >= dist && j < size - dist)
                Console.Write(" * ");
            else
                Console.Write("   ");
        }
        // Nový řádek po každém řádku obrazce
        Console.WriteLine();
    }
    // Oddělovací čára pod třetím obrazcem
    Console.WriteLine(new string('=', size * 3));

    // Výzva k opakování programu
    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    // Čte vstup od uživatele – když zadá 'a', program se znovu spustí
    again = Console.ReadLine();
}
