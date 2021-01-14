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

        //  private static readonly string MotResultatNom = "MOTSRESULTAT.txt";
        Color CouleurDefaut = Color.FromName("Navy");
        Color CouleurDeSelection = Color.FromName("Red");
        char[] matrice = new char[16];
        char[] voyellesCourantes = { 'A', 'E', 'I', 'O', 'U' };
        char[] consonnesChiantes = { 'W', 'X', 'J', 'Q', 'V', 'K', 'Y', 'H' };
        char[] alphabet = new char[26];
        int[] TabloConsonneOuVoyelle = new int[26]; //consonne (0) ou Voyelle (1)
        int[] TabloPointsParLettre = new int[26];
        int[] TabloDifficulte = new int[26];
        // [Nonbre de points associés, consonne (0) ou Voyelle (1),Type de la lettre]
        // Type de la lettre 0:courante ,1: moyennement chiante, 2:assez chiante 3: très chiante.

        string motJoueur = "";
        string[] suiteLabelJoueur = new string[16];
        char[,] tableauDeLettres = new char[4, 4];
        //=================================================================
        void genereAlphabet()
        {
            for (int i = 65; i < 91; i++)
            {
                alphabet[i - 65] = Convert.ToChar(i);
            }
        }

        private void debog()
        {
            genereAlphabet();
            affecteConsonneOuVoyelle();
            affecteDidifficulteUtilisationLettre();
            affectePoidsDesLettres();
            string ch = "", s = "";
            this.textBox2.Clear();
            for (int i = 0; i < 26; i++)
            {
                ch = i.ToString() + " " + alphabet[i].ToString();
                if (TabloConsonneOuVoyelle[i] == 0) { s = " cons "; } else { s = " voyL "; }
                s = s + " dif: " + TabloDifficulte[i] + " points : " + TabloPointsParLettre[i] + "\r\n";
                this.textBox2.Text = this.textBox2.Text + ch + s;
            }
        }
        public void affecteConsonneOuVoyelle()
        {
            for (int i = 0; i < 26; i++)
            {
                TabloConsonneOuVoyelle[i] = 0; // Lettre courante (mis en consonne par défaut)
            }
            //voyelles*
            TabloConsonneOuVoyelle[0] = 1; //A
            TabloConsonneOuVoyelle[4] = 1; //E 
            TabloConsonneOuVoyelle[8] = 1; //I
            TabloConsonneOuVoyelle[14] = 1; //O
            TabloConsonneOuVoyelle[20] = 1; //U
            TabloConsonneOuVoyelle[24] = 1; //Y
        }
        public void affectePoidsDesLettres()
        {
            for (int i = 0; i < 26; i++)
            {
                TabloPointsParLettre[i] = 1; // Lettres communes
            }
            TabloPointsParLettre[5] = 4; //F
            TabloPointsParLettre[6] = 2; //G
            TabloPointsParLettre[7] = 4; //H
            TabloPointsParLettre[10] = 10; //K
            TabloPointsParLettre[11] = 2; //L
            TabloPointsParLettre[12] = 2; //M
            TabloPointsParLettre[15] = 3; //P
            TabloPointsParLettre[16] = 8; //Q
            TabloPointsParLettre[21] = 5; //V
            TabloPointsParLettre[22] = 15; //W
            TabloPointsParLettre[23] = 10; //X
            TabloPointsParLettre[24] = 8; //Y
            TabloPointsParLettre[25] = 10; //Z
        }
        public void affecteDidifficulteUtilisationLettre()
        {
            for (int i = 0; i < 26; i++)
            {
                TabloDifficulte[i] = 0; // Sans difficulté
            }
            for (int i = 11; i < 16; i++)
            {
                TabloDifficulte[i] = 1; // L M N O P peu de difficulté
            }
            TabloDifficulte[5] = 2; // F  difficulté moyenne
            TabloDifficulte[20] = 2;//U
            TabloDifficulte[14] = 2;//O
            TabloDifficulte[6] = 2; //G
            TabloDifficulte[7] = 3; // H difficulté prononcée
            TabloDifficulte[21] = 3;//V
            TabloDifficulte[10] = 4; // difficulté très prononcée 
            TabloDifficulte[9] = 4;  //J
            TabloDifficulte[16] = 4;//Q
            for (int i = 22; i < 26; i++) // W X Y Z
            {
                TabloDifficulte[i] = 4;
            }
        }

        int placeDansLaMatrice(char C)
        {
            int i = 0;
            while (C != alphabet[i])
            {
                i++;
                if (i > 15)
                {
                    i = -1;
                    break;
                }
            }
            //   MessageBox.Show("place de " + C + " dans la matrice : " + i);
            return i;
        }
        public void creerMatrice() // Génère aléatoirement des lettres qui sont mises dans le tableau"matrice"
        {
            int cptVoyelle = 0;
            int voyelleDeSuite = 0;
            int consonneDeSuite = 0;
            int noteDeChiant = 0;
            int difficulteLettre;
            int maxVoyelle = 6;
            bool estUneVoyelle;
            bool accord = true;
            char lettre, lettrePrecedente = ' ';
            var rand = new Random();
            // remplit un tableau [0..15] d'un caractère aléatoire
            int i = 0;
            this.textBox2.Clear();
            while (i < 16)
            {
                int a = rand.Next(0, 25);
                lettre = alphabet[a];
                if (i>0)
                {
                    if (lettre!=matrice[i-1])
                    { accord = true; }
                    else { accord = false; }
                }
                if ( accord)
                {
                    this.textBox2.Text = this.textBox2.Text + lettre.ToString() + " TIRE = " + nbDeLaLettre(lettre).ToString() + " fois \r\n";
                    difficulteLettre = TabloDifficulte[a];
                    if (TabloConsonneOuVoyelle[a] == 1) // détermine si le caractère est ou non une voyelle
                    {
                        estUneVoyelle = true;
                    }
                    else
                    {
                        estUneVoyelle = false;
                    }
                    if (estUneVoyelle && voyelleDeSuite < 3)
                    { // Tirage d'une voyelle                  
                        if (cptVoyelle <= maxVoyelle) // nombre de voyelles tirées inférieur au maximaum autorisé            
                        {  // cas autorisé
                            if (difficulteLettre > 0) // si tirage voyelle difficile
                            {
                                if (placeDansLaMatrice(lettre) == -1 && noteDeChiant <= 4)
                                {
                                    //difficile pas en double
                                    matrice[i] = lettre;
                                    noteDeChiant = noteDeChiant + TabloDifficulte[i];
                                    cptVoyelle++; i++;
                                    voyelleDeSuite++;
                                    consonneDeSuite = 0;
                                    this.textBox2.Text = this.textBox2.Text + "Voyelle difficile Ajoutée = " + lettre.ToString() + "\r\n";
                                }
                            }
                            else
                            {
                                // voyelle facile
                                matrice[i] = lettre;
                                voyelleDeSuite++;
                                consonneDeSuite = 0;
                                this.textBox2.Text = this.textBox2.Text + "Voyelle facile Ajoutée = " + lettre.ToString() + "\r\n";
                            }
                        }
                    }
                    else
                    {// tirage d'une consonne
                        if (consonneDeSuite <= 2) // et pas trop de consonnnes d'affilé
                        {
                            if (difficulteLettre < 2) // facile 
                            {
                                if ((difficulteLettre == 2 && placeDansLaMatrice(lettre) == -1) || ((difficulteLettre <= 1)) && (nbDeLaLettre(lettre) < 3))
                                // si la lettre de difficulté 2 n'est pas déjà tirée
                                {
                                    matrice[i] = lettre;
                                    consonneDeSuite++;
                                    voyelleDeSuite = 0;
                                    i++;
                                    this.textBox2.Text =
                                    this.textBox2.Text = "  " + this.textBox2.Text + "consonne facile Ajoutée = " + lettre.ToString()+" exemplaire n° "+nbDeLaLettre(lettre).ToString()  + "\r\n";
                                }
                                else
                                {
                                    this.textBox2.Text =
                                    this.textBox2.Text = "  " + this.textBox2.Text + "consonne facile rejetée = " + lettre.ToString() + "\r\n";
                                }

                            }
                            else
                            { // pas facile                      
                                if ((noteDeChiant < 3) && (nbDeLaLettre(lettre) < 2))// acceptable et pas doublé
                                {
                                    noteDeChiant += difficulteLettre;
                                    // augmentation de la note globale de chiant
                                    matrice[i] = lettre;
                                    consonneDeSuite++;
                                    voyelleDeSuite = 0;
                                    i++;
                                    this.textBox2.Text = "  " + this.textBox2.Text + " consonne difficile Ajoutée = " + lettre.ToString() + "\r\n";
                                }
                                else
                                {
                                    // on ne fait rien car pas acceptable
                                    this.textBox2.Text =
                                    this.textBox2.Text = "  " + this.textBox2.Text + "      Consonne rejetée" + lettre.ToString() + "\r\n";
                                }
                            }
                        } // consoles d'affilé
                    }
                    lettrePrecedente = lettre;
                } // fin du if = lettre precedente et conssonne et voyelles à suivre trop nombreuses
              
            
            }  // fin du while remmplissage matrice                    

            // modifications pour rendre plus jouable
            if (nbDeLaLettre('E') < 2) // pas assez de E
            {
                int difMax = 0;
                for (int j = 0; j < 16; j++)  // Repérage du plus haut diveau de difficulté présent
                {
                    if (TabloDifficulte[j] < difMax)
                    {
                        difMax = TabloDifficulte[j];
                    }
                }
                for (int j = 0; j < 16; j++) // la première lettre di niveau de difficulté Max est remplacée par E
                {
                    if (TabloDifficulte[j] == difMax)
                    {
                        this.textBox2.Text = this.textBox2.Text + matrice[j].ToString() + " remplacée par = E \r\n";
                        matrice[j] = 'E';
                        cptVoyelle++;
                        j = 16;
                    }
                }
                //  fin modifications pour rendre plus jouable
                for (int k = 0; k < 16; k++)
                {
                    this.textBox2.Text = "  " + this.textBox2.Text + k.ToString() + "  " + matrice[k].ToString() + "\r\n";
                }
            }

            if (cptVoyelle < 6)// pas assez de voyelles
            {
                int aChanger = maxVoyelle - cptVoyelle - 1;
                int tour = 0;
                int b = 0;
                char car;
                while (tour < aChanger)
                { // substitution de consonnes par des voyelles
                    b = rand.Next(0, 15);
                    car = (matrice[b]);
                    if (!estVoyelle(car))
                    {
                        int c = rand.Next(0, 2);
                        this.textBox2.Text = this.textBox2.Text + matrice[b].ToString() + " remplacée par = " + voyellesCourantes[c] + " \r\n";
                        matrice[b] = voyellesCourantes[c];
                        tour++;
                    }

                }
            }
            // MessageBox.Show("nb voyelles =" + cptVoyelle);
        }

        int nbVoyelles()
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


        bool estVoyelle(char lettre)
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
        bool estConsonneChiante(char lettre)
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

        private int nbDeLaLettre(char c) // renvoi le nombre d'occurences de la lettre dans matrice ([0..15] of char
        {
            int cpt = 0;
            for (int i = 0; i < matrice.Length - 1; i++)
            {
                if (matrice[i] == c)
                {
                    cpt++;
                }
            }
            return cpt;
        }
        public void dessineMatrice()
        {
            tableauDeLettres[0, 0] = matrice[0];
            L1.Text = tableauDeLettres[0, 0].ToString();
            tableauDeLettres[0, 1] = matrice[1];
            L2.Text = tableauDeLettres[0, 1].ToString();
            tableauDeLettres[0, 2] = matrice[2];
            L3.Text = tableauDeLettres[0, 2].ToString();
            tableauDeLettres[0, 3] = matrice[3];
            L4.Text = tableauDeLettres[0, 3].ToString();
            tableauDeLettres[1, 0] = matrice[4];
            L5.Text = tableauDeLettres[1, 0].ToString();
            tableauDeLettres[1, 1] = matrice[5];
            L6.Text = tableauDeLettres[1, 1].ToString();
            tableauDeLettres[1, 2] = matrice[6];
            L7.Text = tableauDeLettres[1, 2].ToString();
            tableauDeLettres[1, 3] = matrice[7];
            L8.Text = tableauDeLettres[1, 3].ToString();
            tableauDeLettres[2, 0] = matrice[8];
            L9.Text = tableauDeLettres[2, 0].ToString();
            tableauDeLettres[2, 1] = matrice[9];
            L10.Text = tableauDeLettres[2, 1].ToString();
            tableauDeLettres[2, 2] = matrice[10];
            L11.Text = tableauDeLettres[2, 2].ToString();
            tableauDeLettres[2, 3] = matrice[11];
            L12.Text = tableauDeLettres[2, 3].ToString();
            tableauDeLettres[3, 0] = matrice[12];
            L13.Text = tableauDeLettres[3, 0].ToString();
            tableauDeLettres[3, 1] = matrice[13];
            L14.Text = tableauDeLettres[3, 1].ToString();
            tableauDeLettres[3, 2] = matrice[14];
            L15.Text = tableauDeLettres[3, 2].ToString();
            tableauDeLettres[3, 3] = matrice[15];
            L16.Text = tableauDeLettres[3, 3].ToString();
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

        private void Init()  // initialisation des données pour la construction de l'arbre des lettres des mots français
        {
            this.pictureBox1.Visible = true;
            // Création de l'arbre à partir du fichier texte.
            //===================
            // initialisation du dictionnaire
            // string NomDuDico = "H:\\Famille\\GERALD\\visual_Studio\\Arbre_Dico\\MOTS TRADUITS.txt";
            string NomDuDico = Directory.GetCurrentDirectory() + "\\MOTS TRADUITS.txt";

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
            this.pictureBox1.Visible = false;
            if (motexiste(this.textBox1.Text.ToUpper()))
            {
                this.ImageGai.Visible = true;
            }
            else
            {
                this.ImageTriste.Visible = true;
            }
        }

        bool motexiste(string Mot)
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
                        noeudCourant = noeudCourant.DictionnaireDesSousNoeuds[lettreCourante]; // affectation du noeud trouvé pour la lettre pour le tour de boucle suivant                           
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
        { }

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer1.Start();    
            //debog();
            //   MessageBox.Show("ouf");
            nouvelleDonne();
            couple c1 = new couple(); // ces 2 lignes sont pour tester
            c1.x = 2; c1.y = 4;
        }

        private void nouvelleDonne()
        {
            creerMatrice();
            dessineMatrice();
            initialiseSuiteJoueur();
        }
        private void initDataPourGrille()
        {
            genereAlphabet();
            affecteConsonneOuVoyelle();
            affectePoidsDesLettres();
            affecteDidifficulteUtilisationLettre();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            Init(); // Pour la contructiiion d'un arbre des lettres à partir de la liste demot français
            initDataPourGrille();
            nouvelleDonne();

        }

        private void L1_MouseUp(object sender, MouseEventArgs e)
        {
        }
        //===============================  GESTION DU SURVOL DES LETTRES ==============================
        private void L1_MouseHover(object sender, EventArgs e)
        {
            if (L1.ForeColor == CouleurDeSelection) // déja utilisé
            { L1.ForeColor = CouleurDefaut; }
            else
            {
                L1.ForeColor = CouleurDeSelection;
                actualiseSuiteLabelJoueur("L1");
            }
        }

        private void L2_MouseHover(object sender, EventArgs e)
        {
            if (L2.ForeColor == CouleurDeSelection) // déja utilisé
            { L2.ForeColor = CouleurDefaut; }
            else
            {
                L2.ForeColor = CouleurDeSelection;
                actualiseSuiteLabelJoueur("L2");
            }
        }

        private void L3_MouseHover(object sender, EventArgs e)
        {
            if (L3.ForeColor == CouleurDeSelection) // déja utilisé
            { L3.ForeColor = CouleurDefaut; }
            else
            {
                L3.ForeColor = CouleurDeSelection;
                actualiseSuiteLabelJoueur("L3");
            }
        }
        //================================================================================================
        private void initialiseSuiteJoueur()
        {
            for (int i = 0; i < suiteLabelJoueur.Length - 1; i++)
            {
                suiteLabelJoueur[i] = "";
            }
        }
        private void actualiseSuiteLabelJoueur(string lab)
        {
            int Max = 0;
            for (int cpt = 0; cpt < suiteLabelJoueur.Length; cpt++)
            {
                if (suiteLabelJoueur[cpt] == "")
                {
                    Max = cpt;
                    break;
                }
            }
            if (Max > 0) // pas le première lettre
            {
                if (lab == "L1")
                {
                    string t = suiteLabelJoueur[Max - 1];
                    if (t == "L2" || t == "L4" || t == "L5")
                    {
                        suiteLabelJoueur[Max] = lab; // ajoute la case cochée dans les tableau de suivi
                    }
                    else
                    {
                        MessageBox.Show("Saisie impossible"); return;
                    }
                }
                else // première lettre saisie
                {
                    suiteLabelJoueur[0] = lab;
                }
            }
            suiteLabelJoueur[Max] = lab; // ajoute la case cochée dans les tableau de suivi
            // Ici on doit vérifier  
            // 1- si la case a déja été utilisée => pas possible déja discriminé par couleur
            // 2- si elle est voisine 
            // 3 - Si c'est la précédente on ne doit pas compter la derniere lettre (décrémentation) et remettre la couleur par defaut sur la lettre precedente
        }

    }


}



