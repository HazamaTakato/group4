using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;//vector2用
using Microsoft.Xna.Framework.Input;//入力処理用

namespace _2019Gamejam
{
    class Player
    {
        private Vector2 position;
        Direction dir;
        private Sound sound;

        public Player()
        {
        }

        public void Initialize()
        {
            position = new Vector2(620, 670);
            dir = Direction.Down;
        }


        public void Update(GameTime gameTime)
        {
            //移動量
            Vector2 velocity = Vector2.Zero;

            //右
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X = 1f;
                dir = Direction.Right;
                if (position.X >= Screen.width-96)
                {
                    velocity.X = 0f;
                }
            }
            //左
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity.X = -1f;
                dir = Direction.Left;
                if (position.X <= 64)
                {
                    velocity.X = 0f;
                }
            }
            //上
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity.Y = -1f;
                dir = Direction.Up;
                if (position.Y <= 64)
                {
                    velocity.Y = 0f;
                }
            }
            //下
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity.Y = 1f;
                dir = Direction.Down;
                if (position.Y >= Screen.height - 96)
                {
                    velocity.Y = 0f;
                }
            }
            //正規化
            if (velocity.Length() != 0)
            {
                velocity.Normalize();
            }

            //移動処理
            float speed = 15.0f;
            position = position + velocity * speed;
        }
        public Vector2 GetPosition()
        {
            return position;
        }


        public void SetPos(ref Vector2 other)
        {
            other = position;
        }

        public void Draw(Render render)
        {
            if (dir == Direction.Down)
            {
                render.DrawTexture("playerrinkmae", position);
            }
            if (dir == Direction.Left)
            {
                render.DrawTexture("playerrink", position);
            }
            if (dir == Direction.Right)
            {
                render.DrawTexture("playerrinkmigi", position);
            }
            if (dir == Direction.Up)
            {
                render.DrawTexture("playerrinkusiro", position);
            }
        }


        public void Shutdown()
        {

        }
    }
}
