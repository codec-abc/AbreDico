using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{

    public class ParcoursDeMatrice
    {
        public class Case
        {
            public Couple XY = new Couple();
            public List<Case> ListeDesVoisines = new List<Case>();
        }

        public static void TouverVoisinesAcceptables(Case CaseDeTravail)
        {
            // cette procedure trouve les cases voisine de celle passée en pramètre
            // Créer des instance de Case pour chacune 
            //et les ajoute dans la liste des cases voisine de la case passée en pramètre
            int XdeCase = CaseDeTravail.XY.X;
            int YdeCase = CaseDeTravail.XY.Y;
            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    int CoordonneeX = XdeCase + dx;
                    int CoordonneeY = YdeCase + dy;
                    if ((CoordonneeX == XdeCase) && (CoordonneeY == YdeCase))
                    {
                        //On ne fait rien car les coordonnées sont celles de la case d'appel
                    }
                    else
                    {
                        if (CoordonneeX >= 0 && CoordonneeX < 4 && CoordonneeY >= 0 && CoordonneeY < 4)
                        {
                            // on traite car les coordonnées sont acceptables
                            if (TabloUtilisationCase[CoordonneeX, CoordonneeY])
                            {
                                // La  case est déjà utilisée : on ne fait rien
                            }
                            else
                            {
                                // La case est libre donc utilisable donc
                                // on crée un Case de coordonnées courantes qu'on ajoute à la liste des cases voisines
                                Case CaseVoisine = new Case();
                                CaseVoisine.XY.X = CoordonneeX;
                                CaseVoisine.XY.Y = CoordonneeY;
                                CaseDeTravail.ListeDesVoisines.Add(CaseVoisine);
                                Test += "V> " + LettreDeLaCase(CaseVoisine) + "\r\n";
                            }
                        }
                        else
                        {
                            // on ne fait rien car au moins une des coordonnées est hors limites
                        }
                    }
                }
            }
            Test += "------" + "\r\n";
        }

        public static bool[,] TabloUtilisationCase = new bool[4, 4];
        public static void InitialiseTabloUtilisationCase()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TabloUtilisationCase[i, j] = false;
                }
            }
        }


        public static int ProfondeurDeRecherche = 0;
        
        public static char[] WordGrid = new char[30];
        public static void AfficheWordGrid()
        {
            String t2="";
            for (int i=0; i==ProfondeurDeRecherche;i++)
            {
                t2 += WordGrid[i];
            }
            Test += t2;
        }

        public static void CrerCaseRacine(int X, int Y)
        {
            ProfondeurDeRecherche = 0;
            ParcoursDeMatrice.InitialiseTabloUtilisationCase();
            ParcoursDeMatrice.Case CaseRacine = new ParcoursDeMatrice.Case();
            CaseRacine.XY.X = X;
            CaseRacine.XY.Y = Y;
            ParcoursDeMatrice.TabloUtilisationCase[CaseRacine.XY.X, CaseRacine.XY.Y] = true;
                Test += LettreDeLaCase(CaseRacine)+"\r\n";
            WordGrid[ProfondeurDeRecherche] = LettreDeLaCase(CaseRacine);
            ParcoursDeMatrice.TouverVoisinesAcceptables(CaseRacine);
            int MaxList = CaseRacine.ListeDesVoisines.Count;
            ProfondeurDeRecherche++;           

            if (CaseRacine.ListeDesVoisines.Count >= 0)
            { // Si la liste des cases voisines n'est pas vide                                          
                ExploreCombinaisons(CaseRacine.ListeDesVoisines[0], CaseRacine);
            }          
          
        }
        public static int CompteurGeneral = 2;
        public static void ExploreCombinaisons(ParcoursDeMatrice.Case CaseCourante, ParcoursDeMatrice.Case CaseAppelante)
        {
            CompteurGeneral++;
            ParcoursDeMatrice.TouverVoisinesAcceptables(CaseCourante);          
            if (CaseCourante.ListeDesVoisines.Count == 0)
            {
                //si la liste des voisines de la case courante est vide
                //on  supprime référence à la case courante dans la listes des cases voisines de la case appelante
                CaseAppelante.ListeDesVoisines.RemoveAt(0);               
                ParcoursDeMatrice.TabloUtilisationCase[CaseCourante.XY.X, CaseCourante.XY.Y] = false;
                ProfondeurDeRecherche--;                
            }
            else
            { // La liste des cases voisines de la case courante n'est pas vide
                ParcoursDeMatrice.TabloUtilisationCase[CaseCourante.XY.X, CaseCourante.XY.Y] = true;             
              //  ParcoursDeMatrice.WordGrid[ProfondeurDeRecherche] = LettreDeLaCase(CaseCourante);
                ProfondeurDeRecherche++;              
                ExploreCombinaisons(CaseCourante.ListeDesVoisines[0], CaseCourante);
            }
        }
        public static string Test = ""; // 2 variables à détruire quand le fonctionnement sera OK
      
        //#####################################################################################################
       // La logique effectue bien une descente de 16 Cases mais n'effectue pas les bifurcation à la remontée!
        //#####################################################################################################
       
        public static char LettreDeLaCase(Case UneCase )
        {
            return DonneesLettres.tableauDeLettres[UneCase.XY.X, UneCase.XY.Y];
        }
       

       

    }
}
