using System;
using System.Collections.Generic;
using System.Linq;

namespace NehAlgoritmo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj nazwe pliku z pulpitu");
            string nameOfFIle = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(@"D:\Users\User\Desktop\" + nameOfFIle + ".DAT");
            string[] tmp = lines[0].Split(' ');
            int n = Convert.ToInt32(tmp[0]);
            int m = Convert.ToInt32(tmp[1]);
            List<List<int>> TaskList = new List<List<int>>();
            List<int> SumOfTimes = new List<int>();

            for (int i = 0; i < n; i++)
            {
                TaskList.Add(new List<int>());
                tmp = lines[i + 1].Split(' ');
                int sum = 0;

                for (int j = 0; j < m; j++)
                {
                    sum += Convert.ToInt32(tmp[j]);
                    TaskList[i].Add(Convert.ToInt32(tmp[j]));
                }
                SumOfTimes.Add(sum);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        if (SumOfTimes[i] < SumOfTimes[j])
                        {
                            var tmpSwap = SumOfTimes[i];
                            SumOfTimes[i] = SumOfTimes[j];
                            SumOfTimes[j] = tmpSwap;

                            var tmpSwap2 = TaskList[i];
                            TaskList[i] = TaskList[j];
                            TaskList[j] = tmpSwap2;
                        }
                    }
                }
            }

            int result = Neh.NehAlgorithm(TaskList);
            Console.WriteLine($"Cmax = {result}");
        }
    }
}
