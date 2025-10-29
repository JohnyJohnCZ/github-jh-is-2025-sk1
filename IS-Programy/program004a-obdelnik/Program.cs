string again = "a"; // jedno rovná se - přiřazení hodnoty, dvě rovná se == porovnání hodnot
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("**************************************");
    Console.WriteLine("******** Vykreslení obdélníku ********");
    Console.WriteLine("**************************************");
    Console.WriteLine("**********  Jan Honzíček  ************");
    Console.WriteLine("**************************************");
    Console.WriteLine();

    //vstup hodnoty do programu

    Console.WriteLine("Zadejte celé šířku obrazce (celé číslo):");
    int width;
    while (!int.TryParse(Console.ReadLine(), out width))
    {
        Console.WriteLine("Nezadali jste celé číslo. Zadejte prosím šířku obrazce znovu:");
    }
    Console.WriteLine("Zadejte výšku obrazce (celé číslo):");
    int height;
    while (!int.TryParse(Console.ReadLine(), out height))
    {
        Console.WriteLine("Nezadali jste celé číslo. Zadejte prosím výšku obrazce znovu:");
    }
    

    Console.WriteLine("=====================================");

   for (int i = 1; i <= height; i++)
   {
       for (int j = 1; j <= width; j++)
       {
            Console.Write(" * ");

       }
       Console.WriteLine();
   }
    Console.WriteLine("=====================================");



    Console.WriteLine("");
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    again = Console.ReadLine();


}