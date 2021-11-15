using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND3ConsoleGame.Gui
{
    static class GuiParameters
    {
        public static int MainMenuButton1X = 50;
        public static int MainMenuButton1Y = 30;
        public static int MainMenuButton1Width = 25;
        public static int MainMenuButton1Height = 6;
        public static char MainMenuButton1Char1 = '@';
        public static char MainMenuButton1Char2 = '#';
        public static List<string> MainMenuButton1Text = new List<string> {"Start", "Game"};

        public static int MainMenuButton2X = 100;
        public static int MainMenuButton2Y = 30;
        public static int MainMenuButton2Width = 25;
        public static int MainMenuButton2Height = 6;
        public static char MainMenuButton2Char1 = '@';
        public static char MainMenuButton2Char2 = '#';
        public static List<string> MainMenuButton2Text = new List<string> { "Credits"};

        public static int MainMenuButton3X = 150;
        public static int MainMenuButton3Y = 30;
        public static int MainMenuButton3Width = 25;
        public static int MainMenuButton3Height = 6;
        public static char MainMenuButton3Char1 = '@';
        public static char MainMenuButton3Char2 = '#';
        public static List<string> MainMenuButton3Text = new List<string> { "Upgrades"};

        public static int MainMenuTitleTextX = 90;
        public static int MainMenuTitleTextY = 10;
        public static int MainMenuTitleTextWidth = 20;
        public static int MainMenuTitleTextHeight = 7;
        public static List<string> MainTitleText = new List<string> { "MSB", "" ,"Meteorite Shooting Simulator!" };

        public static char MainMenuMainFrameChar = '%';

        //

        public static int OpptionsMenuButton1X = 35;
        public static int OpptionsMenuButton1Y = 18;
        public static int OpptionsMenuButton1Width = 25;
        public static int OpptionsMenuButton1Height = 6;
        public static char OpptionsMenuButton1Char1 = '@';
        public static char OpptionsMenuButton1Char2 = '#';
        public static List<string> OpptionsMenuButton1Text = new List<string> { "Go", "Back" };

        public static int OpptionsMenuTitleTextX = 35;
        public static int OpptionsMenuTitleTextY = 3;
        public static int OpptionsMenuTitleTextWidth = 25;
        public static int OpptionsMenuTitleTextHeight = 12;
        public static List<string> OpptionsTitleText = new List<string> { "MSB", "Meteorite Shooting Simulator!", "By:", "Joris Plascinskas" };

        public static char OpptionsMenuMainFrameChar = '%';


    }
}
