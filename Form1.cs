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
        // Variables globales
        String chaine = "";
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



        public void VerifAjoutLettre(Noeud NP, int rang, string Word)  //Création de l'arbre 
        {   
            if (Word.Length==0) { return; } // n'effectue pas le traitement pour un mot vide
            char l;
            l = Word[rang];                       
            if (NP.DictionnaireDesSousNoeuds == null)
            {   // si le dico n'existe pas on en crée un vierge
                NP.DictionnaireDesSousNoeuds = new Dictionary<char, Noeud>();
            }
            if (NP.DictionnaireDesSousNoeuds.ContainsKey(l))//le dico existe et  si la clé existe
            {
                foreach (KeyValuePair<char, Noeud> cle in NP.DictionnaireDesSousNoeuds)
                {  // on cherche la clé (lettre)
                    if (cle.Key == l) // clé identifiée 
                    {
                        rang++; //(pour lettre suivante du mot)
                        if (rang < Word.Length ) //-1 viré
                        { // si le traitement du mot n'est pas fini on appelle récursivement la procédure 
                          // en passant le noeud courant le rang incrémenté et le mot en paramètre.
                           // MessageBox.Show("Le dico du noeud père contient " + l + "du mot " + Word + " On cherche " + Word[rang]);
                            VerifAjoutLettre(cle.Value, rang, Word);
                        }
                    }
                }
            }
            else
            {
                //le dico existe et  clé pas trouvée => ajout noeud dans dico
                Noeud NE = new Noeud();
                NE.Lettre = l;
                if (rang == Word.Length - 1)
                {   // dernière lettre du mot  : On ajoute le noeud correspondant
                    NE.FinDeMot = true;
                    NP.DictionnaireDesSousNoeuds.Add(l, NE);
                  //  MessageBox.Show(l+" Dernière lettre du mot "+Word+" => sortie à l'arrache");
                    return;
                }
                else
                {   // PAS dernière lettre du mot  : On ajoute le noeud correspondant et on incémente rang et on relance récursivement la procédure
                    NE.FinDeMot = false;
                    NP.DictionnaireDesSousNoeuds.Add(l, NE);
                   // MessageBox.Show(l + " Pas dernière lettre du mot " + Word + " => ajout noeud");
                    rang++;
                    VerifAjoutLettre(NE, rang, Word);
                }
            }
        }

        private void DecodeArbre(Noeud NP) // Lecture des mots
        {          
            if (NP.DictionnaireDesSousNoeuds != null)
            {   // dictionnaire du noeud existe              
                foreach (KeyValuePair<char, Noeud> cle in NP.DictionnaireDesSousNoeuds)
                {
                   // MessageBox.Show(NP.Lettre + " Valeur Dico " + cle.Key);
                    if (cle.Value.DictionnaireDesSousNoeuds == null)
                    { // n'a pas d'enfant                                
                        chaine = chaine + cle.Value.Lettre;
                        this.listBox1.Items.Add(chaine);
                        chaine = "";
                    }
                    else
                    { // a des enfants                    
                        chaine = chaine + cle.Value.Lettre;
                        if (cle.Value.FinDeMot) { this.listBox1.Items.Add(chaine); }
                        DecodeArbre(cle.Value);
                    }                  
                }
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
                    // MessageBox.Show(mot);
                    // Création de la branche correspondant au mot par passage du noeud racine à la prcédure récussive VerifAjouteLettre                     
                    VerifAjoutLettre(Racine, 0, mot);
                }
                // lecture de l'arbre
                this.listBox1.Items.Clear();
                DecodeArbre(Racine);
            }
        }
    }
}



