using System;
using System.Text;
using System.Timers;

namespace CodeJam2020
{
    class Vestigium
    {
        Vestigium() { }
        static void main(string[] args)
        {
            new Vestigium().Solve();
        }

        void Solve()
        {
            int t = IntPut();
            for (int z = 0; z < t; z++)
            {
                int n = IntPut();
                int[][] m = new int[n][];
                for (int y = 0; y < n; y++)
                {
                    m[y] = new int[n];
                    string[] i = StrPut().Split();
                    for (int x = 0; x < n; x++)
                    {
                        m[y][x] = int.Parse(i[x]);
                    }
                }

                int k = 0;
                int r = 0;
                int c = 0;

                for (int d = 0; d < n; d++)
                {
                    k += m[d][d];
                    r += RowRepeats(d, m) ? 1 : 0;
                    c += ColRepeats(d, m) ? 1 : 0;

                }

                Cout("Case #1: {0} {1} {2}", k, r, c);
            }

        }

        bool RowRepeats(int index, int[][] m)
        {
            int n = m[0].Length;
            for (int i = 0; i < n; i++)
            {
                int current = m[index][i];
                for (int x = i + 1; x < n; x++)
                    if (current == m[index][x])
                        return true;
            }
            return false;
        }

        bool ColRepeats(int index, int[][] m)
        {
            int n = m[0].Length;
            for (int i = 0; i < n; i++)
            {
                int current = m[i][index];
                for (int y = i + 1; y < n; y++)
                    if (current == m[y][index])
                        return true;
            }
            return false;
        }

        void Hold() => Console.ReadKey();

        string StrPut() => Console.ReadLine();
        int IntPut() => int.Parse(StrPut());
        void Cout(string value, params object[] arg) => Console.WriteLine(value, arg);
        void Cout(object value) => Console.WriteLine(value);
    }
}
