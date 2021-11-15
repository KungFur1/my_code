using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    abstract class GuiObject
    {
        public GuiObject(int x = 0, int y = 0, int width = 0, int height = 0, int margin = 0)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Margin = margin;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int Margin { get; set; }


        public abstract void DrawGuiObject();
        public abstract void CleanGuiObject();
    }
}
