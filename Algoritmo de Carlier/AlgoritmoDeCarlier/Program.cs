using System;
using System.IO;
using System.Collections.Generic;

namespace AlgoritmoDeCarlier
{
    class Program
    {
        static void Main(string[] args)
        {

            //List - zamiast kolejki
            // First - pobiera pierwszy element(Top)
            // RemoveAt(0) - usuwanie pierwszego elementu(Pop)
            // Add z dodatkiem OrderBY -dodawanie na koniec i sortowanie(Push)

            int cMax = 999999999;

            List<TaskLine> Tasks = new List<TaskLine>();

            Console.WriteLine("Podaj nazwe pliku z pulpitu");
            string nameOfFIle = Console.ReadLine();
            string[] lines = File.ReadAllLines(@"D:\Users\User\Desktop\" + nameOfFIle + ".DAT");
            int n = Convert.ToInt32(lines[0]);

            for (int i = 1; i < n + 1; i++)
            {
                string[] tmp = lines[i].Split(' ');
                Tasks.Add(new TaskLine(tmp[0], tmp[1], tmp[2]));
            }

            Carlier.CarlierAlgorithm(Tasks, ref cMax);

            Console.WriteLine("Otrzymana wartosc CMAX : " + cMax);
            // File.WriteAllText(@"D:\Users\User\Desktop\" + Global.NameOfFile + ".OUT", resultSplitSchreage.ToString());

        }

    }

}
