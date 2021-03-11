using System;
using System.Collections.Generic;
using System.IO;

namespace WczytywaniePliku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj nazwe pliku z pulpitu");
            string nameOfFIle = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(@"D:\Users\User\Desktop\" + nameOfFIle + ".DAT");
            int n = Convert.ToInt32(lines[0]);
            List<TaskLine> ListOfTask = new List<TaskLine>();
            int[] result = new int[n + 1];
            result[0] = 0;

            for (int i = 0; i < n + 1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"Liczba operacji {n}");
                    ListOfTask.Add(new TaskLine(0, 0));
                }
                else
                {
                    string[] tmp = lines[i].Split(' ');
                    ListOfTask.Add(new TaskLine(tmp[0], tmp[1]));
                }
            }

            Service.DisplayList(ListOfTask);

            Console.WriteLine("");

            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (ListOfTask[j - 1].R > ListOfTask[j].R)
                    {
                        ListOfTask.Reverse(j - 1, 2);
                    }
                }
            }

            Console.WriteLine("Posortowane:");
            Service.DisplayList(ListOfTask);

            for (int i = 1; i < n + 1; i++)
            {
                result[i] = Math.Max(ListOfTask[i].R, result[i - 1]) + ListOfTask[i].P;
            }

            Console.WriteLine("\n Otrzymany wynik= " + result[n]);
            File.WriteAllText(@"D:\Users\User\Desktop\" + nameOfFIle + ".OUT", result[n].ToString());
        }
    }
}
