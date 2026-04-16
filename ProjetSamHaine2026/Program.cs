namespace ProjetSamHaine2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int taille;
            string continuer;
            do
            {
                LireEntier("Quelle taille voulez vous(1-- 10x10  2-- 25x25 3-- 50x50", out taille);
            } while (taille < 1 || taille > 3);
            CreationDeLaMatrice(taille, out int[,] t);

            InitialiserMatrice(taille, t);

            do
            {
                for (int i = 0; i < 10; i++)
                {
                    afficherMatrice(taille, t);
                    CelluleMouvement(taille, t);
                }

                Console.WriteLine("Veux-tu continuer ? (oui/non)");
                continuer = Console.ReadLine();

            } while (continuer == "oui");
        }

        static void LireEntier(string question, out int n)
        {
            string infoUser;
            do
            {
                Console.WriteLine(question);
                infoUser = Console.ReadLine();
            } while (!int.TryParse(infoUser, out n));
        }
        static void CreationDeLaMatrice(int taille, out int[,] t)
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


        static void InitialiserMatrice(int taille, int[,] t)
        {
            string continuer;
            do
            {

                Console.WriteLine("Voulez vous placer une autre cellule ? (oui/non)");
                continuer = Console.ReadLine();
            } while (continuer == "non");
            int dimension = t.GetLength(0);

            t[dimension / 2, dimension / 2 - 1] = 1;
            t[dimension / 2, dimension / 2] = 1;
            t[dimension / 2, dimension / 2 + 1] = 1;
        }


        static void afficherMatrice(int taille, int[,] t)
        {
            int dimension = t.GetLength(0);

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(t[i, j] == 1 ? "■" : "o");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void CelluleMouvement(int taille, int[,] t)
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

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    t[i, j] = nouvelle[i, j];
                }
            }
        }

        static int CompterVoisins(int x, int y, int[,] t)
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