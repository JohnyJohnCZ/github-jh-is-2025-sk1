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
    Console.WriteLine("=======================================");

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
        myRandNumbs[i] = myRandNumb.Next(lowerBound, upperBound+1);
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

    Console.WriteLine("=======================================");
    Console.WriteLine("Počet záporných čísel: {0}", negativeNumbs);
    Console.WriteLine("Počet kladných čísel: {0}", positiveNumbs);
    Console.WriteLine("Počet nul: {0}", zeros);
    Console.WriteLine("=======================================");
    Console.WriteLine("Počet sudých čísel: {0}", evenNumbs);
    Console.WriteLine("Počet lichých čísel: {0}", oddNumbs);
    Console.WriteLine("=======================================");



    //Hledání maxima a minima a jejich prvních pozic
    int max = myRandNumbs[0]; //Předpokládáme, že první prvek v poli je maximem
    int min = myRandNumbs[0]; //Předpokládáme, že první prvek v poli je minimem
    int posMax = 0; //Pozice maxima
    int posMin = 0; //Pozice minima

    for (int i = 1; i < n; i++)
    {
        if (myRandNumbs[i] > max)
        {
            max = myRandNumbs[i];
            posMax = i;
        }
        if (myRandNumbs[i] < min)
        {
            min = myRandNumbs[i];
            posMin = i;
        }
    }
    Console.WriteLine("=======================================");
    Console.WriteLine("První maximum je {0} na pozici {1}", max, posMax);
    Console.WriteLine("První minimum je {0} na pozici {1}", min, posMin);
    Console.WriteLine("=======================================");



    //Vykreslení přesýpacích hodin podle minima a maxima - dva plné trojúhelníky které se uprostřed dotýkají vrcholy

    if (max >= 3)
    {
        for(int i = 0; i < max; i++)
        {
            int spaces, stars;
            if (i < (max / 2))
            {
                spaces = i;
                //horní polovina - s každým dalším řádkem ubývají 2 hvězdičky
                stars = max - 2 * i;

            }
            else
            {
                spaces = max - i - 1;

                //pokud je max liché číslo, tak se střední řádek vykreslí jednou
                if (max % 2 == 1)
                {
                    stars = 2 * (i - (max / 2)) + 1;
                }
                else
                {
                    stars = stars = 2 * (i - (max / 2)) + 2;
                }

            }
           
            Console.ForegroundColor = ConsoleColor.Yellow;
            //vykreslení mezer
            for (int sp = 0; sp < spaces; sp++)
            {
                Console.Write(" ");
            }
            //vykreslení hvězdiček
            for (int st = 0; st < stars; st++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }


    else
    {
        Console.WriteLine("Obrazec se nevykreslí");
    }
    Console.ResetColor();

    Console.WriteLine("");
    Console.WriteLine("Pro opakování programu stiskněte 'a', pro ukončení jinou klávesu.");
    again = Console.ReadLine();


}