using System;
using System.Collections.Generic;
using System.Text;

namespace CodeJam2020
{
    class ParentingPartneringReturns
    {
        ParentingPartneringReturns() { }
        static void main(string[] args)
        {
            new ParentingPartneringReturns().Solve();
        }

        void Solve()
        {
            int t = IntPut();
            for (int z = 0; z < t; z++)
            {
                int n = IntPut();
                int[][] times = new int[n][];
                StringBuilder sb = new StringBuilder(); //Schedule

                for (int i = 0; i < n; i++)
                {
                    times[i] = new int[2];
                    string[] time = StrPut().Split(' ');
                    times[i][0] = IntPut(time[0]);
                    times[i][1] = IntPut(time[1]);
                }
                int[][] sorted = new int[n][];
                times.CopyTo(sorted, 0);
                sorted = sort(sorted);

                bool possible = true;
                for (int i = 0; i < n; i++)
                {
                    string result = AssignNextPerson(sorted, sb.ToString(), i);
                    if (result == "IMPOSSIBLE")
                    {
                        possible = false;
                        break;
                    }
                    else
                        sb.Append(result);
                }
                if (possible)
                {
                    StringBuilder r = new StringBuilder();
                    for (int x = 0; x < times.Length; x++)
                    {
                        for (int y = 0; y < sorted.Length; y++)
                        {
                            if (sorted[y][0] == -1)
                                continue;
                            if (EqualTimes(sorted[y], times[x]))
                            {
                                sorted[y] = new int[] { -1, -1 };
                                r.Append(sb[y]);
                                break;
                            }
                        }
                    }
                    Cout("Case #{0}: {1}", z + 1, r.ToString());
                }
                else
                {
                    Cout("Case #{0}: IMPOSSIBLE", z + 1);
                }

            }
        }

        bool EqualTimes(int[] first, int[] second)
        {
            return (first[0] == second[0]) && (first[1] == second[1]);
        }

        int[][] sort(int[][] t)
        {
            for (int y = 0; y <= t.Length - 1; y++)
            {
                for (int x = 0; x < t.Length - 1; x++)
                    if (t[x][1] < t[x + 1][1])
                    {
                        int[] temp = t[x];
                        t[x] = t[x + 1];
                        t[x + 1] = temp;
                    }
            }
            return t;
        }

        string AssignNextPerson(int[][] times, string schedule, int current)
        {
            if (CheckIfFree(times, schedule, 'C', times[current]))
            {
                return "C";
            }
            else if (CheckIfFree(times, schedule, 'J', times[current]))
            {
                return "J";
            }
            else
                return "IMPOSSIBLE";
        }

        bool CheckIfFree(int[][] times, string schedule, char p, int[] time)
        {
            for (int x = schedule.Length - 1; x >= 0; x--)
            {
                if (schedule[x] == p)
                    if (IsOverlap(time, times[x]))
                        return false;
            }
            return true;
        }

        bool IsOverlap(int[] current, int[] other)
        {
            if (current[0] >= other[0] && current[0] < other[1])
                return true;
            if (current[1] > other[0] && current[1] <= other[1])
                return true;
            return false;
        }

        void Hold() => Console.ReadKey();  //To prevent the console from exiting immediately during local testing 

        string StrPut() => Console.ReadLine();
        int IntPut(string val) => int.Parse(val);
        int IntPut() => IntPut(StrPut());
        void Cout(string value, params object[] arg) => Console.WriteLine(value, arg);
        void Cout(object value) => Console.WriteLine(value);
    }
}
