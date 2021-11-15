using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class SudokuTable : GuiObject
    {
        public SudokuTable(int x = 0, int y = 0, int width = 0, int height = 0, int margin = 0) : base(x, y, width, height, margin)
        {
            for (int yLocal = 0; yLocal < 3; yLocal++)
            {
                for (int xLocal = 0; xLocal < 3; xLocal++)
                {
                    BigSquares[xLocal, yLocal] = new SudokuBigSquare(X + xLocal * 33, Y + yLocal * 15, 32, 15);
                }
            }
        }

        public SudokuBigSquare[,] BigSquares = new SudokuBigSquare[3, 3];

        public override void CleanGuiObject()
        {
            foreach (SudokuBigSquare bigSquare in BigSquares)
            {
                bigSquare.CleanGuiObject();
            }
        }

        public override void DrawGuiObject()
        {
            foreach  (SudokuBigSquare bigSquare in BigSquares)
            {
                bigSquare.DrawGuiObject();
            }
        }
    }
}
