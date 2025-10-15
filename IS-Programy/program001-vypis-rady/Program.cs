string again = "a"; // jedno rovná se - přiřazení hodnoty, dvě rovná se == porovnání hodnot
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("******************************");
    Console.WriteLine("****** Výpis řady čísel ******");
    Console.WriteLine("******************************");
    Console.WriteLine("*******  Jan Honzíček  *******");
    Console.WriteLine("******************************");
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
                Console.WriteLine("Zadejte poslední číslo řady (celé číslo):");

        int last;
    while (!int.TryParse(Console.ReadLine(), out last))
    {
        Console.WriteLine("Neplatný vstup. Zadejte prosím celé číslo:");
    }
                Console.WriteLine("Zadejte diferenci (celé číslo):");

        int step;
    while (!int.TryParse(Console.ReadLine(), out step))
    {
        Console.WriteLine("Neplatný vstup. Zadejte prosím celé číslo:");
    }
        
        //výpis vstupních hodnot
Console.WriteLine("******************************");
Console.WriteLine("** Zadali jste tyto hodnoty **");
Console.WriteLine("******************************");
Console.WriteLine("První číslo řady: {0}", first);
Console.WriteLine("Poslední číslo řady: {0}", last);
Console.WriteLine("Diference: {0}", step);
    Console.WriteLine("******************************");
    Console.WriteLine("První číslo řady: {0}; Poslední číslo řady: {1}; Diference: {2}", first, last, step);


//Výpis řady
    Console.WriteLine("******************************");
    Console.WriteLine("****** Výpis řady čísel ******");
    Console.WriteLine("******************************");
    int current = first;
while (current <= last)
    {
        Console.WriteLine(current);
        current = current + step; // current += step - ruční přičtení diference
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