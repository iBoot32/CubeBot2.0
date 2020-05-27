using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeBot
{
    class cubestringcalc
    {
        public static string corner = "WOBWRBWRGWOGYOGYRGYRBYOB";
        public static string edge = "WBWRWGWOBOGOGRBRYGYRYBYO";

        public static string[] cornerarray = new string[24];
        public static string[] edgearray = new string[24];
        public static int m = 0;
        public static int n = 0;

        public static string[] edgetemp = new string[cornerarray.Length];
        public static string[] cornertemp = new string[cornerarray.Length];
        public static string[] othertemp = new string[cornerarray.Length];

        public static string cornerstring;
        public static string edgestring;
        public static bool isorder = false;

        public static void calc(string[] args)
        {
            Array.Clear(cornerarray, 0, cornerarray.Length);
            Array.Clear(edgearray, 0, edgearray.Length);
            Array.Clear(cornertemp, 0, cornertemp.Length);
            Array.Clear(edgetemp, 0, edgetemp.Length);
            int m = 0;
            int n = 0;

            for (int i = 0; i < 24; i++)
            {
                cornerarray[m] += corner.Substring(n, 1);
                m++;
                n = n + 1;
            }
            m = 0;
            n = 0;
            for (int i = 0; i < 24; i++)
            {
                edgearray[m] += edge.Substring(n, 1);
                m++;
                n = n + 1;
            } //set up edge and corner arrays



            for (int i = 0; i < cornerarray.Length; i++)
            {
                cornertemp[i] = cornerarray[i];
            }
            for (int i = 0; i < edgearray.Length; i++)
            {
                edgetemp[i] = edgearray[i];
            } //create backup of edge and corner arrays

                for (int i = 1; i < args.Length; i++)
                {
                    cornerstring = null;
                    edgestring = null;
                    manipulate(args[i]);
                }
            }





        public static void resetedge()
        {
            for (int i = 0; i < edgearray.Length; i++) //reset othertemp
            {
                othertemp[i] = edgearray[i];
            }
        }

        public static void resetcorner()
        {
            for (int i = 0; i < cornerarray.Length; i++) //reset othertemp
            {
                othertemp[i] = cornerarray[i];
            }
        }

        public static void manipulate(string move)
        {
            switch (move)
            {
                case "R":
                    resetcorner();
                    put(cornerarray, 3, 20); put(cornerarray, 4, 19); put(cornerarray, 5, 18); //put corner 2 into corner 7
                    put(cornerarray, 18, 17); put(cornerarray, 19, 16); put(cornerarray, 20, 15); //put corner 7 into corner 6
                    put(cornerarray, 15, 8); put(cornerarray, 16, 7); put(cornerarray, 17, 6); //put corner 6 into corner 3
                    put(cornerarray, 6, 5); put(cornerarray, 7, 4); put(cornerarray, 8, 3); //put corner 3 into corner 2
                    for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                    resetedge();
                    put(edgearray, 2, 14); put(edgearray, 3, 15); //put edge 2 into edge 8
                    put(edgearray, 14, 18); put(edgearray, 15, 19); //put edge 8 into edge 10
                    put(edgearray, 18, 12); put(edgearray, 19, 13); //put edge 10 into edge 7
                    put(edgearray, 12, 2); put(edgearray, 13, 3); //put edge 7 into edge 10
                    for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }

                    break;
                case "R'":
                    for (int z = 0; z < 3; z++) //R' is the same as R R R
                    {
                        resetcorner();
                        put(cornerarray, 3, 20); put(cornerarray, 4, 19); put(cornerarray, 5, 18); //put corner 2 into corner 7
                        put(cornerarray, 18, 17); put(cornerarray, 19, 16); put(cornerarray, 20, 15); //put corner 7 into corner 6
                        put(cornerarray, 15, 8); put(cornerarray, 16, 7); put(cornerarray, 17, 6); //put corner 6 into corner 3
                        put(cornerarray, 6, 5); put(cornerarray, 7, 4); put(cornerarray, 8, 3); //put corner 3 into corner 2
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 2, 14); put(edgearray, 3, 15); //put edge 2 into edge 8
                        put(edgearray, 14, 18); put(edgearray, 15, 19); //put edge 8 into edge 10
                        put(edgearray, 18, 12); put(edgearray, 19, 13); //put edge 10 into edge 7
                        put(edgearray, 12, 2); put(edgearray, 13, 3); //put edge 7 into edge 10
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "R2":
                    for (int z = 0; z < 2; z++) //R2 is the same as R R
                    {
                        resetcorner();
                        put(cornerarray, 3, 20); put(cornerarray, 4, 19); put(cornerarray, 5, 18); //put corner 2 into corner 7
                        put(cornerarray, 18, 17); put(cornerarray, 19, 16); put(cornerarray, 20, 15); //put corner 7 into corner 6
                        put(cornerarray, 15, 8); put(cornerarray, 16, 7); put(cornerarray, 17, 6); //put corner 6 into corner 3
                        put(cornerarray, 6, 5); put(cornerarray, 7, 4); put(cornerarray, 8, 3); //put corner 3 into corner 2
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 2, 14); put(edgearray, 3, 15); //put edge 2 into edge 8
                        put(edgearray, 14, 18); put(edgearray, 15, 19); //put edge 8 into edge 10
                        put(edgearray, 18, 12); put(edgearray, 19, 13); //put edge 10 into edge 7
                        put(edgearray, 12, 2); put(edgearray, 13, 3); //put edge 7 into edge 10
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "L":
                    resetcorner();
                    put(cornerarray, 0, 11); put(cornerarray, 1, 10); put(cornerarray, 2, 9);
                    put(cornerarray, 9, 14); put(cornerarray, 10, 13); put(cornerarray, 11, 12);
                    put(cornerarray, 12, 23); put(cornerarray, 13, 22); put(cornerarray, 14, 21);
                    put(cornerarray, 21, 2); put(cornerarray, 22, 1); put(cornerarray, 23, 0);
                    for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                    resetedge();
                    put(edgearray, 6, 10); put(edgearray, 7, 11);
                    put(edgearray, 10, 22); put(edgearray, 11, 23);
                    put(edgearray, 22, 8); put(edgearray, 23, 9);
                    put(edgearray, 8, 6); put(edgearray, 9, 7);
                    for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }

                    break;
                case "L'":
                    for (int z = 0; z < 3; z++)
                    {
                        resetcorner();
                        put(cornerarray, 0, 11); put(cornerarray, 1, 10); put(cornerarray, 2, 9);
                        put(cornerarray, 9, 14); put(cornerarray, 10, 13); put(cornerarray, 11, 12);
                        put(cornerarray, 12, 23); put(cornerarray, 13, 22); put(cornerarray, 14, 21);
                        put(cornerarray, 21, 2); put(cornerarray, 22, 1); put(cornerarray, 23, 0);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 6, 10); put(edgearray, 7, 11);
                        put(edgearray, 10, 22); put(edgearray, 11, 23);
                        put(edgearray, 22, 8); put(edgearray, 23, 9);
                        put(edgearray, 8, 6); put(edgearray, 9, 7);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "L2":
                    for (int z = 0; z < 2; z++)
                    {
                        resetcorner();
                        put(cornerarray, 0, 11); put(cornerarray, 1, 10); put(cornerarray, 2, 9);
                        put(cornerarray, 9, 14); put(cornerarray, 10, 13); put(cornerarray, 11, 12);
                        put(cornerarray, 12, 23); put(cornerarray, 13, 22); put(cornerarray, 14, 21);
                        put(cornerarray, 21, 2); put(cornerarray, 22, 1); put(cornerarray, 23, 0);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 6, 10); put(edgearray, 7, 11);
                        put(edgearray, 10, 22); put(edgearray, 11, 23);
                        put(edgearray, 22, 8); put(edgearray, 23, 9);
                        put(edgearray, 8, 6); put(edgearray, 9, 7);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "U":
                    resetcorner();
                    put(cornerarray, 0, 3); put(cornerarray, 1, 5); put(cornerarray, 2, 4);
                    put(cornerarray, 3, 6); put(cornerarray, 4, 8); put(cornerarray, 5, 7);
                    put(cornerarray, 6, 9); put(cornerarray, 7, 11); put(cornerarray, 8, 10);
                    put(cornerarray, 9, 0); put(cornerarray, 10, 2); put(cornerarray, 11, 1);
                    for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                    resetedge();
                    put(edgearray, 0, 2); put(edgearray, 1, 3);
                    put(edgearray, 2, 4); put(edgearray, 3, 5);
                    put(edgearray, 4, 6); put(edgearray, 5, 7);
                    put(edgearray, 6, 0); put(edgearray, 7, 1);
                    for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    break;
                case "U'":
                    for (int z = 0; z < 3; z++)
                    {
                        resetcorner();
                        put(cornerarray, 0, 3); put(cornerarray, 1, 5); put(cornerarray, 2, 4);
                        put(cornerarray, 3, 6); put(cornerarray, 4, 8); put(cornerarray, 5, 7);
                        put(cornerarray, 6, 9); put(cornerarray, 7, 11); put(cornerarray, 8, 10);
                        put(cornerarray, 9, 0); put(cornerarray, 10, 2); put(cornerarray, 11, 1);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 0, 2); put(edgearray, 1, 3);
                        put(edgearray, 2, 4); put(edgearray, 3, 5);
                        put(edgearray, 4, 6); put(edgearray, 5, 7);
                        put(edgearray, 6, 0); put(edgearray, 7, 1);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "U2":
                    for (int z = 0; z < 2; z++)
                    {
                        resetcorner();
                        put(cornerarray, 0, 3); put(cornerarray, 1, 5); put(cornerarray, 2, 4);
                        put(cornerarray, 3, 6); put(cornerarray, 4, 8); put(cornerarray, 5, 7);
                        put(cornerarray, 6, 9); put(cornerarray, 7, 11); put(cornerarray, 8, 10);
                        put(cornerarray, 9, 0); put(cornerarray, 10, 2); put(cornerarray, 11, 1);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 0, 2); put(edgearray, 1, 3);
                        put(edgearray, 2, 4); put(edgearray, 3, 5);
                        put(edgearray, 4, 6); put(edgearray, 5, 7);
                        put(edgearray, 6, 0); put(edgearray, 7, 1);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "D":
                    resetcorner();
                    put(cornerarray, 12, 15); put(cornerarray, 13, 17); put(cornerarray, 14, 16);
                    put(cornerarray, 15, 18); put(cornerarray, 16, 20); put(cornerarray, 17, 19);
                    put(cornerarray, 18, 21); put(cornerarray, 19, 23); put(cornerarray, 20, 22);
                    put(cornerarray, 21, 12); put(cornerarray, 22, 14); put(cornerarray, 23, 13);
                    for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                    resetedge();
                    put(edgearray, 16, 18); put(edgearray, 17, 19);
                    put(edgearray, 18, 20); put(edgearray, 19, 21);
                    put(edgearray, 20, 22); put(edgearray, 21, 23);
                    put(edgearray, 22, 16); put(edgearray, 23, 17);
                    for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }

                    break;
                case "D'":
                    for (int z = 0; z < 3; z++)
                    {
                        resetcorner();
                        put(cornerarray, 12, 15); put(cornerarray, 13, 17); put(cornerarray, 14, 16);
                        put(cornerarray, 15, 18); put(cornerarray, 16, 20); put(cornerarray, 17, 19);
                        put(cornerarray, 18, 21); put(cornerarray, 19, 23); put(cornerarray, 20, 22);
                        put(cornerarray, 21, 12); put(cornerarray, 22, 14); put(cornerarray, 23, 13);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 16, 18); put(edgearray, 17, 19);
                        put(edgearray, 18, 20); put(edgearray, 19, 21);
                        put(edgearray, 20, 22); put(edgearray, 21, 23);
                        put(edgearray, 22, 16); put(edgearray, 23, 17);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "D2":
                    for (int z = 0; z < 2; z++)
                    {
                        resetcorner();
                        put(cornerarray, 12, 15); put(cornerarray, 13, 17); put(cornerarray, 14, 16);
                        put(cornerarray, 15, 18); put(cornerarray, 16, 20); put(cornerarray, 17, 19);
                        put(cornerarray, 18, 21); put(cornerarray, 19, 23); put(cornerarray, 20, 22);
                        put(cornerarray, 21, 12); put(cornerarray, 22, 14); put(cornerarray, 23, 13);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 16, 18); put(edgearray, 17, 19);
                        put(edgearray, 18, 20); put(edgearray, 19, 21);
                        put(edgearray, 20, 22); put(edgearray, 21, 23);
                        put(edgearray, 22, 16); put(edgearray, 23, 17);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "F":
                    resetcorner();
                    put(cornerarray, 9, 7); put(cornerarray, 10, 6); put(cornerarray, 11, 8);
                    put(cornerarray, 6, 16); put(cornerarray, 7, 15); put(cornerarray, 8, 17);
                    put(cornerarray, 15, 13); put(cornerarray, 16, 12); put(cornerarray, 17, 14);
                    put(cornerarray, 12, 10); put(cornerarray, 13, 9); put(cornerarray, 14, 11);
                    for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                    resetedge();
                    put(edgearray, 4, 13); put(edgearray, 5, 12);
                    put(edgearray, 12, 17); put(edgearray, 13, 16);
                    put(edgearray, 16, 11); put(edgearray, 17, 10);
                    put(edgearray, 10, 5); put(edgearray, 11, 4);
                    for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    break;
                case "F'":
                    for (int z = 0; z < 3; z++)
                    {
                        resetcorner();
                        put(cornerarray, 9, 7); put(cornerarray, 10, 6); put(cornerarray, 11, 8);
                        put(cornerarray, 6, 16); put(cornerarray, 7, 15); put(cornerarray, 8, 17);
                        put(cornerarray, 15, 13); put(cornerarray, 16, 12); put(cornerarray, 17, 14);
                        put(cornerarray, 12, 10); put(cornerarray, 13, 9); put(cornerarray, 14, 11);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 4, 13); put(edgearray, 5, 12);
                        put(edgearray, 12, 17); put(edgearray, 13, 16);
                        put(edgearray, 16, 11); put(edgearray, 17, 10);
                        put(edgearray, 10, 5); put(edgearray, 11, 4);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "F2":
                    for (int z = 0; z < 2; z++)
                    {
                        resetcorner();
                        put(cornerarray, 9, 7); put(cornerarray, 10, 6); put(cornerarray, 11, 8);
                        put(cornerarray, 6, 16); put(cornerarray, 7, 15); put(cornerarray, 8, 17);
                        put(cornerarray, 15, 13); put(cornerarray, 16, 12); put(cornerarray, 17, 14);
                        put(cornerarray, 12, 10); put(cornerarray, 13, 9); put(cornerarray, 14, 11);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 4, 13); put(edgearray, 5, 12);
                        put(edgearray, 12, 17); put(edgearray, 13, 16);
                        put(edgearray, 16, 11); put(edgearray, 17, 10);
                        put(edgearray, 10, 5); put(edgearray, 11, 4);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "B":
                    resetcorner();
                    put(cornerarray, 0, 22); put(cornerarray, 1, 21); put(cornerarray, 2, 23);
                    put(cornerarray, 21, 19); put(cornerarray, 22, 18); put(cornerarray, 23, 20);
                    put(cornerarray, 18, 4); put(cornerarray, 19, 3); put(cornerarray, 20, 5);
                    put(cornerarray, 3, 1); put(cornerarray, 4, 0); put(cornerarray, 5, 2);
                    for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                    resetedge();
                    put(edgearray, 0, 9); put(edgearray, 1, 8);
                    put(edgearray, 8, 21); put(edgearray, 9, 20);
                    put(edgearray, 20, 15); put(edgearray, 21, 14);
                    put(edgearray, 14, 1); put(edgearray, 15, 0);
                    for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }

                    break;
                case "B'":
                    for (int z = 0; z < 3; z++)
                    {
                        resetcorner();
                        put(cornerarray, 0, 22); put(cornerarray, 1, 21); put(cornerarray, 2, 23);
                        put(cornerarray, 21, 19); put(cornerarray, 22, 18); put(cornerarray, 23, 20);
                        put(cornerarray, 18, 4); put(cornerarray, 19, 3); put(cornerarray, 20, 5);
                        put(cornerarray, 3, 1); put(cornerarray, 4, 0); put(cornerarray, 5, 2);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 0, 9); put(edgearray, 1, 8);
                        put(edgearray, 8, 21); put(edgearray, 9, 20);
                        put(edgearray, 20, 15); put(edgearray, 21, 14);
                        put(edgearray, 14, 1); put(edgearray, 15, 0);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;
                case "B2":
                    for (int z = 0; z < 2; z++)
                    {
                        resetcorner();
                        put(cornerarray, 0, 22); put(cornerarray, 1, 21); put(cornerarray, 2, 23);
                        put(cornerarray, 21, 19); put(cornerarray, 22, 18); put(cornerarray, 23, 20);
                        put(cornerarray, 18, 4); put(cornerarray, 19, 3); put(cornerarray, 20, 5);
                        put(cornerarray, 3, 1); put(cornerarray, 4, 0); put(cornerarray, 5, 2);
                        for (int i = 0; i < cornerarray.Length; i++) { cornerarray[i] = othertemp[i]; }

                        resetedge();
                        put(edgearray, 0, 9); put(edgearray, 1, 8);
                        put(edgearray, 8, 21); put(edgearray, 9, 20);
                        put(edgearray, 20, 15); put(edgearray, 21, 14);
                        put(edgearray, 14, 1); put(edgearray, 15, 0);
                        for (int i = 0; i < edgearray.Length; i++) { edgearray[i] = othertemp[i]; }
                    }
                    break;


            }


            for (int i = 0; i < cornerarray.Length; i++)
            {
                cornerstring += cornerarray[i];
            }
            for (int i = 0; i < edgearray.Length; i++)
            {
                edgestring += edgearray[i];
            }
        }

        static void put(string[] array, int positionA, int positionB)
        {
            othertemp[positionB] = array[positionA];
        }

        public static void log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
