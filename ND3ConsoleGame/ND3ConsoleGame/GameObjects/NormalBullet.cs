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
    class NormalBullet : GameObject, IHasBounds
    {
        private string _shootersName;


        //Creating Bullet
        public NormalBullet(string shootersName, float x, float y) : base(x, y, TexturesPack.MeteoriteWidth, TexturesPack.NormalBulletHeight, 0, TexturesPack.NormalBulletSpeedY * GameSpeed, TexturesPack.NormalBullet)
        {
            _shootersName = shootersName;
        }


        //Check If In Bounds !!! Bullet death annimation !!!
        public virtual Boolean CheckIfInBounds()
        {
            {
                if (Y < Height)
                {
                    CleanObject();
                    GameScreen.GameObjects.Remove(this);
                    GameScreen.HasBounds.Remove(this);
                    return true;
                }
                return false;
            }
        }

        //Collision

        public override void Collision()
        {
            CleanObject();
            GameScreen.GameObjects.Remove(this);
            GameScreen.HasBounds.Remove(this);
        }

    }
}
