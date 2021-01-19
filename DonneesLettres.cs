using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    class DonneesLettres
    {
      public static  char[] voyellesCourantes = { 'A', 'E', 'I', 'O', 'U' };
       public static  bool estVoyelle(char lettre)
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
       public static int nbVoyelles(char[] matrice )
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
    }
}
