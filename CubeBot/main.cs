using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/**
 * 
 *   CubeBot2.0 by iBoot32
 * 
 *      A computer algorithm to solve any of the 43 
 *      quintillion possible scrambles of a 3x3 Rubik's Cube. 
 *      
 *      Your main interest here is likely cornersolver.cs and edgesolver.cs
 *      
 *      Together, they are standalone classes, that when 
 *      called with a cornerstring and an edgestring
 *      will return a solution to any Rubik's Cube. Simply
 *      download them, add them to your sokution, and call 
 *      cornersolver and then edgesolver as shown. This main
 *      form shows the barebones way to solve cubes using 
 *      a given scramble or given cstring + estring.
 * 
 *      This software is a free, open-source application.
 *      You are free to use this software in any application,
 *      commercial or not, as long as you EMAIL ME prior to
 *      using CubeBot2.0 (iboot32@gmail.com), and give me
 *      clear credit somewhere visible in your program.
 *      
 *      Project started 8/3/19
 *      (c) 2019 iBoot32
 */




namespace CubeBot
{
    class main
    {
        public static string cornerstring;
        public static string edgestring;
        public static bool timeplease = false;
        public static Stopwatch st = new Stopwatch();

        public static void Main(string[] args)
        {
            st.Start();
            if (args[args.Length - 1] == "time")
            {
                timeplease = true;
            }
            if (args[0] != "scr")
            {
                cornerstring = args[0];
                edgestring = args[1];

                cornersolver.alg(cornerstring, edgestring);
            }
            else
            {
                cubestringcalc.calc(args);
                cornersolver.alg(cubestringcalc.cornerstring, cubestringcalc.edgestring);
            }
        }

        public static void stage2()
        {
            edgesolver.alg(cornersolver.estring);
        }

        public static void finished()
        {
            foreach (var item in cornersolver.solutions)
            {
                Console.WriteLine("  " + item);
            }
            foreach (var item in edgesolver.solutions)
            {
                Console.WriteLine("  " + item);
            }
            st.Stop();
            double time = st.Elapsed.TotalMilliseconds;
            if (timeplease)
            {
                Console.WriteLine(Environment.NewLine + "  " + "time: " + time.ToString() + "ms");
            }
            Environment.Exit(0);
        }
    }
}
