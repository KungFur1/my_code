using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class Frame : GuiObject
    {
        public Frame(char border = '@', int x = 0, int y = 0, int width = 0, int height = 0, int margin = 0) : base(x, y, width, height, margin)
        {
            Border = border;
        }

        public char Border { get; set; }

        public override void CleanGuiObject()
        {
            Console.SetCursorPosition(X, Y);
            for (int x = 0; x <= Width; x++)
            {
                Console.Write(' ');
            }
            Console.SetCursorPosition(X, Y + Height);
            for (int x = 0; x <= Width; x++)
            {
                Console.Write(' ');
            }
            for (int y = 0; y <= Height; y++)
            {
                Console.SetCursorPosition(X, Y + y);
                Console.Write(' ');
            }
            for (int y = 0; y <= Height; y++)
            {
                Console.SetCursorPosition(X + Width, Y + y);
                Console.Write(' ');
            }
        }

        public override void DrawGuiObject()
        {
            Console.SetCursorPosition(X, Y);
            for (int x = 0; x <= Width; x++)
            {
                Console.Write(Border);
            }
            Console.SetCursorPosition(X, Y + Height);
            for (int x = 0; x <= Width; x++)
            {
                Console.Write(Border);
            }
            for (int y = 0; y <= Height; y++)
            {
                Console.SetCursorPosition(X, Y + y);
                Console.Write(Border);
            }
            for (int y = 0; y <= Height; y++)
            {
                Console.SetCursorPosition(X + Width, Y + y);
                Console.Write(Border);
            }
        }
    }
}
