using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Colors(out int[] colors)
        {
            colors = new int[4];
            for (int i = 0; i <= 3; i++)
            {
                Random color = new Random();
                colors[i] = color.Next(7);
            }
        }
        static void ReadColors(int[] colors)
        {
            for (int i = 0; i <= 3; i++)
            {
                Console.Write(colors[i]);
            }
            Console.Read();
        }
        static void Main(string[] args)
        {
            Colors(out int[] colors);
            ReadColors(colors);
        }
    }
}
