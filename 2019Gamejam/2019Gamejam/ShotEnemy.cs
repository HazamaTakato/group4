using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _2019Gamejam
{
    class ShotEnemy
    {
        private Vector2 pos;
        private Vector2 vel;
        private Vector2 vel2;
        private bool deadFlag;
        private Player p;
        private Random rand;
        private Sound sound;
        public ShotEnemy()
        {
            p = new Player();
            vel = new Vector2(-10f, 0);
            vel2 = new Vector2(-5f, -5f);
            rand = new Random();
            pos = new Vector2(rand.Next(64,1200), rand.Next(100,500));
            deadFlag = false;
        }

        public void Draw(Render render)
        {
            Rectangle rect = new Rectangle(0, 0, 64, 64);
            render.DrawTexture("enemy", pos);
        }

        public void Update()
        {
            if (pos.X < 64)
            {
                vel = -vel;
            }
            if (pos.X > 1216-32)
            {
                vel = -vel;
            }
            pos += vel;
        }
        

        public void Hit()
        {

            deadFlag = true;
        }

        public bool IsDead()
        {
            return deadFlag;
        }

        public Vector2 GetPos()
        {
            return pos;
        }
    }
}
