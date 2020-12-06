using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class Collision
    {
        private Player p;
        private CharacterManager charaMane;
        private Item i;
        private Flag f;
        private GamePlay gamePlay;
        private Sound sound;
        private bool deadFlag;
        private bool deadF2;
        private bool killFlag;
        private bool killFlag2;
        private bool nxStageFTop;
        private bool nxStageFLeft;
        private bool nxStageFRight;
        public Collision(Player p,CharacterManager charaMane,Item i,Sound sound)
        {
            this.p = p;
            this.i = i;
            this.sound = sound;
            f = new Flag(p);
            this.charaMane = charaMane;
        }
        public void Update()
        {
            CollisionPlayerEnemy();
            CollisionPlayerEnemy1();
            CollisionItemEnemy();
            CollisionItemEnemy1();
            //CollisionPlayerFlag();
            CollisionPlayerStageTop();
            CollisionPlayerStageRight();
            CollisionPlayerStageLeft();
        }
        private void CollisionPlayerStageTop()
        {
            Vector2 playerPosition = new Vector2(0, 0);
            Vector2 stageRightPosition = new Vector2(608,65);
            Vector2 stageLeftPos = new Vector2(672,65);
            Vector2 stageTopPos = new Vector2(0,0);
            Vector2 stageBotPos = new Vector2(0,65);

            playerPosition = p.GetPosition();

            nxStageFTop = false;
            
            Vector2 goal = new Vector2(MathHelper.Clamp(playerPosition.X, stageRightPosition.X, stageLeftPos.X),
                MathHelper.Clamp(playerPosition.Y, stageTopPos.Y, stageBotPos.Y));

            float dist = Vector2.DistanceSquared(goal, playerPosition);

            if (dist < 4)
            {
                nxStageFTop = true;
            }
        }
        
        private void CollisionPlayerStageLeft()
        {
            //332~396
            Vector2 playerPosition = new Vector2(0, 0);
            Vector2 stageRightPosition = new Vector2(0,0);
            Vector2 stageLeftPos = new Vector2(65, 0);
            Vector2 stageTopPos = new Vector2(65, 332);
            Vector2 stageBotPos = new Vector2(65, 396);

            playerPosition = p.GetPosition();

            nxStageFLeft = false;

            Vector2 goal = new Vector2(MathHelper.Clamp(playerPosition.X, stageRightPosition.X, stageLeftPos.X),
                MathHelper.Clamp(playerPosition.Y, stageTopPos.Y, stageBotPos.Y));

            float dist = Vector2.DistanceSquared(goal, playerPosition);

            if (dist < 4)
            {
                nxStageFLeft = true;
            }
        }


        private void CollisionPlayerStageRight()
        {
            //332~396
            //332~396
            Vector2 playerPosition = new Vector2(0, 0);
            Vector2 stageRightPosition = new Vector2(1280-96, 0);
            Vector2 stageLeftPos = new Vector2(1280, 0);
            Vector2 stageTopPos = new Vector2(1280-96, 332);
            Vector2 stageBotPos = new Vector2(1280-96, 396);

            playerPosition = p.GetPosition();

            nxStageFRight = false;

            Vector2 goal = new Vector2(MathHelper.Clamp(playerPosition.X, stageRightPosition.X, stageLeftPos.X),
                MathHelper.Clamp(playerPosition.Y, stageTopPos.Y, stageBotPos.Y));

            float dist = Vector2.DistanceSquared(goal, playerPosition);

            if (dist < 4)
            {
                nxStageFRight = true;
            }
        }
        private void CollisionPlayerFlag()
        {
            Vector2 playerPos = new Vector2(0, 0);
            Vector2 flagPos = new Vector2(0, 0);

            playerPos = p.GetPosition();
            flagPos = f.GetGPos();
            deadFlag = false;

            float dist = Vector2.Distance(playerPos, flagPos);
            if (dist < 70)
            {
                deadFlag = true;
            }

        }
        private void CollisionPlayerEnemy()
        {
            Vector2 playerPosition = new Vector2(0, 0);
            Vector2 enemyPosition = new Vector2(0, 0);

            playerPosition = p.GetPosition();

            deadF2 = false;

            List<ShotEnemy> enemyList = charaMane.GetEnemyes();

            foreach (var e in enemyList)
            {
                enemyPosition = e.GetPos();

                float distance = Vector2.Distance(playerPosition, enemyPosition);

                if (distance < 32)
                {
                    deadF2 = true;
                }
            }
            if (playerPosition.Y > Screen.height + 32)
            {
                deadF2 = true;
            }
        }
        private void CollisionPlayerEnemy1()
        {
            Vector2 playerPosition = new Vector2(0, 0);
            Vector2 enemyPosition = new Vector2(0, 0);

            playerPosition = p.GetPosition();

            deadFlag = false;

            List<Enemy> enemyList = charaMane.GetEnemies();

            foreach (var e in enemyList)
            {
                enemyPosition = e.GetPos();

                float distance = Vector2.Distance(playerPosition, enemyPosition);

                if (distance < 32)
                {
                    deadFlag = true;
                }
            }
            if (playerPosition.Y > Screen.height + 32)
            {
                deadFlag = true;
            }
        }
        private void CollisionItemEnemy()
        {
            Vector2 itemPosition1 = new Vector2(0, 0);
            Vector2 itemPos2 = new Vector2(0, 0);
            Vector2 itemPos3 = new Vector2(0, 0);
            Vector2 enemyPosition = new Vector2(0, 0);

            itemPosition1 = i.GetPos1();
            itemPos2 = i.GetPos2();
            itemPos3 = i.GetPos3();
            
            killFlag2 = false;

            List<ShotEnemy> enemyList = charaMane.GetEnemyes();

            foreach (var e in enemyList)
            {
                enemyPosition = e.GetPos();

                float distance1 = Vector2.Distance(itemPosition1, enemyPosition);
                float dis2 = Vector2.Distance(itemPos2, enemyPosition);
                float dis3 = Vector2.Distance(itemPos3, enemyPosition);

                if (distance1 < 32)
                {
                    killFlag2 = true;
                    e.Hit();
                }
                if (dis2 < 32)
                {
                    killFlag2 = true;
                    e.Hit();
                }
                if (dis3 < 32)
                {
                    killFlag2 = true;
                    e.Hit();
                }
            }
            if (itemPosition1.Y > Screen.height + 32)
            {
                //endFlag = true;
            }
            if (itemPos2.Y > Screen.height + 32)
            {
                //endFlag = true;
            }
            if (itemPos3.Y > Screen.height + 32)
            {
                //endFlag = true;
            }
        }
        private void CollisionItemEnemy1()
        {
            Vector2 itemPosition1 = new Vector2(0, 0);
            Vector2 itemPos2 = new Vector2(0, 0);
            Vector2 itemPos3 = new Vector2(0, 0);
            Vector2 enemyPosition = new Vector2(0, 0);

            itemPosition1 = i.GetPos1();
            itemPos2 = i.GetPos2();
            itemPos3 = i.GetPos3();

            killFlag = false;

            List<Enemy> enemyList = charaMane.GetEnemies();

            foreach (var e in enemyList)
            {
                enemyPosition = e.GetPos();

                float distance1 = Vector2.Distance(itemPosition1, enemyPosition);
                float dis2 = Vector2.Distance(itemPos2, enemyPosition);
                float dis3 = Vector2.Distance(itemPos3, enemyPosition);

                if (distance1 < 32)
                {
                    killFlag = true;
                    e.Hit();
                }
                if (dis2 < 32)
                {
                    killFlag = true;
                    e.Hit();
                }
                if (dis3 < 32)
                {
                    killFlag = true;
                    e.Hit();
                }
            }
            if (itemPosition1.Y > Screen.height + 32)
            {
                //endFlag = true;
            }
            if (itemPos2.Y > Screen.height + 32)
            {
                //endFlag = true;
            }
            if (itemPos3.Y > Screen.height + 32)
            {
                //endFlag = true;
            }
        }
        public bool IsDead()
        {
            return deadFlag;
        }
        public bool IsDead2()
        {
            return deadF2;
        }

        public bool IsKill()
        {
            return killFlag;
        }

        public bool IsKill2()
        {
            return killFlag2;
        }

        public bool IsNextTop()
        {
            return nxStageFTop;
        }

        public bool IsNextLeft()
        {
            return nxStageFLeft;
        }

        public bool IsNextRight()
        {
            return nxStageFRight;
        }
    }
}
