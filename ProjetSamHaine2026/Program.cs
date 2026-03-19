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

            for (int i = 0; i < 10; i++)
            {
                CelluleMouvement(0, 0, taille, t);
                afficherMatrice(taille, t);
                if (i == 10)
                {
                    Console.WriteLine("veut tu continuer");
                    continuer = Console.ReadLine();
                    if (continuer == "oui")
                    {
                        i = 0;
                    }
                }
            }

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
        static void afficherMatrice(int taille, int[,] t)
        {
            if (taille == 1)
            {
                for (int i = 0; i < taille; i++)
                {
                    for (int j = 0; j < taille; j++)
                    {
                        Console.Write(t[i, j] + " ");
                        if (j == 10)
                        {
                            Console.WriteLine("\n");
                        }
                    }
                    Console.WriteLine();
                }
            }

        }
        static void CelluleMouvement(int tTotal, int tTaille, int taille, int[,] t)
        {
            if (taille == 1)
            {
                tTaille = 10;
            }
            else if (taille == 2)
            {
                tTaille = 25;
            }
            else
            {
                tTaille = 50;
            }

            for (int nbr2 = 0; nbr2 < tTaille; nbr2++)
            {
                for (int nbr1 = 0; nbr1 < tTaille; nbr1++)
                {
                    tTotal = ((nbr1 > 0) ? t[nbr1 - 1, nbr2] : 0) + ((nbr1 + 1 < t.GetLength(0)) ? t[nbr1 + 1, nbr2] : 0) + ((nbr1 > 0 && nbr2 > 0) ? t[nbr1 - 1, nbr2 - 1] : 0) + ((nbr1 + 1 < t.GetLength(0) && nbr2 > 0) ? t[nbr1 + 1, nbr2 - 1] : 0) + ((nbr2 > 0) ? t[nbr1, nbr2 - 1] : 0) + ((nbr2 + 1 < t.GetLength(1)) ? t[nbr1, nbr2 + 1] : 0) + ((nbr1 > 0 && nbr2 + 1 < t.GetLength(1)) ? t[nbr1 - 1, nbr2 + 1] : 0) + ((nbr1 + 1 < t.GetLength(0) && nbr2 + 1 < t.GetLength(1)) ? t[nbr1 + 1, nbr2 + 1] : 0);
                    if (tTotal == 3)
                    {
                        t[nbr1, nbr2] = 1;
                    } else if (tTotal == 2)
                    {

                    }else
                    {
                        t[nbr1, nbr2] = 0;
                    }
                }
            }
        }
    }
}