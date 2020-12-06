using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class SceneManager
    {
        private IScene currentScene = null;
        private Dictionary<Scene, IScene> scenes = new Dictionary<Scene, IScene>();

        public SceneManager()
        {

        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
            if (currentScene.IsEnd() == true)
            {
                Scene next = currentScene.Next();
                Change(next);
            }
            if (currentScene.IsClear() == true)
            {
                Scene next = currentScene.Next();
                Change(next);
            }
            if (currentScene.IsKill() == true && currentScene.IsNextTop() == true)
            {
                Scene next = currentScene.Next();
                Change(next);
            }
            if (currentScene.IsKill() == true && currentScene.IsNextRight() == true)
            {
                Scene next = currentScene.Next();
                Change(next);
            }
            if (currentScene.IsKill() == true && currentScene.IsNextLeft() == true)
            {
                Scene next = currentScene.Next();
                Change(next);
            }
        }

        public void Draw(Render render)
        {
            currentScene.Draw(render);
        }
        public void Add(Scene name, IScene scene)
        {
            scenes[name] = scene;
        }
        public void Change(Scene name)
        {
            currentScene = scenes[name];
            currentScene.Initialize();
        }
    }
}
