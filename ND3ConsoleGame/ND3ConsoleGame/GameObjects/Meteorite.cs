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
    class Meteorite : GameObject, IHasBounds
    {
        public float Lives { get; private set; }

        //Creating Meteorite
        public Meteorite(float x, float y) : base (x, y, TexturesPack.MeteoriteWidth, TexturesPack.MeteoriteHeight, 0, TexturesPack.MeteoriteSpeedY * GameSpeed, TexturesPack.Meteorite)
        {
            Lives = TexturesPack.MeteoriteLives; 
        }


        //Check If In Bounds
        public Boolean CheckIfInBounds()
        {
            if (Y > MapFullScreen.ScreenHeight - Height)
            {
                CleanObject();
                GameScreen.GameObjects.Remove(this);
                GameScreen.HasBounds.Remove(this);
                return true;
            }
            return false;
        }

        //Collision

        public override void Collision()
        {
            Lives--;
            if(Lives <= 0)
            {
                CleanObject();
                GameScreen.GameObjects.Remove(this);
                GameScreen.HasBounds.Remove(this);
                GameScreen.Animations.Add(new Animation(X, Y, TexturesPack.MeteoriteDeathAnimation, TexturesPack.MeteoriteDeathAnimationTime));
                WaveStatistics.Score += 100;
            }

        }

    }
}
