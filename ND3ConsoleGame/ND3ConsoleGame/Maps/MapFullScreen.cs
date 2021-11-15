using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ND3ConsoleGame.GameObjects;
using ND3ConsoleGame.GameObjectsInterfaces;
using ND3ConsoleGame.Maps;
using ND3ConsoleGame.Screens;

namespace ND3ConsoleGame.Maps
{
    class MapFullScreen
    {
        private static int ConsolePixelsWidth = 1679;
        private static int ConsolePixelsHeight = 799;
        public static int ScreenWidth;
        public static int ScreenHeight;


        public MapFullScreen (int size)
        {
            switch (size)
            {
                case 18:
                    ScreenWidth = Convert.ToInt16(ConsolePixelsWidth / 8);
                    ScreenHeight = Convert.ToInt16(ConsolePixelsHeight / 18);
                    break;
                case 16:
                    ScreenWidth = Convert.ToInt16(ConsolePixelsWidth / 8);
                    ScreenHeight = Convert.ToInt16(ConsolePixelsHeight / 16);
                    break;
                case 12:
                    ScreenWidth = Convert.ToInt16(ConsolePixelsWidth / 6);
                    ScreenHeight = Convert.ToInt16(ConsolePixelsHeight / 12);
                    break;
                case 8:
                    ScreenWidth = Convert.ToInt16(ConsolePixelsWidth / 4);
                    ScreenHeight = Convert.ToInt16(ConsolePixelsHeight / 8);
                    break;
            }
        }

        public void DrawMap ()
        {
            for (int y = 0; y <= ScreenHeight; y++)
            {
                for (int x = 0; x <= ScreenWidth; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == 0 || x == ScreenWidth || y == 0 || y == ScreenHeight)
                    {
                        Console.Write('@');

                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

            }
        }
    }
}
