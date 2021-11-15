using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND3ConsoleGame.Gui
{
    class TextLine : GuiObject
    {
        private string _text;


        public TextLine (int x, int y, int width, string text) : base(x + Convert.ToInt32((width - text.Length)/2), y, width, 1)
        {
            _text = text;
        }

        public void WriteTextLine ()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(_text);
        }

    }
}
