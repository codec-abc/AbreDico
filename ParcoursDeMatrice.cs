using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    class ParcoursDeMatrice
    {
        class Case
        {
             public Couple XY { get; set; }

            readonly List<Case> Voisines = new List<Case>();             
        }


        public static void  TrouveVoisinePossible(int XdeCase, int YdeCase)
        {
            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    int coordonneeX = XdeCase + dx;
                    int coordonneeY = YdeCase + dy;
                    //   MessageBox.Show("=>  "+coordonneeX.ToString() + " , " + coordonneeY.ToString()+ " X="+X.ToString()+" Y="+Y.ToString());
                    if ((coordonneeX == XdeCase) && (coordonneeY == YdeCase)) // si coordonée différentes de la case d'appel
                    {
                        //   MessageBox.Show(coordonneeX.ToString() + " , " + coordonneeY.ToString() + " case d'appel");
                    }
                    else
                    {
                        if (coordonneeX >= 0 && coordonneeX < 4 && coordonneeY >= 0 && coordonneeY < 4)
                        {
                            //   MessageBox.Show(coordonneeX.ToString() + " , " + coordonneeY.ToString() + " voisine acceptable");
                        }
                        else
                        {
                            //   MessageBox.Show(coordonneeX.ToString() + " , " + coordonneeY.ToString() + " voisine PAS acceptable");
                        }
                    }
                }
            }
        }
    }
}
