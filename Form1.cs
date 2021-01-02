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
    /* Choix : l'abre est représenté par une liste de noeuds
     * Le noeud est une classe qui comprend
     * - Un caractère : la donnée
     * - un booléen indiquant si cette lettre constitue la fin d'un mot
     * - une liste de noeuds désignant les noeuds enfants
     * */


    public partial class Form1 : Form
    {
        //=================================================================             
        public Noeud NoeudRacine { get; private set; }
        // crée une variable d'instance à laquelle on affectera le noeud racine (passage du pointeur) 
        //pour en disposer dans Form1

        private static readonly string MotResultatNom = "MOTSRESULTAT.txt";
        
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

        /// <summary>
        /// Cette methode ajoute la lettre a l index courant au noeud Parent.
        /// </summary>
        /// <param name="noeudParent">Noeud auquel sera rajoute la lettre si elle n existe pas</param>
        /// <param name="indexLettreCourante">Index de la lettre a rajouter si besoi de la string Word.</param>
        /// <param name="Word">Mot de travail</param>
        public void AjoutLettreCouranteSiBesoin(Noeud noeudParent, int indexLettreCourante, string Word)  //Création de l'arbre 
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
                Noeud noeudEnfant = new Noeud();
                noeudEnfant.Lettre = lettreCourante;
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

        //private void DecodeArbre(Noeud NP) // Lecture des mots
        //{
        //    StreamWriter sw2 = new StreamWriter(MotResultatNom);
        //    try
        //    {
        //        if (NP.DictionnaireDesSousNoeuds != null)
        //        {   // dictionnaire du noeud existe              
        //            foreach (KeyValuePair<char, Noeud> cle in NP.DictionnaireDesSousNoeuds)
        //            {
        //                if (cle.Value.DictionnaireDesSousNoeuds == null)
        //                { // n'a pas d'enfant             
        //                    sw2.WriteLine(cle.Value.Lettre);
        //                    //  this.listBox1.Items.Add(cle.Value.Lettre+".");                   
        //                }
        //                else
        //                { // a des enfants                                          
        //                    if (cle.Value.FinDeMot)
        //                    {
        //                        sw2.WriteLine(cle.Value.Lettre);
        //                        //  this.listBox1.Items.Add(cle.Value.Lettre + "=>");
        //                    }
        //                    else
        //                    {
        //                        sw2.WriteLine(cle.Value.Lettre);
        //                        // this.listBox1.Items.Add(cle.Value.Lettre + "=> ...");
        //                    }
        //                    DecodeArbre(cle.Value);
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        sw2.Close();
        //    }
        //}

        private void Init()  // initialisation des données
        {
            string mot;
            this.pictureBox1.Visible = true;
            // Création de l'arbre à partir du fichier texte.
            //===================
            // initialisation du dictionnaire
            string NomDuDico = "H:\\Famille\\GERALD\\visual_Studio\\Arbre_Dico\\MOTS TRADUITS.txt";
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
                    //  this.listBox2.Items.Add(mot);
                    //  MessageBox.Show(mot);
                    // Création de la branche correspondant au mot par passage du noeud racine à la prcédure récussive VerifAjouteLettre                     
                    AjoutLettreCouranteSiBesoin(Racine, 0, mot);
                }
                // lecture de l'arbre                             
                //DecodeArbre(Racine);
                this.pictureBox1.Left += 50;
                this.NoeudRacine = Racine; // affecte à NoeudRacine accessible partout dans form1 la valeur du pointeur de Racine
                this.pictureBox1.Visible = false;
            }
        }

        private void BtVerifMot(object sender, EventArgs e)
        {
            VerifMot();
        }

        private void VerifMot()
        {
            timer1.Stop();
            this.pictureBox1.Visible = false;
            string msg;
            if (VerifMot(this.textBox1.Text.ToUpper()))
            {
                this.ImageGai.Visible = true;
                msg = "Le mot existe";
            }
            else
            {
                this.ImageTriste.Visible = true;
                msg = "Le mot n'existe PAS";
            }
            MessageBox.Show(msg);
        }

        public Noeud Nt2;

        bool VerifMot(string Mot)
        {
            int lg = Mot.Length - 1;
            Noeud Nt = NoeudRacine;
            for (int i = 0; i <= lg; i++) // Faire pour toutes les lettres du mot
            {
                char c = Mot[i];
                if (Nt.DictionnaireDesSousNoeuds != null) // le Dictionnaire du noeud examiné n'est pas null
                {
                    if (Nt.DictionnaireDesSousNoeuds.ContainsKey(c))// contient la lettre du mot
                    {
                        foreach (KeyValuePair<char, Noeud> cle in Nt.DictionnaireDesSousNoeuds)
                        {
                            if (cle.Key == c) // clé identifièe (pour noeud suivant)
                            {
                                Nt2 = cle.Value;
                            }
                        }
                        Nt = Nt2; // affectation du noeud trouvé pour le tour de boucle suivant                           
                    }
                    else
                    {  // la lettre n'est pas trouvée !
                        Nt2 = null;
                        return false;
                    }
                }
                else
                { //le dictionnaire est null
                    if (i != lg + 1)
                    { 
                        return false; 
                    } // si ce n'est pas la fin de mot c'est anormal on retourne false
                    else
                    {
                        return true;
                    }// si fin de mot c'est normal on retourne true
                }
            }
            // pour satisfaire le compilo
            return true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Init();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            this.ImageGai.Visible = false;
            this.ImageTriste.Visible = false;
        }

        int t = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
             t++;
            textBox1.Text = t.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}



