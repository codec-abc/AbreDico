namespace AbreDico
{
    // [Nonbre de points associés, consonne (0) ou Voyelle (1),Type de la lettre]
    // Type de la lettre 0:courante ,1: moyennement chiante, 2:assez chiante 3: très chiante.
    // Classes 
    public class DataGame
    {
        // GERE LES SCORES
        public int scoreMotJoueur;
        public int ScoreTotal;

        public void RazScoreMotJoueur()
        {
            scoreMotJoueur = 0;
        }

        public void ActualiseScoreMotJoeur(int ScoreLettre)
        {
            scoreMotJoueur += ScoreLettre; // remplacer par nb point du mot
        }

        public void RazScoreTotal()
        {
            ScoreTotal = 0;
        }

        public void ActualiseScoreTotal(int ScoreMot)
        {
            ScoreTotal += ScoreMot;
        }
    }

}
