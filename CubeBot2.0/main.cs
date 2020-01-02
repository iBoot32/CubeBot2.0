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

        static void Main(string[] args)
        {
            arg = args;
            st.Start();
            log("");
            log("");
            log("  CubeBot2.0 by iBoot32");
            log("--------------------------");
            log("");
            log("");

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
            {
                StringBuilder sb = new StringBuilder(" Calculating cubestring based on scramble: ");
                for (int i = 1; i < args.Length; i++)
                {
                    sb.Append(" " + args[i]);
                }
                Console.WriteLine("  " + sb.ToString());

                var cs = new cubestringcalc();
                cs.calc(args);

                rescorner = cubestringcalc.cornerstring;
                resedge = cubestringcalc.edgestring;

                log(rescorner);
                log(resedge);

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

            if (args.Length == 0)
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
    }
}
