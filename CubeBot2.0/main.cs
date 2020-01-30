using CubeBotCLI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CubeBot2._0
{
    class main
    {
        public static string rescorner;
<<<<<<< HEAD
        public static string corner = "WOBWRBWRGWOGYOGYRGYRBYOB";
        public static string edge = "WBWRWGWOBOGOGRBRYGYRYBYO";
=======
>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df
        public static string resedge;
        public static Stopwatch st = new Stopwatch();
        public static Stopwatch notall = new Stopwatch();
        public static string[] arg;
        public static int lineCounter;
        public static List<string> scrambles = new List<string>();
        public static int scr;
        public static double pb = 9999999;
        private static int time;
        private static string final;
<<<<<<< HEAD
        private static bool isorder;
        private static int order;
        private static bool done;
        public static string cornerstring = cubestringcalc.cornerstring;
        public static string edgestring = cubestringcalc.edgestring;
        public static Stopwatch stopwatch = new Stopwatch();
        public static string[] edgearray = new string[24];
        public static string[] cornerarray = new string[24];
        public static string[] cornertemp = new string[24];
        public static string[] edgetemp = new string[24];
        public static string[] othertemp = new string[24];
        private static int m;
        private static int n;

        static void Main(string[] args)
        {

=======

        static void Main(string[] args)
        {
>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df
            arg = args;
            st.Start();
            log("");
            log("");
            log("  CubeBot2.0 by iBoot32");
            log("--------------------------");
            log("");
            log("");

<<<<<<< HEAD

            if (args[0] == "order") //algorithm to find order of an inputted series of moves
            {
                stopwatch.Start();


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

                isorder = true;
                order = 0;

                cornerstring = null;
                edgestring = null;

                while (!done)
                {
                    cornerstring = null;
                    edgestring = null;
                    order++;

                    for (int i = 1; i < args.Length; i++)
                    {
                        log("manipulating based on arg " + i + " which is " + args[i]);
                        cornerstring = null;
                        edgestring = null;
                        manipulate(args[i]);
                    } //go through each specified move (all the moves combined is one iteration)

                    Console.WriteLine("  Iteration " + order + " yields us:");
                    Console.WriteLine("  " + cornerstring);
                    Console.WriteLine("  " + edgestring);
                    Console.WriteLine("");


                    log("checking cornerstring"); //after 1 iteration, check if solved
                    if (cornerstring == "WOBWRBWRGWOGYOGYRGYRBYOB")
                    {
                        log("checking edgestring");
                        if (edgestring == "WBWRWGWOBOGOGRBRYGYRYBYO")
                        {
                            stopwatch.Stop();
                            done = true;
                            log("");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("  Solved! Calculation took " + stopwatch.ElapsedMilliseconds + " milliseconds to complete.");
                            Console.WriteLine("  order = " + order);
                            Console.ResetColor();
                            Environment.Exit(0);
                        }
                    }
                }
            }


            if (args[0] == "scr") //solve cube given scramble
=======
            if (args[0] == "scr") //solve cube given scramble
            {
                StringBuilder sb = new StringBuilder(" Calculating cubestring based on scramble: ");
                for (int i = 1; i < args.Length; i++)
                {
                    sb.Append(" " + args[i]);
                }
                Console.WriteLine("  " + sb.ToString());

                var cs = new cubestringcalc();
                cs.calc(args); //calculate state of the cube based on the provided scramble

                rescorner = cubestringcalc.cornerstring;
                resedge = cubestringcalc.edgestring;

                log("Solving Cube");

                Thread t = new Thread(() => cornersolver.alg(rescorner));
                t.Start();
                t.Join();


                Thread tr = new Thread(() => edgesolver.alg(cornersolver.edgestring));
                tr.Start();
                tr.Join();

                st.Stop();
                Console.ForegroundColor = ConsoleColor.Cyan;
                log("");
                log("");
                log("");
                log("YOUR CUBE IS SOLVED IN EXACTLY " + st.Elapsed.TotalMilliseconds + " MILLISECONDS!");


                log("Solution to scramble is the following:");
                log("");
                cornersolver.solutions.ForEach(f => log(" " + f));
                cornersolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                log("");
                edgesolver.solutions.ForEach(f => log(" " + f));
                edgesolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                File.AppendAllText("solutions.txt", Environment.NewLine);
                log("");
                Console.ResetColor();
                Environment.Exit(0);
            }

            if (args[0] == "robot") //ignore this. not useful unless you have a cube-solving robot.
>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df
            {
                StringBuilder sb = new StringBuilder(" Calculating cubestring based on scramble: ");
                for (int i = 1; i < args.Length; i++)
                {
                    sb.Append(" " + args[i]);
                }
                Console.WriteLine("  " + sb.ToString());

                var cs = new cubestringcalc();
<<<<<<< HEAD
                cs.calc(args); //calculate state of the cube based on the provided scramble
=======
                cs.calc(args);
>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df

                rescorner = cubestringcalc.cornerstring;
                resedge = cubestringcalc.edgestring;

<<<<<<< HEAD
=======
                log(rescorner);
                log(resedge);

>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df
                log("Solving Cube");

                Thread t = new Thread(() => cornersolver.alg(rescorner));
                t.Start();
                t.Join();


                Thread tr = new Thread(() => edgesolver.alg(cornersolver.edgestring));
                tr.Start();
                tr.Join();

                st.Stop();
                Console.ForegroundColor = ConsoleColor.Cyan;
                log("");
                log("");
                log("");
                log("YOUR CUBE IS SOLVED IN EXACTLY " + st.Elapsed.TotalMilliseconds + " MILLISECONDS!");


                log("Solution to scramble is the following:");
                log("");
                cornersolver.solutions.ForEach(f => log(" " + f));
<<<<<<< HEAD
                cornersolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                log("");
                edgesolver.solutions.ForEach(f => log(" " + f));
                edgesolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                File.AppendAllText("solutions.txt", Environment.NewLine);
                log("");
                Console.ResetColor();
                Environment.Exit(0);
            }


=======
                cornersolver.solutions.ForEach(f => File.AppendAllText("solution.txt", " " + f + Environment.NewLine));
                log("");
                edgesolver.solutions.ForEach(f => log(" " + f));
                edgesolver.solutions.ForEach(f => File.AppendAllText("solution.txt", " " + f + Environment.NewLine));
                File.AppendAllText("solution.txt", Environment.NewLine);
                log("");
                Console.ResetColor();

                log("");
                log("");
                log("");

                log("Sending solutions to robot...");
                log(ExecuteCommand("ssh raspi@10.0.0.88 `rm /home/raspi/Desktop/solution.txt`"));
                log(ExecuteCommand("scp solution.txt raspi@10.0.0.88:/home/raspi/Desktop"));
                log(ExecuteCommand("ssh raspi@10.0.0.88 `cd /home/raspi/Desktop && sed -i.bak 's/\r$//' solution.txt`"));

                log("");
                log("Running robot");
                log(ExecuteCommand("ssh raspi@10.0.0.88 `./home/raspi/Desktop/split.py`"));

                Environment.Exit(0);
            }
>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df

            if (args[0] == "solve") //solve cube given state of corners and edges
            {
                log("Solving Cube");

                Thread t = new Thread(() => cornersolver.alg(args[1]));
                t.Start();
                t.Join();


                Thread tr = new Thread(() => edgesolver.alg(cornersolver.edgestring));
                tr.Start();
                tr.Join();

                st.Stop();
                Console.ForegroundColor = ConsoleColor.Cyan;
                log("");
                log("YOUR CUBE IS SOLVED IN EXACTLY " + st.Elapsed.TotalMilliseconds + " MILLISECONDS!");


                log("Solution to scramble is the following:");
                log("");

                cornersolver.solutions.ForEach(i => log(" " + i));
                log("");
                edgesolver.solutions.ForEach(i => log(" " + i));
                log("");
                Console.ResetColor();
                Environment.Exit(0);
            }



            if (args[0] == "avg") //solve every scramble in scrambles.txt
            {
                st.Restart();
                if (!File.Exists("scrambles.txt"))
                {
                    log("No scrambles found in scrambles.txt");
                    Environment.Exit(1);
                }
                else
                {
                    using (var reader = new StreamReader("scrambles.txt"))
                    {
                        while (reader.ReadLine() != null)
                        {
                            lineCounter++;
                        }
                    }
                    log("scrambles.txt contains " + lineCounter.ToString() + " scrambles total");
                    log("Reading Lines (may take a while)...");

                    int p = 0;
                    IEnumerable<string> lines = File.ReadLines("scrambles.txt");
                    foreach (var item in lines)
                    {
                        Regex.Split(item, "\r\n");
                        final = item.Substring(item.LastIndexOf(".") + 2);
                        Console.WriteLine(p + "/" + lineCounter + ":" + final);
                        scrambles.Add(final);
                        p++;
                    }

                    log("Done reading " + lineCounter + " lines.");

                    for (int i = 0; i < lineCounter; i++)
                    {
                        notall.Start();
                        var cs = new cubestringcalc();
                        scr = i;
                        cs.calc(scrambles.ToArray());

                        rescorner = cubestringcalc.cornerstring;
                        resedge = cubestringcalc.edgestring;

                        Thread t = new Thread(() => cornersolver.alg(rescorner));
                        t.Start();
                        t.Join();


                        Thread tr = new Thread(() => edgesolver.alg(cornersolver.edgestring));
                        tr.Start();
                        tr.Join();



                        if (args[args.Length - 1] == "v") //if want verbose output, log solutions for each scramble in solutions.txt
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            log("");
                            log("Solving " + scrambles[i]);
                            log("");



                            log("Solution to scramble is the following:");
                            log("");
                            cornersolver.solutions.ForEach(f => log(" " + f));
                            cornersolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                            log("");
                            edgesolver.solutions.ForEach(f => log(" " + f));
                            edgesolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                            File.AppendAllText("solutions.txt", Environment.NewLine);
                            log("");
                            Console.ResetColor();
                        }
                        log("Cube " + (i + 1) + "/" + lineCounter + " took " + notall.Elapsed.TotalMilliseconds + " milliseconds to solve.");
                        if (notall.Elapsed.TotalMilliseconds < pb) //Mom I got a PB!
                        {
                            pb = notall.Elapsed.TotalMilliseconds;
                            log("NEW PB OF " + notall.Elapsed.TotalMilliseconds);
                        }
                        notall.Restart();

                        cornersolver.solutions.Clear();
                        edgesolver.solutions.Clear();
                    }

                    st.Stop();
                    log("It took " + st.Elapsed.TotalMilliseconds + " milliseconds to solve " + lineCounter + " cubes.");
                    log("Average of " + lineCounter + " is " + (st.Elapsed.TotalMilliseconds / lineCounter));
                    log("We also got a PB of " + pb + " milliseconds!");
                }
            }

            if (args[0] == "time") //solve for a specified time in seconds
            {
                time = int.Parse(args[1]);
                log("Solving for " + time + " milliseconds");

                if (!File.Exists("scrambles.txt"))
                {
                    log("No scrambles found in scrambles.txt");
                    Environment.Exit(1);
                }
                else
                {
                    using (var reader = new StreamReader("scrambles.txt"))
                    {
                        while (reader.ReadLine() != null)
                        {
                            lineCounter++;
                        }
                    }
                    log("scrambles.txt contains " + lineCounter.ToString() + " scrambles total");
                    log("Reading Lines (may take a while)...");


                    int p = 0;
                    IEnumerable<string> lines = File.ReadLines("scrambles.txt");
                    foreach (var item in lines)
                    {
                        Regex.Split(item, "\r\n");
                        final = item.Substring(item.LastIndexOf(".") + 2);
                        Console.WriteLine(p + "/" + lineCounter + ":" + final);
                        scrambles.Add(final);
                        p++;
                    }

                    log("Done reading " + lineCounter + " lines.");


                    st.Restart();
                    for (int i = 0; i < lineCounter; i++)
                    {
                        if (st.Elapsed.Seconds < time)
                        {
                            cornersolver.solutions.Clear();
                            edgesolver.solutions.Clear();
                            log(st.Elapsed.Seconds + " " + time);
                            notall.Start();
                            var cs = new cubestringcalc();
                            scr = i;
                            cs.calc(scrambles.ToArray());

                            rescorner = cubestringcalc.cornerstring;
                            resedge = cubestringcalc.edgestring;

                            Thread t = new Thread(() => cornersolver.alg(rescorner));
                            t.Start();
                            t.Join();


                            Thread tr = new Thread(() => edgesolver.alg(cornersolver.edgestring));
                            tr.Start();
                            tr.Join();



                            if (args[args.Length - 1] == "v") //once again with verbose logging to solutions.txt
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                log("");
                                log("Solving " + scrambles[i]);
                                log("");



                                log("Solution to scramble is the following:");
                                log("");
                                cornersolver.solutions.ForEach(f => log(" " + f));
                                cornersolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                                log("");
                                edgesolver.solutions.ForEach(f => log(" " + f));
                                edgesolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                                File.AppendAllText("solutions.txt", Environment.NewLine);
                                log("");
                                Console.ResetColor();
                            }
                            log(notall.Elapsed.TotalMilliseconds + " milliseconds for cube " + (i + 1) + "/" + lineCounter);
                            if (notall.Elapsed.TotalMilliseconds < pb)
                            {
                                pb = notall.Elapsed.TotalMilliseconds;
                                log("NEW PB OF " + notall.Elapsed.TotalMilliseconds);
                            }
                            notall.Restart();
                            log("");
                        }
                        else
                        {
                            st.Stop();
                            log("");
                            log("");
                            log("Done solving for " + time + " seconds!");
                            log("It took " + st.Elapsed.TotalMilliseconds + " milliseconds to solve " + i + " cubes.");
                            log("We also got a PB of " + pb + " milliseconds!");
                            Environment.Exit(0);

                        }
                    }
                }
            }

            if (args[0] == "ao") // ao stands for "average of". solve number of scrambles specified.
            {
                int a = int.Parse(args[1]); //number of scrambles in average
                log("Solving " + a.ToString() + " scrambles");

                if (!File.Exists("scrambles.txt"))
                {
                    log("No scrambles found in scrambles.txt");
                    Environment.Exit(1);
                }

                using (var reader = new StreamReader("scrambles.txt"))
                {
                    while (reader.ReadLine() != null)
                    {
                        lineCounter++;
                    }
                }
                log("scrambles.txt contains " + lineCounter.ToString() + " scrambles total");
                log("Reading Lines (may take a while)...");


                int p = 0;
                IEnumerable<string> lines = File.ReadLines("scrambles.txt");

<<<<<<< HEAD
                foreach (var item in lines)
                {
                    Regex.Split(item, "\r\n");
                    final = item.Substring(item.LastIndexOf(".") + 2);
                    log("Scramble " + (p + 1).ToString() + "/" + a.ToString() + " is: " + final);
                    scrambles.Add(final);
                    p++;

                    if (p == a)
                    {
                        break;
                    }
                }
=======
                    foreach (var item in lines)
                    {
                        Regex.Split(item, "\r\n");
                        final = item.Substring(item.LastIndexOf(".") + 2);
                        log("Scramble " + (p + 1).ToString() + "/" + a.ToString() + " is: " + final);
                        scrambles.Add(final);
                        p++;

                        if (p == a)
                        {
                            break;
                        }
                    }
>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df

                log("Done reading " + a + " lines.");


                st.Restart();
                for (int i = 0; i < lineCounter; i++)
                {
                    if (i < a)
                    {
                        cornersolver.solutions.Clear();
                        edgesolver.solutions.Clear();
                        notall.Start();
                        var cs = new cubestringcalc();
                        scr = i;
                        cs.calc(scrambles.ToArray());

                        rescorner = cubestringcalc.cornerstring;
                        resedge = cubestringcalc.edgestring;

                        Thread t = new Thread(() => cornersolver.alg(rescorner));
                        t.Start();
                        t.Join();


                        Thread tr = new Thread(() => edgesolver.alg(cornersolver.edgestring));
                        tr.Start();
                        tr.Join();



                        if (args[args.Length - 1] == "v")
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            log("");
                            log("Solving " + scrambles[i]);
                            log("");



                            log("Solution to scramble is the following:");
                            log("");
                            cornersolver.solutions.ForEach(f => log(" " + f));
                            cornersolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                            log("");
                            edgesolver.solutions.ForEach(f => log(" " + f));
                            edgesolver.solutions.ForEach(f => File.AppendAllText("solutions.txt", " " + f + Environment.NewLine));
                            File.AppendAllText("solutions.txt", Environment.NewLine);
                            log("");
                            Console.ResetColor();
                        }
                        log(notall.Elapsed.TotalMilliseconds + " milliseconds for cube " + (i + 1) + "/" + a);
                        if (notall.Elapsed.TotalMilliseconds < pb)
                        {
                            pb = notall.Elapsed.TotalMilliseconds;
                            log("NEW PB OF " + notall.Elapsed.TotalMilliseconds);
                        }
                        notall.Restart();
                    }
                    else
                    {
                        st.Stop();
                        log("");
                        log("");
                        log("It took " + st.Elapsed.TotalMilliseconds + " milliseconds (" + st.Elapsed.TotalSeconds + " seconds) to solve " + i + " cubes.");
                        log("Average of " + i + " is " + (st.Elapsed.TotalMilliseconds / i));
                        log("We also got a PB of " + pb + " milliseconds!");
                        Environment.Exit(0);

                    }
                }
            }
<<<<<<< HEAD
            else
=======

            if (args.Length == 0)
>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df
            {
                log("  Valid Arguments:");
                log("    scr:     Solve a 3x3 given a scramble");
                log("    solve:   Solve a 3x3 given a cornerstring followed by an edgestring (advanced users only)");
                log("    avg:     Solve all scrambles in scrambles.txt and report back total time and our PB");
                log("    time:    Solve cubes for a specified time and report back total time and our PB");
                log("    ao:      Solve specified number of cubes in scrambles.txt and report back average, total time, and our PB");
                log("");
                log("  Examples:");
                log("    CubeBot2.0 scr U R2 F B R B2 R U2 L B2 R U' D' R2 F R' L B2 U2 F2");
                log("    CubeBot2.0 solve WOBWRBWRGWOGYOGYRGYRBYOB BWRWGWOWOBOGRGRBGYRYBYOY");
                log("    CubeBot2.0 avg");
                log("    CubeBot2.0 time <time_in_seconds>");
                log("    CubeBot2.0 ao <num_scrambles_in_avg>");
                Environment.Exit(1);
            }
        }

        public static void log(string text)
        {
            Console.WriteLine("   " + text);
        }

        public static string ExecuteCommand(string command)
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the stream ***
            string output = process.StandardOutput.ReadToEnd();

            output.Replace("  ", "");
            Console.WriteLine(output);

            process.Close();
            return output;
        }
<<<<<<< HEAD

        public static void manipulate(string move)
        {
            //log("");
            log("Applying move  [arg = " + move + "]");
            //log("");

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
            } //log(cornerstring);
            for (int i = 0; i < edgearray.Length; i++)
            {
                edgestring += edgearray[i];
            } //log(edgestring); log(""); log("");
        }
        static void put(string[] array, int positionA, int positionB)
        {
            //log("swapping " + positionA + " into " + positionB + " (aka " + array[positionA] + " into " + othertemp[positionB] + ")");
            othertemp[positionB] = array[positionA];
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
=======
>>>>>>> 4b9674c46e2b327d6952af221dc30069d81304df
    }
}
