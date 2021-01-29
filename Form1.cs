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
        // crée une variable d'instance à laquelle on affectera le noeud racine (passage du pointeur) 
        //pour en disposer dans Form1
        // **** Couleurs de l'environnement
        readonly Color CouleurDefaut = Color.FromName("Navy");
        // Variables de classe      
        public WordDictionary wordDictionary { get; private set; }
        //=================================================================




        public void CreerMatrice() // Génère aléatoirement des lettres qui sont mises dans le tableau"matrice"
        {
            int cptVoyelle = 0;
            int voyelleDeSuite = 0;
            int consonneDeSuite = 0;
            int noteDeChiant = 0;
            int difficulteLettre;
            int maxVoyelle = 6;
            bool estUneVoyelle;
            bool accord = true;
            char lettre;
            var rand = new Random();
            // remplit un tableau [0..15] d'un caractère aléatoire
            int i = 0;
            // this.textBox2.Clear();
            while (i < 16)
            {
                int a = rand.Next(0, 25);
                lettre = DonneesLettres.alphabet[a];
                if (i > 0)
                {
                    if (lettre != DonneesLettres.TabloListeDesCaracteres[i - 1])
                    { accord = true; }
                    else { accord = false; }
                }
                if (accord)
                {
                    //  this.textBox2.Text = this.textBox2.Text + lettre.ToString() + " TIRE = " + nbDeLaLettre(lettre).ToString() + " fois \r\n";
                    difficulteLettre = DonneesLettres.TabloDifficulte[a];
                    if (DonneesLettres.TabloConsonneOuVoyelle[a] == 1) // détermine si le caractère est ou non une voyelle
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
                                if (DonneesLettres.PlaceDansLaMatrice(lettre) == -1 && noteDeChiant <= 4)
                                {
                                    //difficile pas en double
                                    DonneesLettres.TabloListeDesCaracteres[i] = lettre;
                                    noteDeChiant += DonneesLettres.TabloDifficulte[i];
                                    cptVoyelle++; i++;
                                    voyelleDeSuite++;
                                    consonneDeSuite = 0;
                                    //  this.textBox2.Text = this.textBox2.Text + "Voyelle difficile Ajoutée = " + lettre.ToString() + "\r\n";
                                }
                            }
                            else
                            {
                                // voyelle facile
                                DonneesLettres.TabloListeDesCaracteres[i] = lettre;
                                voyelleDeSuite++;
                                consonneDeSuite = 0;
                                //  this.textBox2.Text = this.textBox2.Text + "Voyelle facile Ajoutée = " + lettre.ToString() + "\r\n";
                            }
                        }
                    }
                    else
                    {// tirage d'une consonne
                        if (consonneDeSuite <= 2) // et pas trop de consonnnes d'affilé
                        {
                            if (difficulteLettre < 2) // facile 
                            {
                                if ((difficulteLettre == 2 && DonneesLettres.PlaceDansLaMatrice(lettre) == -1) || ((difficulteLettre <= 1)) && (DonneesLettres.NbDeLaLettreDansMatrice(lettre) < 3))
                                // si la lettre de difficulté 2 n'est pas déjà tirée
                                {
                                    DonneesLettres.TabloListeDesCaracteres[i] = lettre;
                                    consonneDeSuite++;
                                    voyelleDeSuite = 0;
                                    i++;
                                    //   this.textBox2.Text =
                                    //  this.textBox2.Text = "  " + this.textBox2.Text + "consonne facile Ajoutée = " + lettre.ToString() + " exemplaire n° " + nbDeLaLettre(lettre).ToString() + "\r\n";
                                }
                                else
                                {
                                    this.textBox2.Text =
                                    this.textBox2.Text = "  " + this.textBox2.Text + "consonne facile rejetée = " + lettre.ToString() + "\r\n";
                                }

                            }
                            else
                            { // pas facile                      
                                if ((noteDeChiant < 3) && (DonneesLettres.NbDeLaLettreDansMatrice(lettre) < 2))// acceptable et pas doublé
                                {
                                    noteDeChiant += difficulteLettre;
                                    // augmentation de la note globale de chiant
                                    DonneesLettres.TabloListeDesCaracteres[i] = lettre;
                                    consonneDeSuite++;
                                    voyelleDeSuite = 0;
                                    i++;
                                    //  this.textBox2.Text = "  " + this.textBox2.Text + " consonne difficile Ajoutée = " + lettre.ToString() + "\r\n";
                                }
                                else
                                {
                                    // on ne fait rien car pas acceptable
                                    //  this.textBox2.Text =
                                    //  this.textBox2.Text = "  " + this.textBox2.Text + "      Consonne rejetée" + lettre.ToString() + "\r\n";
                                }
                            }
                        } // consoles d'affilé
                    }
                } // fin du if = lettre precedente et conssonne et voyelles à suivre trop nombreuses


            }  // fin du while remmplissage matrice                    

            // modifications pour rendre plus jouable
            if (DonneesLettres.NbDeLaLettreDansMatrice('E') < 2) // pas assez de E
            {
                int difMax = 0;
                for (int j = 0; j < 16; j++)  // Repérage du plus haut diveau de difficulté présent
                {
                    if (DonneesLettres.TabloDifficulte[j] > difMax)
                    {
                        difMax = DonneesLettres.TabloDifficulte[j];
                    }
                }
                for (int j = 0; j < 16; j++) // la première lettre di niveau de difficulté Max est remplacée par E
                {
                    if (DonneesLettres.TabloDifficulte[j] == difMax)
                    {
                        //  this.textBox2.Text = this.textBox2.Text + matrice[j].ToString() + " remplacée par = E \r\n";
                        DonneesLettres.TabloListeDesCaracteres[j] = 'E';
                        cptVoyelle++;
                        j = 16;
                    }
                }
                for (int k = 0; k < 16; k++)
                {
                    //  this.textBox2.Text = "  " + this.textBox2.Text + k.ToString() + "  " + matrice[k].ToString() + "\r\n";
                }
            }

            if (cptVoyelle < 6)// pas assez de voyelles
            {
                int aChanger = maxVoyelle - cptVoyelle - 1;
                int tour = 0;
                char car;
                while (tour < aChanger)
                { // substitution de consonnes par des voyelles
                    int b = rand.Next(0, 15);
                    car = (DonneesLettres.TabloListeDesCaracteres[b]);
                    if (!DonneesLettres.EstVoyelle(car))
                    {
                        int c = rand.Next(0, 2);
                        //   this.textBox2.Text = this.textBox2.Text + matrice[b].ToString() + " remplacée par = " + voyellesCourantes[c] + " \r\n";
                        DonneesLettres.TabloListeDesCaracteres[b] = DonneesLettres.voyellesCourantes[c];
                        tour++;
                    }

                }
                //  fin modifications pour rendre plus jouable
            }
            // transfert des lettres de Matrice vers tableaudelettres
            int ligne = 0, colonne = 0;
            for (int r = 0; r < 16; r++)
            {
                DonneesLettres.tableauDeLettres[ligne, colonne] = DonneesLettres.TabloListeDesCaracteres[r];
                colonne++;
                if (colonne == 4)
                {
                    ligne++;
                    colonne = 0;
                }
            }
            // MessageBox.Show("nb voyelles =" + cptVoyelle);
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void InitialiseEnvironnement()  // initialisation des données pour la construction de l'arbre des lettres des mots français
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
                wordDictionary = new WordDictionary(lignesDico);
                this.pictureBox1.Left += 50;
                this.pictureBox1.Visible = false;
            }
        }



        private void BoutonVerifMot(object sender, EventArgs e)
        // Bouton qui déclenche l'action de vocontroler si le mot estr acceptable        
        {
            VerifMot();
            this.textBox1.Clear();
            DataGame.RazScoreMotJoueur();
            labScoreMotJoueur.Text = "";
            DessineMatrice();
        }

        private void VerifMot() // Vérifie si le mot à controler n'est pas un mot déjà utilisé
        {
            this.pictureBox1.Visible = false;
            if (this.wordDictionary.IsWordValid(this.textBox1.Text))
            { // le mot propose par joueur existe
                bool MotDejaUtilise = false;
                for (int cptM = 0; cptM < listBox1.Items.Count; cptM++)
                {   // verifie si le mot a déjà été proposé
                    if (listBox1.Items[cptM].ToString() == textBox1.Text)
                    {
                        MotDejaUtilise = true;
                        ImageTriste.Visible = true;
                        labNotification.Text = "Mot déja choisi";
                        DessineMatrice();
                    }
                }

                if (MotDejaUtilise == false)
                {
                    this.ImageGai.Visible = true;
                    this.ImageTriste.Visible = false;
                    DataGame.ActualiseScoreTotal(DataGame.scoreMotJoueur);
                    labScoreTotal.Text = DataGame.ScoreTotal.ToString();
                    listBox1.Items.Add(textBox1.Text);
                    this.textBox1.Clear();
                }
                else
                {
                    this.ImageGai.Visible = false;
                    this.ImageTriste.Visible = true;
                }
            }
            else
            {
                ImageTriste.Visible = true;
            }

        }



        private void TextBox1_Enter(object sender, EventArgs e)
        {// n'est plus utilisé dans la configuration terminée du jeu
            this.pictureBox1.Visible = true;
            this.ImageGai.Visible = false;
            this.ImageTriste.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {   // Réalise un nouveau tirage de lettres et configure l'IHM
            DataGame.RazScoreMotJoueur();
            NouvelleDonne();
            DessineMatrice();
            textBox1.Clear();
            pictureBox1.Visible = true;
        }

        private void NouvelleDonne()
        { //Réalise un nouveau tirage de lettres
            this.listBox1.Items.Clear();
            DataGame.RazScoreMotJoueur();
            DataGame.RazScoreTotal();
            labScoreMotJoueur.Text = ("Score du mot");
            labScoreTotal.Text = ("Score de la partie.");
            CreerMatrice();
            DessineMatrice();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void Form1_Load(object sender, EventArgs e)
        {
            string T;
            int cpt = 0;
            for (int j = 0; j < 4; j++)  // Création des LABEL  de la grille
            {

                for (int i = 0; i < 4; i++)
                {
                    cpt++;
                    int pas = 60;
                    //  Label L = new System.Windows.Forms.Label();
                    LAbelXY L = new LAbelXY();
                    {
                        L.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        L.Parent = this;
                    };
                    L.Click += new EventHandler(LableEstChoisi);
                    T = cpt.ToString();
                    L.Text = T;
                    L.Name = T;
                    L.Width = pas - 20;
                    L.Height = pas - 20;
                    L.Top = 20 + j * pas;
                    L.Left = 20 + i * pas;
                    L.ForeColor = CouleurDefaut;
                    L.X = i;
                    L.Y = j;
                    L.Show();
                }
            }
            DataGame.RazScoreMotJoueur();
            DataGame.RazScoreTotal();
            InitialiseEnvironnement(); // Pour la contruction d'un arbre des lettres à partir de la liste des mots français        
            DonneesLettres.InitDataPourGrille();
            NouvelleDonne();
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        class LAbelXY : Label
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        private void LableEstChoisi(object sender, EventArgs e)
        {
            ImageGai.Visible = false;
            ImageTriste.Visible = false;
            LAbelXY Choisi = (LAbelXY)sender;
            //   this.Text = Choisi.X.ToString() + ", " + Choisi.Y.ToString();
            Choisi.Visible = false;
            GereClicSurLettre(Choisi.Name.ToString(), Choisi.Y, Choisi.X);
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void DessineMatrice()
        {
            int compteur = 0;
            try
            {
                foreach (LAbelXY labelDeLettre in Controls.OfType<LAbelXY>())
                {
                    labelDeLettre.Text = DonneesLettres.tableauDeLettres[labelDeLettre.Y, labelDeLettre.X].ToString();
                    labelDeLettre.Visible = true;
                    compteur++;
                }
            }

            catch
            {
                MessageBox.Show("Erreur dans la boucle foreach de dessinneMatrice");
            }
            DonneesLettres.casePrecedente.X = -1; //initialise case précédente
            DonneesLettres.casePrecedente.Y = -1;
            DonneesLettres.InitialiseTablocochage();
        }

        bool EstVoisineDeCasePrecedente()
        {    // retourn vrai si la case est une case voisine 
            int rx, ry;
            labNotification.Text = "";
            if (DonneesLettres.casePrecedente.X != -1) // pas la première case
            {// traitement
                rx = Math.Abs(DonneesLettres.caseChoisie.X - DonneesLettres.casePrecedente.X);
                ry = Math.Abs(DonneesLettres.caseChoisie.Y - DonneesLettres.casePrecedente.Y);
                if ((rx >= -1 && rx <= 1) && (ry >= -1 && ry <= 1))
                {
                    DonneesLettres.StockeCaseChoisie();
                    labNotification.Text = " ";
                    return true;
                }
                else
                {
                    labNotification.Text = "Choix innacceptable : pas voisine";
                    return false;
                }
            }
            else
            {
                DonneesLettres.StockeCaseChoisie();
                labNotification.Text = " ";
                return true;
            }
        }

        private void GereClicSurLettre(string nomDuLabel, int ligne, int colonne)
        {
            DonneesLettres.caseChoisie.X = colonne;
            DonneesLettres.caseChoisie.Y = ligne;
            // ParcoursDeMatrice.TrouveVoisinePossible(colonne, ligne);
            if (EstVoisineDeCasePrecedente())
            {

                foreach (Label labelDeLettre in Controls.OfType<Label>()) // pour tous les label de la form
                {
                    if (labelDeLettre.Name == nomDuLabel) // si le label est celui cliqué
                    {

                        this.textBox1.Text += labelDeLettre.Text;
                        ActualiseScoreMot(char.Parse(labelDeLettre.Text));
                        DonneesLettres.TabloCochage[colonne, ligne] = true;
                    }

                    DonneesLettres.DefinitCoupleCaseCochee(ligne, colonne);
                }
            }
        }
        void ActualiseScoreMot(char C)
        {
            for (int i = 0; i < DonneesLettres.alphabet.Length - 1; i++)
            {
                if (DonneesLettres.alphabet[i] == C) // caractère identifié
                {
                    DataGame.ActualiseScoreMotJoeur(DonneesLettres.TabloPointsParLettre[i]);
                    labScoreMotJoueur.Text = DataGame.scoreMotJoueur.ToString();
                }
            }
        }

        private void Bt_Rotation_Click(object sender, EventArgs e)
        {
            DonneesLettres.TourneTableauDeLettres();
            DessineMatrice();
        }

        private void Bt_test_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            ParcoursDeMatrice.CrerCaseRacine(0, 0);
            ParcoursDeMatrice.Test += "\r\n" + ParcoursDeMatrice.CompteurGeneral.ToString();
            this.textBox2.Text = ParcoursDeMatrice.Test;
        }


    }// fin classe Form1

}// FIn  namspace



