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
    class HoamingMissile : GameObject, ICollidible, IHasBounds, IPhysicsEngine
    {
        public float Lives { get; private set; }


        public HoamingMissile(float x, float y) : base(x, y, TexturesPack.HoamingMissileWidth, TexturesPack.HoamingMissileHeight, 0, TexturesPack.HoamingMissileSpeedy * GameSpeed, TexturesPack.HoamingMissile)
        {
            Lives = TexturesPack.HoamingMissileLives;
        }


        //Check If In Bounds
        public Boolean CheckIfInBounds()
        {
            if (Y > MapFullScreen.ScreenHeight - Height)
            {
                CleanObject();
                GameScreen.GameObjects.Remove(this);
                GameScreen.HasBounds.Remove(this);
                GameScreen.PhysicsEngines.Remove(this);
                return true;
            }
            else if (X > MapFullScreen.ScreenWidth - Width)
            {
                CleanObject();
                GameScreen.GameObjects.Remove(this);
                GameScreen.HasBounds.Remove(this);
                GameScreen.PhysicsEngines.Remove(this);
                return true;
            }
            else if (X - 1 < Width)
            {
                CleanObject();
                GameScreen.GameObjects.Remove(this);
                GameScreen.HasBounds.Remove(this);
                GameScreen.PhysicsEngines.Remove(this);
                return true;
            }
            return false;
        }

        //Collision

        public override void Collision()
        {
            Lives--;
            if (Lives <= 0)
            {
                CleanObject();
                GameScreen.GameObjects.Remove(this);
                GameScreen.HasBounds.Remove(this);
                WaveStatistics.Score += 10;
                //Death Animation!!!
            }

        }

        //Physics engine, following missiles

        public void PhysicsEngine()
        {
            if (GameScreen.Hero.X < X)
            {
                SpeedX -= GameSpeed * TexturesPack.HoamingMissileSpeedX;
            }
            else if (GameScreen.Hero.X > X)
            {
                SpeedX += GameSpeed * TexturesPack.HoamingMissileSpeedX;
            }
        }
    }
}
