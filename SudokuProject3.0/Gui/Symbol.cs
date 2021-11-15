using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class Symbol
    {
        public char Character { get; set; }
        public int DistanceX { get; set; }
        public int DistanceY { get; set; }

        public Symbol(char symbol, int distanceX, int distanceY)
        {
            Character = symbol;
            DistanceX = distanceX;
            DistanceY = distanceY;
        }

        public void ClearOldLocation(float x, float y)
        {
            Console.SetCursorPosition((int)x + DistanceX, (int)y + DistanceY);
            Console.Write(' ');
        }

        public void DrawNewLocation(float x, float y)
        {
            Console.SetCursorPosition((int)x + DistanceX, (int)y + DistanceY);
            Console.Write(Character);
        }

    }
}
