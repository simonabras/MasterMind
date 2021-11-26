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
        static void CompareArray(int[] programColorsArray, out int[] programColorsArray_)
        {
            programColorsArray_ = new int[4];
            // Ajout des couleurs de l'ordinateur dans un tableau comparatif
            for (int i = 0; i < 4; i++)
            {
                programColorsArray_[i] = programColorsArray[i];
            }
        }
        static void CalculRedPawn(int[] programColorsArray_, int[] playerColorsArray, out int redPawn)
        {
            redPawn = 0;
            // Ajout des pions rouges
            for (int i = 0; i < 4; i++)
            {
                if (playerColorsArray[i] == programColorsArray_[i])
                {
                    programColorsArray_[i] = -1;
                    playerColorsArray[i] = -2;
                    redPawn++;
                }
            }
        }
        static void CalculWhitePawn(int[] programColorsArray_, int[] playerColorsArray, out int whitePawn)
        {
            whitePawn = 0;
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
        static void CheckInt(ref string reponse)
        {
            int result;
            bool success = int.TryParse(reponse, out result);
            while (!success)
            {
                Console.WriteLine("Il faut entrer un nombre !");
                reponse = Console.ReadLine();
                success = int.TryParse(reponse, out result);
            }
        }
        static void CheckLength(ref string reponse, int require)
        {
            while (reponse.Length != require)
            {
                Console.WriteLine($"Il faut entrer {require} nombres !");
                reponse = Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            int round = 1;
            int redPawn = 0;
            int whitePawn = 0;

            // Générer les couleurs de l'ordinateur
            GenerateColors(out int[] programColorsArray);
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
                CheckInt(ref playerColors);
                CheckLength(ref playerColors, 4);
                // Convertir les couleurs du joueur en tableau
                PlayerColorsToArray(playerColors, out int[] playerColorsArray);
                // Comparer les couleurs de l'ordinateur aux couleurs du joueur
                CompareArray(programColorsArray, out int[] programColorsArray_);
                CalculRedPawn(programColorsArray_, playerColorsArray, out redPawn);
                CalculWhitePawn(programColorsArray_, playerColorsArray, out whitePawn);
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