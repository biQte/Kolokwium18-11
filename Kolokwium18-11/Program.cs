using System.Collections;

namespace Kolokwium18_11
{
    internal class Program
    {

        static void printArrayList(ArrayList array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Count; i++)
            {
                Console.Write(array[i]);
                if (i != array.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]\n");
        }

        static string[] readFile(String file)
        {
            string[] lines = File.ReadAllLines(file);
            return lines;
        }

        static bool isPrime(int a)
        {
            if(a < 2) return false;
            for (int i = 2; i < Math.Sqrt(a) + 1; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static ArrayList checkIdentificatorsForOnlyPrimeNumbers(string[] identificators)
        {
            ArrayList idsWithOnlyPrimeNumbers = new ArrayList();

            for (int i = 0; i < identificators.Length; i++)
            {
                int primeCount = 0;
                for (int j = 3; j < identificators[i].Length; j++)
                {
                    char c = identificators[i][j];
                    int a = int.Parse(c.ToString());


                    if (isPrime(a))
                    {
                        primeCount++;
                    }

                }

                if (primeCount == identificators[i].Length - 3 - 1) // If the value of the variable counting the occurrences of prime numbers in a given identifier(primeCount) is equal to the number of digits in that identifier, then the identifier consists only of prime numbers
                {
                    idsWithOnlyPrimeNumbers.Add(identificators[i]);
                }
            }

            return idsWithOnlyPrimeNumbers;
        }

        static ArrayList sumAllNumbersInIdentificators(string[] identificators)
        {
            ArrayList addedNumbersInIds = new ArrayList();

            for(int i = 0; i < identificators.Length; i++)
            {
                int sum = 0;
                for(int j = 3; j < identificators[i].Length; j++)
                {
                    char c = identificators[i][j];
                    int a = int.Parse(c.ToString());

                    sum += a;
                }

                addedNumbersInIds.Add(sum);
            }

            return addedNumbersInIds;
        }

        static void Main(string[] args)
        {

            string[] lines = readFile("identyfikator.txt");
            Console.WriteLine("Wszystkie identyfikatory: ");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();

            ArrayList identificatorsWithOnlyPrimeNumbers = checkIdentificatorsForOnlyPrimeNumbers(lines);

            Console.WriteLine("Identyfikatory w których znajdują się tylko liczby pierwsze: ");
            printArrayList(identificatorsWithOnlyPrimeNumbers);
            Console.WriteLine();

            Console.WriteLine("Sumy cyfr w każdym z identyfikatorów: ");
            ArrayList addedNumbersInIds = sumAllNumbersInIdentificators(lines);
            printArrayList(addedNumbersInIds);
        }
    }
}
