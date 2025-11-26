using System.Diagnostics;

string again = "a"; // jedno rovná se - přiřazení hodnoty, dvě rovná se == porovnání hodnot
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("****************************************");
    Console.WriteLine("*** Generátor pseudonáhodných čísel ***");
    Console.WriteLine("***************************************");
    Console.WriteLine("**********  Jan Honzíček  *************");
    Console.WriteLine("***************************************");
    Console.WriteLine();

    //vstup hodnoty do programu

    Console.WriteLine("Zadejte počet generovaných čísel (celé číslo):");
    int n;
    while (!int.TryParse(Console.ReadLine(), out n))
    {
        Console.WriteLine("Nezadali jste celé číslo. Zadejte prosím počet generovaných čísel znovu:");
    }
    
Console.WriteLine("Zadejte dolní mez (celé číslo):");
    int lowerBound;
    while (!int.TryParse(Console.ReadLine(), out lowerBound))
    {
        Console.WriteLine("Nezadali jste celé číslo. Zadejte prosím dolní mez znovu:");
    }
Console.WriteLine("Zadejte horní mez (celé číslo):");
    int upperBound;
    while (!int.TryParse(Console.ReadLine(), out upperBound))
    {
        Console.WriteLine("Nezadali jste celé číslo. Zadejte prosím horní mez znovu:");
    }
    Console.WriteLine("=======================================");
    Console.WriteLine("Generovaná čísla jsou: ");
    Console.WriteLine($"Počet čísel: {n}, Dolní mez: {lowerBound}, Horní mez: {upperBound}");
    //deklarace pole
    int[] myRandNumbs = new int[n];
    Random myRandNumb = new Random();
Console.WriteLine();
    Console.WriteLine("=============================================");
    Console.WriteLine("Pseudonáhodná čísla:");
    for (int i = 0; i < n ; i++)
    {
        myRandNumbs[i] = myRandNumb.Next(lowerBound, upperBound+1);
        Console.Write("{0}; ", myRandNumbs[i]);
    }
    for (int i = 0; i < n / 2; i++) {
        int tmp = myRandNumbs[i];
        myRandNumbs[i] = myRandNumbs[n-1-i];
        myRandNumbs[n-1-i] = tmp;
    }

    Console.WriteLine();
    Console.WriteLine("==========================");
    Console.WriteLine("Pole po reverzi:");
    Console.WriteLine();
    for (int i = 0; i < n ; i++)
    {
        Console.Write("{0}; ", myRandNumbs[i]);
    }

    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    again = Console.ReadLine();



    Console.WriteLine("");
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    again = Console.ReadLine();


}