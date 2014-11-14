using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace euler
{
    class Program
    {
        private static List<decimal> maxFactor;
        private static List<decimal> primes_list;

        private static void init()
        {
            maxFactor = new List<decimal> { };
            primes_list = new List<decimal>{ 2, 3 };

            decimal candidate = primes_list.Max() + 2;
            bool gotOne;

            while (primes_list.Count < 10000)
            {
                gotOne = true;
                for (int i = 0; primes_list[i] <= (decimal)Math.Sqrt((double)candidate); i++)
                {
                    if (candidate % primes_list[i] == 0)
                    {
                        gotOne = false;
                        break;
                    }
                }
                if (gotOne)
                    primes_list.Add(candidate);

                candidate += 2;
            }

        }

        public static void Main(string[] args)
        {

            init();

            //Q1 Sum of all numbers under 1000 that are divisible by 3 and 5
            Debug.WriteLine(q1() + "");

            //Q2 Sum of all fibonacci numbers < 4,000,000 that are even numbers
            Debug.WriteLine(q2() + "");

            //Q3 Largest prime factor of 600851475143 - uses combination brute force and fermat's factorization method
            Debug.WriteLine(q3(600851475143) + "");

            //Q4 Find the largest palindrome made from the product of two 3-digit numbers.
            Debug.WriteLine(q4() + "");
            
            //Q5 What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20
            Debug.WriteLine(q5() + "");

            //Q6 Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
            Debug.WriteLine(q6() + "");

            //Q7 What is the 10 001st prime number?
            Debug.WriteLine(q7() + "");

            //Q8 Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
            Debug.WriteLine(q8() + "");

            //Q9 There exists exactly one Pythagorean triplet for which a + b + c = 1000.
            //Find the product abc.
            Debug.WriteLine(q9() + "");

            //Q10 Find the sum of all the primes below two million.
            Debug.WriteLine(q10() + "");

        }

        private static decimal q10()
        {
            decimal candidate = primes_list.Max() + 2;
            bool gotOne;

            while (candidate < 2000000)
            {
                gotOne = true;
                for (int i = 0; primes_list[i] <= (decimal)Math.Sqrt((double)candidate); i++)
                {
                    if (candidate % primes_list[i] == 0)
                    {
                        gotOne = false;
                        break;
                    }
                }
                if (gotOne)
                    primes_list.Add(candidate);

                candidate += 2;
            }

            return primes_list.Sum();

        
        }
        private static int q9()
        {
            for (int a = 1; a < 1000; a++)
            {
                for (int b = a; b < 1000; b++)
                {
                    int c = 1000 - a - b;
                    if (c > 0)
                    {
                        if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                            return (a * b * c);
                    }
                }
            }
            return 0;
        }

        private static decimal q8()
        {
            decimal candidate = 0;
            decimal multiplier = 1;
            decimal rtnSum = 0;

            List<decimal> series = new List<decimal>
            {
                7,3,1,6,7,1,7,6,5,3,1,3,3,0,6,2,4,9,1,9,2,2,5,1,1,9,6,7,4,4,2,6,5,7,4,7,4,2,3,5,5,3,4,9,1,9,4,9,3,4,
                9,6,9,8,3,5,2,0,3,1,2,7,7,4,5,0,6,3,2,6,2,3,9,5,7,8,3,1,8,0,1,6,9,8,4,8,0,1,8,6,9,4,7,8,8,5,1,8,4,3,
                8,5,8,6,1,5,6,0,7,8,9,1,1,2,9,4,9,4,9,5,4,5,9,5,0,1,7,3,7,9,5,8,3,3,1,9,5,2,8,5,3,2,0,8,8,0,5,5,1,1,
                1,2,5,4,0,6,9,8,7,4,7,1,5,8,5,2,3,8,6,3,0,5,0,7,1,5,6,9,3,2,9,0,9,6,3,2,9,5,2,2,7,4,4,3,0,4,3,5,5,7,
                6,6,8,9,6,6,4,8,9,5,0,4,4,5,2,4,4,5,2,3,1,6,1,7,3,1,8,5,6,4,0,3,0,9,8,7,1,1,1,2,1,7,2,2,3,8,3,1,1,3,
                6,2,2,2,9,8,9,3,4,2,3,3,8,0,3,0,8,1,3,5,3,3,6,2,7,6,6,1,4,2,8,2,8,0,6,4,4,4,4,8,6,6,4,5,2,3,8,7,4,9,
                3,0,3,5,8,9,0,7,2,9,6,2,9,0,4,9,1,5,6,0,4,4,0,7,7,2,3,9,0,7,1,3,8,1,0,5,1,5,8,5,9,3,0,7,9,6,0,8,6,6,
                7,0,1,7,2,4,2,7,1,2,1,8,8,3,9,9,8,7,9,7,9,0,8,7,9,2,2,7,4,9,2,1,9,0,1,6,9,9,7,2,0,8,8,8,0,9,3,7,7,6,
                6,5,7,2,7,3,3,3,0,0,1,0,5,3,3,6,7,8,8,1,2,2,0,2,3,5,4,2,1,8,0,9,7,5,1,2,5,4,5,4,0,5,9,4,7,5,2,2,4,3,
                5,2,5,8,4,9,0,7,7,1,1,6,7,0,5,5,6,0,1,3,6,0,4,8,3,9,5,8,6,4,4,6,7,0,6,3,2,4,4,1,5,7,2,2,1,5,5,3,9,7,
                5,3,6,9,7,8,1,7,9,7,7,8,4,6,1,7,4,0,6,4,9,5,5,1,4,9,2,9,0,8,6,2,5,6,9,3,2,1,9,7,8,4,6,8,6,2,2,4,8,2,
                8,3,9,7,2,2,4,1,3,7,5,6,5,7,0,5,6,0,5,7,4,9,0,2,6,1,4,0,7,9,7,2,9,6,8,6,5,2,4,1,4,5,3,5,1,0,0,4,7,4,
                8,2,1,6,6,3,7,0,4,8,4,4,0,3,1,9,9,8,9,0,0,0,8,8,9,5,2,4,3,4,5,0,6,5,8,5,4,1,2,2,7,5,8,8,6,6,6,8,8,1,
                1,6,4,2,7,1,7,1,4,7,9,9,2,4,4,4,2,9,2,8,2,3,0,8,6,3,4,6,5,6,7,4,8,1,3,9,1,9,1,2,3,1,6,2,8,2,4,5,8,6,
                1,7,8,6,6,4,5,8,3,5,9,1,2,4,5,6,6,5,2,9,4,7,6,5,4,5,6,8,2,8,4,8,9,1,2,8,8,3,1,4,2,6,0,7,6,9,0,0,4,2,
                2,4,2,1,9,0,2,2,6,7,1,0,5,5,6,2,6,3,2,1,1,1,1,1,0,9,3,7,0,5,4,4,2,1,7,5,0,6,9,4,1,6,5,8,9,6,0,4,0,8,
                0,7,1,9,8,4,0,3,8,5,0,9,6,2,4,5,5,4,4,4,3,6,2,9,8,1,2,3,0,9,8,7,8,7,9,9,2,7,2,4,4,2,8,4,9,0,9,1,8,8,
                8,4,5,8,0,1,5,6,1,6,6,0,9,7,9,1,9,1,3,3,8,7,5,4,9,9,2,0,0,5,2,4,0,6,3,6,8,9,9,1,2,5,6,0,7,1,7,6,0,6,
                0,5,8,8,6,1,1,6,4,6,7,1,0,9,4,0,5,0,7,7,5,4,1,0,0,2,2,5,6,9,8,3,1,5,5,2,0,0,0,5,5,9,3,5,7,2,9,7,2,5,
                7,1,6,3,6,2,6,9,5,6,1,8,8,2,6,7,0,4,2,8,2,5,2,4,8,3,6,0,0,8,2,3,2,5,7,5,3,0,4,2,0,7,5,2,9,6,3,4,5,0
            };
        
            for(int i = 0; i < series.Count - 13; i++)
            {
                candidate = 0;
                multiplier = 1;
                for (int j = 0; j < 13; j++)
                {
                    candidate = multiplier * series[i + j];
                    multiplier = candidate;
                }
                if (candidate > rtnSum)
                    rtnSum = candidate;
            }
            return rtnSum;
        }

        private static decimal q7()
        {
            decimal candidate = primes_list.Max() + 2;
            bool gotOne;

            while (primes_list.Count < 10001)
            {
                gotOne = true;
                for (int i = 0; primes_list[i] <= (decimal)Math.Sqrt((double)candidate); i++)
                {
                    if (candidate % primes_list[i] == 0)
                    {
                        gotOne = false;
                        break;
                    }

                }
                if (gotOne)
                    primes_list.Add(candidate);

                candidate += 2;

            }
            return primes_list.Max();
        }

        private static double q6()
        {
            double sumSquare = 0;
            double squareSum = 0;

            for (int i = 1; i <101; i++)
            {
                sumSquare = sumSquare + Math.Pow(i, 2);
                squareSum += i;
            }

            return (Math.Pow(squareSum, 2) - sumSquare);
        }

        private static int q5()
        {
            int candidate = 20;
            int currentFactor = 19;
            int currentAdd = 20;
            bool tryAgain = true;

            while (tryAgain)
            {
                tryAgain = false;
                while (candidate  % (currentFactor) != 0)
                {
                    candidate += currentAdd;
                }
                currentAdd = candidate;

                for (int i = 20; i > 0; i--)
                {
                    if (candidate % i != 0)
                    {
                        tryAgain = true;
                        currentFactor = i;
                        i = 0;
                    }
                }            
            }

            return candidate;
        }

        private static int q4()
        {
            int num_1 = 999;
            int num_2 = 999;

            int lowest = 0;
            int palind = 0;

            while (isPalindrome(num_1 * num_2) < 0)
            {
                if (num_1 == num_2)
                    num_1--;
                else
                    num_2--;
            }

            palind = num_1 * num_2;
            lowest = num_1;

            for (num_2 = lowest; num_2 < 1000; num_2++)
            {
                for (num_1 = num_2; num_1 < 1000; num_1++)
                {
                    if (isPalindrome(num_1 * num_2) > palind)
                    {
                        palind = isPalindrome(num_1 * num_2);
                    }
                 }
            }
            return palind;
        }

        public static int isPalindrome(int candidate)
        {
            int left = candidate;
            int r;
            int rev = 0;
            while (left > 0)
            {
                r = left % 10;
                rev = rev * 10 + r;
                left = left / 10;  //left = Math.floor(left / 10); 
            }
            if (rev == candidate)
                return rev;
            else
                return -1;

        }

        private static decimal q3(decimal numFactor)
        {
            maxFactor.Add(numFactor);
            while (addFactorsToList(maxFactor.Max())) ;
            return maxFactor.Max();
        }

        //Uses brute force for lower values and Fermats factorization method to find prime factors of the input > 100,000
        private static bool addFactorsToList(decimal numFactor)
        {
            bool addedSome = false;

            // First check if it is an even number - if it is divide by 2 and call again
            if (numFactor % 2 == 0)
            {
                maxFactor.Remove(numFactor);
                addFactorsToList(numFactor / 2);
                addedSome = true;
                return addedSome;
            }

            // check we're not a prime already - if we're prime here this is the correct answer
            if (primes_list.Contains(numFactor))
                return addedSome;

            // brute force for the first 10,000 primes
            foreach (decimal x in primes_list)
            {
                if (numFactor % x == 0)
                {
                    //got one
                    maxFactor.Add(x);
                    maxFactor.Add(numFactor / x);
                    addedSome = true;
                }

            }

            // fermat's factorization method used below
            // double approximation for Math class shouldn't be an issue on most machines
            decimal squareAdd = 1;
            decimal possSquare = numFactor + squareAdd;
            decimal squareEven = (decimal)Math.Ceiling(Math.Sqrt((double)numFactor));
            decimal squareTotal = (decimal)Math.Pow((double)squareEven, 2);

            decimal fct1, fct2;

            fct1 = 0;
            fct2 = 0;

            // All numbers are divisble by themselves and 1 so this will definitely halt at that point, but should stop once numbers to be checked are under 100k, this is trivial to change
            while (fct1 != numFactor)
            {
                if (possSquare == squareTotal)
                {
                    fct1 = squareEven + ((squareAdd + 1) / 2);
                    fct2 = squareEven - ((squareAdd + 1) / 2);

                    if (fct2 != 1)
                    {
                        // found some factors
                        // only add them if they're prime
                        if (IsPrime((int)fct1))
                        {
                            maxFactor.Add(fct1);
                            addedSome = true;
                        }
                        if (IsPrime((int)fct1))
                        {
                            maxFactor.Add(fct2);
                            addedSome = true;
                        }
                    }
                }

                squareAdd = squareAdd + 2;
                possSquare += squareAdd;

                while (squareTotal < possSquare)
                {
                    squareTotal += (squareEven * 2) + 1;
                    squareEven += 1;
                }
                // if we're checking values under 100k we can stop as it's been brute forced above
                if (squareEven - ((squareAdd + 1) / 2) < 100000)
                    break;

            }

            // If factors have been added remove the current factor as it isn't prime
            if (addedSome)
                maxFactor.Remove(numFactor);

            return addedSome;
        }

        // Warning - this will probably work but not guaranteed - see Carmichael Numbers
        private static bool IsPrime(int candidate)
        {
            //checking if candidate = 0 || 1 || 2
            double a = (double)candidate - 1; //candidate can't be divisor of candidate - 1

            double result = 1;
            for (int i = 0; i < candidate; i++)
            {
                result = result * a;
                result = result % candidate;
            }

            result -= a;
            return result == 0;
        }

        private static long q2()
        {
            long sum = 2;
            long fbnFirst = 1;
            long fbnSecond = 2;


            for (long currentTerm = 2; currentTerm <= 4000000; )
            {
                currentTerm = fbnFirst + fbnSecond;
                if (currentTerm % 2 == 0)
                    sum += currentTerm;

                fbnFirst = fbnSecond;
                fbnSecond = currentTerm;

            }
            return sum;
        }


        private static int q1()
        {
            int sum = 0;

            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }


            return sum;
        }


    }
}
