﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class GameClear:IScene
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
        public GameClear()
        {
            var gameD = GameDevice.Instance();
            sound = gameD.GetSound();
            boxP = new Vector2(525, 50);
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
            sound.PlayBGM("clearbgm");
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
            if (boxP.Y < 270)
            {
                boxP.Y += 5;
            }
            timer++;
        }
        public void Draw(Render renderer)
        {
            renderer.DrawTexture("gameclear", new Vector2(0, 0));
            renderer.DrawTexture("Box", boxP);
        }
        public bool IsClear()
        {
            return clearF;
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
        public Scene Next()
        {
            return Scene.Title;
        }
    }
}