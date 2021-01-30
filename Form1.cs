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
        
        private WordDictionary m_dictionary { get; set; }
        private GameScore m_gameScore = new GameScore();
        private GameRules m_gameRules = new GameRules();
        private GameState m_gameState = new GameState();

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
            char letter;
            var rand = new Random();
            // remplit un tableau [0..15] d'un caractère aléatoire
            int i = 0;
            // this.textBox2.Clear();
            while (i < 16)
            {
                int randomLetterIndex = rand.Next(0, 25);
                letter = m_gameRules.GetLetters()[randomLetterIndex];
                if (i > 0)
                {
                    if (letter != m_gameState.GetCellContentAtIndex(i - 1))
                    { 
                        accord = true; 
                    }
                    else 
                    { 
                        accord = false; 
                    }
                } 
                if (accord)
                {
                    //  this.textBox2.Text = this.textBox2.Text + lettre.ToString() + " TIRE = " + nbDeLaLettre(lettre).ToString() + " fois \r\n";
                    difficulteLettre = m_gameRules.GetDifficultyByLetter()[randomLetterIndex];
                    if (m_gameRules.IsLetterVowel(letter)) // détermine si le caractère est ou non une voyelle
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
                                if (noteDeChiant <= 4)
                                {
                                    //difficile pas en double
                                    m_gameState.SetCellContentAtIndex(i, letter);
                                    noteDeChiant += m_gameRules.GetDifficultyByLetter()[i];
                                    cptVoyelle++; i++;
                                    voyelleDeSuite++;
                                    consonneDeSuite = 0;
                                    //  this.textBox2.Text = this.textBox2.Text + "Voyelle difficile Ajoutée = " + lettre.ToString() + "\r\n";
                                }
                            }
                            else
                            {
                                // voyelle facile
                                m_gameState.SetCellContentAtIndex(i, letter);
                                voyelleDeSuite++;
                                consonneDeSuite = 0;
                                //  this.textBox2.Text = this.textBox2.Text + "Voyelle facile Ajoutée = " + lettre.ToString() + "\r\n";
                            }
                        }
                    }
                    else
                    {
                        // tirage d'une consonne
                        if (consonneDeSuite <= 2) // et pas trop de consonnnes d'affilé
                        {
                            if (difficulteLettre < 2) // facile 
                            {
                                if (
                                    difficulteLettre == 2 || 
                                    ((difficulteLettre <= 1)) && (m_gameState.NumberTimesLetterAppearInGrid(letter) < 3)
                                )
                                // si la lettre de difficulté 2 n'est pas déjà tirée
                                {
                                    m_gameState.SetCellContentAtIndex(i, letter);
                                    consonneDeSuite++;
                                    voyelleDeSuite = 0;
                                    i++;
                                    //   this.textBox2.Text =
                                    //  this.textBox2.Text = "  " + this.textBox2.Text + "consonne facile Ajoutée = " + lettre.ToString() + " exemplaire n° " + nbDeLaLettre(lettre).ToString() + "\r\n";
                                }
                                else
                                {
                                    this.textBox2.Text =
                                    this.textBox2.Text = "  " + this.textBox2.Text + "consonne facile rejetée = " + letter.ToString() + "\r\n";
                                }

                            }
                            else
                            { // pas facile                      
                                if ((noteDeChiant < 3) && (m_gameState.NumberTimesLetterAppearInGrid(letter) < 2))// acceptable et pas doublé
                                {
                                    noteDeChiant += difficulteLettre;
                                    // augmentation de la note globale de chiant
                                    m_gameState.SetCellContentAtIndex(i, letter);
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
            if (m_gameState.NumberTimesLetterAppearInGrid('E') < 2) // pas assez de E
            {
                int difMax = 0;
                for (int j = 0; j < 16; j++)  // Repérage du plus haut diveau de difficulté présent
                {
                    if (m_gameRules.GetDifficultyByLetter()[j] > difMax)
                    {
                        difMax = m_gameRules.GetDifficultyByLetter()[j];
                    }
                }
                for (int j = 0; j < 16; j++) // la première lettre di niveau de difficulté Max est remplacée par E
                {
                    if (m_gameRules.GetDifficultyByLetter()[j] == difMax)
                    {
                        //  this.textBox2.Text = this.textBox2.Text + matrice[j].ToString() + " remplacée par = E \r\n";
                        m_gameState.SetCellContentAtIndex(j, 'E');
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
                    car = m_gameState.GetCellContentAtIndex(b);
                    if (!m_gameRules.IsLetterVowel(car))
                    {
                        int c = rand.Next(0, 2);
                        //   this.textBox2.Text = this.textBox2.Text + matrice[b].ToString() + " remplacée par = " + voyellesCourantes[c] + " \r\n";
                        m_gameState.SetCellContentAtIndex(b, m_gameRules.GetCommonVowels()[c]);
                        tour++;
                    }

                }
                //  fin modifications pour rendre plus jouable
            }
            // transfert des lettres de Matrice vers tableaudelettres
            int ligne = 0, colonne = 0;
            for (int r = 0; r < 16; r++)
            {
                //m_donneesLettre.CellsContent[ligne, colonne] = m_donneesLettre.TabloListeDesCaracteres[r];
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
                m_dictionary = new WordDictionary(lignesDico);
                this.pictureBox1.Left += 50;
                this.pictureBox1.Visible = false;
            }
        }

        // Bouton qui déclenche l'action de vocontroler si le mot estr acceptable        
        private void BoutonVerifMot(object sender, EventArgs e)
        {
            VerifMot();
            this.textBox1.Clear();
            m_gameScore.ResetWordScore();
            labScoreMotJoueur.Text = "";
            DessineMatrice();
        }

        private void VerifMot() // Vérifie si le mot à controler n'est pas un mot déjà utilisé
        {
            this.pictureBox1.Visible = false;
            if (this.m_dictionary.IsWordValid(this.textBox1.Text))
            { 
                // le mot propose par joueur existe
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
                    m_gameScore.AddPointsToTotalScore(m_gameScore.GetWordScore());
                    labScoreTotal.Text = m_gameScore.GetTotalScore().ToString();
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
        {
            // n'est plus utilisé dans la configuration terminée du jeu
            this.pictureBox1.Visible = true;
            this.ImageGai.Visible = false;
            this.ImageTriste.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {   
            // Réalise un nouveau tirage de lettres et configure l'IHM
            m_gameScore.ResetWordScore();
            NouvelleDonne();
            DessineMatrice();
            textBox1.Clear();
            pictureBox1.Visible = true;
        }

        private void NouvelleDonne()
        { 
            //Réalise un nouveau tirage de lettres
            this.listBox1.Items.Clear();
            m_gameScore.ResetWordScore();
            m_gameScore.ResetTotalScore();
            labScoreMotJoueur.Text = ("Score du mot");
            labScoreTotal.Text = ("Score de la partie.");
            CreerMatrice();
            var chemin = new Chemin(m_gameState.GetGrid(), m_dictionary);
            chemin.TotalExploration();
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
                        L.Font = 
                            new System.Drawing.Font(
                                "Microsoft Sans Serif", 
                                14F, 
                                System.Drawing.FontStyle.Bold, 
                                System.Drawing.GraphicsUnit.Point, 
                                ((byte)(0))
                           );

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
            m_gameScore.ResetWordScore();
            m_gameScore.ResetTotalScore();
            InitialiseEnvironnement(); // Pour la contruction d'un arbre des lettres à partir de la liste des mots français        
            //DonneesLettres.InitDataPourGrille();
            NouvelleDonne();
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
                    labelDeLettre.Text = m_gameState.GetCellContentAtPosition(labelDeLettre.Y, labelDeLettre.X).ToString();
                    labelDeLettre.Visible = true;
                    compteur++;
                }
            }

            catch
            {
                MessageBox.Show("Erreur dans la boucle foreach de dessinneMatrice");
            }
            m_gameState.ResetClickedCells();
        }

        private void GereClicSurLettre(string nomDuLabel, int ligne, int colonne)
        {
            //ParcoursDeMatrice.TrouveVoisinePossible(colonne, ligne);
            if (m_gameState.IsValidClick(ligne, colonne))
            {
                labNotification.Text = " ";
                foreach (Label labelDeLettre in Controls.OfType<Label>()) // pour tous les label de la form
                {
                    if (labelDeLettre.Name == nomDuLabel) // si le label est celui cliqué
                    {

                        this.textBox1.Text += labelDeLettre.Text;
                        ActualiseScoreMot(char.Parse(labelDeLettre.Text));
                    }
                }
                m_gameState.PushClick(ligne, colonne);
            }
            else
            {
                labNotification.Text = "Choix innacceptable : pas voisine";
            }
        }

        void ActualiseScoreMot(char C)
        {
            var letters = m_gameRules.GetLetters();
            var scoreByLetters = m_gameRules.GetScoreByLetter();
            for (int i = 0; i < letters.Length - 1; i++)
            {
                if (letters[i] == C) // caractère identifié
                {
                    m_gameScore.AddPointsToWordScore(scoreByLetters[i]);
                    labScoreMotJoueur.Text = m_gameScore.GetWordScore().ToString();
                }
            }
        }

        private void Bt_Rotation_Click(object sender, EventArgs e)
        {
            //m_donneesLettre.TourneTableauDeLettres();
            DessineMatrice();
        }


    }// fin classe Form1

}// FIn  namspace



