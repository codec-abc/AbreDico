using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    public class Noeud
    {
        public char Lettre { get; set; }
        public bool FinDeMot { get; set; }
        public Dictionary<char, Noeud> DictionnaireDesSousNoeuds;
    }
    public class GestionDesNoeuds
    {
       public static Noeud CreationArbreDico(string[] lignesDico)
        {
            //création de la racine
            Noeud racine = new Noeud
            {
                Lettre = ' ',
                FinDeMot = false,
                DictionnaireDesSousNoeuds = null
            };
            // traitement des mots               
            for (int i = 0; i <= lignesDico.Length - 1; i++)  // traitement des lettres du mot
            {
                string mot = lignesDico[i];
                //  this.listBox2.Items.Add(mot);
                //  MessageBox.Show(mot);
                // Création de la branche correspondant au mot par passage du noeud racine à la prcédure récussive VerifAjouteLettre                     
                AjoutLettreCouranteSiBesoin(racine, 0, mot);
            }
            return  racine; // affecte à NoeudRacine accessible partout dans form1 la valeur du pointeur de Racine
        }
        public static void AjoutLettreCouranteSiBesoin(Noeud noeudParent, int indexLettreCourante, string Word)  //Création de l'arbre 
        {
            if (Word.Length == 0)
            {
                return;
            } // n'effectue pas le traitement pour un mot vide
            char lettreCourante = Word[indexLettreCourante];
            if (noeudParent.DictionnaireDesSousNoeuds == null)
            {   // si le dico n'existe pas on en crée un vierge
                noeudParent.DictionnaireDesSousNoeuds = new Dictionary<char, Noeud>();
            }
            if (noeudParent.DictionnaireDesSousNoeuds.ContainsKey(lettreCourante))//le dico existe et  si la clé existe
            {
                foreach (KeyValuePair<char, Noeud> cle in noeudParent.DictionnaireDesSousNoeuds)
                {  // on cherche la clé (lettre)
                    if (cle.Key == lettreCourante) // clé identifiée 
                    {
                        indexLettreCourante++; //(pour lettre suivante du mot)
                        if (indexLettreCourante < Word.Length) //-1 viré
                        { // si le traitement du mot n'est pas fini on appelle récursivement la procédure 
                          // en passant le noeud courant le rang incrémenté et le mot en paramètre.
                          // MessageBox.Show("Le dico du noeud père contient " + l + "du mot " + Word + " On cherche " + Word[rang]);
                            AjoutLettreCouranteSiBesoin(cle.Value, indexLettreCourante, Word);
                        }
                    }
                }
            }
            else
            {
                //le dico existe et  clé pas trouvée => ajout noeud dans dico
                Noeud noeudEnfant = new Noeud
                {
                    Lettre = lettreCourante
                };
                if (indexLettreCourante == Word.Length - 1)
                {   // dernière lettre du mot  : On ajoute le noeud correspondant
                    noeudEnfant.FinDeMot = true;
                    noeudParent.DictionnaireDesSousNoeuds.Add(lettreCourante, noeudEnfant);
                    //  MessageBox.Show(l+" Dernière lettre du mot "+Word+" => sortie à l'arrache");
                    return;
                }
                else
                {   // PAS dernière lettre du mot  : On ajoute le noeud correspondant et on incémente rang et on relance récursivement la procédure
                    noeudEnfant.FinDeMot = false;
                    noeudParent.DictionnaireDesSousNoeuds.Add(lettreCourante, noeudEnfant);
                    // MessageBox.Show(l + " Pas dernière lettre du mot " + Word + " => ajout noeud");
                    indexLettreCourante++;
                    AjoutLettreCouranteSiBesoin(noeudEnfant, indexLettreCourante, Word);
                }
            }
        }


    }

}
