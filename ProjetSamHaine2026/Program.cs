using System.ComponentModel.Design;

namespace ProjetSamHaine2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int taille;
            int[] coordX = new int[5];
            int[] coordY = new int[5];
            string continuer, reco;
            taille = 0;

            do
            {
                MethodesDuProjet.LireEntier("Quelle taille voulez vous(1-- 10x10  2-- 25x25 3-- 50x50", out taille);
            } while (taille < 1 || taille > 3);
            MethodesDuProjet.CreationDeLaMatrice(taille, out int[,] t);
            do
            {
                Console.Clear();
                int dimension = t.GetLength(0);

                // Lire jusqu'à 5 cellules de départ de manière répétitive en évitant la duplication
                for (int idx = 0; idx < 5; idx++)
                {
                    do
                    {
                        MethodesDuProjet.LireEntier($"Entrez la ligne (x) de la cellule #{idx + 1} (0..{dimension - 1}) (entrer 99 si vous ne voulez pas initialiser cette cellule):", out coordX[idx]);
                        MethodesDuProjet.afficherMatrice(taille, t);
                        MethodesDuProjet.LireEntier($"Entrez la colonne (y) de la cellule #{idx + 1} (0..{dimension - 1}) (entrer 99 si vous ne voulez pas initialiser cette cellule):", out coordY[idx]);
                        // accepter 99 pour ignorer, sinon valider les bornes
                    } while ((coordX[idx] != 99 && (coordX[idx] < 0 || coordX[idx] >= dimension)) || (coordY[idx] != 99 && (coordY[idx] < 0 || coordY[idx] >= dimension)));
                }

                MethodesDuProjet.InitialiserMatrice(taille, t, coordX[0], coordY[0], coordX[1], coordY[1], coordX[2], coordY[2], coordX[3], coordY[3], coordX[4], coordY[4]);

                Console.WriteLine("Veux-tu recommencer ? (o/n)");
                reco = Console.ReadLine();

            } while (reco == "o");

            do
            {
                for (int i = 0; i < 10; i++)
                {
                    MethodesDuProjet.afficherMatrice(taille, t);
                    MethodesDuProjet.CelluleMouvement(taille, t);
                }

                Console.WriteLine("Veux-tu continuer ? (o/n)");
                continuer = Console.ReadLine();

            } while (continuer == "o");
        }
    }

}