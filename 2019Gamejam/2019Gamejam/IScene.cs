using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    interface IScene
    {
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(Render render);
        bool IsEnd();

        bool IsClear();
        bool IsKill();

        bool IsNextTop();

        bool IsNextLeft();

        bool IsNextRight();
        Scene Next();
    }
}
