using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbreDico
{


    public partial class Form1 : Form
    {
        public class Noeud
        {
            public char Lettre { get; set; }
            public bool FinDeMot { get; set; }
        }
        //=================================================================
        List<Noeud> Fils = new List<Noeud>();
        //=================================================================
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fils.Clear();
            for (int i=0; i<5; i++)
            {
            Noeud NouveauNoeud = new Noeud();
               NouveauNoeud.Lettre = Convert.ToChar(i+65); //'A';
                if (i % 2 == 0) { NouveauNoeud.FinDeMot = true; }
                else
                { NouveauNoeud.FinDeMot = false; }
                Fils.Add(NouveauNoeud);
            }
            
        }
    }
}
