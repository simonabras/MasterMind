using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void GenerateColors(out int[] programColorsArray)
        {
            programColorsArray = new int[4];
            Random number = new Random();
            for (int i = 0; i <= 3; i++)
            {
                // Nombre aléatoire entre 0 et 6
                programColorsArray[i] = number.Next(7);
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
        static void playerColorsToArray(string playerColors, out int[] playerColorsArray)
        {
            playerColorsArray = new int[4];
            for (int i = 0; i <= 3; i++)
            {
                // Placer chaque couleur dans un index du tabeau
                playerColorsArray[i] = int.Parse(playerColors[i].ToString());
            }
        }
        static void CompareColors(int[] programColorsArray, int[] playerColorsArray, out int redPawn, out int whitePawn)
        {
            int[] programColorsArray_ = new int[4];
            redPawn = 0;
            whitePawn = 0;

            // Ajout des couleurs de l'ordinateur dans un tableau comparatif
            for (int i = 0; i <= 3; i++)
            {
                programColorsArray_[i] = programColorsArray[i];
            }
            // Ajout des pions rouges
            for (int i = 0; i <= 3; i++)
            {
                if (playerColorsArray[i] == programColorsArray[i])
                {
                    programColorsArray_[i] = -1;
                    playerColorsArray[i] = -2;
                    redPawn++;
                }
            }
            // Ajout des pions blancs
            for (int i = 0; i <= 3; i++)
            {
                if(Array.Exists(playerColorsArray, element => element == programColorsArray_[i]))
                {
                    whitePawn++;
                }
            }
        }
        static void Main(string[] args)
        {
            // Générer les couleurs de l'ordinateur
            GenerateColors(out int[] programColorsArray);
            programColorsArray[0] = 1;
            programColorsArray[1] = 2;
            programColorsArray[2] = 4;
            programColorsArray[3] = 3;
            // Demander au joueur d'encoder les couleurs
            Console.WriteLine("-------");
            Console.WriteLine("Blanc = 0");
            Console.WriteLine("Noir = 1");
            Console.WriteLine("Bleu = 2");
            Console.WriteLine("Rouge = 3");
            Console.WriteLine("Vert = 4");
            Console.WriteLine("Jaune = 5");
            Console.WriteLine("-------");
            Console.WriteLine("Entrez 4 couleurs de votre choix");
            // Stocker les couleurs du joueur
            string playerColors = Console.ReadLine();
            // Convertir les couleurs du joueur en tableau
            playerColorsToArray(playerColors, out int[] playerColorsArray);
            // Comparer les couleurs de l'ordinateur aux couleurs du joueur
            CompareColors(programColorsArray, playerColorsArray, out int redPawn, out int whitePawn);
            Console.WriteLine($"Pions rouges : {redPawn}");
            Console.WriteLine($"Pions blancs : {whitePawn}");
            Console.ReadLine();
        }
    }
}
