using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class Flag
    {
        public Vector2 pos;
        private bool endFlag;
        private Player p;

        public Flag(Player p)
        {
            this.p = p;
            endFlag = false;
            pos = new Vector2(620, 300);
        }
        public void Draw(Render render)
        {
            render.DrawTexture("Goal", pos);
        }
        public void Update()
        {

        }
        public void Hit()
        {
            endFlag = true;
        }

        public bool IsEnd()
        {
            return endFlag;
        }
        public Vector2 GetGPos()
        {
            return pos;
        }
    }
}
