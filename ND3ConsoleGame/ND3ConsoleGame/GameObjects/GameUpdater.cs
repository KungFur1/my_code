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
    static class GameUpdater
    {




        public static void RunThroughAnimations()
        {
            Boolean animationRemoved = false;

            do
            {
                animationRemoved = false;
                foreach (Animation thing in GameScreen.Animations)
                {
                    if (GameScreen._frameCount % thing.Time == 0)
                    {
                        animationRemoved = thing.Animate();
                        if (animationRemoved)
                        {
                            break;
                        }
                    }
                }
            } while (animationRemoved == true);
        }

        public static void RunThroughPhysicsEngines()
        {
            foreach (IPhysicsEngine thing in GameScreen.PhysicsEngines)
            {
                thing.PhysicsEngine();
            }
        }



        public static void RunThrougHasBounds()
        {
            foreach (IHasBounds thing in GameScreen.HasBounds)
            {
                Boolean thingRemoved = thing.CheckIfInBounds();
                if (thingRemoved)
                {
                    break;
                }
            }
        }



        public static void RunThroughGameObjects()
        {

            foreach (GameObject thing1 in GameScreen.GameObjects)
            {
                Boolean collisionHappened = false;
                foreach (GameObject thing2 in GameScreen.GameObjects)
                {
                    if (thing1 != thing2)
                    {
                        if ((thing1.Y + thing1.Height <= thing2.Y + thing2.Height && thing1.Y + thing1.Height >= thing2.Y - thing2.Height) &&
                             (thing1.X + thing1.Width <= thing2.X + thing2.Width && thing1.X + thing1.Width >= thing2.X - thing2.Width) ||

                            (thing1.Y - thing1.Height <= thing2.Y - thing2.Height && thing1.Y + thing1.Height >= thing2.Y - thing2.Height) &&
                            (thing1.X - thing1.Width <= thing2.X - thing2.Width && thing1.X + thing1.Width >= thing2.X - thing2.Width))
                        {
                            thing1.Collision();
                            thing2.Collision();
                            collisionHappened = true;
                            break;
                        }
                    }
                }
                if (collisionHappened)
                {
                    break;
                }
            }

            //Remove Objects!!!


            foreach (GameObject thing in GameScreen.GameObjects)
            {
                thing.Update();
            }
        }
    }
}
