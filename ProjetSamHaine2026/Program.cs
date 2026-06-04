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
                MethodesDuProjet.LireEntier("Quelle taille voulez vous(1-- 10x10  2-- 25x25 3-- 50x50)?", out taille);
            } while (taille < 1 || taille > 3);

            // Création de la matrice selon la taille choisie. La méthode retourne la matrice via un paramètre out
            MethodesDuProjet.CreationDeLaMatrice(taille, out int[,] t);
            do
            {
                Console.Clear();
                // Récupère la dimension actuelle de la matrice (nombre de lignes = nombre de colonnes)
                int dimension = t.GetLength(0);

                // Pour chaque cellule on demande la ligne (rx) puis la colonne (ry).
                // L'utilisateur peut entrer 99 pour ignorer une cellule.
                // idx : index de la cellule demandée (0..4)
                // rx : valeur lue pour la ligne ou 99 pour ignorer
                // ry : valeur lue pour la colonne ou 99 pour ignorer
                for (int idx = 0; idx < 5; idx++)
                {
                    int rx, ry;
                    // Lecture de la ligne. La validation empêche les valeurs hors plage
                    // sauf la valeur spéciale 99 qui signifie "ignorer cette cellule".
                    do
                    {
                        string questionLigne = "Entrez la ligne (x) de la cellule #" + (idx + 1) + " (1.." + dimension + ", 99 pour ignorer):";
                        MethodesDuProjet.LireEntier(questionLigne, out rx);
                    } while (rx != 99 && (rx < 1 || rx > dimension));
                    // Si l'utilisateur a choisi d'ignorer la ligne, on marque la paire comme 99,99
                    // et on n'exécute pas la suite pour cette itération.
                    if (rx == 99)
                    {
                        coordX[idx] = 99;
                        coordY[idx] = 99;
                    }
                    else
                    {
                        // Lecture de la colonne avec la même logique que pour la ligne
                        do
                        {
                            string questionCol = "Entrez la colonne (y) de la cellule #" + (idx + 1) + " (ligne = " + rx + ") (1.." + dimension + ", 99 pour ignorer):";
                            MethodesDuProjet.LireEntier(questionCol, out ry);
                        } while (ry != 99 && (ry < 1 || ry > dimension));

                        // Si l'utilisateur a choisi d'ignorer la colonne, on marque la paire comme 99,99
                        if (ry == 99)
                        {
                            coordX[idx] = 99;
                            coordY[idx] = 99;
                        }
                        else
                        {
                            // Convertit les coordonnées de l'interface utilisateur vers l'indexation du tableau car sinon sa décale le tableau.
                            coordX[idx] = rx - 1;
                            coordY[idx] = ry - 1;
                        }
                    }
                }


                // Appelle une méthode qui initialise la matrice en utilisant les coordonnées saisies
                // Les coordonnées non fournies sont marquées comme 99 et la méthode doit en tenir compte
                MethodesDuProjet.InitialiserMatrice(taille, t, coordX[0], coordY[0], coordX[1], coordY[1], coordX[2], coordY[2], coordX[3], coordY[3], coordX[4], coordY[4]);

                // Demande si l'utilisateur veut recommencer la saisie des coordonnées
                Console.WriteLine("Veux-tu recommencer ? (o/n)");
                reco = Console.ReadLine();

            } while (reco == "o");

            // Boucle principale d'exécution : affiche la matrice et effectue des mouvements de cellules
            // Ici on répète un cycle de 10 itérations avant de demander à l'utilisateur s'il veut continuer
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