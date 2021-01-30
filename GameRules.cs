using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreDico
{
    class GameRules
    {
        private char[] m_commonVowel = { 'A', 'E', 'I', 'O', 'U' };

        //private readonly char[] DifficultLetters = { 'W', 'X', 'J', 'Q', 'V', 'K', 'Y', 'H' };

        private readonly char[] m_letters = new char[26];
        private readonly int[] m_isLetterVowel = new int[26]; //consonne (0) ou Voyelle (1)
        private readonly int[] m_scoreByLetter = new int[26];
        private readonly int[] m_difficultyByLetter = new int[26];

        public GameRules()
        {
            BuildAlphabet();
            BuildIsLetterVowel();
            BuildScoreByLetter();
            BuildDifficultyByLetter();
        }

        public char[] GetLetters()
        {
            return (char[]) m_letters.Clone();
        }

        public int[] GetScoreByLetter()
        {
            return (int[])m_scoreByLetter.Clone();
        }

        public int[] GetDifficultyByLetter()
        {
            return (int[])m_difficultyByLetter.Clone();
        }

        public char[] GetCommonVowels()
        {
            return (char[])m_commonVowel.Clone();
        }

        private void BuildAlphabet()
        {
            for (int i = 65; i < 91; i++)
            {
                m_letters[i - 65] = Convert.ToChar(i);
            }
        }

        private void BuildIsLetterVowel()
        {
            for (int i = 0; i < 26; i++)
            {
                m_isLetterVowel[i] = 0; // Lettre courante (mis en consonne par défaut)
            }
            //voyelles*
            m_isLetterVowel[0] = 1; //A
            m_isLetterVowel[4] = 1; //E 
            m_isLetterVowel[8] = 1; //I
            m_isLetterVowel[14] = 1; //O
            m_isLetterVowel[20] = 1; //U
            m_isLetterVowel[24] = 1; //Y
        }
        private void BuildScoreByLetter()
        {
            for (int i = 0; i < 26; i++)
            {
                m_scoreByLetter[i] = 1; // Lettres communes
            }
            m_scoreByLetter[5] = 4; //F
            m_scoreByLetter[6] = 2; //G
            m_scoreByLetter[7] = 4; //H
            m_scoreByLetter[10] = 10; //K
            m_scoreByLetter[11] = 2; //L
            m_scoreByLetter[12] = 2; //M
            m_scoreByLetter[15] = 3; //P
            m_scoreByLetter[16] = 8; //Q
            m_scoreByLetter[21] = 5; //V
            m_scoreByLetter[22] = 15; //W
            m_scoreByLetter[23] = 10; //X
            m_scoreByLetter[24] = 8; //Y
            m_scoreByLetter[25] = 10; //Z
        }

        internal bool IsLetterVowel(char a)
        {
            var index = -1;
            for (int i = 0; i < m_letters.Length; i++)
            {
                if (m_letters[i] == a)
                {
                    index = i;
                }
            }
            return m_isLetterVowel[index] != 0;
        }

        private void BuildDifficultyByLetter()
        {
            for (int i = 0; i < 26; i++)
            {
                m_difficultyByLetter[i] = 0; // Sans difficulté
            }

            for (int i = 11; i < 16; i++)
            {
                m_difficultyByLetter[i] = 1; // L M N O P peu de difficulté
            }

            m_difficultyByLetter[5] = 2; // F  difficulté moyenne
            m_difficultyByLetter[20] = 2;//U
            m_difficultyByLetter[14] = 2;//O
            m_difficultyByLetter[6] = 2; //G
            m_difficultyByLetter[7] = 3; // H difficulté prononcée
            m_difficultyByLetter[21] = 3;//V
            m_difficultyByLetter[10] = 4; // difficulté très prononcée 
            m_difficultyByLetter[9] = 4;  //J
            m_difficultyByLetter[16] = 4;//Q

            for (int i = 22; i < 26; i++) // W X Y Z
            {
                m_difficultyByLetter[i] = 4;
            }
        }

        public bool IsVowel(char lettre)
        {
            bool returned = false;
            for (int i = 0; i < m_commonVowel.Length; i++)
            {
                if (m_commonVowel[i] == lettre)
                {
                    returned = true;
                }
            }
            return returned;
        }

        public int NumberOfVowelsInMatrix(char[] matrix)
        {
            int nbVowel = 0;
            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < m_commonVowel.Length; k++)
                {
                    if (matrix[j] == m_commonVowel[k]) { nbVowel++; };
                }
            }
            return nbVowel;
        }
    }
}
