/* Hlavní program - začátek */

string again = "a";
while (again == "a")
{
    Console.Clear();

    // Metoda pro razítko - hlavičku
    razitko();

    // Načítání hodnot
    ulong a = nactiCislo("Zadejte číslo a: ");
    ulong b = nactiCislo("Zadejte číslo b: ");

    ulong nsd = vypocitatNSD(a, b);

    ulong nsn = vypocitatNSN(a, b, nsd);

    zobrazitVysledky(a, b, nsd, nsn);

    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();
}

/* Hlavní program - konec */

/* metoda která nic nevrací - nevrací hodnotu */
static void razitko()
{
    Console.WriteLine("*****************************");
    Console.WriteLine("***** Výpočet NSD a NSN *****"); //Největší společný násobek/dělitel
    Console.WriteLine("*****************************");
    Console.WriteLine("******* Jan Honzíček ********");
    Console.WriteLine("*****************************");
    Console.WriteLine();
}    

/* metoda pro načtení čísel */
static ulong nactiCislo(string zprava)
{
    Console.Write(zprava);
    ulong cislo;
    while (!ulong.TryParse(Console.ReadLine(), out cislo))
    {
        Console.Write("Nezadali jste přirozené číslo. Zadejte hodnotu znovu: ");
    }

    // !!! Metoda, která vrací nějaký konkrétní datový typ, musí obsahovat následující řádek
    return cislo;

}

//metoda pro výpočet NSD
static ulong vypocitatNSD(ulong a, ulong b)
{
    while (a != b)
    {
        if (a > b)
        {
            a = a - b;
        }
        else
        {
            b = b - a;
        }
        return a;
    }
    Console.WriteLine();
    Console.WriteLine($"Největší společný dělitel (NSD) je: {a}");
    return a;
}

//metoda pro výpočet NSN na základě známé hodnoty NSD
static ulong vypocitatNSN(ulong a, ulong b, ulong nsd)
{
    return (a * b) / nsd;
}

//metoda pro zobrazení výsledků
static void zobrazitVysledky(ulong a, ulong b, ulong nsd, ulong nsn)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"Pro čísla {a} a {b} platí:");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Největší společný dělitel (NSD) je: {nsd}");
    Console.WriteLine($"Nejmenší společný násobek (NSN) je: {nsn}");
    Console.ForegroundColor = ConsoleColor.White;
}