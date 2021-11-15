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
    static class Spawner
    {

        private static Random _randomNumber = new Random();



        private static void SpawnMeteorite(float x, float y)
        {
            Meteorite meteorite = new Meteorite(x, y);
            GameScreen.GameObjects.Add(meteorite);
            GameScreen.HasBounds.Add(meteorite);
        }


        private static void SpawnHoamingMissile(float x, float y)
        {
            HoamingMissile hoamingMissile = new HoamingMissile(x, y);
            GameScreen.GameObjects.Add(hoamingMissile);
            GameScreen.HasBounds.Add(hoamingMissile);
            GameScreen.PhysicsEngines.Add(hoamingMissile);
        }

        public static void SpawnHoamingMissiles(int ammount)
        {
            for (int i = 0; i < ammount; i++)
            {
                int randomNumber = _randomNumber.Next((int)TexturesPack.HoamingMissileWidth, MapFullScreen.ScreenWidth - (int)TexturesPack.HoamingMissileWidth);
                SpawnHoamingMissile(randomNumber, TexturesPack.HoamingMissileHeight);
            }
        }

        public static void SpawnMeteorites(int ammount)
        {
            for (int i = 0; i < ammount; i++)
            {
                int randomNumber = _randomNumber.Next((int)TexturesPack.MeteoriteWidth, MapFullScreen.ScreenWidth - (int)TexturesPack.MeteoriteWidth);
                SpawnMeteorite(randomNumber, TexturesPack.MeteoriteHeight);
            }
        }
    }
}
