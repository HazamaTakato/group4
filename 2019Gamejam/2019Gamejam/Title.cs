using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class Title:IScene
    {
        private bool endFlag;//終了フラグ
        private bool nxFlagTop;
        private bool nxFlagLeft;
        private bool nxFlagRight;
        private bool isPressKey;//キーを押したか?
        private int timer;//タイマー
        private bool killFlag;
        private bool clearF;
        private Vector2 pos;
        private Vector2 vel;
        private Vector2 vel2;
        private Random rand;
        private Sound sound;
        public Title()
        {
            var gameD = GameDevice.Instance();
            sound = gameD.GetSound();
        }
        public void Initialize()
        {
            //変数の初期化
            endFlag = false;
            killFlag = false;
            nxFlagTop = false;
            nxFlagLeft = false;
            nxFlagRight = false;
            isPressKey = true;
            clearF = false;
            vel = new Vector2(-10f, 0);
            vel2 = new Vector2(-5f, -5f);
            rand = new Random();
            pos = new Vector2(rand.Next(64, 1216-300), rand.Next(100, 150));
            timer = 0;//タイマー
        }
        public void Update(GameTime gameTime)
        {
            sound.PlayBGM("playbgm");
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (isPressKey == false)
                {
                    endFlag = true;
                    isPressKey = true;
                    sound.PlaySE("enterse");
                    sound.StopBGM();
                    
                }
                else
                {
                    isPressKey = false;
                }
            }
            timer++;
            if (pos.X < 64)
            {
                vel = -vel;
            }
            if (pos.X > 1216-300)
            {
                vel = -vel;
            }
            pos += vel;
        }
        public void Draw(Render renderer)
        {
            //背景の表示
            //文字の表示
            renderer.DrawTexture("title",new Vector2(0,0));
            renderer.DrawTexture("playerrinkmaescale", pos);
            //スタートテキストの表示
            if (timer % 60 < 30)
            {
            }
            else
            {//半透明
            }
        }
        public bool IsEnd()
        {
            return endFlag;
        }

        public bool IsKill()
        {
            return killFlag;
        }
        public bool IsClear()
        {
            return clearF;
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
            return Scene.Tutorial;
        }
    }
}
