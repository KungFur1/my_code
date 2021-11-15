using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class ComplexGuiObject
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }
        private float _oldX;
        private float _oldY;
        private List<Symbol> _appearance;

        public ComplexGuiObject(float x, float y, float width, float height, float speedX, float speedY, List<Symbol> appearance)
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

        public void Update()
        {
            UpdateLocation();
            if (!((int)_oldX == (int)X && (int)_oldY == (int)Y))
            {
                CleanAndPrintObject();
            }
        }

        public void CleanAndPrintObject()
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

        public void CleanObject()
        {
            foreach (Symbol symbol in _appearance)
            {
                symbol.ClearOldLocation(_oldX, _oldY);
            }
        }

        private void UpdateLocation()
        {
            _oldX = X;
            _oldY = Y;
            X += SpeedX;
            Y += SpeedY;
        }

    }
}
