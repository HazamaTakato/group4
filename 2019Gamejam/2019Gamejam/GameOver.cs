using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class GameOver:IScene
    {
        private bool endFlag;
        private bool isPressKey;
        private bool nxFlagTop;
        private bool nxFlagLeft;
        private bool nxFlagRight;
        private int timer;
        private bool killFlag;
        private bool clearF;
        private Sound sound;
        private Vector2 boxP;
        public GameOver()
        {
            var gameD = GameDevice.Instance();
            sound = gameD.GetSound();
        }
        public void Initialize()
        {
            endFlag = false;
            isPressKey = true;
            nxFlagTop = false;
            nxFlagLeft = false;
            nxFlagRight = false;
            clearF = false;
            timer = 0;
        }
        public void Update(GameTime gameTime)
        {
            sound.PlayBGM("overbgm");
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (isPressKey == false)
                {
                    sound.PlaySE("enterse");
                    endFlag = true;
                    isPressKey = true;
                }
            }
            else
            {
                isPressKey = false;
            }
            timer++;
        }
        public void Draw(Render renderer)
        {
            renderer.DrawTexture("GAMEOVER", new Vector2(0, 0));
        }
        public bool IsEnd()
        {
            return endFlag;
        }
        public bool IsKill()
        {
            return killFlag;
        }

        public bool IsNextTop()
        {
            return nxFlagTop;
        }
        public bool IsNextLeft()
        {
            return nxFlagLeft;
        }

        public bool IsNextRight()
        {
            return nxFlagRight;
        }
        public bool IsClear()
        {
            return clearF;
        }
        public Scene Next()
        {
            return Scene.Title;
        }
    }
}
