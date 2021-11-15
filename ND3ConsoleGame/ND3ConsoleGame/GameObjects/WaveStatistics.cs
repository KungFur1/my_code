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
    class WaveStatistics
    {
        protected int WaveNumber;
        public static int Score;
        private int MaxScore;

        public WaveStatistics (int waveNumber)
        {
            WaveNumber = waveNumber;
            switch (waveNumber)
            {
                case 1:
                    MaxScore = Wave1.MaxPoints;
                    break;
                case 2:
                    MaxScore = Wave2.MaxPoints;
                    break;
                case 3:
                    MaxScore = Wave3.MaxPoints;
                    break;
                case 4:
                    MaxScore = 100000;
                    break;
            }
        }

        public Boolean CheckIfVictory ()
        {
            if (Score >= MaxScore)
            {
                return true;
            }
            return false;
        }
    }
}
