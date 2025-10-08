string again = "a"; // jedno rovná se - přiřazení hodnoty, dvě rovná se == porovnání hodnot
while (again == "a")
{
    Console.Clear();
    Console.WriteLine(" ******************************");
    Console.WriteLine(" ****** Výpis řady čísel ******");
    Console.WriteLine(" ******************************");
    Console.WriteLine(" *******  Jan Honzíček  *******");
    Console.WriteLine(" ******************************");
    Console.WriteLine();

    /*vstup hodnoty do programu - špatně řešený
        Console.Write("Zadejte číslo řady: ");
        int first = int.Parse(Console.ReadLine());*/

    //vstup hodnoty do programu - lépe řešený

        Console.WriteLine("Zadejte první číslo řady (celé číslo):");
        int first;
        while (!int.TryParse(Console.ReadLine(), out first))
        {
            Console.WriteLine("Neplatný vstup. Zadejte prosím celé číslo:");
        }
       
    Console.WriteLine("");
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    again = Console.ReadLine();
}



/* prvni kod


Console.Clear();
Console.WriteLine("Hello, World!");
Console.WriteLine("Program ukončíte stiskem klávesy ENTER");
Console.ReadLine();

console.WriteLine("Zadejte číslo řady:");*/