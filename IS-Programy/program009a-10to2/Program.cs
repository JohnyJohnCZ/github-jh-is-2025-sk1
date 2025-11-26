using System.Diagnostics;

string again = "a"; // jedno rovná se - přiřazení hodnoty, dvě rovná se == porovnání hodnot
while (again == "a")
{
    Console.Clear();
    Console.WriteLine("***********************************************");
    Console.WriteLine("*** Převod z desítkové do dvojkové soustavy ***");
    Console.WriteLine("***********************************************");
    Console.WriteLine("**************  Jan Honzíček  *****************");
    Console.WriteLine("***********************************************");
    Console.WriteLine();

    //vstup hodnoty do programu

    Console.WriteLine("Zadejte hodnotu (přirozené číslo):");
    uint number10;
    while (!uint.TryParse(Console.ReadLine(), out number10))
    {
        Console.WriteLine("Nezadali jste přirozené číslo. Zadejte prosím hodnotu znovu:");
    }
    
    // převod z desítkové do dvojkové soustavy - jednodušší způsob
    /*string number2 = Convert.ToString(number10, 2);
    Console.WriteLine($"Hodnota {number10} v dvojkové soustavě je: {number2}");
*/


//převod z desítkové do dvojkové soustavy - složitější způsob
    
    uint backupNumber10 = number10; //záloha původní hodnoty
    uint zbytek;
    uint[] poleZbytku = new uint[32]; //pole pro zbytky po dělení 2
    uint i;
    for (i = 0; number10 > 0; i++)
    {
        zbytek = number10 % 2;
        number10 = (number10 - zbytek) / 2;
        poleZbytku[i] = zbytek;

        Console.WriteLine($"zbytek: {zbytek}, číslo10: {number10}");
    }

    Console.WriteLine("");
    for (int j = (int)i - 1; j >= 0; j--)
    {
        Console.Write("{0}", poleZbytku[j]);
    }






    Console.WriteLine("");
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    again = Console.ReadLine();


}