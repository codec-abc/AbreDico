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
        int scoreMotJoueur = 0;
        int scoreTotal = 0;
        public Noeud NoeudRacine { get; private set; }
        //=================================================================

        private void Button_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            MessageBox.Show("Button " + clicked.Name + " was Clicked.");
        }
        /* private void Debog()
         {
             GenereAlphabet();
             AffecteConsonneOuVoyelle();
             AffecteDidifficulteUtilisationLettre();
             AffectePoidsDesLettres();
             this.textBox2.Clear();
             for (int i = 0; i < 26; i++)
             {
                 string chaine = i.ToString() + " " + DonneesLettres. alphabet[i].ToString();
                 string s;
                 if (TabloConsonneOuVoyelle[i] == 0) { s = " cons "; } else { s = " voyL "; }
                 s = s + " dif: " + TabloDifficulte[i] + " points : " + TabloPointsParLettre[i] + "\r\n";
                 this.textBox2.Text = this.textBox2.Text + chaine + s;
             }
         }*/

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
                    if (lettre != DonneesLettres.matrice[i - 1])
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
                                    DonneesLettres.matrice[i] = lettre;
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
                                DonneesLettres.matrice[i] = lettre;
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
                                if ((difficulteLettre == 2 && DonneesLettres.PlaceDansLaMatrice(lettre) == -1) || ((difficulteLettre <= 1)) && (DonneesLettres.NbDeLaLettre(lettre) < 3))
                                // si la lettre de difficulté 2 n'est pas déjà tirée
                                {
                                    DonneesLettres.matrice[i] = lettre;
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
                                if ((noteDeChiant < 3) && (DonneesLettres.NbDeLaLettre(lettre) < 2))// acceptable et pas doublé
                                {
                                    noteDeChiant += difficulteLettre;
                                    // augmentation de la note globale de chiant
                                    DonneesLettres.matrice[i] = lettre;
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
            if (DonneesLettres.NbDeLaLettre('E') < 2) // pas assez de E
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
                        DonneesLettres.matrice[j] = 'E';
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
                    car = (DonneesLettres.matrice[b]);
                    if (!DonneesLettres.EstVoyelle(car))
                    {
                        int c = rand.Next(0, 2);
                        //   this.textBox2.Text = this.textBox2.Text + matrice[b].ToString() + " remplacée par = " + voyellesCourantes[c] + " \r\n";
                        DonneesLettres.matrice[b] = DonneesLettres.voyellesCourantes[c];
                        tour++;
                    }

                }
                //  fin modifications pour rendre plus jouable
            }
            // MessageBox.Show("nb voyelles =" + cptVoyelle);
        }

        public Form1()
        {
            InitializeComponent();
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
               this.NoeudRacine= GestionDesNoeuds.CreationArbreDico(lignesDico);
                this.pictureBox1.Left += 50;
                this.pictureBox1.Visible = false;
            }
        }

     

        private void BoutonVerifMot(object sender, EventArgs e)
        {
            VerifMot();
            this.textBox1.Clear();
            scoreMotJoueur = 0;
            labScoreMotJoueur.Text = "";
            DessineMatrice();
        }

        private void VerifMot()
        {
            this.pictureBox1.Visible = false;
            if (Motexiste(this.textBox1.Text))
            {
                bool MotDejaUtilise = false;
                for (int cptM = 0; cptM < listBox1.Items.Count; cptM++)
                {
                    if (listBox1.Items[cptM].ToString() == textBox1.Text)
                    {
                        MotDejaUtilise = true;
                        labNotification.Text = "Mot déja choisi";
                        DessineMatrice();
                    }
                }

                if (MotDejaUtilise == false)
                {
                    this.ImageGai.Visible = true;
                    this.ImageTriste.Visible = false;
                    scoreTotal += scoreMotJoueur;
                    labScoreTotal.Text = scoreTotal.ToString();
                    scoreMotJoueur = 0;
                    listBox1.Items.Add(textBox1.Text);
                    // this.textBox2.Text = this.textBox2.Text + this.textBox1.Text + "\r\n";
                    this.textBox1.Clear();
                }
                else
                {
                    this.ImageGai.Visible = false;
                    this.ImageTriste.Visible = true;
                }
            }

        }

        bool Motexiste(string Mot)
        {
            int lg = Mot.Length;
            Noeud noeudCourant = this.NoeudRacine;
            for (int i = 0; i < lg; i++) // Faire pour toutes les lettres du mot
            {
                char lettreCourante = Mot[i];
                if (noeudCourant.DictionnaireDesSousNoeuds != null) // le Dictionnaire du noeud examiné n'est pas null
                {
                    if (noeudCourant.DictionnaireDesSousNoeuds.ContainsKey(lettreCourante))//le dico contient la lettre du mot
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
            if (noeudCourant.FinDeMot)
            { return true; }
            else
            { return false; }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            this.ImageGai.Visible = false;
            this.ImageTriste.Visible = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            scoreMotJoueur = 0;
            NouvelleDonne();
            DessineMatrice();
            textBox1.Clear();
            pictureBox1.Visible = true;
        }

        private void NouvelleDonne()
        {
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
                    Label L = new System.Windows.Forms.Label
                    {
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        Parent = this
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
                    L.Show();
                }
            }
            Init(); // Pour la contruction d'un arbre des lettres à partir de la liste demot français        
            DonneesLettres.InitDataPourGrille();
            NouvelleDonne();
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void LableEstChoisi(object sender, EventArgs e)
        {
            Label choisi = (Label)sender;
            string n = choisi.Name;
            int li = DonneesLettres.RetourneLigneDuLabel(n);
            int co = DonneesLettres.RetourneColonneDuLabel(n);
            choisi.Visible = false;
            GereClicSurLettre(choisi.Name.ToString(), li, co);
        }

        private void DessineMatrice()
        {
            int compteur = 0, ligne = 0, colonne = 0;
            string nomDuLabel;
            try
            {
                foreach (Label lableDeLette in Controls.OfType<Label>())
                {
                    //  MessageBox.Show(matrice[cpt].ToString()+" co="+co.ToString()+" li ="+li.ToString());
                    lableDeLette.ForeColor = CouleurDefaut;
                    nomDuLabel = DonneesLettres.matrice[compteur].ToString();
                    lableDeLette.Text = nomDuLabel;
                    lableDeLette.Visible = true;
                    DonneesLettres.tableauDeLettres[ligne, colonne] = DonneesLettres.matrice[compteur];
                    colonne++;
                    if (colonne == 4)
                    {
                        colonne = 0;
                        ligne++;
                    }
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
            TrouveVoisinePossible(colonne, ligne);
            if (EstVoisineDeCasePrecedente())
            {

                foreach (Label labelDeLetrre in Controls.OfType<Label>()) // pour tous les label de la form
                {
                    if (labelDeLetrre.Name == nomDuLabel) // si le label est celui cliqué
                    {

                        this.textBox1.Text += labelDeLetrre.Text;
                        ActualiseScoreMot(char.Parse(labelDeLetrre.Text));
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
                    scoreMotJoueur += DonneesLettres.TabloPointsParLettre[i];
                    labScoreMotJoueur.Text = scoreMotJoueur.ToString();
                }
            }
        }


        private void TrouveVoisinePossible(int X, int Y)
        {
            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {

                    // NE FONCTIONNE PAS => A DEBOGUER
                    int coordonneeX = X + dx;
                    int coordonneeY = Y + dy;
                    //   MessageBox.Show("=>  "+coordonneeX.ToString() + " , " + coordonneeY.ToString()+ " X="+X.ToString()+" Y="+Y.ToString());
                    if ((coordonneeX == X) && (coordonneeY == Y)) // si coordonée différentes de la case d'appel
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
    }// fin classe Form1

}// FIn  namspace



