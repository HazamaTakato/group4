using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class Enemy
    {
        public Vector2 Pos;
        private bool deadFlag;
        private Player p;
        private Random rand;
        public Enemy(Player p)
        {
            this.p = p;
            rand = new Random();
            rand = new Random();
            deadFlag = false;
            Pos = new Vector2(rand.Next(64, 1200), rand.Next(64,100));
        }

        public void Draw(Render render)
        {
            Rectangle rect = new Rectangle(0, 0, 64, 64);
            render.DrawTexture("enemy", Pos);
        }

        public virtual void Update(GameTime gameTime)
        {
            var otherpos = Vector2.Zero;
            p.SetPos(ref otherpos);
            var vel = otherpos - Pos;
            vel.Normalize();
            Pos += vel * 2;
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
            return Pos;
        }
    }
}
