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
        public class Noeud
        {
            public char Lettre { get; set; }
            public bool FinDeMot { get; set; }
            public Dictionary<char, Noeud> DictionnaireDesSousNoeuds;
        }


    }

}
