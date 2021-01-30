using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    class GameState
    {
        private readonly char[] m_lettersGrid = new char[16];
        private readonly bool[,] m_clickedCells = new bool[4, 4];
        private Point2D m_lastClickedCell = null;

        public char GetCellContentAtPosition(int x, int y)
        {
            return m_lettersGrid[y * 4 + x];
        }

        public char GetCellContentAtIndex(int index)
        {
            return m_lettersGrid[index];
        }

        public void SetCellContentAtIndex(int index, char c)
        {
            m_lettersGrid[index] = c;
        }

        // renvoi le nombre d'occurences de la lettre dans matrice ([0..15] of char
        public int NumberTimesLetterAppearInGrid(char c) 
        {
            int returned = 0;
            for (int i = 0; i < m_lettersGrid.Length - 1; i++)
            {
                if (m_lettersGrid[i] == c)
                {
                    returned++;
                }
            }
            return returned;
        }

        public void ResetClickedCells()
        {   // met toutes les case du tablo des cases cochées = false
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    m_clickedCells[i, j] = false;
                }
            }

            m_lastClickedCell = null;
        }

        public bool IsValidClick(int x, int y)
        {
            // first click is always valid
            if (m_lastClickedCell == null)
            {
                return true;
            }
            else
            {
                // Invalid click if cell has already been clicked
                if (m_clickedCells[x, y])
                {
                    return false;
                }
                else
                {
                    // otherwise check that the new click is a direct neighbor of the last click

                    int lastX = m_lastClickedCell.X;
                    int lastY = m_lastClickedCell.Y;

                    return
                        Math.Abs(x - lastX) <= 1 &&
                        Math.Abs(y - lastY) <= 1;
                }
            }
        }

        internal void PushClick(int x, int y)
        {
            if (!IsValidClick(x, y))
            {
                throw new Exception("Invalid click");
            }

            m_clickedCells[x, y] = true;

            m_lastClickedCell = 
                new Point2D()
                {
                    X = x,
                    Y = y
                };

        }
    }

}
