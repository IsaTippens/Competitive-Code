using System;
using System.Text;

namespace CodeJam2020
{
    class Program
    {
        public Program() { }
        static void Main(string[] args)
        {
            new Program().Solve();
        }

        void Solve()
        {
            int t = Intput();
            for (int _t = 0; _t < t; _t++)
            {
                int a = Intput();
                int b = Intput();
                int guess = (int)Math.Round((double)(a + b) / 2);
                int target = new Random().Next(a, b);
                int n = Intput();
                string s = "";
                for (int _n = 0; _n < n; _n++)
                {
                    Cout(guess);
                    if (guess == target)
                    {
                        Cout("CORRECT");
                        break;
                    }

                    if (guess > target)
                    {
                        Cout("Too big");
                        s = "b";
                    }

                    if (guess < target)
                    {
                        Cout("Too small"); 
                        s = "s";
                    }

                    if (s == "b")
                    {
                        b = guess;
                        guess = (int)Math.Round((double)(a + b) / 2);
                    }
                    else
                    {
                        a = guess;
                        guess = (int)Math.Round((double)(a + b) / 2);
                    }

                }
            }
            Console.ReadKey();
        }

        int Str2Int(string s)
        {
            return int.Parse(s);
        }
        int Intput()
        {
            return Str2Int(Strput());
        }

        string Strput()
        {
            return Console.ReadLine();
        }

        void Cout(object s)
        {
            Console.WriteLine(s);
        }

        void Cout(string s, params string[] args)
        {
            Console.WriteLine(s, args);
        }
    }
}
