using System;
using System.Collections.Generic;
using System.Text;

namespace WczytywaniePliku
{
    public class TaskLine
    {
        public int R { get; set; }
        public int P { get; set; }

        public TaskLine(string R, string P)
        {
            this.R = Convert.ToInt32(R);
            this.P = Convert.ToInt32(P);
        }
        public TaskLine(int R, int P)
        {
            this.R = R;
            this.P = P;
        }
    }
}
