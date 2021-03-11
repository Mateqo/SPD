using System;
using System.Collections.Generic;
using System.Text;

namespace WczytywaniePliku
{
    public static class Service
    {
        public static void DisplayList(List<TaskLine> list)
        {
            foreach (var item in list)
            {
                if (item.R != 0 || item.P != 0)
                    Console.WriteLine(item.R + " " + item.P);
            }
        }
    }
}
