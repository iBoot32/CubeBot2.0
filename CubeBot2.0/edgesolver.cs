using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CubeBot2._0
{
    class edgesolver
    {
        public static string cubestring;
        public static string[] current = new string[13];
        public static string TPerm = "(R U R' U' R' F R2 U' R' U' R U R' F')";
        public static List<string> solvedpieces = new List<string>();


        public static string[] solved = new string[] //define state of solved cube
        {
                "WB", "WR", "WG", "WO", "BO", "GO", "GR", "BR", "YG", "YR", "YB", "YO"
        };

        public static string setup;
        public static string und;
        public static string oldpiece;
        public static string newpiece;
        public static int oldedgecolor;
        public static int newedgecolor;
        public static bool cubeissolved = true;
        private static int shoot;
        public static List<string> solutions = new List<string>();

        public static void alg(string args)
        {
            cubestring = args;

            int sub = 0;
            for (int i = 0; i < 12; i++)
            {
                current[i] = cubestring.Substring(sub, 2);
                sub = sub + 2;
            }

            oldpiece = "A";
            oldedgecolor = 0;

            findsetup(current[1]);
            string solution = setup + " " + TPerm + " " + und;
            solutions.Add(solution);

            updatecurrent();
            solvenextedge();
        }

        public static void solvenextedge()
        {
            for (int i = 0; i < 12; i++)
            {
                if (current[i] != solved[i])
                {
                    cubeissolved = false;
                }
            }
            if (cubeissolved)
            {
                done();
            }
            cubeissolved = true; //not actually solved, just restore default state for next loop (or else everything breaks)

            if (current[1] == solved[1]) //if buffer is solved
            {
                HandleTwist();
            }

            oldedgecolor = 0;
            findsetup(current[1]);

            string solution = setup + " " + TPerm + " " + und;
            solutions.Add(solution);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
            updatecurrent();
            solvenextedge();
        }



        public static void FindIfAnySolvedPieces()
        {
            for (int i = 0; i < current.Length - 2; i++)
            {
                if (current[i] == solved[i])
                {
                    solvedpieces.Add(belongs(current[i], "loc"));
                }
            }
        }

        public static string belongs(string a, string mode)
        {
            switch (mode)
            {
                case "loc" when a.Contains("W") && a.Contains("B"):
                    return "TB";
                case "loc" when a.Contains("W") && a.Contains("R"):
                    return "TR";
                case "loc" when a.Contains("W") && a.Contains("G"):
                    return "TF";
                case "loc" when a.Contains("W") && a.Contains("O"):
                    return "TL";
                case "loc" when a.Contains("B") && a.Contains("O"):
                    return "BL";
                case "loc" when a.Contains("G") && a.Contains("O"):
                    return "FL";
                case "loc" when a.Contains("G") && a.Contains("R"):
                    return "FR";
                case "loc" when a.Contains("B") && a.Contains("R"):
                    return "BR";
                case "loc" when a.Contains("Y") && a.Contains("G"):
                    return "DF";
                case "loc" when a.Contains("Y") && a.Contains("R"):
                    return "DR";
                case "loc" when a.Contains("Y") && a.Contains("B"):
                    return "DB";
                case "loc" when a.Contains("Y") && a.Contains("O"):
                    return "DL";
                case "loc":
                    return "bug";
            }

            return "bug";
        }

        public static void findsetup(string c)
        {
            //definitely need to clean this up somehow
            //convert to switch statement???
            if (c.Contains("W") && c.Contains("B"))
            {
                if (c.Substring(0, 1) == "W")
                {
                    setup = "R2 U' R2";
                    und = "R2 U R2";
                    newpiece = "A";
                    newedgecolor = 0;
                }
                if (c.Substring(0, 1) == "B")
                {
                    setup = "R2 U’ L2 R2 D U’ F U L’";
                    und = "L U' F' U D' R2 L2 U R2";
                    newpiece = "Q";
                    newedgecolor = 0;
                }
            }
            if (c.Contains("W") && c.Contains("R"))
            {
                if (c.Substring(0, 1) == "W")
                {
                    setup = "";
                    und = "";
                    newpiece = "B";
                    newedgecolor = 1;
                    HandleTwist();
                }
                if (c.Substring(0, 1) == "R")
                {
                    setup = "";
                    und = "";
                    newpiece = "M";
                    newedgecolor = 1;
                    HandleTwist();
                }
            }
            if (c.Contains("W") && c.Contains("G"))
            {
                if (c.Substring(0, 1) == "W")
                {
                    setup = "R2 U R2";
                    und = "R2 U' R2";
                    newpiece = "C";
                    newedgecolor = 2;
                }
                if (c.Substring(0, 1) == "G")
                {
                    setup = "R F’ L’ R’";
                    und = "R L F R'";
                    newpiece = "I";
                    newedgecolor = 2;
                }
            }
            if (c.Contains("W") && c.Contains("O"))
            {
                if (c.Substring(0, 1) == "W")
                {
                    setup = "";
                    und = "";
                    newpiece = "D";
                    newedgecolor = 3;
                }
                if (c.Substring(0, 1) == "O")
                {
                    setup = "L2 D U’ F U L’";
                    und = "L U' F' U D' L2";
                    newpiece = "E";
                    newedgecolor = 3;
                }
            }
            if (c.Contains("B") && c.Contains("O"))
            {
                if (c.Substring(0, 1) == "B")
                {
                    setup = "L";
                    und = "L'";
                    newpiece = "R";
                    newedgecolor = 4;
                }
                if (c.Substring(0, 1) == "O")
                {
                    setup = "U B’ U’";
                    und = "U B U'";
                    newpiece = "H";
                    newedgecolor = 4;
                }
            }
            if (c.Contains("G") && c.Contains("O"))
            {
                if (c.Substring(0, 1) == "G")
                {
                    setup = "L'";
                    und = "L";
                    newpiece = "L";
                    newedgecolor = 5;
                }
                if (c.Substring(0, 1) == "O")
                {
                    setup = "U’ F U";
                    und = "U' F' U";
                    newpiece = "F";
                    newedgecolor = 5;
                }
            }
            if (c.Contains("G") && c.Contains("R"))
            {
                if (c.Substring(0, 1) == "G")
                {
                    setup = "U2 R U2";
                    und = "U2 R' U2";
                    newpiece = "J";
                    newedgecolor = 6;
                }
                if (c.Substring(0, 1) == "R")
                {
                    setup = "U’ F’ U";
                    und = "U' F U";
                    newpiece = "P";
                    newedgecolor = 6;
                }
            }
            if (c.Contains("B") && c.Contains("R"))
            {
                if (c.Substring(0, 1) == "B")
                {
                    setup = "U2 R' U2";
                    und = "U2 R U2";
                    newpiece = "T";
                    newedgecolor = 7;
                }
                if (c.Substring(0, 1) == "R")
                {
                    setup = "U B U'";
                    und = "U B' U'";
                    newpiece = "N";
                    newedgecolor = 7;
                }
            }
            if (c.Contains("Y") && c.Contains("G"))
            {
                if (c.Substring(0, 1) == "Y")
                {
                    setup = "D' L2";
                    und = "L2 D";
                    newpiece = "U";
                    newedgecolor = 8;
                }
                if (c.Substring(0, 1) == "G")
                {
                    setup = "U’ F U L’";
                    und = "L U' F' U";
                    newpiece = "K";
                    newedgecolor = 8;
                }
            }
            if (c.Contains("Y") && c.Contains("R"))
            {
                if (c.Substring(0, 1) == "Y")
                {
                    setup = "D2 L2";
                    und = "L2 D2";
                    newpiece = "V";
                    newedgecolor = 9;
                }
                if (c.Substring(0, 1) == "R")
                {
                    setup = "U2 R’ U’ B U’";
                    und = "U B' U R U2";
                    newpiece = "O";
                    newedgecolor = 9;
                }
            }
            if (c.Contains("Y") && c.Contains("B"))
            {
                if (c.Substring(0, 1) == "Y")
                {
                    setup = "D L2";
                    und = "L2 D'";
                    newpiece = "W";
                    newedgecolor = 10;
                }
                if (c.Substring(0, 1) == "B")
                {
                    setup = "D2 U’ F U L’";
                    und = "L U' F' U D2";
                    newpiece = "S";
                    newedgecolor = 10;
                }
            }
            if (c.Contains("Y") && c.Contains("O"))
            {
                if (c.Substring(0, 1) == "Y")
                {
                    setup = "L2";
                    und = "L2";
                    newpiece = "X";
                    newedgecolor = 11;
                }
                if (c.Substring(0, 1) == "O")
                {
                    setup = "D U’ F U L’";
                    und = "L U' F' U D'";
                    newpiece = "G";
                    newedgecolor = 11;
                }
            }
        }

        public static void updatecurrent()
        {
            switch (newpiece)
            {
                case "A":
                    //this stuff here will swap the buffer and piece we shot to, and put each color in the correct orientation we will see in real life
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2); //swap buffer sticker 1 with shot sticker 1, an buffer sticker 2 with buffer sticker 2
                    return;
                case "C":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "D":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "E":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "F":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "G":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "H":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "I":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "J":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "K":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "L":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "N":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "O":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "P":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "Q":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "R":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "S":
                    swapchar(current[1], current[newedgecolor], 1, 2, 2, 1);
                    return;
                case "T":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "U":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "V":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "W":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
                case "X":
                    swapchar(current[1], current[newedgecolor], 1, 1, 2, 2);
                    return;
            }
        }

        public static void swapchar(string buffer, string shotto, int buff_swap1_buffchar, int buff_swap1_shotchar, int buff_swap2_buffchar, int buff_swap2_shotchar)
        {

            //this is a pretty odd algorithm which swaps the buffer and shot piece, and vice versa, according to how we specify, in order to achieve the correct representation of the pieces' orientations and permutations in the program. edgecolor[] array does not care about orientation, so current[] array is actually accurate in regard to piece permutation and orientation.
            StringBuilder buff_builder = new StringBuilder(buffer);
            StringBuilder shot_builder = new StringBuilder(shotto);
            StringBuilder temp_for_buff = new StringBuilder(buffer);


            //first we build buffer
            temp_for_buff[buff_swap1_buffchar - 1] = shot_builder[buff_swap1_shotchar - 1]; //minus one because arrays start at zero, not 1
            temp_for_buff[buff_swap2_buffchar - 1] = shot_builder[buff_swap2_shotchar - 1];

            //next we build piece we shot to
            shot_builder[buff_swap1_shotchar - 1] = buff_builder[buff_swap1_buffchar - 1];
            shot_builder[buff_swap2_shotchar - 1] = buff_builder[buff_swap2_buffchar - 1];

            current[1] = temp_for_buff.ToString();
            current[newedgecolor] = shot_builder.ToString(); //pack changes back into current piece array
        }

        public static void done()
        {
            if (main.arg[main.arg.Length - 1] == "v")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("      EDGES ARE DONE");
                Console.ResetColor();
            }
                Thread.CurrentThread.Abort();
        }

        public static void HandleTwist()
        {
            for (int i = 0; i < 12; i++)
            {
                if (i != 1 && current[i] != solved[i]) //loop through each edge and compare it to its solved version... also we must do i != 1 since we cannot shoot to the buffer (doesn't make any sense)
                {
                    shoot = i;
                    break;
                }
            }

            findsetup(solved[shoot]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            solutions.Add(setup + " " + TPerm + " " + und);
            Console.ResetColor();
            updatecurrent();

            solvenextedge();
        }

        public static void log(string text)
        {
            Console.WriteLine("   " + text);
        }
    }
}
