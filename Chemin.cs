using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    public class Chemin
    {
        private int m_numberOfWordsThatCanBeFound = 0;
        private List<string> m_exsitingWords = new List<string>();
        private readonly bool[,] m_usedCells = new bool[4, 4];
        private char[] m_possibleWord = new char[16];
        private string m_wordFind;
        private char[,] m_grid;

        private WordDictionary m_dictionary;

        public Chemin(char[,] lettersGrid, WordDictionary dictionary)
        {
            m_grid = lettersGrid;
            m_dictionary = dictionary;
        }

        public class MyCellClass
        // définition de la case : level sera affecté en fonction de la profondeur d'exploration du chemin
        {
            public Point2D Position { get; set; } = new Point2D();
            public int Level { get; set; }
            public List<MyCellClass> ListOfPossibleNeighbor = new List<MyCellClass>();
        }

        private void InitialiseArrayOfUsedfCells()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    m_usedCells[i, j] = false;
                }
            }
        }

        private void FindAcceptablesNeighbors(MyCellClass WorkingCell)
        {
            // cette procedure trouve les cases voisines de celle passée en pramètre
            // Créer des instance de Case pour chacune 
            //et les ajoute dans la liste des cases voisine de la case passée en pramètre 
            // et le niveau de parcours du chemin?
            int XofCell = WorkingCell.Position.X;
            int YofCell = WorkingCell.Position.Y;
            int NextLevel = WorkingCell.Level + 1;
            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    int CoordonneeX = XofCell + dx;
                    int CoordonneeY = YofCell + dy;
                    if ((CoordonneeX == XofCell) && (CoordonneeY == YofCell))
                    {
                        //On ne fait rien car les coordonnées sont celles de la case d'appel
                    }
                    else
                    {
                        if (CoordonneeX >= 0 && CoordonneeX < 4 && CoordonneeY >= 0 && CoordonneeY < 4)
                        {
                            // on traite car les coordonnées sont acceptables
                            if (m_usedCells[CoordonneeX, CoordonneeY])
                            {
                                // La  case est déjà utilisée : on ne fait rien
                            }
                            else
                            {
                                // La case est libre donc utilisable donc
                                // on crée une Case de coordonnées courantes 
                                // qu'on ajoute à la liste des cases voisines de la case courante
                                MyCellClass NeighborsCell = new MyCellClass
                                {
                                    Position = new Point2D()
                                    {
                                        X = CoordonneeX,
                                        Y = CoordonneeY,
                                    },
                                    Level = NextLevel
                                };
                                WorkingCell.ListOfPossibleNeighbor.Add(NeighborsCell);
                            }
                        }
                        else
                        {
                            // on ne fait rien car au moins une des coordonnées est hors limites
                        }
                    }
                }
            }
        }

        private char LetterOfCell(MyCellClass OneCell)
        {
            return m_grid[OneCell.Position.X, OneCell.Position.Y];
        }

        private void InitializePossibleWord()
        {
            for (int i = 0; i < 16; i++)
            {
                m_possibleWord[i] = '.';
            }
        }

        private void FindPossibleWord(int Level)
        {
            m_wordFind = "";
            for (int i = 0; i <= Level; i++)
            {
                m_wordFind += m_possibleWord[i];
            }

        }

        public void TotalExploration()
        {
            int cpt = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cpt++;
                    BeginTree(i, j);
                }
            }
        }

        private void BeginTree(int X, int Y)
        {
            InitialiseArrayOfUsedfCells();
            InitializePossibleWord();
            MyCellClass Root = new MyCellClass();
            Root.Position.X = X;
            Root.Position.Y = Y;
            Root.Level = 0;
            m_usedCells[Root.Position.X, Root.Position.Y] = true;
            m_possibleWord[Root.Level] = LetterOfCell(Root);
            FindAcceptablesNeighbors(Root);
            ShowCell(Root);
            for (int round0 = 0; round0 < Root.ListOfPossibleNeighbor.Count; round0++)
            {
                GoOnTree(Root, Root.ListOfPossibleNeighbor[round0]);
            }
        }

        private void GoOnTree(MyCellClass TopCell, MyCellClass DonwCell)
        {
            m_usedCells[DonwCell.Position.X, DonwCell.Position.Y] = true;
            m_possibleWord[DonwCell.Level] = LetterOfCell(DonwCell);
            FindAcceptablesNeighbors(DonwCell);
            ShowCell(DonwCell);
            if (DonwCell.ListOfPossibleNeighbor.Count == 0)
            {
                m_usedCells[DonwCell.Position.X, DonwCell.Position.Y] = false;
                m_possibleWord[DonwCell.Level] = '*';
                int MaxIndex = TopCell.ListOfPossibleNeighbor.Count;
                // Vire la reference à la celulle courante de la liste de la cellule mère
                for (int NumCell = 0; NumCell < MaxIndex; NumCell++)
                {   // Vire de la liste des voisines possibles de la case de niveau supérieur la référence à la cellule en cours
                    if (
                        TopCell.ListOfPossibleNeighbor[NumCell].Position.X == DonwCell.Position.X && 
                        TopCell.ListOfPossibleNeighbor[NumCell].Position.Y == DonwCell.Position.Y)
                    {
                        TopCell.ListOfPossibleNeighbor.RemoveAt(NumCell);
                        NumCell = MaxIndex; //pour sortir

                    }
                }
            }
            else
            {
                GoOnTree(DonwCell, DonwCell.ListOfPossibleNeighbor[0]);
                if (DonwCell.ListOfPossibleNeighbor.Count != 0)
                {
                    m_usedCells[DonwCell.Position.X, DonwCell.Position.Y] = false;
                    m_possibleWord[DonwCell.Level] = '|';
                }
            }
        }

        private void ShowCell(MyCellClass Cell)
        {
            FindPossibleWord(Cell.Level);
            if (m_dictionary.IsWordValid(m_wordFind))
            {
                // Test += WordFind + "\r\n";     
                AddWordInListExistingWords(m_wordFind);
            }
        }

        private void AddWordInListExistingWords(string Word)
        {
            bool AlreadyExists = false;
            if (m_exsitingWords.Count == 0) // si la liste est vide on ajoute le mot
            {
                m_exsitingWords.Add(Word);
                m_numberOfWordsThatCanBeFound++;
            }
            else
            { 
                // on regarde si le mot existe déja dans la liste
                for (int i = 0; i < m_exsitingWords.Count; i++)
                {
                    if (m_exsitingWords[i] == Word)
                    {
                        AlreadyExists = true;
                        i = m_exsitingWords.Count;
                    }
                }
                if (AlreadyExists == false)
                {
                    m_exsitingWords.Add(Word);
                    m_numberOfWordsThatCanBeFound++;
                }
            }

        }

    }
}
