string again = "a"; // jedno rovná se - přiřazení hodnoty, dvě rovná se == porovnání hodnot
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("*************************************");
    Console.WriteLine("******** Seřazení dvou čísel ********");
    Console.WriteLine("*************************************");
    Console.WriteLine("**********  Jan Honzíček  ***********");
    Console.WriteLine("*************************************");
    Console.WriteLine();

    //vstup hodnoty do programu

    Console.WriteLine("Zadejte celé číslo - hodnota A");
    int a;
    while (!int.TryParse(Console.ReadLine(), out a))
    {
        Console.WriteLine("Nezadali jste celé číslo. Zadejte prosím hodnotu A znovu:");
    }
    Console.WriteLine("Zadejte celé číslo - hodnota B");
    int b;
    while (!int.TryParse(Console.ReadLine(), out b))
    {
        Console.WriteLine("Nezadali jste celé číslo. Zadejte prosím hodnotu B znovu:");
    }

    Console.WriteLine();
    int pom;
    if (a > b)
    {
        pom = a;
        a = b;
        b = pom;
        Console.WriteLine("Došlo k prohození proměnných");
    }
    Console.WriteLine($"Seřazená čísla: {a}, {b}");
    Console.WriteLine("");
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    again = Console.ReadLine();


}