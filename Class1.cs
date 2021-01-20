using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    public class Case
    {
        public couple coordonnées;        
        public Dictionary<char, Case> DictionnaireDesCasesVoisiness;
    }
    public class couple
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    
}
