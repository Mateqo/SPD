using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoritmoDeCarlier
{
    public static class Schrage
    {
        public static List<TaskLine> Pi = new List<TaskLine>();
        public static int SchrageSplit(List<TaskLine> Tasks)
        {
            List<TaskLine> N = Tasks.Select(x => x.Copy(x)).ToList();
            List<TaskLine> G = new List<TaskLine>();
            TaskLine l = new TaskLine(0, 0, 0);
            int time = 0;
            int c = 0;

            N = N.OrderBy(task => task.R).ToList();

            while (N.Count > 0 || G.Count > 0)
            {
                while (N.Count > 0 && N.First().R <= time)
                {
                    TaskLine temp = N.First();
                    N.RemoveAt(0);
                    G.Add(temp);
                    G = G.OrderByDescending(task => task.Q).ToList();

                    if (temp.Q > l.Q)
                    {
                        l.P = time - temp.R;
                        time = temp.R;
                        if (l.P > 0)
                        {
                            G.Add(l);
                            G = G.OrderByDescending(task => task.Q).ToList();
                        }
                    }
                }

                if (G.Count == 0)
                {
                    time = N.First().R;
                }
                else
                {
                    TaskLine temp = G.First();

                    // Console.WriteLine(temp.R + " " + temp.P + " " + temp.Q);
                    G.RemoveAt(0);
                    l = temp;
                    time += temp.P;
                    c = Math.Max(c, time + temp.Q);
                }
            }
            return c;
        }

        public static int SchrageBasic(List<TaskLine> Tasks)
        {
            Pi.Clear();
            List<TaskLine> N = Tasks.Select(x => x.Copy(x)).ToList();
            List<TaskLine> G = new List<TaskLine>();
            TaskLine l = new TaskLine(0, 0, 0);
            int time = 0;
            int c = 0;

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
                    // Console.WriteLine("pi(" + k++ + "):" + temp.R + " " + temp.P + " " + temp.Q);
                    Pi.Add(temp);
                    G.RemoveAt(0);
                    time += temp.P;
                    c = Math.Max(c, time + temp.Q);
                }
            }

            return c;
        }
    }
}
