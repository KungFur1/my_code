using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    static class GuiTools
    {
        public static List<Symbol> CombineLetters(List<Symbol>[] letters, int distanceBetweenLetters)
        {
            int letterNr = 0;
            List<Symbol> retVal = new List<Symbol>();
            foreach (List<Symbol> symbols in letters)
            {
                foreach (Symbol symbol in symbols)
                {
                    symbol.DistanceX += distanceBetweenLetters * letterNr;
                    retVal.Add(symbol);
                }
                letterNr++;
            }
            return retVal;
        }

        public static List<Symbol> LetterS = new List<Symbol> { new Symbol('#', 0, 1), new Symbol('#', 0, 2), new Symbol('#', 0, 3), new Symbol('#', 0, -1), new Symbol('#', 0, -2), new Symbol('#', 0, -3), new Symbol('#', -1, 3), new Symbol('#', -2, 3), new Symbol('#', -3, 3), new Symbol('#', -4, 3), new Symbol('#', -5, 3), new Symbol('#', -6, 3), new Symbol('#', 1, -3), new Symbol('#', 2, -3), new Symbol('#', 3, -3), new Symbol('#', 4, -3), new Symbol('#', 5, -3), new Symbol('#', 6, -3),
            new Symbol('#', 1, 0), new Symbol('#', 2, 0),  new Symbol('#', 1, 1),  new Symbol('#', 1, -1),  new Symbol('#', 3, 0), new Symbol('#', 2, 1),  new Symbol('#', 2, -1),
            new Symbol('#', -1, -2),  new Symbol('#', -1, -3),  new Symbol('#', 0, -4), new Symbol('#', 1, -4), new Symbol('#', 1, -2), new Symbol('#', -2, -3),
            new Symbol('#', 1, 2),  new Symbol('#', 1, 3), new Symbol('#', -1, 2),
        };

        public static List<Symbol> LetterU = new List<Symbol> { new Symbol('#', 0, 3), new Symbol('#', 1, 2), new Symbol('#', -1, 2), new Symbol('#', -3, 1), new Symbol('#', 3, 1), new Symbol('#', 3, 0), new Symbol('#', -3, 0), new Symbol('#', 3, -1), new Symbol('#', -3, -1), new Symbol('#', 3, -2), new Symbol('#', -3, -2), new Symbol('#', -3, 2), new Symbol('#', 3, 2),
            new Symbol('#', -4, 1), new Symbol('#', 4, 1), new Symbol('#', 4, 0), new Symbol('#', -4, 0), new Symbol('#', 4, -1), new Symbol('#', -4, -1), new Symbol('#', 4, -2), new Symbol('#', -4, -2),
        };

        public static List<Symbol> LetterD = new List<Symbol> { new Symbol('#', -4, 0), new Symbol('#', -4, 1), new Symbol('#', -4, 2), new Symbol('#', -4, 3), new Symbol('#', -4, -1), new Symbol('#', -4, -2), new Symbol('#', -4, -3),
            new Symbol('#', -5, 0), new Symbol('#', -5, 1), new Symbol('#', -5, 2), new Symbol('#', -5, 3), new Symbol('#', -5, -1), new Symbol('#', -5, -2), new Symbol('#', -5, -3),
             new Symbol('#', -3, 3),  new Symbol('#', -2, 3),  new Symbol('#', -1, 3),  new Symbol('#', 0, 3),  new Symbol('#', 1, 2),  new Symbol('#', 2, 2),  new Symbol('#', 3, 1),  new Symbol('#', 4, 0),
             new Symbol('#', -3, -3),  new Symbol('#', -2, -3),  new Symbol('#', -1, -3),  new Symbol('#', 0, -3),  new Symbol('#', 1, -2),  new Symbol('#', 2, -2),  new Symbol('#', 3, -1),
             //new Symbol('#', 1, 2), new Symbol('#', 1, -2), new Symbol('#', 1, 3), new Symbol('#', 1, -3),
             //new Symbol('#', -3, 2), new Symbol('#', -2, 2), new Symbol('#', -3, -2), new Symbol('#', -2, -2), new Symbol('#', -1, 2), new Symbol('#', -1, -2),
        };

        public static List<Symbol> LetterK = new List<Symbol> { new Symbol('#', -5, 0), new Symbol('#', -5, 1), new Symbol('#', -5, 2), new Symbol('#', -5, 3), new Symbol('#', -5, -1), new Symbol('#', -5, -2), new Symbol('#', -5, -3),
            new Symbol('#', -4, 0), new Symbol('#', -4, 1), new Symbol('#', -4, 2), new Symbol('#', -4, 3), new Symbol('#', -4, -1), new Symbol('#', -4, -2), new Symbol('#', -4, -3),
            new Symbol('#', -3, 0),
            new Symbol('#', -3, 1), new Symbol('#', -2, 1), new Symbol('#', -1, 1), new Symbol('#', 0, 1), new Symbol('#', -1, 2), new Symbol('#', 0, 2), new Symbol('#', 1, 2), new Symbol('#', 2, 2), new Symbol('#', 0, 3), new Symbol('#', 1, 3), new Symbol('#', 2, 3), new Symbol('#', 3, 3), new Symbol('#', 4, 3),
            new Symbol('#', -3, -1), new Symbol('#', -2, -1), new Symbol('#', -1, -1), new Symbol('#', -1, -2), new Symbol('#', 0, -2), new Symbol('#', 1, -2), new Symbol('#', 0, -3), new Symbol('#', 1, -3), new Symbol('#', 2, -3), new Symbol('#', 3, -3),

        };

        public static List<Symbol> LetterO = new List<Symbol> { new Symbol('#', 0, 3), new Symbol('#', 1, 3), new Symbol('#', 2, 3), new Symbol('#', 2, 2), new Symbol('#', 3, 2), new Symbol('#', 3, 1), new Symbol('#', 3, 0), new Symbol('#', 4, 0),
            new Symbol('#', -1, 3), new Symbol('#', -2, 3), new Symbol('#', -2, 2), new Symbol('#', -3, 2), new Symbol('#', -3, 1), new Symbol('#', -3, 0), new Symbol('#', -4, 0),
            new Symbol('#', -1, -3), new Symbol('#', -2, -3), new Symbol('#', -2, -2), new Symbol('#', -3, -2), new Symbol('#', -3, -1),
            new Symbol('#', 0, -3), new Symbol('#', 1, -3), new Symbol('#', 2, -3), new Symbol('#', 2, -2), new Symbol('#', 3, -2), new Symbol('#', 3, -1),
        };

        public static List<Symbol> CopyLetter(List<Symbol> letter)
        {
            List<Symbol> retVal = new List<Symbol>();
            foreach (Symbol symbol in letter)
            {
                retVal.Add(new Symbol(symbol.Character, symbol.DistanceX, symbol.DistanceY));
            }
            return retVal;
        }
        
        }
}
