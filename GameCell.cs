using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    // définition de la case : level sera affecté en fonction de la profondeur d'exploration du chemin
    public class GameCell
    {
        public Point2D Position { get; private set; }
        public int Level { get; set; }

        public List<GameCell> ListOfPossibleNeighbors = new List<GameCell>();
    }
}
