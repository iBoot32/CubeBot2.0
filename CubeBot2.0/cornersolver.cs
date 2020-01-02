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
    class cornersolver
    {
        public static string cubestring;
        public static string edgestring;
        public static string[] current = new string[10];
        public static List<string> solvedpieces = new List<string>();


        public static string[] solved = new string[] //define state of solved cube
        {
                "WOB",  "WRB",
                "WRG",  "WOG",

                "YOG",  "YRG",
                "YRB",  "YOB"
        };

        public static string setup;
        public static string und;
        public static string oldpiece;
        public static string newpiece;
        public static int oldcornercolor;
        public static int newcornercolor;
        public static bool cubeissolved = true;
        public static int shoot;
        public static List<string> solutions = new List<string>();

        public static void alg(string args)
        {
            cubestring = args;
            if (main.arg[0] == "scr" || main.arg[0] == "avg" || main.arg[0] == "time" || main.arg[0] == "ao" || main.arg[0] == "robot")
            {
                edgestring = main.resedge;
            }
            else
            {
                edgestring = main.arg[2];
            }

            int sub = 0;
            for (int i = 0; i < 8; i++)
            {
                current[i] = cubestring.Substring(sub, 3);
                sub = sub + 3;
            }

            for (int i = 0; i < 8; i++)
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

            oldpiece = "A";
            oldcornercolor = 0;

            findsetup(current[0]);
            string solution = setup + " (R U' R' U' R U R' F' R U R' U' R' F R) " + und;
            solutions.Add(solution);

            updatecurrent();
            solvenextcorner();
        }

        public static void solvenextcorner()
        {
            for (int i = 0; i < 8; i++)
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

            if (current[0] == solved[0]) //if buffer is solved
            {
                HandleTwist();
            }

            //oldpiece = newpiece;
            oldcornercolor = 0;
            findsetup(current[0]);

            string solution = setup + " (R U' R' U' R U R' F' R U R' U' R' F R) " + und;
            solutions.Add(solution);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
            updatecurrent();
            solvenextcorner();
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
                case "loc" when a.Contains("R") && a.Contains("B") && a.Contains("Y"):
                    return "BBR";
                case "loc" when a.Contains("G") && a.Contains("Y") && a.Contains("R"):
                    return "FBR";
                case "loc" when a.Contains("Y") && a.Contains("B") && a.Contains("O"):
                    return "BBL";
                case "loc" when a.Contains("O") && a.Contains("G") && a.Contains("W"):
                    return "FTL";
                case "loc" when a.Contains("G") && a.Contains("Y") && a.Contains("O"):
                    return "FBL";
                case "loc" when a.Contains("W") && a.Contains("B") && a.Contains("O"):
                    return "BTL";
                case "loc" when a.Contains("W") && a.Contains("R") && a.Contains("G"):
                    return "FTR";
                case "loc" when a.Contains("W") && a.Contains("R") && a.Contains("B"):
                    return "BTR";
                case "loc":
                    return "bug";
            }

            return "bug";
        }


        public static void findsetup(string c)
        {
            //definitely need to clean this up somehow
            //convert to switch statement???
            if (c.Contains("R") && c.Contains("B") && c.Contains("Y"))
            {
                if (c.Substring(0, 1) == "R")
                {
                    setup = "R";
                    und = "R'";
                    newpiece = "O";
                    newcornercolor = 6;
                }
                if (c.Substring(0, 1) == "B")
                {
                    setup = "D'";
                    und = "D";
                    newpiece = "T";
                    newcornercolor = 6;
                }
                if (c.Substring(0, 1) == "Y")
                {
                    setup = "D2 F'";
                    und = "F D2";
                    newpiece = "W";
                    newcornercolor = 6;
                }
            }
            if (c.Contains("G") && c.Contains("Y") && c.Contains("R"))
            {
                if (c.Substring(0, 1) == "G")
                {
                    setup = "F D";
                    und = "D' F'";
                    newpiece = "K";
                    newcornercolor = 5;
                }
                if (c.Substring(0, 1) == "Y")
                {
                    setup = "D' F'";
                    und = "F D";
                    newpiece = "V";
                    newcornercolor = 5;
                }
                if (c.Substring(0, 1) == "R")
                {
                    setup = "";
                    und = "";
                    newpiece = "P";
                    newcornercolor = 5;
                }
            }
            if (c.Contains("Y") && c.Contains("B") && c.Contains("O"))
            {
                if (c.Substring(0, 1) == "Y")
                {
                    setup = "D F'";
                    und = "F D'";
                    newpiece = "X";
                    newcornercolor = 7;
                }
                if (c.Substring(0, 1) == "B")
                {
                    setup = "D' R";
                    und = "R' D";
                    newpiece = "S";
                    newcornercolor = 7;
                }
                if (c.Substring(0, 1) == "O")
                {
                    setup = "D2";
                    und = "D2";
                    newpiece = "H";
                    newcornercolor = 7;
                }
            }
            if (c.Contains("O") && c.Contains("G") && c.Contains("W"))
            {
                if (c.Substring(0, 1) == "O")
                {
                    setup = "F2";
                    und = "F2";
                    newpiece = "F";
                    newcornercolor = 3;
                }
                if (c.Substring(0, 1) == "G")
                {
                    setup = "F' D";
                    und = "D' F";
                    newpiece = "I";
                    newcornercolor = 3;
                }
                if (c.Substring(0, 1) == "W")
                {
                    setup = "L D L'";
                    und = "L D' L'";
                    newpiece = "D";
                    newcornercolor = 3;
                }
            }
            if (c.Contains("G") && c.Contains("Y") && c.Contains("O"))
            {
                if (c.Substring(0, 1) == "G")
                {
                    setup = "D";
                    und = "D'";
                    newpiece = "L";
                    newcornercolor = 4;
                }
                if (c.Substring(0, 1) == "Y")
                {
                    setup = "F'";
                    und = "F";
                    newpiece = "U";
                    newcornercolor = 4;
                }
                if (c.Substring(0, 1) == "O")
                {
                    setup = "D2 R";
                    und = "R' D2";
                    newpiece = "G";
                    newcornercolor = 4;
                }
            }
            if (c.Contains("W") && c.Contains("B") && c.Contains("O"))
            {
                if (c.Substring(0, 1) == "W")
                {
                    setup = "";
                    und = "";
                    HandleTwist();
                    newpiece = "A";
                    newcornercolor = 0;
                }
                if (c.Substring(0, 1) == "B")
                {
                    setup = "";
                    und = "";
                    HandleTwist();
                    newpiece = "R";
                    newcornercolor = 0;
                }
                if (c.Substring(0, 1) == "O")
                {
                    setup = "";
                    und = "";
                    HandleTwist();
                    newpiece = "E";
                    newcornercolor = 0;
                }
            }
            if (c.Contains("W") && c.Contains("R") && c.Contains("G"))
            {
                if (c.Substring(0, 1) == "W")
                {
                    setup = "F";
                    und = "F'";
                    newpiece = "C";
                    newcornercolor = 2;
                }
                if (c.Substring(0, 1) == "R")
                {
                    setup = "R'";
                    und = "R";
                    newpiece = "M";
                    newcornercolor = 2;
                }
                if (c.Substring(0, 1) == "G")
                {
                    setup = "F2 D";
                    und = "D' F2";
                    newpiece = "J";
                    newcornercolor = 2;
                }
            }
            if (c.Contains("W") && c.Contains("R") && c.Contains("B"))
            {
                if (c.Substring(0, 1) == "W")
                {
                    setup = "R D'";
                    und = "D R'";
                    newpiece = "B";
                    newcornercolor = 1;
                }
                if (c.Substring(0, 1) == "R")
                {
                    setup = "R2";
                    und = "R2";
                    newpiece = "N";
                    newcornercolor = 1;
                }
                if (c.Substring(0, 1) == "B")
                {
                    setup = "R' F";
                    und = "F' R";
                    newpiece = "Q";
                    newcornercolor = 1;
                }
            }
        }

        public static void updatecurrent()
        {
            switch (newpiece)
            {
                case "A":
                    //no change- it's already in "a"
                    break;
                case "B":
                    //this stuff here will swap the buffer and piece we shot to, and put each color in the correct orientation we will see in real life
                    swapchar(true, current[0], current[newcornercolor], /* first we build buffer -> */ 1, 1, 2, 3, 3, 2, /* next we build piece we shot to ->*/ 1, 1, 2, 3, 3, 2);
                    break;
                case "C":
                    swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3);
                    break;
                case "D":
                    swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 3, 3, 2, 1, 1, 2, 3, 3, 2);
                    break;
                case "E":
                    //this wouldn't make any sense. Can't swap buffer with buffer ;)
                    break;
                case "F":
                    swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 1, 3, 3, 1, 2, 2, 1, 3, 3);
                    break;
                case "G":
                    swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3, 1);
                    break;
                case "H":
                    swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 1, 3, 3, 1, 2, 2, 1, 3, 3);
                    break;
                case "I":
                    swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1);
                    break;
                case "J":
                    swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2);
                    break;
                case "K":
                    swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1);
                    break;
                case "L":
                    swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2);
                    break;
                case "M":
                    swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3, 1);
                    break;
                case "N":
                    swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 1, 3, 3, 1, 2, 2, 1, 3, 3);
                    break;
                case "O":
                    swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3, 1);
                    break;
                case "P":
                    swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 1, 3, 3, 1, 2, 2, 1, 3, 3);
                    break;
                case "Q":
                    swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1);
                    break;
                case "R":
                    //r is on the buffer so wouldnt make sense
                    break;
                case "S":
                    swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1);
                    break;
                case "T":
                    swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2);
                    break;
                case "U":
                    swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3);
                    break;
                case "V":
                    swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 3, 3, 2, 1, 1, 2, 3, 3, 2);
                    break;
                case "W":
                    swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3);
                    break;
                case "X":
                    swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 3, 3, 2, 1, 1, 2, 3, 3, 2);
                    break;
            }
        }

        public static void swapchar(bool swapbuffer, string buffer, string shotto, int buff_swap1_buffchar, int buff_swap1_shotchar, int buff_swap2_buffchar, int buff_swap2_shotchar, int buff_swap3_buffchar, int buff_swap3_shotchar, int shot_swap1_buffchar, int shot_swap1_shotchar, int shot_swap2_buffchar, int shot_swap2_shotchar, int shot_swap3_buffchar, int shot_swap3_shotchar)
        {

            //this is a pretty odd method which swaps the buffer and shot piece, and vice versa, according to how we specify, in order to achieve the correct representation of the pieces' orientations and permutations in the program. Cornercolor[] array does not care about orientation, so current[] array is more accurate in reagrd to piece attributes (permutation and orientation).
            StringBuilder buff_builder = new StringBuilder(buffer);
            StringBuilder shot_builder = new StringBuilder(shotto);
            StringBuilder temp_for_buff = new StringBuilder(buffer);


            //first we build buffer
            temp_for_buff[buff_swap1_buffchar - 1] = shot_builder[buff_swap1_shotchar - 1]; //minus one because arrays start at zero, not 1
            temp_for_buff[buff_swap2_buffchar - 1] = shot_builder[buff_swap2_shotchar - 1];
            temp_for_buff[buff_swap3_buffchar - 1] = shot_builder[buff_swap3_shotchar - 1];

            //next we build piece we shot to
            shot_builder[shot_swap1_shotchar - 1] = buff_builder[shot_swap1_buffchar - 1];
            shot_builder[shot_swap2_shotchar - 1] = buff_builder[shot_swap2_buffchar - 1];
            shot_builder[shot_swap3_shotchar - 1] = buff_builder[shot_swap3_buffchar - 1];

            current[0] = temp_for_buff.ToString();
            current[newcornercolor] = shot_builder.ToString(); //pack changes back into current piece array
        }

        public static void done()
        {
            if (main.arg[main.arg.Length - 1] == "v")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("      CORNERS ARE DONE");
                Console.ResetColor();
            }


            if (solutions.Count % 2 != 0) //if number of solutions is even, edges remain how they began, otherwise we need to swap 2 edges
            {
                string buff = edgestring.Substring(0, 2);
                string beforereplace = edgestring.Substring(2, 4);
                string afterreplace = edgestring.Substring(8, 16);
                string replace = (edgestring.Substring(6, 2));

                string newedge = replace + beforereplace + buff + afterreplace;
                edgestring = newedge;
            }


            Thread.CurrentThread.Abort();
        }

        public static void HandleTwist()
        {
            for (int i = 1; i < 8; i++) //must be like this as opposed to   (int i = 0; i < 8; i++)  because we need to skip over buffer piece because obviously it's not solved or else we wouldn't be here
            {
                if (current[i] != solved[i]) //loop through each corner and compare it to its solved version
                {
                    shoot = i;
                    break;
                }
            }

            findsetup(solved[shoot]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            solutions.Add(setup + " (R U' R' U' R U R' F' R U R' U' R' F R) " + und);
            Console.ResetColor();
            updatecurrent();

            solvenextcorner();
        }

        public static void log(string text)
        {
            Console.WriteLine("   " + text);
        }
    }
}
