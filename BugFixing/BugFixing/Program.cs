﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BugFixing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //int nY, missing semicolon. 
            int nY;
            int nAnswer;

            //Console.WriteLine(This program calculates x ^ y.); No quotation marks. Compile-time
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //Console.ReadLine();
                sNumber = Console.ReadLine(); //sNumber was not declared properly. Compile-time
            }
            while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } //while (int.TryParse(sNumber, out nX)); Was X instead of Y, plus was int.tryParse and not !int Runtime. 
            while (!int.TryParse(sNumber, out nY));

            // compute the exponent of the number using a recursive function
            nAnswer = Power(nX, nY);

            //Console.WriteLine("{nX}^{nY} = {nAnswer}"); Logic error. Was not actually printing values. 
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
        }


        //int Power(int nBase, int nExponent)
        static int Power(int nBase, int nExponent) //Needed to have static involved. Compile-time
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //returnVal = 0;
                returnVal = 1; //1 is the base case, not 0. Logic
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //nextVal = Power(nBase, nExponent + 1); Was doing +1, not -1. Runtime
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //returnVal; This doesn't actually return the value. Compile-time
            return returnVal; 
        }
    }
}
 