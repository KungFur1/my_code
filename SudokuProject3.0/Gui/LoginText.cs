using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class LoginText : GuiObject
    {
        private string _realInput = "";
        private Text _input;
        private Boolean Secrete;
        public LoginText(string info, Boolean secrete = false, int x = 0, int y = 0, int width = 0, int height = 0, int margin = 0) : base(x, y, width, height, margin)
        {
            Frame1 = new Frame('@', X, Y, Width, Height);
            Frame2 = new Frame('#', X, Y, Width, Height);
            Info = new Text(info, false, false, X + 2, Y + 1, Width - 4, 1);
            Secrete = secrete;
            _input = new Text(" ", false, false, X + 2, Y + 2, Width - 4, 1);
            _input.Words[0] = "";
        }

        public Frame Frame1 { get; set; }
        public Frame Frame2 { get; set; }
        public Text Info { get; set; }


        public void TakeNumber(char symbol)
        {
            if (_input.Words.Count <= 20)
            {
                    _input = new Text(_input.Words[0] + symbol, _input.CenteredHorizontal, _input.CenteredVertically, _input.X, _input.Y, _input.Width, _input.Height);
                    _realInput += symbol;
            }
            GiveInput();
        }


        public override void CleanGuiObject()
        {
            Frame1.CleanGuiObject();
            Info.CleanGuiObject();
            _input.CleanGuiObject();
        }

        public override void DrawGuiObject()
        {
            Frame1.DrawGuiObject();
            Info.DrawGuiObject();
        }

        public void Selected()
        {
            Frame1.CleanGuiObject();
            Frame2.DrawGuiObject();
        }

        public void Unselected()
        {
            Frame2.CleanGuiObject();
            Frame1.DrawGuiObject();
        }

        public void GiveInput()
        {
            _input.CleanGuiObject();
            if (Secrete)
            {
                Console.SetCursorPosition(_input.X, _input.Y);
                int i = 0;
                foreach (char symbol in _input.Words[0])
                {
                    if (symbol == '.' && _input.Words.Count - 3 <= i)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write('*');
                    }
                    i++;
                }
            }
            else
            {
                _input.CleanGuiObject();
                _input.DrawGuiObject();
            }
        }

        
    }
}
