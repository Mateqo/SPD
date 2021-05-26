using System;
using System.Collections.Generic;
using System.Linq;

namespace NehAlgoritmo
{
    public static class Neh
    {
        public static int NehAlgorithm(List<List<int>> list)
        {
            List<List<int>> copy = new List<List<int>>(list);
            List<List<int>> pi = new List<List<int>>();
            List<int> job = new List<int>();

            int cmax = int.MaxValue;
            int n = copy.Count();

            for (int i = 0; i < copy[n - 1].Count(); i++)
            {
                job.Add(copy[n - 1][i]);
            }
            copy.RemoveAt(copy.Count() - 1);
            pi.Add(job);
            job.Clear();

            n = copy.Count();

            for (int i = n - 1 ; i > 0; i--)
            {
                for (int j = 0; j < copy[i].Count(); j++)
                {
                    job.Add(copy[i][j]);
                }
                copy.RemoveAt(copy.Count() - 1);

                List<List<int>> result = new List<List<int>>();
                cmax = FindBestTaskPosition(ref pi, job);
                job.Clear();
            }

            return cmax;
        }

        public static int FindBestTaskPosition(ref List<List<int>> list, List<int> task)
        {
            List<List<int>> newPi = new List<List<int>>();
            int cmax = int.MaxValue;

            for(int i = 0; i <= list.Count(); i++)
            {
                List<List<int>> copy = new List<List<int>>(list);

                copy.Insert(i, task);

                int c = CalculateCmax(copy);

                if(c < cmax)
                {
                    cmax = c;
                    newPi = copy;
                }
            }

            list = newPi;

            return cmax;
        }

        public static int CalculateCmax(List<List<int>> list)
        {
            int n = list.Count();
            int m = list[0].Count();
            List<List<int>> endTimes = new List<List<int>>();

            endTimes.Clear();

            for(int i = 0; i < n; i++)
            {
                List<int> tmp = new List<int>();
                endTimes.Add(tmp);

                for(int j = 0; j < m; j++)
                {
                    endTimes[i].Add(0);
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if(i == 0 && j == i)
                    {
                        endTimes[i][j] = list[i][j];
                    }
                    else if(i == 0)
                    {
                        endTimes[i][j] = list[i][j] + endTimes[i][j - 1];
                    }
                    else if(j == 0)
                    {
                        endTimes[i][j] = list[i][j] + endTimes[i - 1][j];
                    }
                    else
                    {
                        if(endTimes[i][j-1] > endTimes[i - 1][j])
                        {
                            endTimes[i][j] = list[i][j] + endTimes[i][j - 1];
                        }
                        else
                        {
                            endTimes[i][j] = list[i][j] + endTimes[i - i][j];
                        }
                    }
                }
            }
            return endTimes[n - 1][m - 1];
        }
    }
}
