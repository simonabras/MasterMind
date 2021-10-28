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
            for (int i = 0; i < 4; i++)
            {
                // Nombre aléatoire entre 0 et 6
                programColorsArray[i] = number.Next(7);
            }
        }
        static void ReadColors(int[] colors)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write(colors[i]);
            }
            Console.Read();
        }
        static void PlayerColorsToArray(string playerColors, out int[] playerColorsArray)
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
            for (int i = 0; i < 4; i++)
            {
                programColorsArray_[i] = programColorsArray[i];
            }
            // Ajout des pions rouges
            for (int i = 0; i < 4; i++)
            {
                if (playerColorsArray[i] == programColorsArray[i])
                {
                    programColorsArray_[i] = -1;
                    playerColorsArray[i] = -2;
                    redPawn++;
                }
            }
            // Ajout des pions blancs
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (playerColorsArray[i] == programColorsArray_[j])
                    {
                        playerColorsArray[i] = -2;
                        whitePawn++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int round = 1;
            int redPawn = 0;
            int whitePawn = 0;

            // Générer les couleurs de l'ordinateur
            GenerateColors(out int[] programColorsArray);
            programColorsArray[0] = 1;
            programColorsArray[1] = 2;
            programColorsArray[2] = 3;
            programColorsArray[3] = 4;
            // Boucle des manches
            while (redPawn != 4 && round <= 12)
            {
                // Début de la partie
                Console.WriteLine();
                Console.WriteLine($"----- Manche {round} -----");
                Console.WriteLine("Blanc = 0  Noir = 1");
                Console.WriteLine("Bleu = 2  Rouge = 3");
                Console.WriteLine("Vert = 4  Jaune = 5");
                Console.WriteLine();
                Console.WriteLine("Entrez 4 couleurs de votre choix");
                Console.WriteLine("---------------------");
                // Stocker les couleurs du joueur
                string playerColors = Console.ReadLine();
                // Convertir les couleurs du joueur en tableau
                PlayerColorsToArray(playerColors, out int[] playerColorsArray);
                // Comparer les couleurs de l'ordinateur aux couleurs du joueur
                CompareColors(programColorsArray, playerColorsArray, out redPawn, out whitePawn);
                Console.WriteLine();
                Console.WriteLine($"Pions rouges : {redPawn}");
                Console.WriteLine($"Pions blancs : {whitePawn}");
                // Vérifier si il y a 4 pions rouges
                if (redPawn == 4)
                {
                    // Fin de la partie
                    Console.WriteLine();
                    Console.WriteLine("Bien joué ! Vous avez gagné !");
                    Console.ReadLine();
                }
                else
                {
                    // Ajout d'une manche
                    round++;
                    // Vérifier si le nombre de manches est plus grand de 12
                    if (round > 12)
                    {
                        // Fin de la partie
                        Console.WriteLine();
                        Console.WriteLine("Dommage ! Vous avez perdu !");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}