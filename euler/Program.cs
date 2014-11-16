﻿using System;
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

            //Q9 There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.
            Debug.WriteLine(q9() + "");

            //Q10 Find the sum of all the primes below two million.
            Debug.WriteLine(q10() + "");

            //Q11 What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
            Debug.WriteLine(q11() + "");

            //Q12 What is the value of the first triangle number to have over five hundred divisors?
            Debug.WriteLine(q12() + "");

            //Q13 Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
            Debug.WriteLine(q13() + "");

            //Q14 Which starting number, under one million, produces the longest Collatz Sequence chain?
            Debug.WriteLine(q14() + "");

            //Q15 How many such routes are there through a 20×20 grid?
            Debug.WriteLine(q15() + "");

            //Q16 What is the sum of the digits of the number 2^1000?
            Debug.WriteLine(q16() + "");

            //Q17 What is the sum of the digits of the number 2^1000?
            Debug.WriteLine(q17() + "");

        }

        private static int q17()
        {
            IDictionary<int, string> numbers = new Dictionary<int, string> { };
            int total = 0;

            numbers.Add(0, "");
            numbers.Add(1, "one");
            numbers.Add(2, "two");
            numbers.Add(3, "three");
            numbers.Add(4, "four");
            numbers.Add(5, "five");
            numbers.Add(6, "six");
            numbers.Add(7, "seven");
            numbers.Add(8, "eight");
            numbers.Add(9, "nine");
            numbers.Add(10, "ten");
            numbers.Add(11, "eleven");
            numbers.Add(12, "twelve");
            numbers.Add(13, "thirteen");
            numbers.Add(14, "fourteen");
            numbers.Add(15, "fifteen");
            numbers.Add(16, "sixteen");
            numbers.Add(17, "seventeen");
            numbers.Add(18, "eighteen");
            numbers.Add(19, "nineteen");
            numbers.Add(20, "twenty");
            numbers.Add(30, "thirty");
            numbers.Add(40, "forty");
            numbers.Add(50, "fifty");
            numbers.Add(60, "sixty");
            numbers.Add(70, "seventy");
            numbers.Add(80, "eighty");
            numbers.Add(90, "ninety");
            numbers.Add(100, "hundred");
            numbers.Add(1000, "thousand");

            for (int i = 1; i <= 1000; i++ )
            {
                if (i < 20)
                    total += numbers[i].Length;
                else if (i < 100)
                    total += numbers[i - (i % 10)].Length + numbers[i % 10].Length;
                else if (i == 1000)
                    total += numbers[1].Length + numbers[1000].Length;
                else if ((i % 100) == 0)
                    total += numbers[(i - (i % 100)) / 100].Length + numbers[100].Length;
                else if ((i % 100) < 20)
                    total += numbers[(i - (i % 100)) / 100].Length + numbers[100].Length + 3 + numbers[i % 100].Length;
                else
                    total += numbers[(i - (i % 100)) / 100].Length + numbers[100].Length + 3 + numbers[(i % 100) - (i % 10)].Length + numbers[i % 10].Length;

            }

            return total;
        }

        private static double q16()
        {
            int[] powers = new int[3400];
            int[] powers_2 = new int[3400];
            int rtn_val = 0;

            for (int l = 0; l < 3400; l++ )
            {
                powers[l] = 0;
                powers_2[l] = 0;

            }

            powers[0] = 2;
            int current = 1;
            int remainder;

            for (int i = 0; i < 999; i++)
            {
                int j = 0;
                remainder = 0;

                while (j < current)
                {
                    powers_2[j] = ((powers[j] * 2) + remainder )% 10;
                    remainder = (((powers[j] * 2) + remainder) - (((powers[j] * 2) + remainder) % 10)) / 10;
                    j++;
                }
                current = j + 1;
                powers_2[j] = remainder;

                int k = 0;
                while (k <= current)
                {
                    powers[k] = powers_2[k];
                    powers_2[k] = 0;
                    k++;
                }

            }
            for (int y = 0; y < current; y++)
                rtn_val += powers[y];

            return rtn_val;
        }

        private static double q15()
        {
            double[,] path_grid = new double[21, 21];


            for (int l = 0; l < 21; l++)
            { 
                path_grid[0, l] = 1;
                path_grid[l, 0] = 1;
            }

            for (int i = 1; i < 21; i++)
            {
                for (int j = 1; j < 21; j++)
                {
                    path_grid[i, j] = path_grid[i - 1, j] + path_grid[i, j - 1];
                }
            }
            return path_grid[20, 20];

        }

        private static double q14()
        {
            double rtn_chain = 0;
            double current_chain;
            double start_num;
            double rtn_num = 0;

            for (double i = 1; i < 1000000; i++)
            {
                current_chain = 0;
                start_num = i;

                while (start_num != 1)
                {
                    current_chain++;
                    if (start_num % 2 == 0)
                        start_num = start_num / 2;
                    else
                        start_num = start_num * 3 + 1;
                }
                if (current_chain > rtn_chain)
                {
                    rtn_chain = current_chain;
                    rtn_num = i;
                }
            }

            return rtn_num;
        }
        private static string q13()
        {
            int[,] sum = new int[100,50] {
                {3,7,1,0,7,2,8,7,5,3,3,9,0,2,1,0,2,7,9,8,7,9,7,9,9,8,2,2,0,8,3,7,5,9,0,2,4,6,5,1,0,1,3,5,7,4,0,2,5,0},
                {4,6,3,7,6,9,3,7,6,7,7,4,9,0,0,0,9,7,1,2,6,4,8,1,2,4,8,9,6,9,7,0,0,7,8,0,5,0,4,1,7,0,1,8,2,6,0,5,3,8},
                {7,4,3,2,4,9,8,6,1,9,9,5,2,4,7,4,1,0,5,9,4,7,4,2,3,3,3,0,9,5,1,3,0,5,8,1,2,3,7,2,6,6,1,7,3,0,9,6,2,9},
                {9,1,9,4,2,2,1,3,3,6,3,5,7,4,1,6,1,5,7,2,5,2,2,4,3,0,5,6,3,3,0,1,8,1,1,0,7,2,4,0,6,1,5,4,9,0,8,2,5,0},
                {2,3,0,6,7,5,8,8,2,0,7,5,3,9,3,4,6,1,7,1,1,7,1,9,8,0,3,1,0,4,2,1,0,4,7,5,1,3,7,7,8,0,6,3,2,4,6,6,7,6},
                {8,9,2,6,1,6,7,0,6,9,6,6,2,3,6,3,3,8,2,0,1,3,6,3,7,8,4,1,8,3,8,3,6,8,4,1,7,8,7,3,4,3,6,1,7,2,6,7,5,7},
                {2,8,1,1,2,8,7,9,8,1,2,8,4,9,9,7,9,4,0,8,0,6,5,4,8,1,9,3,1,5,9,2,6,2,1,6,9,1,2,7,5,8,8,9,8,3,2,7,3,8},
                {4,4,2,7,4,2,2,8,9,1,7,4,3,2,5,2,0,3,2,1,9,2,3,5,8,9,4,2,2,8,7,6,7,9,6,4,8,7,6,7,0,2,7,2,1,8,9,3,1,8},
                {4,7,4,5,1,4,4,5,7,3,6,0,0,1,3,0,6,4,3,9,0,9,1,1,6,7,2,1,6,8,5,6,8,4,4,5,8,8,7,1,1,6,0,3,1,5,3,2,7,6},
                {7,0,3,8,6,4,8,6,1,0,5,8,4,3,0,2,5,4,3,9,9,3,9,6,1,9,8,2,8,9,1,7,5,9,3,6,6,5,6,8,6,7,5,7,9,3,4,9,5,1},
                {6,2,1,7,6,4,5,7,1,4,1,8,5,6,5,6,0,6,2,9,5,0,2,1,5,7,2,2,3,1,9,6,5,8,6,7,5,5,0,7,9,3,2,4,1,9,3,3,3,1},
                {6,4,9,0,6,3,5,2,4,6,2,7,4,1,9,0,4,9,2,9,1,0,1,4,3,2,4,4,5,8,1,3,8,2,2,6,6,3,3,4,7,9,4,4,7,5,8,1,7,8},
                {9,2,5,7,5,8,6,7,7,1,8,3,3,7,2,1,7,6,6,1,9,6,3,7,5,1,5,9,0,5,7,9,2,3,9,7,2,8,2,4,5,5,9,8,8,3,8,4,0,7},
                {5,8,2,0,3,5,6,5,3,2,5,3,5,9,3,9,9,0,0,8,4,0,2,6,3,3,5,6,8,9,4,8,8,3,0,1,8,9,4,5,8,6,2,8,2,2,7,8,2,8},
                {8,0,1,8,1,1,9,9,3,8,4,8,2,6,2,8,2,0,1,4,2,7,8,1,9,4,1,3,9,9,4,0,5,6,7,5,8,7,1,5,1,1,7,0,0,9,4,3,9,0},
                {3,5,3,9,8,6,6,4,3,7,2,8,2,7,1,1,2,6,5,3,8,2,9,9,8,7,2,4,0,7,8,4,4,7,3,0,5,3,1,9,0,1,0,4,2,9,3,5,8,6},
                {8,6,5,1,5,5,0,6,0,0,6,2,9,5,8,6,4,8,6,1,5,3,2,0,7,5,2,7,3,3,7,1,9,5,9,1,9,1,4,2,0,5,1,7,2,5,5,8,2,9},
                {7,1,6,9,3,8,8,8,7,0,7,7,1,5,4,6,6,4,9,9,1,1,5,5,9,3,4,8,7,6,0,3,5,3,2,9,2,1,7,1,4,9,7,0,0,5,6,9,3,8},
                {5,4,3,7,0,0,7,0,5,7,6,8,2,6,6,8,4,6,2,4,6,2,1,4,9,5,6,5,0,0,7,6,4,7,1,7,8,7,2,9,4,4,3,8,3,7,7,6,0,4},
                {5,3,2,8,2,6,5,4,1,0,8,7,5,6,8,2,8,4,4,3,1,9,1,1,9,0,6,3,4,6,9,4,0,3,7,8,5,5,2,1,7,7,7,9,2,9,5,1,4,5},
                {3,6,1,2,3,2,7,2,5,2,5,0,0,0,2,9,6,0,7,1,0,7,5,0,8,2,5,6,3,8,1,5,6,5,6,7,1,0,8,8,5,2,5,8,3,5,0,7,2,1},
                {4,5,8,7,6,5,7,6,1,7,2,4,1,0,9,7,6,4,4,7,3,3,9,1,1,0,6,0,7,2,1,8,2,6,5,2,3,6,8,7,7,2,2,3,6,3,6,0,4,5},
                {1,7,4,2,3,7,0,6,9,0,5,8,5,1,8,6,0,6,6,0,4,4,8,2,0,7,6,2,1,2,0,9,8,1,3,2,8,7,8,6,0,7,3,3,9,6,9,4,1,2},
                {8,1,1,4,2,6,6,0,4,1,8,0,8,6,8,3,0,6,1,9,3,2,8,4,6,0,8,1,1,1,9,1,0,6,1,5,5,6,9,4,0,5,1,2,6,8,9,6,9,2},
                {5,1,9,3,4,3,2,5,4,5,1,7,2,8,3,8,8,6,4,1,9,1,8,0,4,7,0,4,9,2,9,3,2,1,5,0,5,8,6,4,2,5,6,3,0,4,9,4,8,3},
                {6,2,4,6,7,2,2,1,6,4,8,4,3,5,0,7,6,2,0,1,7,2,7,9,1,8,0,3,9,9,4,4,6,9,3,0,0,4,7,3,2,9,5,6,3,4,0,6,9,1},
                {1,5,7,3,2,4,4,4,3,8,6,9,0,8,1,2,5,7,9,4,5,1,4,0,8,9,0,5,7,7,0,6,2,2,9,4,2,9,1,9,7,1,0,7,9,2,8,2,0,9},
                {5,5,0,3,7,6,8,7,5,2,5,6,7,8,7,7,3,0,9,1,8,6,2,5,4,0,7,4,4,9,6,9,8,4,4,5,0,8,3,3,0,3,9,3,6,8,2,1,2,6},
                {1,8,3,3,6,3,8,4,8,2,5,3,3,0,1,5,4,6,8,6,1,9,6,1,2,4,3,4,8,7,6,7,6,8,1,2,9,7,5,3,4,3,7,5,9,4,6,5,1,5},
                {8,0,3,8,6,2,8,7,5,9,2,8,7,8,4,9,0,2,0,1,5,2,1,6,8,5,5,5,4,8,2,8,7,1,7,2,0,1,2,1,9,2,5,7,7,6,6,9,5,4},
                {7,8,1,8,2,8,3,3,7,5,7,9,9,3,1,0,3,6,1,4,7,4,0,3,5,6,8,5,6,4,4,9,0,9,5,5,2,7,0,9,7,8,6,4,7,9,7,5,8,1},
                {1,6,7,2,6,3,2,0,1,0,0,4,3,6,8,9,7,8,4,2,5,5,3,5,3,9,9,2,0,9,3,1,8,3,7,4,4,1,4,9,7,8,0,6,8,6,0,9,8,4},
                {4,8,4,0,3,0,9,8,1,2,9,0,7,7,7,9,1,7,9,9,0,8,8,2,1,8,7,9,5,3,2,7,3,6,4,4,7,5,6,7,5,5,9,0,8,4,8,0,3,0},
                {8,7,0,8,6,9,8,7,5,5,1,3,9,2,7,1,1,8,5,4,5,1,7,0,7,8,5,4,4,1,6,1,8,5,2,4,2,4,3,2,0,6,9,3,1,5,0,3,3,2},
                {5,9,9,5,9,4,0,6,8,9,5,7,5,6,5,3,6,7,8,2,1,0,7,0,7,4,9,2,6,9,6,6,5,3,7,6,7,6,3,2,6,2,3,5,4,4,7,2,1,0},
                {6,9,7,9,3,9,5,0,6,7,9,6,5,2,6,9,4,7,4,2,5,9,7,7,0,9,7,3,9,1,6,6,6,9,3,7,6,3,0,4,2,6,3,3,9,8,7,0,8,5},
                {4,1,0,5,2,6,8,4,7,0,8,2,9,9,0,8,5,2,1,1,3,9,9,4,2,7,3,6,5,7,3,4,1,1,6,1,8,2,7,6,0,3,1,5,0,0,1,2,7,1},
                {6,5,3,7,8,6,0,7,3,6,1,5,0,1,0,8,0,8,5,7,0,0,9,1,4,9,9,3,9,5,1,2,5,5,7,0,2,8,1,9,8,7,4,6,0,0,4,3,7,5},
                {3,5,8,2,9,0,3,5,3,1,7,4,3,4,7,1,7,3,2,6,9,3,2,1,2,3,5,7,8,1,5,4,9,8,2,6,2,9,7,4,2,5,5,2,7,3,7,3,0,7},
                {9,4,9,5,3,7,5,9,7,6,5,1,0,5,3,0,5,9,4,6,9,6,6,0,6,7,6,8,3,1,5,6,5,7,4,3,7,7,1,6,7,4,0,1,8,7,5,2,7,5},
                {8,8,9,0,2,8,0,2,5,7,1,7,3,3,2,2,9,6,1,9,1,7,6,6,6,8,7,1,3,8,1,9,9,3,1,8,1,1,0,4,8,7,7,0,1,9,0,2,7,1},
                {2,5,2,6,7,6,8,0,2,7,6,0,7,8,0,0,3,0,1,3,6,7,8,6,8,0,9,9,2,5,2,5,4,6,3,4,0,1,0,6,1,6,3,2,8,6,6,5,2,6},
                {3,6,2,7,0,2,1,8,5,4,0,4,9,7,7,0,5,5,8,5,6,2,9,9,4,6,5,8,0,6,3,6,2,3,7,9,9,3,1,4,0,7,4,6,2,5,5,9,6,2},
                {2,4,0,7,4,4,8,6,9,0,8,2,3,1,1,7,4,9,7,7,7,9,2,3,6,5,4,6,6,2,5,7,2,4,6,9,2,3,3,2,2,8,1,0,9,1,7,1,4,1},
                {9,1,4,3,0,2,8,8,1,9,7,1,0,3,2,8,8,5,9,7,8,0,6,6,6,9,7,6,0,8,9,2,9,3,8,6,3,8,2,8,5,0,2,5,3,3,3,4,0,3},
                {3,4,4,1,3,0,6,5,5,7,8,0,1,6,1,2,7,8,1,5,9,2,1,8,1,5,0,0,5,5,6,1,8,6,8,8,3,6,4,6,8,4,2,0,0,9,0,4,7,0},
                {2,3,0,5,3,0,8,1,1,7,2,8,1,6,4,3,0,4,8,7,6,2,3,7,9,1,9,6,9,8,4,2,4,8,7,2,5,5,0,3,6,6,3,8,7,8,4,5,8,3},
                {1,1,4,8,7,6,9,6,9,3,2,1,5,4,9,0,2,8,1,0,4,2,4,0,2,0,1,3,8,3,3,5,1,2,4,4,6,2,1,8,1,4,4,1,7,7,3,4,7,0},
                {6,3,7,8,3,2,9,9,4,9,0,6,3,6,2,5,9,6,6,6,4,9,8,5,8,7,6,1,8,2,2,1,2,2,5,2,2,5,5,1,2,4,8,6,7,6,4,5,3,3},
                {6,7,7,2,0,1,8,6,9,7,1,6,9,8,5,4,4,3,1,2,4,1,9,5,7,2,4,0,9,9,1,3,9,5,9,0,0,8,9,5,2,3,1,0,0,5,8,8,2,2},
                {9,5,5,4,8,2,5,5,3,0,0,2,6,3,5,2,0,7,8,1,5,3,2,2,9,6,7,9,6,2,4,9,4,8,1,6,4,1,9,5,3,8,6,8,2,1,8,7,7,4},
                {7,6,0,8,5,3,2,7,1,3,2,2,8,5,7,2,3,1,1,0,4,2,4,8,0,3,4,5,6,1,2,4,8,6,7,6,9,7,0,6,4,5,0,7,9,9,5,2,3,6},
                {3,7,7,7,4,2,4,2,5,3,5,4,1,1,2,9,1,6,8,4,2,7,6,8,6,5,5,3,8,9,2,6,2,0,5,0,2,4,9,1,0,3,2,6,5,7,2,9,6,7},
                {2,3,7,0,1,9,1,3,2,7,5,7,2,5,6,7,5,2,8,5,6,5,3,2,4,8,2,5,8,2,6,5,4,6,3,0,9,2,2,0,7,0,5,8,5,9,6,5,2,2},
                {2,9,7,9,8,8,6,0,2,7,2,2,5,8,3,3,1,9,1,3,1,2,6,3,7,5,1,4,7,3,4,1,9,9,4,8,8,9,5,3,4,7,6,5,7,4,5,5,0,1},
                {1,8,4,9,5,7,0,1,4,5,4,8,7,9,2,8,8,9,8,4,8,5,6,8,2,7,7,2,6,0,7,7,7,1,3,7,2,1,4,0,3,7,9,8,8,7,9,7,1,5},
                {3,8,2,9,8,2,0,3,7,8,3,0,3,1,4,7,3,5,2,7,7,2,1,5,8,0,3,4,8,1,4,4,5,1,3,4,9,1,3,7,3,2,2,6,6,5,1,3,8,1},
                {3,4,8,2,9,5,4,3,8,2,9,1,9,9,9,1,8,1,8,0,2,7,8,9,1,6,5,2,2,4,3,1,0,2,7,3,9,2,2,5,1,1,2,2,8,6,9,5,3,9},
                {4,0,9,5,7,9,5,3,0,6,6,4,0,5,2,3,2,6,3,2,5,3,8,0,4,4,1,0,0,0,5,9,6,5,4,9,3,9,1,5,9,8,7,9,5,9,3,6,3,5},
                {2,9,7,4,6,1,5,2,1,8,5,5,0,2,3,7,1,3,0,7,6,4,2,2,5,5,1,2,1,1,8,3,6,9,3,8,0,3,5,8,0,3,8,8,5,8,4,9,0,3},
                {4,1,6,9,8,1,1,6,2,2,2,0,7,2,9,7,7,1,8,6,1,5,8,2,3,6,6,7,8,4,2,4,6,8,9,1,5,7,9,9,3,5,3,2,9,6,1,9,2,2},
                {6,2,4,6,7,9,5,7,1,9,4,4,0,1,2,6,9,0,4,3,8,7,7,1,0,7,2,7,5,0,4,8,1,0,2,3,9,0,8,9,5,5,2,3,5,9,7,4,5,7},
                {2,3,1,8,9,7,0,6,7,7,2,5,4,7,9,1,5,0,6,1,5,0,5,5,0,4,9,5,3,9,2,2,9,7,9,5,3,0,9,0,1,1,2,9,9,6,7,5,1,9},
                {8,6,1,8,8,0,8,8,2,2,5,8,7,5,3,1,4,5,2,9,5,8,4,0,9,9,2,5,1,2,0,3,8,2,9,0,0,9,4,0,7,7,7,0,7,7,5,6,7,2},
                {1,1,3,0,6,7,3,9,7,0,8,3,0,4,7,2,4,4,8,3,8,1,6,5,3,3,8,7,3,5,0,2,3,4,0,8,4,5,6,4,7,0,5,8,0,7,7,3,0,8},
                {8,2,9,5,9,1,7,4,7,6,7,1,4,0,3,6,3,1,9,8,0,0,8,1,8,7,1,2,9,0,1,1,8,7,5,4,9,1,3,1,0,5,4,7,1,2,6,5,8,1},
                {9,7,6,2,3,3,3,1,0,4,4,8,1,8,3,8,6,2,6,9,5,1,5,4,5,6,3,3,4,9,2,6,3,6,6,5,7,2,8,9,7,5,6,3,4,0,0,5,0,0},
                {4,2,8,4,6,2,8,0,1,8,3,5,1,7,0,7,0,5,2,7,8,3,1,8,3,9,4,2,5,8,8,2,1,4,5,5,2,1,2,2,7,2,5,1,2,5,0,3,2,7},
                {5,5,1,2,1,6,0,3,5,4,6,9,8,1,2,0,0,5,8,1,7,6,2,1,6,5,2,1,2,8,2,7,6,5,2,7,5,1,6,9,1,2,9,6,8,9,7,7,8,9},
                {3,2,2,3,8,1,9,5,7,3,4,3,2,9,3,3,9,9,4,6,4,3,7,5,0,1,9,0,7,8,3,6,9,4,5,7,6,5,8,8,3,3,5,2,3,9,9,8,8,6},
                {7,5,5,0,6,1,6,4,9,6,5,1,8,4,7,7,5,1,8,0,7,3,8,1,6,8,8,3,7,8,6,1,0,9,1,5,2,7,3,5,7,9,2,9,7,0,1,3,3,7},
                {6,2,1,7,7,8,4,2,7,5,2,1,9,2,6,2,3,4,0,1,9,4,2,3,9,9,6,3,9,1,6,8,0,4,4,9,8,3,9,9,3,1,7,3,3,1,2,7,3,1},
                {3,2,9,2,4,1,8,5,7,0,7,1,4,7,3,4,9,5,6,6,9,1,6,6,7,4,6,8,7,6,3,4,6,6,0,9,1,5,0,3,5,9,1,4,6,7,7,5,0,4},
                {9,9,5,1,8,6,7,1,4,3,0,2,3,5,2,1,9,6,2,8,8,9,4,8,9,0,1,0,2,4,2,3,3,2,5,1,1,6,9,1,3,6,1,9,6,2,6,6,2,2},
                {7,3,2,6,7,4,6,0,8,0,0,5,9,1,5,4,7,4,7,1,8,3,0,7,9,8,3,9,2,8,6,8,5,3,5,2,0,6,9,4,6,9,4,4,5,4,0,7,2,4},
                {7,6,8,4,1,8,2,2,5,2,4,6,7,4,4,1,7,1,6,1,5,1,4,0,3,6,4,2,7,9,8,2,2,7,3,3,4,8,0,5,5,5,5,6,2,1,4,8,1,8},
                {9,7,1,4,2,6,1,7,9,1,0,3,4,2,5,9,8,6,4,7,2,0,4,5,1,6,8,9,3,9,8,9,4,2,2,1,7,9,8,2,6,0,8,8,0,7,6,8,5,2},
                {8,7,7,8,3,6,4,6,1,8,2,7,9,9,3,4,6,3,1,3,7,6,7,7,5,4,3,0,7,8,0,9,3,6,3,3,3,3,0,1,8,9,8,2,6,4,2,0,9,0},
                {1,0,8,4,8,8,0,2,5,2,1,6,7,4,6,7,0,8,8,3,2,1,5,1,2,0,1,8,5,8,8,3,5,4,3,2,2,3,8,1,2,8,7,6,9,5,2,7,8,6},
                {7,1,3,2,9,6,1,2,4,7,4,7,8,2,4,6,4,5,3,8,6,3,6,9,9,3,0,0,9,0,4,9,3,1,0,3,6,3,6,1,9,7,6,3,8,7,8,0,3,9},
                {6,2,1,8,4,0,7,3,5,7,2,3,9,9,7,9,4,2,2,3,4,0,6,2,3,5,3,9,3,8,0,8,3,3,9,6,5,1,3,2,7,4,0,8,0,1,1,1,1,6},
                {6,6,6,2,7,8,9,1,9,8,1,4,8,8,0,8,7,7,9,7,9,4,1,8,7,6,8,7,6,1,4,4,2,3,0,0,3,0,9,8,4,4,9,0,8,5,1,4,1,1},
                {6,0,6,6,1,8,2,6,2,9,3,6,8,2,8,3,6,7,6,4,7,4,4,7,7,9,2,3,9,1,8,0,3,3,5,1,1,0,9,8,9,0,6,9,7,9,0,7,1,4},
                {8,5,7,8,6,9,4,4,0,8,9,5,5,2,9,9,0,6,5,3,6,4,0,4,4,7,4,2,5,5,7,6,0,8,3,6,5,9,9,7,6,6,4,5,7,9,5,0,9,6},
                {6,6,0,2,4,3,9,6,4,0,9,9,0,5,3,8,9,6,0,7,1,2,0,1,9,8,2,1,9,9,7,6,0,4,7,5,9,9,4,9,0,1,9,7,2,3,0,2,9,7},
                {6,4,9,1,3,9,8,2,6,8,0,0,3,2,9,7,3,1,5,6,0,3,7,1,2,0,0,4,1,3,7,7,9,0,3,7,8,5,5,6,6,0,8,5,0,8,9,2,5,2},
                {1,6,7,3,0,9,3,9,3,1,9,8,7,2,7,5,0,2,7,5,4,6,8,9,0,6,9,0,3,7,0,7,5,3,9,4,1,3,0,4,2,6,5,2,3,1,5,0,1,1},
                {9,4,8,0,9,3,7,7,2,4,5,0,4,8,7,9,5,1,5,0,9,5,4,1,0,0,9,2,1,6,4,5,8,6,3,7,5,4,7,1,0,5,9,8,4,3,6,7,9,1},
                {7,8,6,3,9,1,6,7,0,2,1,1,8,7,4,9,2,4,3,1,9,9,5,7,0,0,6,4,1,9,1,7,9,6,9,7,7,7,5,9,9,0,2,8,3,0,0,6,9,9},
                {1,5,3,6,8,7,1,3,7,1,1,9,3,6,6,1,4,9,5,2,8,1,1,3,0,5,8,7,6,3,8,0,2,7,8,4,1,0,7,5,4,4,4,9,7,3,3,0,7,8},
                {4,0,7,8,9,9,2,3,1,1,5,5,3,5,5,6,2,5,6,1,1,4,2,3,2,2,4,2,3,2,5,5,0,3,3,6,8,5,4,4,2,4,8,8,9,1,7,3,5,3},
                {4,4,8,8,9,9,1,1,5,0,1,4,4,0,6,4,8,0,2,0,3,6,9,0,6,8,0,6,3,9,6,0,6,7,2,3,2,2,1,9,3,2,0,4,1,4,9,5,3,5},
                {4,1,5,0,3,1,2,8,8,8,0,3,3,9,5,3,6,0,5,3,2,9,9,3,4,0,3,6,8,0,0,6,9,7,7,7,1,0,6,5,0,5,6,6,6,3,1,9,5,4},
                {8,1,2,3,4,8,8,0,6,7,3,2,1,0,1,4,6,7,3,9,0,5,8,5,6,8,5,5,7,9,3,4,5,8,1,4,0,3,6,2,7,8,2,2,7,0,3,2,8,0},
                {8,2,6,1,6,5,7,0,7,7,3,9,4,8,3,2,7,5,9,2,2,3,2,8,4,5,9,4,1,7,0,6,5,2,5,0,9,4,5,1,2,3,2,5,2,3,0,6,0,8},
                {2,2,9,1,8,8,0,2,0,5,8,7,7,7,3,1,9,7,1,9,8,3,9,4,5,0,1,8,0,8,8,8,0,7,2,4,2,9,6,6,1,9,8,0,8,1,1,1,9,7},
                {7,7,1,5,8,5,4,2,5,0,2,0,1,6,5,4,5,0,9,0,4,1,3,2,4,5,8,0,9,7,8,6,8,8,2,7,7,8,9,4,8,7,2,1,8,5,9,6,1,7},
                {7,2,1,0,7,8,3,8,4,3,5,0,6,9,1,8,6,1,5,5,4,3,5,6,6,2,8,8,4,0,6,2,2,5,7,4,7,3,6,9,2,2,8,4,5,0,9,5,1,6},
                {2,0,8,4,9,6,0,3,9,8,0,1,3,4,0,0,1,7,2,3,9,3,0,6,7,1,6,6,6,8,2,3,5,5,5,2,4,5,2,5,2,8,0,4,6,0,9,7,2,2},
                {5,3,5,0,3,5,3,4,2,2,6,4,7,2,5,2,4,2,5,0,8,7,4,0,5,4,0,7,5,5,9,1,7,8,9,7,8,1,2,6,4,3,3,0,3,3,1,6,9,0}                
            };

            int carryOver = 0;
            int prelimTotal;
            string[] total = new string[52];

            for (int j = 0; j < 50; j++)
            {
                prelimTotal = carryOver;
                for (int i = 0; i < 100; i++)
                {
                    prelimTotal += sum[i, 49 - j];
                }
                total[j] = (prelimTotal % 10) + "";
                carryOver = (prelimTotal - (prelimTotal % 10)) / 10;
            }

            return carryOver + total[49] + total[48] + total[47] + total[46] + total[45] + total[44] + total[43] + total[42];

        }
        private static double q12()
        {
            double currentPoss = 7;
            double total = 28;
            List<double> numDivisors = new List<double> { };

            while(numDivisors.Count < 499)
            {
                currentPoss++;
                total += currentPoss;

                numDivisors.Clear();
                numDivisors.Add(1);
                numDivisors.Add(total);

                for (double i = 1; i <= Math.Sqrt(total); i++)
                {
                    if (total % i == 0)
                    {
                        if (!numDivisors.Contains(i))
                            numDivisors.Add(i);
                        if (!numDivisors.Contains(total / i))
                            numDivisors.Add(total / i);
                    }

                }

            }

            return total;
        }

        // This is a pretty bad hack approach but it works ok
        private static double q11()
        {
            /*
             * In the 20×20 grid below, four numbers along a diagonal line have been marked in red.
             *
             *    08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
             *    49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
             *    81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
             *    52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
             *    22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
             *    24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
             *    32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
             *    67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
             *    24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
             *    21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
             *    78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
             *    16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
             *    86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
             *    19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
             *    04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
             *    88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
             *    04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
             *    20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
             *    20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
             *    01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48
             *   
             *    The product of these numbers is 26 × 63 × 78 × 14 = 1788696.
             *
             *   What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
             */

            double[,] grid;
            grid = new double[20,20]
            {
                {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}
            };

            double candidate;
            double multiplier;
            double rtnSum = 0;

            for (int x = 0; x < 17; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    candidate = 0;
                    multiplier = 1;

                    //Checking right
                    for (int i = 0; i < 4; i++)
                    {
                        candidate = multiplier * grid[y, x + i];
                        multiplier = candidate;
                    }

                    if (candidate > rtnSum)
                        rtnSum = candidate;

                    candidate = 0;
                    multiplier = 1;

                    //Checking down
                    for (int i = 0; i < 4; i++)
                    {
                        candidate = multiplier * grid[x + i, y];
                        multiplier = candidate;
                    }
                    if (candidate > rtnSum)
                        rtnSum = candidate;

                    candidate = 0;
                    multiplier = 1;

                    //Checking left
                    for (int i = 0; i < 4; i++)
                    {
                        candidate = multiplier * grid[19 - x - i, 19 - y];
                        multiplier = candidate;
                    }
                    if (candidate > rtnSum)
                        rtnSum = candidate;

                    candidate = 0;
                    multiplier = 1;

                    //Checking up
                    for (int i = 0; i < 4; i++)
                    {
                        candidate = multiplier * grid[19 - y, 19 - x - i];
                        multiplier = candidate;
                    }
                    if (candidate > rtnSum)
                        rtnSum = candidate;

                    candidate = 0;
                    multiplier = 1;

                    if (y < 17)
                    {
                        // Check diagonal
                        candidate = 0;
                        multiplier = 1;

                        //Checking down and right
                        for (int i = 0; i < 4; i++)
                        {
                            candidate = multiplier * grid[y + i, x + i];
                            multiplier = candidate;
                        }

                        if (candidate > rtnSum)
                            rtnSum = candidate;

                        candidate = 0;
                        multiplier = 1;

                        //Checking down and left
                        for (int i = 0; i < 4; i++)
                        {
                            candidate = multiplier * grid[y + i, 19 - x - i];
                            multiplier = candidate;
                        }
                        if (candidate > rtnSum)
                            rtnSum = candidate;

                        candidate = 0;
                        multiplier = 1;

                        //Checking up and right
                        for (int i = 0; i < 4; i++)
                        {
                            candidate = multiplier * grid[19 - y - i, x + i];
                            multiplier = candidate;
                        }
                        if (candidate > rtnSum)
                            rtnSum = candidate;

                        candidate = 0;
                        multiplier = 1;

                        //Checking up and left
                        for (int i = 0; i < 4; i++)
                        {
                            candidate = multiplier * grid[19 - x - i, 19 - y - i];
                            multiplier = candidate;
                        }
                        if (candidate > rtnSum)
                            rtnSum = candidate;

                        candidate = 0;
                        multiplier = 1;

                    }
                }
            }


            return rtnSum;
        }

        // This could be sped up a lot by using double - but getting errors on my machine with doubles
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
