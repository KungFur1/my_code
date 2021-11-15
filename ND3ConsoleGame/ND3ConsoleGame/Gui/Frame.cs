using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND3ConsoleGame.Gui
{
    class Frame : GuiObject
    {
        private char _borderChar;


        public Frame(int x, int y, int width, int height, char borderChar) : base(x, y, width, height)
        {
            _borderChar = borderChar;
        }



        public void DrawFrame ()
        {
            for (int y = Y; y <= Height + Y; y++)
            {
                for (int x = X; x <= Width + X; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == X || x == X + Width || y == Y || y == Y + Height)
                    {
                        Console.Write(_borderChar);

                    }
                }

            }
        }

        public void RemoveFrame ()
        {
            for (int y = Y; y <= Height + Y; y++)
            {
                for (int x = X; x <= Width + X; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == X || x == X + Width || y == Y || y == Y + Height)
                    {
                        Console.WriteLine(' ');
                    }


                }

            }
        }


    }
}
