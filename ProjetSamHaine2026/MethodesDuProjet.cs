using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSamHaine2026
{
    public static class MethodesDuProjet
    {
        public static void LireEntier(string question, out int a)
        {
            string aUser;
            do
            {
                Console.WriteLine(question);
                aUser = Console.ReadLine();
            } while (!int.TryParse(aUser, out a));
        }


        public static void CreationDeLaMatrice(int taille, out int[,] t)
        {
            if (taille == 1)
            {
                t = new int[10, 10];
            }
            else if (taille == 2)
            {
                t = new int[25, 25];
            }
            else
            {
                t = new int[50, 50];
            }
        }

        public static void InitialiserMatrice(int taille, int[,] t, int coord1x, int coord1y, int coord2x, int coord2y, int coord3x, int coord3y, int coord4x, int coord4y, int coord5x, int coord5y)
        {
            int dimension = t.GetLength(0);

            // Réinitialiser la matrice à 0
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    t[i, j] = 0;
                }
            }

            if (coord1x != 99 && coord1y != 99)
            {
                t[coord1x, coord1y] = 1;
            }
            if (coord2x != 99 && coord2y != 99)
            {
                t[coord2x, coord2y] = 1;
            }
            if (coord3x != 99 && coord3y != 99)
            {
                t[coord3x, coord3y] = 1;
            }
            if (coord4x != 99 && coord4y != 99)
            {
                t[coord4x, coord4y] = 1;
            }
            if (coord5x != 99 && coord5y != 99)
            {
                t[coord5x, coord5y] = 1;
            }
        }

        public static void CelluleMouvement(int taille, int[,] t)
        {
            int dimension = t.GetLength(0);
            int[,] nouvelle = new int[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    int voisins = CompterVoisins(i, j, t);

                    if (t[i, j] == 1)
                    {
                        if (voisins == 2 || voisins == 3)
                            nouvelle[i, j] = 1;
                        else
                            nouvelle[i, j] = 0;
                    }
                    else
                    {
                        if (voisins == 3)
                            nouvelle[i, j] = 1;
                        else
                            nouvelle[i, j] = 0;
                    }
                }
            }

            // Copier la nouvelle matrice dans l'ancienne
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    t[i, j] = nouvelle[i, j];
                }
            }
        }

        public static void afficherMatrice(int taille, int[,] t)
        {
            int dimension = t.GetLength(0);

            // En-tête des colonnes avec largeur fixe pour l'alignement
            Console.Write("    "); // espace pour l'indice de ligne
            for (int col = 0; col < dimension; col++)
            {
                Console.Write($"{col + 1,3}");
            }
            Console.WriteLine();

            // Lignes de la matrice avec étiquettes de lignes et cellules à largeur fixe
            for (int i = 0; i < dimension; i++)
            {
                Console.Write($"{i + 1,3} "); // étiquette de ligne
                for (int j = 0; j < dimension; j++)
                {
                    if (t[i, j] == 1)
                    {
                        Console.Write(" ■ ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int CompterVoisins(int x, int y, int[,] t)
        {
            int total = 0;
            int dimension = t.GetLength(0);

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx >= 0 && nx < dimension && ny >= 0 && ny < dimension)
                    {
                        total += t[nx, ny];
                    }
                }
            }

            return total;
        }
    }
}
