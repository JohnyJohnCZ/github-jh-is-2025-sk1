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

    //Záporná, kladná čísla a nuly
    int negativeNumbs = 0; //počet záporných čísel
    int positiveNumbs = 0; //počet kladných čísel
    int zeros = 0;     //počet nul

    //Sudá a lichá čísla
    int evenNumbs = 0; //počet sudých čísel
    int oddNumbs = 0;  //počet lichých čísel


    Console.WriteLine("=======================================");
    Console.WriteLine("Pseudonáhodná čísla: ");
    for (int i = 0; i < n; i++)
    {
        myRandNumbs[i] = myRandNumb.Next(lowerBound, upperBound);
        Console.Write("{0}; ", myRandNumbs[i]);

        //počítání záporných, kladných čísel a nul
        if (myRandNumbs[i] < 0)
        {
            negativeNumbs++;
        }
        else if (myRandNumbs[i] > 0)
        {
            positiveNumbs++;
        }
        else
        {
            zeros++;
        }

        if (myRandNumbs[i] % 2 == 0)
        {
            evenNumbs++;
        }
        else
        {
            oddNumbs++;
        }
    }
    Console.WriteLine(" ");
    Console.WriteLine("=======================================");
    Console.WriteLine("Počet záporných čísel: {0}", negativeNumbs);
    Console.WriteLine("Počet kladných čísel: {0}", positiveNumbs);
    Console.WriteLine("Počet nul: {0}", zeros);
    Console.WriteLine("=======================================");
    Console.WriteLine("Počet sudých čísel: {0}", evenNumbs);
    Console.WriteLine("Počet lichých čísel: {0}", oddNumbs);
    Console.WriteLine("=======================================");

Stopwatch myStopwatch = new Stopwatch();

int compare = 0;
int change = 0;
 

//bubble-sort
myStopwatch.Start();
for (int i = 0; i < n-1; i++){
        for(int j= 0; j < n-i-1; j++){
            compare++;
            if(myRandNumbs[j] < myRandNumbs[j+1]){    //Otočením znaménka z < na > se čísla setřídí vzestupně
                int tmp = myRandNumbs[j+1];
                myRandNumbs[j+1] = myRandNumbs[j];
                myRandNumbs[j] = tmp;
                change++;
            }
        }
    }
myStopwatch.Stop();


//výpis setříděných čísel
    Console.WriteLine("Seřazená čísla:");
    for (int i = 0; i < n; i++)
    {
        Console.Write("{0}; ", myRandNumbs[i]);
    }
    Console.WriteLine(" ");
    Console.WriteLine("Počet porovnání: {0}", compare);
    Console.WriteLine("Počet změn: {0}", change);

Console.WriteLine("Čas potřebný na seřazení čísel: {0} ", myStopwatch.Elapsed);

//určení druhého největšího čísla řady
int druhenejvetsicislo = 0;
for (int i = 0; i < n; i++){
    if(myRandNumbs[i] < myRandNumbs[0]){
        druhenejvetsicislo = myRandNumbs[i];
        Console.WriteLine("Druhé největší číslo je: {0}", druhenejvetsicislo);
        break;
    }}

Console.WriteLine("=======================================");

//vykreslení obrazce podle druhého největšího čísla
Console.WriteLine("Obrázek podle druhého největšího čísla:");



    Console.WriteLine("");
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    again = Console.ReadLine();


}