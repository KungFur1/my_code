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
    class Animation
    {
        protected List<List<Symbol>> AnimationFrames;
        public int Time { get; private set; }
        private int _frameId = -1;
        protected int X;
        protected int Y;

        public Animation(float x, float y, List<List<Symbol>> animationFrames, int time)
        {
            AnimationFrames = animationFrames;
            Time = time;
            X = (int)x;
            Y = (int)y;

        }


        public Boolean Animate()
        {
            if (AnimationFrames.Count - 1 == _frameId)
            {
                _frameId++;
                CleanOldFrame();
                GameScreen.Animations.Remove(this);
                return true;

            }
            else
            {
                DrawNewFrame();
                CleanOldFrame();
                return false;
            }

        }

        private void DrawNewFrame()
        {
            _frameId++;
            foreach (Symbol symbol in AnimationFrames[_frameId])
            {
                symbol.DrawNewLocation(X, Y);
            }
        }

        private void CleanOldFrame()
        {
            if (_frameId > 0)
            {
                foreach (Symbol symbol in AnimationFrames[_frameId - 1])
                {
                    symbol.ClearOldLocation(X, Y);
                }
            }
        }
    }
}
