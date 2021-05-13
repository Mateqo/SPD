using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorytmSchrage
{
    class Program
    {
        static void Main(string[] args)
        {
            // List - zamiast kolejki
            // First - pobiera pierwszy element (Top)
            // RemoveAt(0) - usuwanie pierwszego elementu (Pop)
            // Add z dodatkiem OrderBY - dodawanie na koniec i sortowanie (Push)

            Console.WriteLine("Podaj nazwe pliku z pulpitu");
            string nameOfFIle = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(@"D:\Users\User\Desktop\" + nameOfFIle + ".DAT");
            int n = Convert.ToInt32(lines[0]);
            List<TaskLine> N = new List<TaskLine>();
            List<TaskLine> G = new List<TaskLine>();
            int time = 0;
            int c = 0;
            int k = 0;

            for (int i = 1; i < n + 1; i++)
            {
                string[] tmp = lines[i].Split(' ');
                N.Add(new TaskLine(tmp[0], tmp[1], tmp[2]));
            }

            N = N.OrderBy(task => task.R).ToList();

            while (N.Count > 0 || G.Count > 0)
            {
                while (N.Count > 0 && N.First().R <= time)
                {
                    TaskLine temp = N.First();
                    N.RemoveAt(0);
                    G.Add(temp);
                    G = G.OrderByDescending(task => task.Q).ToList();
                }

                if (G.Count == 0)
                {
                    time = N.First().R;
                }
                else
                {
                    TaskLine temp = G.First();
                    Console.WriteLine("pi(" + k++ + "):" + temp.R + " " + temp.P + " " + temp.Q);
                    G.RemoveAt(0);
                    time += temp.P;
                    c = Math.Max(c, time + temp.Q);
                }
            }

            Console.WriteLine("Czas:" + c);
            File.WriteAllText(@"D:\Users\User\Desktop\" + nameOfFIle + ".OUT", c.ToString());
        }
    }
}
