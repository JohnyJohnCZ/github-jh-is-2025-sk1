using System.Security.Cryptography.X509Certificates;

string again = "a";
while (again == "a")
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("*******************************************");
    Console.WriteLine("************* Zápočtový test IS ***********");
    Console.WriteLine("************** Datum: 7.1.2026 ************");
    Console.WriteLine("**************  Honzíček Jan **************");
    Console.WriteLine("*******************************************");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;

    Console.Write("Zadejte počet generovaných čísel (celé číslo): ");
    int n;

    while (!int.TryParse(Console.ReadLine(), out n))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte znovu počet čísel: ");
    }

    Console.Write("Zadejte dolní mez (celé číslo): ");
    int lowerBound;

    while (!int.TryParse(Console.ReadLine(), out lowerBound))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte znovu dolní mez: ");
    }

    Console.Write("Zadejte horní mez (celé číslo): ");
    int upperBound;

    while (!int.TryParse(Console.ReadLine(), out upperBound))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte znovu horní mez: ");
    }

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Zadané hodnoty:");
    Console.WriteLine("Počet čísel: {0}; Dolní mez: {1}; Horní mez: {2}", n, lowerBound, upperBound);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;

    int[] myRandNumbs = new int[n];

    Random myRandNumb = new Random();

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Pseudonáhodná čísla:");
    for (int i = 0; i < n; i++)
    {
        myRandNumbs[i] = myRandNumb.Next(lowerBound, upperBound + 1);
        Console.Write("{0}; ", myRandNumbs[i]);
    }

    //Zacatek meho kodu
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;

    //maximum generovanych cisel
    int maximumcisel;
    maximumcisel = myRandNumbs[0];
    for (int i = 1; i < myRandNumbs.Length; i++)
    {
        if (myRandNumbs[i] > maximumcisel)
        {
            maximumcisel = myRandNumbs[i];
        }
    }
    Console.WriteLine("Maximum generovaných čísel je: {0}",maximumcisel);

    //minimum generovanych cisel
    int minimumcisel;
    minimumcisel = myRandNumbs[0];
    for (int i = 1; i < myRandNumbs.Length; i++)
    {
        if (myRandNumbs[i] < minimumcisel)
        {
            minimumcisel = myRandNumbs[i];
        }
    }
    Console.WriteLine("Minimum generovaných čísel je: {0}",minimumcisel);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;

    //seřazení algoritmem selection sort
    for (int i = 0; i < myRandNumbs.Length - 1; i++)
    {
        int minIndex = i;
        for (int j = i + 1; j < myRandNumbs.Length; j++)
        {
            if (myRandNumbs[j] < myRandNumbs[minIndex])
            {
                minIndex = j;
            }
        }
        int temp = myRandNumbs[i];
        myRandNumbs[i] = myRandNumbs[minIndex];
        myRandNumbs[minIndex] = temp;
    }

    //Vypis serazenych cisel
    Console.WriteLine("Seřazená čísla:");
    for (int i = 0; i < myRandNumbs.Length; i++)
    {
        Console.Write("{0}; ", myRandNumbs[i]);
    }
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;

    //druhe nejvetsi cislo
    int druhenejvetsicislo = myRandNumbs[myRandNumbs.Length - 2];
    Console.WriteLine("Druhé největší číslo je: {0}", druhenejvetsicislo);

    //ctvrte nejvetsi cislo
    int ctvrtejvetsicislo = myRandNumbs[myRandNumbs.Length - 4];
    Console.WriteLine("Čtvrté největší číslo je: {0}", ctvrtejvetsicislo);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;

    //prumer generovanych cisel (vyjadreny celociselne)
    int soucet = 0;
    for (int i = 0; i < myRandNumbs.Length; i++)
    {
        soucet += myRandNumbs[i];
    }
    int prumer = soucet / myRandNumbs.Length;
    Console.WriteLine("Průměr generovaných čísel je: {0}", prumer);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;

    //nejmensi spolecny nasobek druheho a ctvrteho nejvetsiho cisla.
    int a = druhenejvetsicislo;
    int b = ctvrtejvetsicislo;  
    int nejmensinasobek = (a * b) / GCD(a, b);
    Console.WriteLine("NSN druhého a čtvrtého největšího čísla je: {0}", nejmensinasobek);
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    
    //nejvetsi spolecny delitel druheho a ctvrteho nejvetsiho cisla
    int nejvetsidelitel = GCD(a, b);
    Console.WriteLine("NSD druhého a čtvrtého největšího čísla je: {0}", nejvetsidelitel);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;

    //Vygenerovany obrazec - Sipka (1. Verze - generuje se pouze spodní část šipky)
    Console.WriteLine("Vygenerovaný obrazec:");
    Console.WriteLine("(Velikost se mění pouze dole)");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("        *        ");
    Console.WriteLine("      * * *      ");
    Console.WriteLine("    * *   * *    ");
    Console.WriteLine("  * * *   * * *  ");
    Console.WriteLine("* * * *   * * * *");

    //Opakování, dokud se nevypíše spodní část šípky, která je stejně velká jako průměr
    int x = 0;
    do
    {
    Console.WriteLine("      *   *      ");
    x++;
    } while (x < prumer-1);
    Console.WriteLine("      * * *      ");
    Console.ForegroundColor = ConsoleColor.White;





    //2. pokus po zjištění, že obrazec se mění i nahoře - bohužel nedokončeno
    /*Console.WriteLine("Vygenerovaný obrazec:");
    Console.WriteLine("(Velikost se mění i nahoře)");
    x = 0;
    do
    {
    Console.WriteLine("*");
    x++;
    } while (x < prumer-1);
*/






    Console.WriteLine();
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("================================================");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Pro opakování programu stiskněte klávesu a.");
    Console.ResetColor();
    again = Console.ReadLine();


}