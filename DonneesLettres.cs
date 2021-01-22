using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    // [Nonbre de points associés, consonne (0) ou Voyelle (1),Type de la lettre]
    // Type de la lettre 0:courante ,1: moyennement chiante, 2:assez chiante 3: très chiante.
    // Classes 
    public class DataGame
    {
        // GERE LES SCORES
        public static int scoreMotJoueur;
        public static void RazScoreMotJoueur()
        {
            scoreMotJoueur = 0;
        }
        public static void ActualiseScoreMotJoeur(int ScoreLettre)
        {
            scoreMotJoueur += ScoreLettre; // remplacer par nb point du mot
        }
        public static int ScoreTotal;
        public static void RazScoreTotal()
        {
            ScoreTotal = 0;
        }
        public static void ActualiseScoreTotal(int ScoreMot)
        {
            ScoreTotal += ScoreMot;
        }
    }
    public class Case
    {
        public Couple coordonnées;
        public Dictionary<char, Case> DictionnaireDesCasesVoisiness;
    }
    public class Couple
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class DonneesLettres
    {
        public static int ScoreMotJoueur()
        {
            return 0;
        }
        public int scoreTotal = 0;
        public static char[] voyellesCourantes = { 'A', 'E', 'I', 'O', 'U' };
        public static bool EstVoyelle(char lettre)
        {
            bool retour = false;
            for (int i = 0; i < voyellesCourantes.Length; i++)
            {
                if (voyellesCourantes[i] == lettre)
                {
                    retour = true;
                }
            }
            return retour;
        }
        public static int NbVoyelles(char[] matrice)
        {
            int cptV = 0;
            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < voyellesCourantes.Length; k++)
                {
                    if (matrice[j] == voyellesCourantes[k]) { cptV++; };
                }
            }
            return cptV;
        }

        public static readonly char[] p = { 'W', 'X', 'J', 'Q', 'V', 'K', 'Y', 'H' };
        public char[] consonnesChiantes = p;
        public static readonly char[] alphabet = new char[26];
        public static readonly int[] TabloConsonneOuVoyelle = new int[26]; //consonne (0) ou Voyelle (1)
        public static readonly int[] TabloPointsParLettre = new int[26];
        public static readonly int[] TabloDifficulte = new int[26];
        public static readonly bool[,] TabloCochage = new bool[4, 4];
        public static readonly char[,] tableauDeLettres = new char[4, 4];
        public static readonly char[] matrice = new char[16];
        public static readonly Couple caseChoisie = new Couple();
        public static readonly Couple casePrecedente = new Couple();

        public static void TourneTableauDeLettres()
        {
            char[,] TableauDeTravail = new char[4, 4];
            // Vidage du tableau
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TableauDeTravail[i, j] = '?';
                }
            }


            for (int j = 0; j < 4; j++) // From line 0 to target column 3
            {
                TableauDeTravail[j, 3] = tableauDeLettres[0, j];
            }
            
            for (int j = 0; j < 4; j++) // From column 3 to target line 3
            {
                TableauDeTravail[3 , 3-j] = tableauDeLettres[j, 3];
            }
            
              for (int j = 0; j < 4; j++) // From line 3 to target column 0
              {
                  TableauDeTravail[j, 0] = tableauDeLettres[3, j];
              }
           
            for (int j = 0; j < 4; j++) // From column 0 to target line 0
            {
                TableauDeTravail[0, 3-j] = tableauDeLettres[j, 0];
            }

            for (int j = 1; j <3 ; j++) // From column 1 to target line 1
            {
                TableauDeTravail[1, 3 - j] = tableauDeLettres[j, 1];
            }
            for (int j = 1; j < 3; j++) // From line 1 to target column2 1
            {
                TableauDeTravail[j, 2] = tableauDeLettres[1, j];
            }
            for (int j = 1; j < 3; j++) // From column 2 to target line 2
            {
                TableauDeTravail[2, 3 - j] = tableauDeLettres[j, 2];
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tableauDeLettres[i, j] = TableauDeTravail[i, j];
                }
            }

        }
        public static void AffecteConsonneOuVoyelle()
        {
            for (int i = 0; i < 26; i++)
            {
                DonneesLettres.TabloConsonneOuVoyelle[i] = 0; // Lettre courante (mis en consonne par défaut)
            }
            //voyelles*
            DonneesLettres.TabloConsonneOuVoyelle[0] = 1; //A
            DonneesLettres.TabloConsonneOuVoyelle[4] = 1; //E 
            DonneesLettres.TabloConsonneOuVoyelle[8] = 1; //I
            DonneesLettres.TabloConsonneOuVoyelle[14] = 1; //O
            DonneesLettres.TabloConsonneOuVoyelle[20] = 1; //U
            DonneesLettres.TabloConsonneOuVoyelle[24] = 1; //Y
        }
        public static void GenereAlphabet()
        {
            for (int i = 65; i < 91; i++)
            {
                DonneesLettres.alphabet[i - 65] = Convert.ToChar(i);
            }
        }
        public static void AffectePoidsDesLettres()
        {
            for (int i = 0; i < 26; i++)
            {
                DonneesLettres.TabloPointsParLettre[i] = 1; // Lettres communes
            }
            DonneesLettres.TabloPointsParLettre[5] = 4; //F
            DonneesLettres.TabloPointsParLettre[6] = 2; //G
            DonneesLettres.TabloPointsParLettre[7] = 4; //H
            DonneesLettres.TabloPointsParLettre[10] = 10; //K
            DonneesLettres.TabloPointsParLettre[11] = 2; //L
            DonneesLettres.TabloPointsParLettre[12] = 2; //M
            DonneesLettres.TabloPointsParLettre[15] = 3; //P
            DonneesLettres.TabloPointsParLettre[16] = 8; //Q
            DonneesLettres.TabloPointsParLettre[21] = 5; //V
            DonneesLettres.TabloPointsParLettre[22] = 15; //W
            DonneesLettres.TabloPointsParLettre[23] = 10; //X
            DonneesLettres.TabloPointsParLettre[24] = 8; //Y
            DonneesLettres.TabloPointsParLettre[25] = 10; //Z
        }
        public static void AffecteDidifficulteUtilisationLettre()
        {
            for (int i = 0; i < 26; i++)
            {
                DonneesLettres.TabloDifficulte[i] = 0; // Sans difficulté
            }
            for (int i = 11; i < 16; i++)
            {
                DonneesLettres.TabloDifficulte[i] = 1; // L M N O P peu de difficulté
            }
            DonneesLettres.TabloDifficulte[5] = 2; // F  difficulté moyenne
            DonneesLettres.TabloDifficulte[20] = 2;//U
            DonneesLettres.TabloDifficulte[14] = 2;//O
            DonneesLettres.TabloDifficulte[6] = 2; //G
            DonneesLettres.TabloDifficulte[7] = 3; // H difficulté prononcée
            DonneesLettres.TabloDifficulte[21] = 3;//V
            DonneesLettres.TabloDifficulte[10] = 4; // difficulté très prononcée 
            DonneesLettres.TabloDifficulte[9] = 4;  //J
            DonneesLettres.TabloDifficulte[16] = 4;//Q
            for (int i = 22; i < 26; i++) // W X Y Z
            {
                DonneesLettres.TabloDifficulte[i] = 4;
            }
        }
        public static void InitDataPourGrille()
        {
            GenereAlphabet();
            DonneesLettres.AffecteConsonneOuVoyelle();
            AffectePoidsDesLettres();
            AffecteDidifficulteUtilisationLettre();
        }
        public static void InitialiseTablocochage()
        {   // met toutes les case du tablo des cases cochées = false
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    TabloCochage[i, j] = false;
                }
            }
        }
        public static void DefinitCoupleCaseCochee(int X, int Y)
        {
            caseChoisie.X = X;
            caseChoisie.Y = Y;
        }
        public static void StockeCaseChoisie()
        {
            casePrecedente.X = caseChoisie.X;
            casePrecedente.Y = caseChoisie.Y;
        }
        public static int PlaceDansLaMatrice(char C)
        {
            int i = 0;
            while (C != DonneesLettres.alphabet[i])
            {
                i++;
                if (i > 15)
                {
                    i = -1;
                    break;
                }
            }
            return i;
        }
        public static int NbDeLaLettre(char c) // renvoi le nombre d'occurences de la lettre dans matrice ([0..15] of char
        {
            int cpt = 0;
            for (int i = 0; i < DonneesLettres.matrice.Length - 1; i++)
            {
                if (DonneesLettres.matrice[i] == c)
                {
                    cpt++;
                }
            }
            return cpt;
        }
     
    }

}
