using System;
using System.Text;

namespace CodeJam2020
{
    class NestingDepth
    {
        NestingDepth() { }
        static void main(string[] args)
        {
            new NestingDepth().Solve();
        }

        void Solve()
        {
            int t = IntPut();
            for (int z = 0; z < t; z++)
            {
                string s = StrPut();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    int current = (int)s[i] - 48;

                    int next = 0;
                    if (i != 0)
                        next = s[i - 1] - 48;
                    for (int l = 0; l < current - next; l++)
                        sb.Append("(");

                    sb.Append(current);

                    int previous = 0;
                    if (i != s.Length - 1)
                        previous = s[i + 1] - 48;
                    for (int r = 0; r < current - previous; r++)
                        sb.Append(")");
                }
                Cout("Case #{0}: {1}", z + 1, sb.ToString());
            }
        }

        void Hold() => Console.ReadKey();  //To prevent the console from exiting immediately during local testing 

        string StrPut() => Console.ReadLine();
        int IntPut() => int.Parse(StrPut());
        void Cout(string value, params object[] arg) => Console.WriteLine(value, arg);
        void Cout(object value) => Console.WriteLine(value);
    }
}
