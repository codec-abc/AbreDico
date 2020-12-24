using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbreDico
{
    /* Choix : l'abre est représenté par une liste de noeud
     * Le noeud est une classe qui comprend
     * - Un caractère : la donnée
     * - un booléen indiquant si cette lettre constitue la fin d'un mot
     * - une liste de noeuds désignant les noeuds enfants
     * */


    public partial class Form1 : Form
    {    //=================================================================

        //=================================================================

        public class Noeud
        {
            public char Lettre { get; set; }
            public bool FinDeMot { get; set; }
            public Dictionary<char, Noeud> DictionnaireDesSousNoeuds;
        }


        public Form1()
        {
            InitializeComponent();
        }

        public void AjouteNoeud(Noeud NoeudParent, Noeud NoeudEnfant, char l)
        // Ajoute un noeud dans le dictionnaire parent
        {
            if (NoeudParent.DictionnaireDesSousNoeuds == null)
            {
                NoeudParent.DictionnaireDesSousNoeuds = new Dictionary<char, Noeud>();
            }
            NoeudParent.DictionnaireDesSousNoeuds.Add(l, NoeudEnfant);
        }

        public void VerifAjoutLettre(Noeud NP, int rang, string Word)
        {
            char l;
            l = Word[rang];
            int lg = Word.Length;
            if (NP.DictionnaireDesSousNoeuds == null)
            {
                NP.DictionnaireDesSousNoeuds = new Dictionary<char, Noeud>();
            }
            if (NP.DictionnaireDesSousNoeuds.ContainsKey(l))// clé existe
            {
                foreach (KeyValuePair<char, Noeud> cle in NP.DictionnaireDesSousNoeuds)
                {
                    if (cle.Key == l) // clé identifiée
                    {
                        rang++;
                        if (rang < Word.Length - 1)
                        {
                            VerifAjoutLettre(cle.Value, rang, Word);
                        }
                    }
                }
            }
            else
            {
                // clé pas trouvée => ajout noeud dans dico
                Noeud NE = new Noeud();
                NE.Lettre = l;
                if (rang == Word.Length - 1)
                {
                    NE.FinDeMot = true;
                }
                else
                {
                    NE.FinDeMot = false;
                }
                NP.DictionnaireDesSousNoeuds.Add(l, NE);
            }
        }

        private void BtCreateTree_Click(object sender, EventArgs e)
        {
            string mot;
            // Création de l'arbre à partir du fichier texte.
            //========================
            // initialisation du dictionnaire
            string NomDuDico = "H:\\Famille\\GERALD\\visual_Studio\\Arbre_Dico\\fichierTest.txt";
            if (!File.Exists(NomDuDico))
            {
                MessageBox.Show(NomDuDico + " n'existe pas");
            }
            else
            {
                // le fichier existe : Lecture
                string[] lignesDico = System.IO.File.ReadAllLines(NomDuDico);
                // Traitement des données==========
                //création de la racine
                Noeud Racine = new Noeud();
                Racine.Lettre = ' ';
                Racine.FinDeMot = false;
                Racine.DictionnaireDesSousNoeuds = null;
                // traitement des mots
                for (int i = 0; i <= lignesDico.Length - 1; i++)  // traitement des lettres du mot
                {
                    mot = lignesDico[i];
                    // première lettre sous la racine                        
                    VerifAjoutLettre(Racine, 0, mot);       // la procédure doit s'appeler récursivement 
                                                            //pour finir la construction de l'arbre pour ce mot                                       
                    MessageBox.Show(mot);
                }
            }

        }
    }
}



