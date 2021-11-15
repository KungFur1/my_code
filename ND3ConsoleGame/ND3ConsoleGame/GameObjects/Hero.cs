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
    class Hero : GameObject, IHasBounds, IPhysicsEngine
    {
        public string Name { get; private set; }
        public float Lives { get; private set; }
        public float Swiftness { get; private set; }
        public float Jumpyness { get; private set; }
        public int Ammo { get; private set; }
        private readonly float _airResistance;
        private readonly float _maxSpeedX;
        private const float _gravity = 0.002f;
        



        //Hero Birth
        public Hero (float x, float y) : base(x, y, TexturesPack.HeroWidth, TexturesPack.HeroHeight, 0, 0, TexturesPack.Hero)
        {
            Name = TexturesPack.HeroName;
            Lives = TexturesPack.HeroLives;
            Swiftness = TexturesPack.HeroSwifftness;
            Jumpyness = TexturesPack.HeroJumpyness;
            Ammo = TexturesPack.HeroAmmo;
            _airResistance = Swiftness / 100;
            _maxSpeedX = TexturesPack.HeroSwifftness;

        }

        //Hero Controlls
        public void LeftArrowPressed()
        {
            if (-SpeedX < _maxSpeedX)
            {
                SpeedX -= GameSpeed * Swiftness;
            }
        }

        public void RightArrowPressed()
        {
            if (SpeedX < _maxSpeedX)
            {
                SpeedX += GameSpeed * Swiftness;
            }
        }
        public void UpArrowPressed()
        {
            if (Y >= MapFullScreen.ScreenHeight - Height - 0.05f)
            {
                SpeedY -= GameSpeed * Jumpyness;
            }

        }
        public void SpaceBarPressed()
        {
            if (Ammo > 0)
            {
                Ammo--;
                NormalBullet bullet = new NormalBullet(Name, X, Y - Height - TexturesPack.NormalBulletHeight - 0.05f);
                GameScreen.GameObjects.Add(bullet);
                GameScreen.HasBounds.Add(bullet);
            }
        }

        //CheckIf In Bounds
        public Boolean CheckIfInBounds()
        {
            if (X + Width >= MapFullScreen.ScreenWidth && SpeedX > 0)
            {
                SpeedX = 0;
            }
            else if (X <= Width && SpeedX < 0)
            {
                SpeedX = 0;
            }
            if (Y + Height >= MapFullScreen.ScreenHeight && SpeedY > 0)
            {
                SpeedY = 0;
            }
            else if (Y <= Height && SpeedY < 0)
            {
                SpeedY = 0;
            }
            return false;
        }


        //PhysicsEngine

        public void PhysicsEngine ()
        {
            if (SpeedX > 0)
            {
                SpeedX -= (SpeedX * _airResistance / 1 + _airResistance) * GameSpeed;
            }
            else if (SpeedX < 0)
            {
                SpeedX += (-SpeedX * _airResistance / 1 + _airResistance) * GameSpeed;
            }
            SpeedY += _gravity * GameSpeed;
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
                GameScreen.PhysicsEngines.Remove(this);
            }
        }

    }
}
