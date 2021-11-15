using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    class Button : GuiObject
    {
        public Button(char buttonFrame1, char buttonFrame2,string text,int x = 0, int y = 0, int width = 0, int height = 0, int margin = 0) : base(x, y, width, height, margin)
        {
            ButtonText = new Text(words: text, xBase: X + 3, yBase: Y + 1, width: Width - 6, height: Height - 2);
            ButtonFrame1 = new Frame(buttonFrame1, X, Y, Width, Height);
            ButtonFrame2 = new Frame(buttonFrame2, X, Y - 1, Width, Height);
        }

        public Text ButtonText { get; set; }
        public Frame ButtonFrame1 { get; set; }
        public Frame ButtonFrame2 { get; set; }
        public Boolean ButtonOn { get; set; }

        public override void CleanGuiObject()
        {
            ButtonFrame1.CleanGuiObject();
            ButtonFrame2.CleanGuiObject();
            ButtonText.CleanGuiObject();
        }

        public override void DrawGuiObject()
        {
            ButtonFrame1.DrawGuiObject();
            ButtonText.DrawGuiObject();
        }

        public void ButtonTurnOn()
        {
            if (!ButtonOn)
            {
                ButtonFrame1.CleanGuiObject();
                ButtonFrame2.DrawGuiObject();
                ButtonOn = true;
            }
        }
        public void ButtonTurnOff()
        {
            if (ButtonOn)
            {
                ButtonFrame2.CleanGuiObject();
                ButtonFrame1.DrawGuiObject();
                ButtonOn = false;
            }
        }
    }
}
