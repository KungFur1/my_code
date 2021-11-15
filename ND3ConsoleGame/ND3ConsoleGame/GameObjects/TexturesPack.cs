using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND3ConsoleGame.GameObjects
{
    static class TexturesPack
    {
        //Norma Bullet Parameters
        public static List<Symbol> NormalBullet = new List<Symbol> { new Symbol('#', 1, 0), new Symbol('#', 1, 1), new Symbol('#', 1, -1), new Symbol('#', 0, 0), new Symbol('#', 0, -1), new Symbol('#', 0, 1) };
        public static float NormalBulletWidth = 1.5f;
        public static float NormalBulletHeight = 3f;
        public static float NormalBulletSpeedY = -100f;
        //
        public static List<Symbol> Meteorite = new List<Symbol> { new Symbol('#', 0, 0), new Symbol('#', 1, 0), new Symbol('#', -1, 0),
            new Symbol('#', 0, -1), new Symbol('#', 1, -1), new Symbol('#', -1, -1),
            new Symbol('#', 0, 1), new Symbol('#', 1, 1), new Symbol('#', -1, 1),
            new Symbol('#', 1, -2),  new Symbol('#', -1, -2), new Symbol('#', 0, -2),
            new Symbol('#', 0, 2), new Symbol('#', 1, 2), new Symbol('#', -1, 2),
            new Symbol('#', -2, 0), new Symbol('#', -2, -1), new Symbol('#', -2, 0),
            new Symbol('#', 2, 0), new Symbol('#', 2, 1), new Symbol('#', 2, -1),
            new Symbol('#', -3, 0), new Symbol('#', 3, 0),
            new Symbol('#', 0, -3), new Symbol('#', 0, 3), new Symbol('#', -2, 1) };

        public static float MeteoriteWidth = 5;
        public static float MeteoriteHeight = 5;
        public static float MeteoriteLives = 7;
        public static float MeteoriteSpeedY = 5f;

        private static List<Symbol> MeteoriteDeathFrame1 = new List<Symbol> { new Symbol('#', 0, 0), new Symbol('#', -1, 0),
            new Symbol('#', 0, -1), new Symbol('#', -1, -1),
            new Symbol('#', 0, 1), new Symbol('#', 1, 1), new Symbol('#', -1, 1),
            new Symbol('#', 1, -2), new Symbol('#', 0, -2),
            new Symbol('#', 0, 2), new Symbol('#', 1, 2), new Symbol('#', -1, 2),
            new Symbol('#', -2, 0),
            new Symbol('#', 2, 0), new Symbol('#', 2, 1), new Symbol('#', 2, -1),
            new Symbol('#', -3, 0), new Symbol('#', 3, 0),
            new Symbol('#', 0, -3), new Symbol('#', -2, 1) };

        private static List<Symbol> MeteoriteDeathFrame2 = new List<Symbol> { new Symbol('#', 1, 0), new Symbol('#', -1, 0),
            new Symbol('#', 1, -1), new Symbol('#', -1, -1),
            new Symbol('#', 0, 1), new Symbol('#', 1, 1), new Symbol('#', -1, 1),
            new Symbol('#', 1, -2),  new Symbol('#', -1, -2), new Symbol('#', 0, -2),
            new Symbol('#', 0, 2), new Symbol('#', 1, 2),
            new Symbol('#', -2, 0), new Symbol('#', -2, -1), new Symbol('#', -2, 0),
            new Symbol('#', 2, 0), new Symbol('#', 2, 1),
            new Symbol('#', 3, 0),
            new Symbol('#', 0, -3), new Symbol('#', 0, 3) };
        private static List<Symbol> MeteoriteDeathFrame3 = new List<Symbol> { new Symbol('#', 0, 0), new Symbol('#', -1, 0),
            new Symbol('#', 1, 1), new Symbol('#', -1, 1),
            new Symbol('#', 1, -2), new Symbol('#', 0, -2),
            new Symbol('#', 0, 2), new Symbol('#', 1, 2), new Symbol('#', -1, 2),
            new Symbol('#', -2, 0),
            new Symbol('#', 2, 0), new Symbol('#', 2, 1), new Symbol('#', 2, -1),
            new Symbol('#', -3, 0), new Symbol('#', 3, 0)};
        private static List<Symbol> MeteoriteDeathFrame4 = new List<Symbol> { new Symbol('#', 0, 0),
            new Symbol('#', 1, 1), new Symbol('#', -1, 1),
            new Symbol('#', 1, -2), new Symbol('#', 0, -2),
            new Symbol('#', 0, 2),
            new Symbol('#', -2, 0),
            new Symbol('#', 2, 0),
            new Symbol('#', -3, 0), new Symbol('#', 3, 0)};



        public static List<List<Symbol>> MeteoriteDeathAnimation = new List<List<Symbol>> {MeteoriteDeathFrame1, MeteoriteDeathFrame2, MeteoriteDeathFrame3, MeteoriteDeathFrame4, MeteoriteDeathFrame3, MeteoriteDeathFrame2, MeteoriteDeathFrame1, MeteoriteDeathFrame4  };

        public static int MeteoriteDeathAnimationTime = Convert.ToInt32(0.01/GameObject.GameSpeed);

        //
        public static List<Symbol> HoamingMissile = new List<Symbol> { new Symbol('@', 0, 0) };

        public static float HoamingMissileWidth = 1;
        public static float HoamingMissileHeight = 1;
        public static float HoamingMissileLives = 1;
        public static float HoamingMissileSpeedy = 25f;
        public static float HoamingMissileSpeedX = 0.0005f;

        //
        public static List<Symbol> Hero = new List<Symbol> { new Symbol('@', 0, 0), new Symbol('@', 1, 0), new Symbol('@', 2, 0), new Symbol('@', 3, 0), new Symbol('@', -3, 0), new Symbol('@', -1, 0), new Symbol('@', -2, 0), new Symbol('@', 0, -1), new Symbol('@', 1, -1), new Symbol('@', 2, -1), new Symbol('@', 3, -1), new Symbol('@', -3, -1), new Symbol('@', -1, -1), new Symbol('@', -2, -1), new Symbol('@', 3, 1), new Symbol('@', -3, 1), new Symbol('@', 0, 1), new Symbol('@', 1, 1), new Symbol('@', 2, 1), new Symbol('@', -1, 1), new Symbol('@', -2, 1), new Symbol('@', 0, 2), new Symbol('@', 3, 2), new Symbol('@', -3, 2), new Symbol('@', 1, 2), new Symbol('@', 2, 2), new Symbol('@', -1, 2), new Symbol('@', -2, 2), new Symbol('@', 1, -2), new Symbol('@', -1, -2), new Symbol('@', 1, -3), new Symbol('@', -1, -3), new Symbol('@', 1, -4), new Symbol('@', -1, -4), new Symbol('@', 1, -5), new Symbol('@', -1, -5) };

        public static float HeroSwifftness = 5000f;
        public static float HeroJumpyness = 150f;
        public static float HeroLives = 5;
        public static float HeroWidth = 5;
        public static float HeroHeight = 3;
        public static string HeroName = "Freddy";
        public static int HeroAmmo = 100;

    }
}
