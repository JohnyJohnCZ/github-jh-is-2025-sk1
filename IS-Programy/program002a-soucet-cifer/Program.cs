string again = "a"; // jedno rovná se - přiřazení hodnoty, dvě rovná se == porovnání hodnot
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("************************************");
    Console.WriteLine("****** Ciferný součet a součin *****");
    Console.WriteLine("************************************");
    Console.WriteLine("**********  Jan Honzíček  **********");
    Console.WriteLine("************************************");
    Console.WriteLine();

    //vstup hodnoty do programu

        Console.WriteLine("Zadejte celé číslo pro nějž chcete určit součet a součin cifer");
        int number;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("Neplatný vstup. Zadejte prosím celé číslo:");
    }

    int suma = 0;
    int numberbackup = number;
    int digit;
    int soucin = 1;

    if (number < 0)
    {
        number = -number;
    }

//varianta z hodiny
while (number > 0)
    {
        digit = number % 10;  //operátor modulo - zbytek po dělení
        number = (number - digit) / 10;
        Console.WriteLine("Zbytek je {0}", digit);
        suma = suma + digit;

    }

    suma = suma + number; //přičtení poslední cifry - nesmíme zapomenout


    Console.WriteLine("Součet cifer čísla {0} je {1}", numberbackup, suma);

/*varianta domácí úkol
    while (number > 0)
    {
        digit = number % 10;  //operátor modulo - zbytek po dělení
        suma += digit;
        soucin *= digit;
        number /= 10;
    }

    Console.WriteLine("Součet cifer: {0}", suma);
    Console.WriteLine("Součin cifer: {0}", soucin);
    */



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