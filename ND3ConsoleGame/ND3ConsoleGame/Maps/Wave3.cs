using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ND3ConsoleGame.GameObjects;
using ND3ConsoleGame.GameObjectsInterfaces;
using ND3ConsoleGame.Maps;
using ND3ConsoleGame.Screens;

namespace ND3ConsoleGame.Maps
{
    class Wave3
    {
        public static int StartHoamingMisslieCount = 4;
        public static int StartMeteoriteCount = 1;
        public static int SpawnMeteoriteTime = Convert.ToInt32(7 / GameObject.GameSpeed);
        public static int SpawnMissileTime = Convert.ToInt32(1 / GameObject.GameSpeed);
        public static int MaxPoints = 1000;

    }
}
