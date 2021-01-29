using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WordDictionary
{
    class DictonaryTreeNode
    {
        public char Letter { get; set; }
        public bool IsLetterEndOfWord { get; set; }
        public Dictionary<char, DictonaryTreeNode> NextLetters;
    }

    private DictonaryTreeNode m_root;

    public WordDictionary(string[] wordList)
    {
        this.m_root = BuildDictionary(wordList);
    }

    public bool IsWordValid(string word)
    {
        int wordLength = word.Length;
        var currentNode = this.m_root;
        for (int i = 0; i < wordLength; i++) // Faire pour toutes les lettres du mot
        {
            char currentLetter = word[i];
            if (currentNode.NextLetters != null) // le Dictionnaire du noeud examiné n'est pas null
            {
                if (currentNode.NextLetters.ContainsKey(currentLetter))//le dico contient la lettre du mot
                {
                    currentNode = currentNode.NextLetters[currentLetter]; // affectation du noeud trouvé pour la lettre pour le tour de boucle suivant                           
                }
                else
                {  // la lettre n'est pas trouvée !
                    return false;
                }
            }
            else
            {
                //le dictionnaire est null
                if (i != wordLength)
                {
                    return false;
                } // si ce n'est pas la fin de mot c'est anormal on retourne false
                else
                {
                    return true;
                }// si fin de mot c'est normal on retourne true
            }
        }
        if (currentNode.IsLetterEndOfWord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static DictonaryTreeNode BuildDictionary(string[] wordList)
    {
        //création de la racine
        DictonaryTreeNode root = new DictonaryTreeNode
        {
            Letter = ' ',
            IsLetterEndOfWord = false,
            NextLetters = null
        };

        // traitement des mots               
        for (int i = 0; i <= wordList.Length - 1; i++)  // traitement des lettres du mot
        {
            string mot = wordList[i];
            // Création de la branche correspondant au mot par passage du noeud racine à la prcédure récussive VerifAjouteLettre                     
            HandleLetterOfWord(root, 0, mot);
        }

        return root; // affecte à NoeudRacineConstructionArbre accessible partout dans form1 la valeur du pointeur de Racine
    }
    private static void HandleLetterOfWord(DictonaryTreeNode parentNode, int letterIndex, string Word)  //Création de l'arbre 
    {
        if (Word.Length == 0)
        {
            return;
        } // n'effectue pas le traitement pour un mot vide

        char currentLetter = Word[letterIndex];

        if (parentNode.NextLetters == null)
        {   // si le dico n'existe pas on en crée un vierge
            parentNode.NextLetters = new Dictionary<char, DictonaryTreeNode>();
        }

        if (parentNode.NextLetters.ContainsKey(currentLetter))//le dico existe et  si la clé existe
        {
            foreach (var kvp in parentNode.NextLetters)
            {  // on cherche la clé (lettre)
                if (kvp.Key == currentLetter) // clé identifiée 
                {
                    letterIndex++; //(pour lettre suivante du mot)
                    if (letterIndex < Word.Length) //-1 viré
                    { // si le traitement du mot n'est pas fini on appelle récursivement la procédure 
                      // en passant le noeud courant le rang incrémenté et le mot en paramètre.
                      // MessageBox.Show("Le dico du noeud père contient " + l + "du mot " + Word + " On cherche " + Word[rang]);
                        HandleLetterOfWord(kvp.Value, letterIndex, Word);
                    }
                }
            }
        }
        else
        {
            //le dico existe et  clé pas trouvée => ajout noeud dans dico
            DictonaryTreeNode childNode = new DictonaryTreeNode
            {
                Letter = currentLetter
            };

            if (letterIndex == Word.Length - 1)
            {   // dernière lettre du mot  : On ajoute le noeud correspondant
                childNode.IsLetterEndOfWord = true;
                parentNode.NextLetters.Add(currentLetter, childNode);
                return;
            }

            else
            {   // PAS dernière lettre du mot  : On ajoute le noeud correspondant et on incémente rang et on relance récursivement la procédure
                childNode.IsLetterEndOfWord = false;
                parentNode.NextLetters.Add(currentLetter, childNode);
                letterIndex++;
                HandleLetterOfWord(childNode, letterIndex, Word);
            }
        }
    }
}
