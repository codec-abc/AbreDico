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
        Color CouleurDefaut = Color.FromName("DarkMagenta");
        Color CouleurDeSelection = Color.FromName("Red");
        char[] matrice = new char[16];
        char[] voyellesCourantes = { 'A', 'E', 'I', 'O', 'U' };
        char[] consonnesChiantes = { 'W', 'X', 'J', 'Q', 'V', 'K', 'Y' };
        string motJoueur="";
        string[] suiteLabelJoueur = new string[16];
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
        /// 
      

        bool estVoyelle( char lettre)
        {
            bool retour = false;
            for (int i = 0; i < voyellesCourantes.Length; i++)
            {
                if ( voyellesCourantes[i] ==lettre)
                {
                    retour = true;
                }
            }
            return retour;
        }
        bool estConsoleChiante(char lettre)
        {
            bool retour = false;
            for (int i = 0; i < consonnesChiantes.Length; i++)
            {
                if (consonnesChiantes[i] == lettre)
                {
                    retour = true;
                }
            }
            return retour;
        }
        public void creerNouvelleMatrice()
        {           
            var rand = new Random();
            for (int i = 0; i < 16; i++)
            {
                int a = rand.Next(65, 90);                
                matrice[i]= Convert.ToChar(a);
            }
            // comptage des voyelles
            int cptV = 0;
            for (int j = 0; j < 16; j++)
            {                
                for ( int k=0; k<voyellesCourantes.Length; k++)
                {
                    if(matrice[j]==voyellesCourantes[k]) { cptV++; };
                }               
            }
            // ajout de voyelles si  nombre de voyelles courantes inférieure à 6
            if (cptV<6)
            {
                for (int l=cptV; l<=6;l++) 
                {
                    int b = rand.Next(0, voyellesCourantes.Length-1);
                    int a= rand.Next(0, matrice.Length-1);
                    do
                    {  // cherche une case différent de voyelle
                         a = rand.Next(0, matrice.Length - 1);
                    } while (estVoyelle(matrice[a]));
                    matrice[a] = voyellesCourantes[b]; // remplacement par une voyelle
                }
            }
            // vire le trop plein de consoles chiantes Maxi 1
            int cptCchiante = 0;
            for (int j = 0; j < 16; j++) // compte le nombre de consoles chiantes
            {
                for (int k = 0; k < consonnesChiantes.Length; k++)
                {
                    if (matrice[j] == consonnesChiantes[k]) { cptCchiante++; };
                }
            }
            if(cptCchiante>1)
            {// échange les consonnes chiantes par des voyelles
                //MessageBox.Show(cptCchiante.ToString());
                int compteur = 0;
                for (int i = 0; i< matrice.Length - 1;i++)
                {
                   if (estConsoleChiante( matrice[i]) && compteur<cptCchiante-1)
                    { // remplace la consonne chiante par une voyelle
                        int b = rand.Next(0, voyellesCourantes.Length - 1);
                        matrice[i] = voyellesCourantes[b];
                    }
                }
            }

            dessineMatrice();
        }
        public void dessineMatrice()
        {
            int j = 0;
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    c.ForeColor = CouleurDefaut;
                    c.Text = matrice[j].ToString();
                    c.Width = 40;
                    j++;                 
                }
            }
        }

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

        private void Init()  // initialisation des données
        {
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
                CreationArbreDico(lignesDico);
                this.pictureBox1.Left += 50;
                this.pictureBox1.Visible = false;
            }
        }

        private void CreationArbreDico(string[] lignesDico)
        {
            //création de la racine
            Noeud racine = new Noeud();
            racine.Lettre = ' ';
            racine.FinDeMot = false;
            racine.DictionnaireDesSousNoeuds = null;
            // traitement des mots               
            for (int i = 0; i <= lignesDico.Length - 1; i++)  // traitement des lettres du mot
            {
                string mot = lignesDico[i];
                //  this.listBox2.Items.Add(mot);
                //  MessageBox.Show(mot);
                // Création de la branche correspondant au mot par passage du noeud racine à la prcédure récussive VerifAjouteLettre                     
                AjoutLettreCouranteSiBesoin(racine, 0, mot);
            }
            this.NoeudRacine = racine; // affecte à NoeudRacine accessible partout dans form1 la valeur du pointeur de Racine
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

        bool VerifMot(string Mot)
        {
            int lg = Mot.Length;
            Noeud noeudCourant = NoeudRacine;
            for (int i = 0; i < lg; i++) // Faire pour toutes les lettres du mot
            {
                char lettreCourante = Mot[i];
                if (noeudCourant.DictionnaireDesSousNoeuds != null) // le Dictionnaire du noeud examiné n'est pas null
                {
                    if (noeudCourant.DictionnaireDesSousNoeuds.ContainsKey(lettreCourante))// contient la lettre du mot
                    {
                        noeudCourant = noeudCourant.DictionnaireDesSousNoeuds[lettreCourante]; // affectation du noeud trouvé pour le tour de boucle suivant                           
                    }
                    else
                    {  // la lettre n'est pas trouvée !
                        return false;
                    }
                }
                else
                { 
                    //le dictionnaire est null
                    if (i != lg)
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
          //  textBox1.Text = t.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer1.Start();
            creerNouvelleMatrice();
            initialiseSuiteJoueur();
        }
     
        private void L1_Click(object sender, EventArgs e)
        {         
            if (L1.ForeColor == CouleurDeSelection)
            { L1.ForeColor = CouleurDefaut; }
            else { L1.ForeColor = CouleurDeSelection; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            creerNouvelleMatrice();
            initialiseSuiteJoueur();
        }

        private void L1_MouseUp(object sender, MouseEventArgs e)
        {   
          


        }
        //===============================  GESTION DU SURVOL DES LETTRES ==============================
        private void L1_MouseHover(object sender, EventArgs e)
        {           
            if (L1.ForeColor == CouleurDeSelection)
            { L1.ForeColor = CouleurDefaut; }
            else { L1.ForeColor = CouleurDeSelection; actualiseSuiteLabelJoueur("L1"); }         
        }

        private void L2_MouseHover(object sender, EventArgs e)
        {
            if (L2.ForeColor == CouleurDeSelection)
            { L2.ForeColor = CouleurDefaut; }
            else { L2.ForeColor = CouleurDeSelection; actualiseSuiteLabelJoueur("L2"); }
        }

        private void L3_MouseHover(object sender, EventArgs e)
        {
            if (L3.ForeColor == CouleurDeSelection)
            { L3.ForeColor = CouleurDefaut; }
            else { L3.ForeColor = CouleurDeSelection; }
        }
        //================================================================================================
        private void initialiseSuiteJoueur()
        {
            for (int i=0; i<suiteLabelJoueur.Length-1;i++)
            {
                suiteLabelJoueur[i] = "";
            }
        }
        private void actualiseSuiteLabelJoueur(string lab)
        {
            int Max = 0;         
          for (int cpt=0; cpt<suiteLabelJoueur.Length;cpt++)
            {
                if (suiteLabelJoueur[cpt]=="")
                {
                    Max = cpt;
                    break;
                }
            }
            suiteLabelJoueur[Max] = lab; // ajoute la case cochée dans les tableau de suivi
            // Ici on doit vérifier 
            // 1- si la case a déja été utilisée
            // 2- si elle est voisine
            // 3 - Si c'est la précédente on ne doit pas compter la derniere lettre (décrémentation
        }
    }
       
    
}



