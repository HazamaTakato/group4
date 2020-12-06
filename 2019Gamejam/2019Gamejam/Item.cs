using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;//vector2用
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace _2019Gamejam
{
    class Item
    {
        // アイテムの回転速度    
        float RotateSpeed = 4.0f;
        // アイテムの回転半径
        float ItemRadius = 100.0f;
        // アイテムの回転角度
        float angle = 0;
        // アイテムの位置を格納するリスト
        List<Vector2> itemPositions = new List<Vector2>();
        Vector2 itemPos;
        Vector2 itemPos2;
        Vector2 itemPos3;
        // プレイヤーの位置
        public Vector2 PlayerPos;

        KeyboardState prevKeyboardState;

        int itemCount = 0;

        public Item(Vector2 playerPos)
        {
            PlayerPos = playerPos;
            RotateSpeed = 4.0f;
            ItemRadius = 100.0f;
            angle = 0;
            itemCount = 0;
        }

        public void Update(GameTime gameTime)
        {
            // アイテムの回転角度を更新
            angle += RotateSpeed;
            itemPos = Vector2.Zero;
            itemPos2 = Vector2.Zero;
            itemPos3 = Vector2.Zero;
            // スペースキーを押したら、アイテムを追加する
            if (prevKeyboardState.IsKeyUp(Keys.B) &&
                Keyboard.GetState().IsKeyDown(Keys.B))
            {
                ItemRadius = 200f;
                RotateSpeed = 2.0f;
            }
            if(prevKeyboardState.IsKeyUp(Keys.N)&&
                Keyboard.GetState().IsKeyDown(Keys.N))
            {
                ItemRadius = 100f;
                RotateSpeed = 4.0f;
            }
            // アイテムの位置を更新
            //for (int i = 0; i < itemPositions.Count; i++)
            //{
                float delta = 360f / 3;// アイテム同士の角度
                float angle1 = delta * 1 + angle;
                float angle2 = delta * 2 + angle;
                float angle3 = delta * 3 + angle;

                itemPos =
                    CalcOptionPosition(PlayerPos, angle1, ItemRadius);
                itemPos2 =
                    CalcOptionPosition(PlayerPos, angle2, ItemRadius);
                itemPos3 =
                     CalcOptionPosition(PlayerPos, angle3, ItemRadius);

            //}

            // 次フレームで使うためにキーボードの押下状況を保存しておく
            prevKeyboardState = Keyboard.GetState();



        }

        /// <summary>
        /// アイテムの位置を計算して返却する
        /// </summary>
        /// <param name="center">回転の中心位置</param>
        /// <param name="angle">回転角度</param>
        /// <param name="radius">回転の半径</param>
        /// <returns>アイテムがあるべき位置</returns>
        Vector2 CalcOptionPosition(Vector2 center, float angle, float radius)
        {
            // 度数法の角度をラジアンに変換する
            float radian = MathHelper.ToRadians(angle);
            // サインとコサインを使って位置を計算する
            return center + new Vector2((float)Math.Cos(radian),
                (float)Math.Sin(radian)) * radius;
        }

        public void Draw(Render render)
        {
           render.DrawTexture("beam", itemPos);
           render.DrawTexture("beam", itemPos2);
           render.DrawTexture("beam", itemPos3);
        }
        public Vector2 GetPos1()
        {
            return itemPos;
        }

        public Vector2 GetPos2()
        {
            return itemPos2;
        }

        public Vector2 GetPos3()
        {
            return itemPos3;
        }

    }
}
