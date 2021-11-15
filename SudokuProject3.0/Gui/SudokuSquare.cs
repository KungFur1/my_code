using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class SudokuSquare : GuiObject
    {

        public Boolean IsWrong { get; set; }
        public Boolean IsSpecial { get; set; }
        public int Number { get; set; }
        private Frame _wrongFrame;
        private Frame _specialFrame;

        public SudokuSquare(int number = 0, int x = 0, int y = 0, int width = 0, int height = 0, int margin = 0) : base(x, y, width, height, margin)
        {
            Number = number;
            _wrongFrame = new Frame('@', X, Y, Width, Height);
            _specialFrame = new Frame('+', X, Y, Width, Height);
        }

        public override void CleanGuiObject()
        {
            _specialFrame.CleanGuiObject();
            CleanAnwser();
        }

        public override void DrawGuiObject()
        {
            DrawFrame();
            WriteAnwser();
        }

        public void DrawFrame()
        {
            if (IsSpecial)
            {
                _specialFrame.DrawGuiObject();
            }
            else if(IsWrong)
            {
                _wrongFrame.DrawGuiObject();
            }
        }

        public void CleanFrame()
        {
            if (!IsSpecial && !IsWrong)
            {
                _specialFrame.CleanGuiObject();
            }
        }

        public void WriteAnwser()
        {
            if (Number != 0)
            {
                Console.SetCursorPosition(X + Width/2, Y + Height/2);
                Console.Write(Number);
            }
        }

        public void CleanAnwser()
        {
            Console.SetCursorPosition(X + Width/2, Y + Height/2);
            Console.Write(' ');
        }
    }
}
