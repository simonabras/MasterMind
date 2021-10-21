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
            Random color = new Random();
            for (int i = 0; i <= 3; i++)
            {
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
