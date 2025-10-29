string again = "a"; // jedno rovná se - přiřazení hodnoty, dvě rovná se == porovnání hodnot
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("*******************************************");
    Console.WriteLine("*** Vykreslení pravoúhlého trojúhelníku ***");
    Console.WriteLine("*******************************************");
    Console.WriteLine("************  Jan  Honzíček  **************");
    Console.WriteLine("*******************************************");
    Console.WriteLine();

    // Vstup hodnoty do programu
    Console.WriteLine("Zadejte délku odvěsny trojúhelníku (celé číslo):");
    int height;
    while (!int.TryParse(Console.ReadLine(), out height))
    {
        Console.WriteLine("Nezadali jste celé číslo. Zadejte prosím délku odvěsny znovu:");
    }

    Console.WriteLine("===========================================");

    for (int i = 1; i <= height; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write(" * ");
        }
        Console.WriteLine();
    }

    Console.WriteLine("===========================================");

    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    again = Console.ReadLine();
}
