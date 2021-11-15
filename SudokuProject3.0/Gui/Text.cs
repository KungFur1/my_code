using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class Text : GuiObject
    {
        public Text(string words = "", Boolean centeredHorizontal = true, Boolean centeredVertically = true,int xBase = 0, int yBase = 0, int width = 0, int height = 0, int margin = 0) : base(xBase, yBase, width, height, margin)
        {
            CenteredHorizontal = centeredHorizontal;
            CenteredVertically = centeredVertically;
            int firstChar = 0;
            int secondChar = 0;
            for (int selectedChar = 0; selectedChar < words.Length; selectedChar++)
            {
                if (words[selectedChar] == ' ')
                {
                    secondChar = selectedChar;
                }
                if (selectedChar - firstChar >= Width)
                {
                    if (firstChar - secondChar != 0)
                    {
                        if (CenteredHorizontal)
                        {
                            Words.Add(CreateEmptyString((Width - (secondChar - firstChar)) / 2) + words.Substring(firstChar, secondChar - firstChar));
                        }
                        else
                        {
                            Words.Add(words.Substring(firstChar, secondChar - firstChar));
                        }
                    }
                    else
                    {
                        if (CenteredHorizontal)
                        {
                            Words.Add(CreateEmptyString((Width - (selectedChar - firstChar)) / 2) + words.Substring(firstChar, selectedChar - firstChar));
                        }
                        else
                        {
                            Words.Add(words.Substring(firstChar, selectedChar - firstChar));
                        }
                        secondChar = selectedChar;
                    }
                    firstChar = secondChar;
                    selectedChar = secondChar;
                }
                else if (selectedChar == words.Length - 1)
                {
                    if (CenteredHorizontal)
                    {
                        Words.Add(CreateEmptyString((Width - (selectedChar - firstChar)) / 2) + words.Substring(firstChar, selectedChar - firstChar + 1));
                    }
                    else
                    {
                        Words.Add(words.Substring(firstChar, selectedChar - firstChar + 1));
                    }
                }
            }
            if (Words.Count > Height)
            {
                for (int y = Words.Count; y > Height; y--)
                {
                    Words.RemoveAt(y-1);
                }
                for (int y = Words[Words.Count - 1].Length; y > Width - 3; y--)
                {
                    Words[Words.Count - 1] = Words[Words.Count - 1].Remove(Words[Words.Count - 1].Length - 1, 1);
                }
                Words[Words.Count - 1] += "...";
            }
            else if (Words.Count < Height && CenteredVertically)
            {
                for (int y = 0; y <= (Height - Words.Count) / 2; y++)
                {
                    Words.Insert(0, " ");
                }
            }
        }
        

        public List<string> Words { get; set; } = new List<string>();
        public Boolean CenteredHorizontal { get; set; }
        public Boolean CenteredVertically { get; set; }


        public void WriteText()
        {
            foreach (string text in Words)
            {
                Console.WriteLine(text);
            }
        }

        public void CleanText()
        {

        }

        private string CreateEmptyString(int length)
        {
            string retVal = "";
            for (int i = 0; i < length; i++)
            {
                retVal += ' ';
            }
            return retVal;
        }

        public override void DrawGuiObject()
        {
            int y = 0;
            foreach (string line in Words)
            {
                Console.SetCursorPosition(X, y + Y);
                Console.Write(line);
                y++;
            }
        }
        
        public override void CleanGuiObject()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Console.SetCursorPosition(x + X, y + Y);
                    Console.Write(' ');
                }
            }
        }
    }
}
