using System;

namespace AlgoritmoDeCarlier
{
    public class TaskLine
    {
        public int P { get; set; }
        public int Q { get; set; }
        public int R { get; set; }

        public TaskLine()
        {

        }

        public TaskLine Copy(TaskLine copy)
        {
            return new TaskLine()
            {
                P = copy.P,
                Q = copy.Q,
                R = copy.R
            };
        }

        public TaskLine(string r, string p, string q)
        {
            P = Convert.ToInt32(p);
            Q = Convert.ToInt32(q);
            R = Convert.ToInt32(r);
        }

        public TaskLine(int r, int p, int q)
        {
            P = p;
            Q = q;
            R = r;
        }
    }
}
