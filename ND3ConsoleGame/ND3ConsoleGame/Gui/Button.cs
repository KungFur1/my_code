using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND3ConsoleGame.Gui
{
    class Button : GuiObject
    {
        private List<TextLine> _buttonTextLines = new List<TextLine>();
        private Frame _buttonFrame1;
        private Frame _buttonFrame2;


        public Button (int x, int y, int width, int height, char frame1Char, char frame2Char, List<string> buttonTextLines) : base (x, y, width, height)
        {
            _buttonFrame1 = new Frame(X, Y, Width, Height, frame1Char);
            _buttonFrame2 = new Frame(X, Y, Width, Height, frame2Char);
            int vertical = 0;
            foreach (string line in buttonTextLines)
            {
                _buttonTextLines.Add(new TextLine(X + 1, Convert.ToInt32(Y + (height - buttonTextLines.Count + 2)/2 + vertical), width - 2, line));
                vertical++;
            }
        }

        private void DrawFrame1()
        {
            _buttonFrame1.DrawFrame();
        }
        private void DrawFrame2()
        {
            _buttonFrame2.DrawFrame();
        }
        private void CleanFrame1()
        {
            _buttonFrame1.RemoveFrame();
        }
        private void CleanFrame2()
        {
            _buttonFrame2.RemoveFrame();
        }
        public void ButtonOn()
        {
            CleanFrame1();
            DrawFrame2();
        }
        public void ButtonOff()
        {
            CleanFrame2();
            DrawFrame1();
        }

        public void DrawButton ()
        {
            DrawFrame1();
            foreach(TextLine line in _buttonTextLines)
            {
                line.WriteTextLine();
            }
        }
    }
}
