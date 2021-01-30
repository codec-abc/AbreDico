namespace AbreDico
{
    // [Nonbre de points associés, consonne (0) ou Voyelle (1),Type de la lettre]
    // Type de la lettre 0:courante ,1: moyennement chiante, 2:assez chiante 3: très chiante.
    // Classes 
    public class GameScore
    {
        // GERE LES SCORES
        private int m_wordScore;
        private int m_totalScore;

        public int GetWordScore()
        {
            return m_wordScore;
        }

        public int GetTotalScore()
        {
            return m_totalScore;
        }

        public void ResetWordScore()
        {
            m_wordScore = 0;
        }

        public void AddPointsToWordScore(int ScoreLettre)
        {
            m_wordScore += ScoreLettre; // remplacer par nb point du mot
        }

        public void AddPointsToTotalScore(int ScoreMot)
        {
            m_totalScore += ScoreMot;
        }

        public void ResetTotalScore()
        {
            m_totalScore = 0;
        }


    }

}
