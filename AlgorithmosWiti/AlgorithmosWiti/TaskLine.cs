using System;

namespace AlgorithmosWiti
{
    class TaskLine
    {
        public int P { get; set; }
        public int W { get; set; }
        public int D { get; set; }

        public TaskLine(string p, string w, string d)
        {
            P = Convert.ToInt32(p);
            W = Convert.ToInt32(w);
            D = Convert.ToInt32(d);
        }

        public TaskLine(int p, int w, int d)
        {
            P = p;
            W = w;
            D = d;
        }

        public int CheckPenalty(int t)
        {
            int penalty = (t - this.D) * this.W;
            return penalty > 0 ? penalty : 0;
        }
    }
}
