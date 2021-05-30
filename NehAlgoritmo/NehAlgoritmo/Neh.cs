using System;
using System.Collections.Generic;
using System.Linq;

namespace NehAlgoritmo
{
    public static class Neh
    {
        public static int NehAlgorithm(List<List<int>> list)
        {
            List<List<int>> copy = CopyDoubleList(list);
            List<List<int>> pi = new List<List<int>>();
            List<int> task = new List<int>();

            int cmax = int.MaxValue;
            int n = copy.Count();

            for (int i = 0; i < copy[0].Count(); i++)
            {
                task.Add(copy[n - 1][i]);
            }
            copy.RemoveAt(n - 1);
            pi.Add(new List<int>(task));

            task.Clear();

            n = copy.Count();

            for (int i = n; i > 0; i--)
            {
                for (int j = 0; j < copy[0].Count(); j++)
                {
                    task.Add(copy[i - 1][j]);
                }
                copy.RemoveAt(i - 1);

                cmax = FindBestTaskPosition(ref pi, task);

                task.Clear();
            }

            return cmax;
        }

        public static int FindBestTaskPosition(ref List<List<int>> list, List<int> task)
        {
            List<List<int>> newPi = new List<List<int>>();
            int cmax = int.MaxValue;

            for (int i = 0; i <= list.Count(); i++)
            {
                List<List<int>> copy = CopyDoubleList(list);

                copy.Insert(i, new List<int>(task));

                int c = CalculateCmax(copy);

                if (c < cmax)
                {
                    cmax = c;
                    newPi = CopyDoubleList(copy);
                }
            }

            list = CopyDoubleList(newPi);

            return cmax;
        }

        public static int CalculateCmax(List<List<int>> list)
        {
            int n = list.Count();
            int m = list[0].Count();
            List<List<int>> endTimes = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                endTimes.Add(new List<int>());

                for (int j = 0; j < m; j++)
                {
                    endTimes[i].Add(0);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        endTimes[i][j] = list[i][j];
                    }
                    else if (i == 0)
                    {
                        endTimes[i][j] = list[i][j] + endTimes[i][j - 1];
                    }
                    else if (j == 0)
                    {
                        endTimes[i][j] = list[i][j] + endTimes[i - 1][j];
                    }
                    else
                    {
                        if (endTimes[i][j - 1] > endTimes[i - 1][j])
                        {
                            endTimes[i][j] = list[i][j] + endTimes[i][j - 1];
                        }
                        else
                        {
                            endTimes[i][j] = list[i][j] + endTimes[i - 1][j];
                        }
                    }
                }
            }
            return endTimes[n - 1][m - 1];
        }

        public static List<List<int>> CopyDoubleList(List<List<int>> list)
        {
            List<List<int>> result = new List<List<int>>();

            foreach (var item in list)
            {
                result.Add(new List<int>(item));
            }

            return result;
        }
    }
}