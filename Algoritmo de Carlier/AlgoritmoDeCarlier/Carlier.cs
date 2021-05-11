using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoDeCarlier
{
    public class Carlier
    {
		public static void CarlierAlgorithm(List<TaskLine> Tasks, ref int ub)
		{
			int u = Schrage.SchrageBasic(Tasks);

			if (u < ub)
			{
				ub = u;
			}

			int b = FindB(Schrage.Pi, u);
			int a = FindA(Schrage.Pi, u, b);
			int c = FindC(Schrage.Pi, u, b, a);

			if (c == -1)
			{
				return;
			}

			int ri = 999999999;
			int pi = 0;
			int qi = 999999999;

			for (int i = c + 1; i <= b; i++)
			{
				if (Schrage.Pi[i].R < ri)
				{
					ri = Schrage.Pi[i].R;
				}
				if (Schrage.Pi[i].Q < qi)
				{
					qi = Schrage.Pi[i].Q;
				}
				pi += Schrage.Pi[i].P;
			}

			int tmpR = Schrage.Pi[c].R;
			Schrage.Pi[c].R = Math.Max(Schrage.Pi[c].R, ri + pi);

			int lb = Schrage.SchrageSplit(Schrage.Pi);
			if (lb < ub)
			{
				CarlierAlgorithm(Schrage.Pi, ref ub);
			}

			Schrage.Pi[c].R = tmpR;
			int tmpQ = Schrage.Pi[c].Q;
			Schrage.Pi[c].Q = Math.Max(Schrage.Pi[c].Q, qi + pi);
			lb = Schrage.SchrageSplit(Schrage.Pi);

			if(lb < ub)
            {
				CarlierAlgorithm(Schrage.Pi, ref ub);
            }

			Schrage.Pi[c].Q = tmpQ;
		}
		public static int FindA(List<TaskLine> Pi, int Cmax, int b)
		{
			int aSum = 0;
			int a = -1;
			int time = Pi[0].R;
			for (int i = 0; i < Pi.Count; i++)
			{
				TaskLine tmp = Pi[i];
				time = Math.Max(time, tmp.R);
				time += tmp.P;

				if(a == -1)
                {
					aSum = 0;
					for(int j = i; j <= b; j++)
                    {
						aSum += Pi[j].P;
                    }
					aSum += Pi[b].Q;
					if(Cmax == (Pi[i].R + aSum))
                    {
						a = i;
                    }
                }
			}
			return a;
		}
		public static int FindB(List<TaskLine> Pi, int Cmax)
		{
			int b = -1;
			int time = Pi[0].R;
			for (int i = 0; i < Pi.Count; i++)
			{
				TaskLine tmp = Pi[i];
				time = Math.Max(time, tmp.R);
				time += tmp.P;

				if (Cmax == (Pi[i].Q + time))
				{
					b = i;
				}
			}
			return b;
		}

		public static int FindC(List<TaskLine> Pi, int Cmax, int a, int b)
		{
			int c = -1;
			int time = Pi[0].R;
			for (int i = a; i <= b; i++)
			{
				if (Pi[i].Q < Pi[b].Q)
				{
					c = i;
				}
			}
			return c;
		}
	}
}
