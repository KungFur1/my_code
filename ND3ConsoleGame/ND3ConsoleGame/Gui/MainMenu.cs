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

namespace ND3ConsoleGame.Gui
{
    class MainMenu : GuiObject
    {
        private Button _button1;
        private Button _button2;
        private Button _button3;
        private Frame _mainFrame;
        private List<TextLine> _title = new List<TextLine>();



        public MainMenu(int x, int y, int width, int height) : base (x, y, width, height)
        {
            _button1 = new Button(x + GuiParameters.MainMenuButton1X, y + GuiParameters.MainMenuButton1Y, GuiParameters.MainMenuButton1Width, GuiParameters.MainMenuButton1Height, GuiParameters.MainMenuButton1Char1, GuiParameters.MainMenuButton1Char2, GuiParameters.MainMenuButton1Text);
            _button2 = new Button(x + GuiParameters.MainMenuButton2X, y + GuiParameters.MainMenuButton2Y, GuiParameters.MainMenuButton2Width, GuiParameters.MainMenuButton2Height, GuiParameters.MainMenuButton2Char1, GuiParameters.MainMenuButton2Char2, GuiParameters.MainMenuButton2Text);
            _button3 = new Button(x + GuiParameters.MainMenuButton3X, y + GuiParameters.MainMenuButton3Y, GuiParameters.MainMenuButton3Width, GuiParameters.MainMenuButton3Height, GuiParameters.MainMenuButton3Char1, GuiParameters.MainMenuButton3Char2, GuiParameters.MainMenuButton3Text);
            _mainFrame = new Frame(x, y, width, height, GuiParameters.MainMenuMainFrameChar);
            for (int i = 0; i < GuiParameters.MainTitleText.Count; i++)
            {
                _title.Add(new TextLine(x + GuiParameters.MainMenuTitleTextX, y + GuiParameters.MainMenuTitleTextY + i, GuiParameters.MainMenuTitleTextWidth, GuiParameters.MainTitleText[i]));
            }

            _mainFrame.DrawFrame();
            foreach(TextLine line in _title)
            {
                line.WriteTextLine();
            }
            _button1.DrawButton();
            _button2.DrawButton();
            _button3.DrawButton();
            Switch();
        }

        private int _buttonSelected = 2;

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
                        case ConsoleKey.RightArrow:
                            _buttonSelected++;
                            Switch();
                            break;
                        case ConsoleKey.LeftArrow:
                            _buttonSelected--;
                            Switch();
                            break;
                        case ConsoleKey.Enter:
                            switch (_buttonSelected)
                            {
                                case 1:
                                    Hero hero = new Hero(50, 40);
                                    GameScreen gameScreen = new GameScreen(16, hero);
                                    gameScreen.StartGame(1);
                                    break;
                                case 2:
                                    CreditsWindow creditsWindow = new CreditsWindow(50, 15, 100, 26);
                                    creditsWindow.Update();
                                    _mainFrame.DrawFrame();
                                    foreach (TextLine line in _title)
                                    {
                                        line.WriteTextLine();
                                    }
                                    _button1.DrawButton();
                                    _button2.DrawButton();
                                    _button3.DrawButton();
                                    Switch();
                                    break;
                                case 3:

                                    break;
                            }
                            break;
                    }
                }

            }
        }

        public void Switch()
        {
            if (_buttonSelected > 3)
            {
                _buttonSelected = 1;
            }
            else if (_buttonSelected < 1)
            {
                _buttonSelected = 3;
            }


            switch(_buttonSelected)
            {
                case 1:
                    _button2.ButtonOff();
                    _button3.ButtonOff();
                    _button1.ButtonOn();
                    break;
                case 2:
                    _button1.ButtonOff();
                    _button3.ButtonOff();
                    _button2.ButtonOn();
                    break;
                case 3:
                    _button1.ButtonOff();
                    _button2.ButtonOff();
                    _button3.ButtonOn();
                    break;

            }
        }


    }
}
