using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    class DonneesLettres
    {
        public readonly bool[,] TabloCochage = new bool[4, 4];
        public readonly char[,] tableauDeLettres = new char[4, 4];
        public readonly char[] TabloListeDesCaracteres = new char[16];
        public readonly Point2D caseChoisie = new Point2D();
        public readonly Point2D casePrecedente = new Point2D();

        private GameRules rules = new GameRules();

        public int PlaceDansLaMatrice(char c)
        {
            int i = 0;
            while (c != rules.GetLetters()[i])
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

        public int NbDeLaLettreDansMatrice(char c) // renvoi le nombre d'occurences de la lettre dans matrice ([0..15] of char
        {
            int cpt = 0;
            for (int i = 0; i < TabloListeDesCaracteres.Length - 1; i++)
            {
                if (TabloListeDesCaracteres[i] == c)
                {
                    cpt++;
                }
            }
            return cpt;
        }

        public void TourneTableauDeLettres()
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
                TableauDeTravail[3, 3 - j] = tableauDeLettres[j, 3];
            }

            for (int j = 0; j < 4; j++) // From line 3 to target column 0
            {
                TableauDeTravail[j, 0] = tableauDeLettres[3, j];
            }

            for (int j = 0; j < 4; j++) // From column 0 to target line 0
            {
                TableauDeTravail[0, 3 - j] = tableauDeLettres[j, 0];
            }

            for (int j = 1; j < 3; j++) // From column 1 to target line 1
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

        public void InitialiseTabloCochage()
        {   // met toutes les case du tablo des cases cochées = false
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    TabloCochage[i, j] = false;
                }
            }
        }

        public void DefinitCoupleCaseCochee(int X, int Y)
        {
            caseChoisie.X = X;
            caseChoisie.Y = Y;
        }

        public void StockeCaseChoisie()
        {
            casePrecedente.X = caseChoisie.X;
            casePrecedente.Y = caseChoisie.Y;
        }

    }

}
