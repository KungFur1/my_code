using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ND3ConsoleGame.GameObjects;
using ND3ConsoleGame.GameObjectsInterfaces;
using ND3ConsoleGame.Maps;
using ND3ConsoleGame.Screens;

namespace ND3ConsoleGame.GameObjects
{
    class Symbol
    {
        private char _symbol;
        private int _distanceX;
        private int _distanceY;

        public Symbol(char symbol, int distanceX, int distanceY)
        {
            _symbol = symbol;
            _distanceX = distanceX;
            _distanceY = distanceY;
        }

        public void ClearOldLocation(float x, float y)
        {
            Console.SetCursorPosition((int)x + _distanceX, (int)y + _distanceY);
            Console.Write(' ');
        }

        public void DrawNewLocation(float x, float y)
        {
            Console.SetCursorPosition((int)x + _distanceX, (int)y + _distanceY);
            Console.Write(_symbol);
        }

    }
}
