using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmosWiti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj nazwe pliku z pulpitu");
            string nameOfFIle = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(@"D:\Users\User\Desktop\" + nameOfFIle + ".txt");
            int n = Convert.ToInt32(lines[0]);
            List<TaskLine> tasks = new List<TaskLine>();

            for (int i = 1; i < n + 1; i++)
            {
                string[] tmp = lines[i].Split(' ');
                tasks.Add(new TaskLine(tmp[0], tmp[1], tmp[2]));
            }

            var combinationCount = (int)Math.Pow(2, tasks.Count);
            int[] combinations = new int[combinationCount];
            combinations[0] = 0;

            for (int i = 1; i < combinationCount; i++)
            {
                int t = 0;
                combinations[i] = int.MaxValue;

                for (int j = 0; j < tasks.Count; j++)
                {
                    if ((i & (1 << j)) > 0)
                        t += tasks[j].P;
                }

                for (int j = 0; j < tasks.Count; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        int tmp = combinations[i & (~(1 << j))] + tasks[j].CheckPenalty(t);
                            if (combinations[i] > tmp)
                            combinations[i] = tmp;
                    }
                }
            }
            Console.WriteLine(combinations[combinationCount - 1]);
            File.WriteAllText(@"D:\Users\User\Desktop\" + nameOfFIle + ".out", combinations[combinationCount - 1].ToString());
        }
    }
}
