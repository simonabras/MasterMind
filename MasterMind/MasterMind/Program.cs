using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void GenerateColors(out int[] colorsArray)
        {
            colorsArray = new int[4];
            Random colorsArray = new Random();
            for (int i = 0; i <= 3; i++)
            {
                colorsArray[i] = colorsArray.Next(7);
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
        static void ReponseColorsToArray(string reponseColors, out int[] reponseColorsArray)
        {
            reponseColorsArray = new int[4];
            for (int i = 0; i <= 3; i++)
            {
                reponseColorsArray[i] = reponseColors[i];
            }
        }
        static void CompareColors(int[] colorsArray, int[] reponseColorsArray)
        {
            for (int i = 0; i <= 3; i++)
            {

            }
        }
        static void Main(string[] args)
        {
            string reponseColors = "";

            GenerateColors(out int[] colorsArray);

            Console.WriteLine("Entrez des couleurs");
            reponseColors = Console.ReadLine();

            ReponseColorsToArray(reponseColors, out int[] reponseColorsArray);
            CompareColors(colorsArray, reponseColorsArray);
        }
    }
}
