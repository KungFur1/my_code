using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ND3ConsoleGame.GameObjects;
using ND3ConsoleGame.GameObjectsInterfaces;
using ND3ConsoleGame.Maps;
using ND3ConsoleGame.Screens;
using ND3ConsoleGame.Gui;

namespace ND3ConsoleGame.GameObjects
{
    abstract class GameObject
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }
        private float _oldX;
        private float _oldY;
        public const float GameSpeed = 0.000005f;
        private List<Symbol> _appearance;
        abstract public void Collision();


        //Objects Birth
        public GameObject (float x, float y, float width, float height, float speedX, float speedY, List<Symbol> appearance)
        {
            X = x;
            Y = y;
            _oldX = X;
            _oldY = Y;
            SpeedX = speedX;
            SpeedY = speedY;
            _appearance = appearance;
            Width = width;
            Height = height;
        }

        //Updating Object
        private void CleanAndPrintObject()
        {
            foreach (Symbol symbol in _appearance)
            {
                symbol.ClearOldLocation(_oldX, _oldY);
            }
            foreach (Symbol symbol in _appearance)
            {
                symbol.DrawNewLocation(X, Y);
            }
        }

        private void UpdateLocation ()
        {
            _oldX = X;
            _oldY = Y;
            X += SpeedX;
            Y += SpeedY;
        }

        public void Update()
        {
            UpdateLocation();
            if (!((int)_oldX == (int)X && (int)_oldY == (int)Y))
            {
                CleanAndPrintObject();
            }
        }

        //Objects Death
        public void CleanObject()
        {
            foreach (Symbol symbol in _appearance)
            {
                symbol.ClearOldLocation(X, Y);
            }
        }

        //



    }
}
