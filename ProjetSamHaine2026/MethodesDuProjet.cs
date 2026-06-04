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
            // Crée la matrice carrée t en fonction du choix de taille
            // taille == 1 => 10x10, taille == 2 => 25x25, sinon 50x50
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

            // Initialise toute la matrice à 0 (cellules mortes)
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    t[i, j] = 0;
                }
            }

            // Les paramètres coordNx/coordNy indiquent jusqu'à 5 positions initiales.
            // La valeur 99 est utilisée comme sentinelle pour "pas de valeur".
            // Si une paire n'est pas 99, on place une cellule vivante (1) à cet emplacement.
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

                    // - Si la cellule est vivante (1) : elle survit si elle a 2 ou 3 voisins, sinon elle meurt.
                    // - Si la cellule est morte (0) : elle devient vivante si elle a exactement 3 voisins.
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
                        {
                            nouvelle[i, j] = 1;
                        }
                        else
                        {
                            nouvelle[i, j] = 0;
                        }
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
            Console.Write("   ");
            for (int col = 0; col < dimension; col++)
            {
                int num = col + 1;
                // Champ largeur 3 : deux espaces + chiffre pour 1..9, un espace + deux chiffres pour 10..99
                if (num < 10)
                {
                    Console.Write("  " + num);
                }
                else
                {
                    Console.Write(" " + num);
                }
            }
            Console.WriteLine();

            for (int i = 0; i < dimension; i++)
            {
                int rNum = i + 1;
                // Affiche l'indice de la ligne en champ largeur 3
                if (rNum < 10)
                {
                    Console.Write("  " + rNum);
                }
                else
                {
                    Console.Write(" " + rNum);
                }

                for (int j = 0; j < dimension; j++)
                {
                    int sym;
                    if (t[i, j] == 1)
                    {
                        sym = 1;
                    }
                    else
                    {
                        sym = 0;
                    }

                    string affich;
                    if (sym == 1)
                    {
                        affich = "■";
                    }
                    else
                    {
                        affich = ".";
                    }

                    // Chaque cellule occupe 3 caractères : espace + symbole + espace
                    Console.Write(" " + affich + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int CompterVoisins(int x, int y, int[,] t)
        {
            int total = 0;
            int dimension = t.GetLength(0);

            // Parcourt les 8 voisins autour de la cellule (x,y) en utilisant des offsets dx/dy
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    // On ignore la position centrale (dx == 0 && dy == 0)
                    if (dx == 0 && dy == 0)
                        continue;

                    int nx = x + dx;
                    int ny = y + dy;

                    // Vérifie que le voisin est à l'intérieur des limites de la matrice
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
