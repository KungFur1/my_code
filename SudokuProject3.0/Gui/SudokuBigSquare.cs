using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class SudokuBigSquare : GuiObject
    {
        public Boolean IsBasic { get; set; }
        public Boolean IsWrong { get; set; }
        public Boolean IsSpecial { get; set; }
        private Frame _wrongFrame;
        private Frame _specialFrame;
        private Frame _basicFrame;
        public SudokuSquare[,] SmallSquares { get; set; } = new SudokuSquare[3, 3];

        public SudokuBigSquare(int x = 0, int y = 0, int width = 0, int height = 0, int margin = 0) : base(x, y, width, height, margin)
        {
            IsBasic = true;
            _wrongFrame = new Frame('@', X, Y, Width, Height);
            _specialFrame = new Frame('%', X, Y, Width, Height);
            _basicFrame = new Frame('#', X, Y, Width, Height);
            for (int yLocal = 0; yLocal < 3; yLocal++)
            {
                for (int xLocal = 0; xLocal < 3; xLocal++)
                {
                    SmallSquares[xLocal, yLocal] = new SudokuSquare(x: X + xLocal * 10 + 3, y: Y + yLocal * 4 + 1, width: 7, height: 4);
                }
            }
        }

        public override void CleanGuiObject()
        {
            _specialFrame.CleanGuiObject();
            foreach (SudokuSquare square in SmallSquares)
            {
                square.CleanGuiObject();
            }
        }

        public override void DrawGuiObject()
        {
            DrawFrame();
            WriteAllSquares();
        }

        public void WriteAllSquares()
        {
            foreach (SudokuSquare square in SmallSquares)
            {
                square.WriteAnwser();
            }
        }

        public void WriteSpecificAnwser(int x, int y)
        {
            SmallSquares[x, y].CleanAnwser();
            SmallSquares[x, y].WriteAnwser();
        }

        public void DrawSpecificSquare(int x, int y)
        {
            SmallSquares[x, y].DrawFrame();
        }

        public void DrawFrame()
        {
            if (IsSpecial)
            {
                _specialFrame.DrawGuiObject();
            }
            else if (IsWrong)
            {
                _wrongFrame.DrawGuiObject();
            }
            else if (IsBasic)
            {
                _basicFrame.DrawGuiObject();
            }
        }

        public void CleanFrame()
        {
            if (IsSpecial)
            {
                _specialFrame.CleanGuiObject();
            }
            else if (IsWrong)
            {
                _wrongFrame.CleanGuiObject();
            }
            else if (IsBasic)
            {
                _basicFrame.CleanGuiObject();
            }
        }
    }
}
