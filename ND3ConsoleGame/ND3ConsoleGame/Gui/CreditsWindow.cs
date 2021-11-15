using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND3ConsoleGame.Gui
{
    class CreditsWindow : GuiObject
    {


        private Button _button1;
        private Frame _mainFrame;
        private List<TextLine> _title = new List<TextLine>();



        public CreditsWindow(int x, int y, int width, int height) : base(x, y, width, height)
        {
            _button1 = new Button(x + GuiParameters.OpptionsMenuButton1X, y + GuiParameters.OpptionsMenuButton1Y, GuiParameters.OpptionsMenuButton1Width, GuiParameters.OpptionsMenuButton1Height, GuiParameters.OpptionsMenuButton1Char1, GuiParameters.OpptionsMenuButton1Char2, GuiParameters.OpptionsMenuButton1Text);
            _mainFrame = new Frame(x, y, width, height, GuiParameters.OpptionsMenuMainFrameChar);
            for (int i = 0; i < GuiParameters.OpptionsTitleText.Count; i++)
            {
                _title.Add(new TextLine(x + GuiParameters.OpptionsMenuTitleTextX, y + GuiParameters.OpptionsMenuTitleTextY + i, GuiParameters.OpptionsMenuTitleTextWidth, GuiParameters.OpptionsTitleText[i]));
            }
            for (int a = Y; a < Y + Height; a++)
            {
                for (int b = X; b < Width + X; b++)
                {
                    Console.SetCursorPosition(b, a);
                    Console.Write(' ');
                }
            }

            _mainFrame.DrawFrame();
            foreach (TextLine line in _title)
            {
                line.WriteTextLine();
            }
            _button1.DrawButton();

        }



        public void Update()
        {

            Boolean esc = false;
            while (!esc)
            {
                while (Console.KeyAvailable)
                {

                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    switch (pressedChar.Key)
                    {

                        case ConsoleKey.Enter:
                            esc = true;
                            Console.Clear();
                            break;
                    }
                }
            }
        }

    }
}
