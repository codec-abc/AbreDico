//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AbreDico
//{
//    class Chemin
//    {
//        private Chemin()
//        {

//        }

//        public string Test = "";
//        public char[] PossibleWord = new char[16];
//        public string WordFind;
//        private bool[,] ArrayOfUsedCells = new bool[4, 4];

//        private void InitialiseArrayOfUsedfCells()
//        {
//            for (int i = 0; i < 4; i++)
//            {
//                for (int j = 0; j < 4; j++)
//                {
//                    ArrayOfUsedCells[i, j] = false;
//                }
//            }
//        }

//        public void FindAcceptablesNeighbors(GameCell WorkingCell)
//        {
//            // cette procedure trouve les cases voisines de celle passée en pramètre
//            // Créer des instance de Case pour chacune 
//            //et les ajoute dans la liste des cases voisine de la case passée en pramètre 
//            // et le niveau de parcours du chemin?
//            int XofCell = WorkingCell.Pos.X;
//            int YofCell = WorkingCell.Pos.Y;
//            int NextLevel = WorkingCell.Level + 1;
//            for (int dx = -1; dx < 2; dx++)
//            {
//                for (int dy = -1; dy < 2; dy++)
//                {
//                    int CoordonneeX = XofCell + dx;
//                    int CoordonneeY = YofCell + dy;
//                    if ((CoordonneeX == XofCell) && (CoordonneeY == YofCell))
//                    {
//                        //On ne fait rien car les coordonnées sont celles de la case d'appel
//                    }
//                    else
//                    {
//                        if (CoordonneeX >= 0 && CoordonneeX < 4 && CoordonneeY >= 0 && CoordonneeY < 4)
//                        {
//                            // on traite car les coordonnées sont acceptables
//                            if (ArrayOfUsedCells[CoordonneeX, CoordonneeY])
//                            {
//                                // La  case est déjà utilisée : on ne fait rien
//                            }
//                            else
//                            {
//                                // La case est libre donc utilisable donc
//                                // on crée une Case de coordonnées courantes 
//                                // qu'on ajoute à la liste des cases voisines de la case courante
//                                GameCell NeighborsCell = new GameCell();
//                                NeighborsCell.Pos.X = CoordonneeX;
//                                NeighborsCell.Pos.Y = CoordonneeY;
//                                NeighborsCell.Level = NextLevel;
//                                WorkingCell.ListOfPossibleNeighbor.Add(NeighborsCell);
//                            }
//                        }
//                        else
//                        {
//                            // on ne fait rien car au moins une des coordonnées est hors limites
//                        }
//                    }
//                }
//            }
//        }

//        //public char LetterOfCell(GameCell OneCell)
//        //{
//        //    return DonneesLettres.tableauDeLettres[OneCell.Pos.X, OneCell.Pos.Y];
//        //}

//        public void InitializePossibleWord()
//        {
//            for (int i = 0; i < 16; i++)
//            {
//                PossibleWord[i] = '.';
//            }
//        }

//        public void FindPossibleWord()
//        {
//            WordFind = "";
//            for (int i = 0; i < PossibleWord.Length; i++)
//            {
//                WordFind += PossibleWord[i];
//            }
//        }

//        public void BeginTree(int X, int Y)
//        {
//            InitialiseArrayOfUsedfCells();
//            InitializePossibleWord();
//            GameCell Root = new GameCell();
//            Root.Pos.X = X;
//            Root.Pos.Y = Y;
//            Root.Level = 0;
//            ArrayOfUsedCells[Root.Pos.X, Root.Pos.Y] = true;
//            PossibleWord[Root.Level] = LetterOfCell(Root);
//            FindAcceptablesNeighbors(Root);
//            ShowCell(Root);
//            //  GoOnTree(Root, Root.ListOfPossibleNeighbor[0]);
//            for (int round0 = 0; round0 < Root.ListOfPossibleNeighbor.Count; round0++)
//            {
//                Test += " Exploration n°" + round0.ToString() + " de puis la racine        \r\n";
//                GoOnTree(Root, Root.ListOfPossibleNeighbor[round0]);
//            }
//        }

//        public void GoOnTree(GameCell TopCell, GameCell DonwCell)
//        {
//            ArrayOfUsedCells[DonwCell.Pos.X, DonwCell.Pos.Y] = true;
//            PossibleWord[DonwCell.Level] = LetterOfCell(DonwCell);
//            FindAcceptablesNeighbors(DonwCell);
//            //  Test += "=>  " + "\r\n";
//            ShowCell(DonwCell);
//            if (DonwCell.ListOfPossibleNeighbor.Count == 0)
//            {
//                ArrayOfUsedCells[DonwCell.Pos.X, DonwCell.Pos.Y] = false;
//                PossibleWord[DonwCell.Level] = '*';
//                int MaxIndex = TopCell.ListOfPossibleNeighbor.Count;
//                // Vire la reference à la celulle courante de la liste de la cellule mère
//                for (int NumCell = 0; NumCell < MaxIndex; NumCell++)
//                {   // Vire de la liste des voisines possibles de la case de niveau supérieur la référence à la cellule en cours
//                    if (TopCell.ListOfPossibleNeighbor[NumCell].Pos.X == DonwCell.Pos.X &&
//                        TopCell.ListOfPossibleNeighbor[NumCell].Pos.Y == DonwCell.Pos.Y)
//                    {
//                        TopCell.ListOfPossibleNeighbor.RemoveAt(NumCell);
//                        NumCell = MaxIndex; //pour sortir
//                        Test += " # Remontée +\r\n";
//                    }
//                }
//            }
//            else
//            {
//                GoOnTree(DonwCell, DonwCell.ListOfPossibleNeighbor[0]);
//                if (DonwCell.ListOfPossibleNeighbor.Count != 0)
//                {
//                    ArrayOfUsedCells[DonwCell.Pos.X, DonwCell.Pos.Y] = false;
//                    PossibleWord[DonwCell.Level] = '|';
//                    Test += " @ Back step to top +\r\n";
//                }
//            }

//            //  ArrayOfUsedCells[DonwCell.X, DonwCell.Y] = false;
//        }

//        public void ShowCell(GameCell Cell)
//        {
//            Test +=
//                LetterOfCell(Cell).ToString() +
//                "  (" +
//                Cell.Pos.X.ToString() + "," +
//                Cell.Pos.Y.ToString() +
//                ")  Niveau = " +
//                Cell.Level.ToString() + "\r\n";

//            /* Test += "Voisines acceptables ";
//             for (int i = 0; i < Cell.ListOfPossibleNeighbor.Count; i++)
//             {
//                 Test += LetterOfCell(Cell.ListOfPossibleNeighbor[i]) + "  ";
//             }*/
//            Test += "\r\n";
//            FindPossibleWord();
//            Test += " Combinaison = " + WordFind + "\r\n";
//        }
//    }
//}
