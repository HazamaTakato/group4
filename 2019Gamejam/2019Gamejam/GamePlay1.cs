using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class GamePlay1 : IScene
    {
        private bool endFlag;
        private bool killFlag;
        private bool nxFlagTop;
        private bool nxFlagLeft;
        private bool nxFlagRight;
        private bool clearF;
        private ShotEnemy enemy;
        private Enemy enemyy;
        private Player player;
        private Item item;
        private Flag flag;
        private CharacterManager characterManager;
        private Collision collision;
        private int count;
        private Sound sound;
        public GamePlay1()
        {
            var gameD = GameDevice.Instance();
            sound = gameD.GetSound();
            player = new Player();
            enemy = new ShotEnemy();
            enemyy = new Enemy(player);
            item = new Item(player.GetPosition());
            flag = new Flag(player);
            characterManager = new CharacterManager(player, item,sound);
            collision = new Collision(player, characterManager, item,sound);
        }

        public void Initialize()
        {
            killFlag = false;
            endFlag = false;
            nxFlagTop = false;
            nxFlagLeft = false;
            nxFlagRight = false;
            clearF = false;
            player.Initialize();
            characterManager.Initialize();
            count = 0;
        }

        public void Update(GameTime gameTime)
        {
            sound.PlayBGM("playbgm");
            player.Update(gameTime);
            characterManager.Update(gameTime);
            collision.Update();
            enemy.Update();
            enemyy.Update(gameTime);
            item.PlayerPos = player.GetPosition();
            item.Update(gameTime);
            //CollisionPlayerFlag();
            if (collision.IsDead() == true)
            {
                sound.PlaySE("enemyse");

                endFlag = true;
            }
            if (collision.IsDead2() == true)
            {
                sound.PlaySE("enemyse");
                endFlag = true;
            }
            if (collision.IsKill2() == true)
            {
                //sound.PlaySE("enemyse");
                count++;
                if (count == 5)
                {
                    killFlag = true;
                }
            }
            if (collision.IsNextTop() == true && killFlag == true)
            {
                sound.PlaySE("doorse");

                nxFlagTop = true;
            }
            if (collision.IsNextLeft() == true && killFlag == true)
            {
                sound.PlaySE("doorse");

                nxFlagLeft = true;
            }
            if (collision.IsNextRight() == true && killFlag == true)
            {
                sound.PlaySE("doorse");

                nxFlagRight = true;
            }
        }
        public void Draw(Render renderer)
        {
            renderer.DrawTexture("maptest2", new Vector2());
            if (killFlag == false)
            {
                renderer.DrawTexture("door", new Vector2(608, 0), 1f);
                renderer.DrawTexture("door", new Vector2(0, 352), 1f);
                renderer.DrawTexture("door", new Vector2(1216, 352), 1f);
            }
            else if (killFlag == true)
            {
                renderer.DrawTexture("dooropend", new Vector2(608, 0), 1f);
                renderer.DrawTexture("dooropend", new Vector2(0, 352), 1f);
                renderer.DrawTexture("dooropend", new Vector2(1216, 352), 1f);
            }
            //ドア 608~672
            //enemy.Draw(renderer);
            characterManager.Draw(renderer);
            item.Draw(renderer);
            player.Draw(renderer);
            //flag.Draw(renderer);
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

        private void CollisionPlayerFlag()
        {
            Vector2 playerPos = new Vector2(0, 0);
            Vector2 flagPos = new Vector2(0, 0);

            playerPos = player.GetPosition();
            flagPos = flag.GetGPos();
            endFlag = false;

            float dist = Vector2.Distance(playerPos, flagPos);
            if (dist < 32)
            {
                endFlag = true;
            }

        }
        public bool IsClear()
        {
            return clearF;
        }
        public Scene Next()
        {
            if (nxFlagRight == true && killFlag == true)
            {
                return Scene.GamePlay2;
            }
            else if (nxFlagTop == true && killFlag == true)
            {
                return Scene.GamePlay;
            }
            else if (nxFlagLeft == true && killFlag == true)
            {
                return Scene.GamePlay1;
            }
            else
            {
                return Scene.GameOver;
            }
        }
    }
}
