using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class SELoader:Loader
    {
        private Sound sound;

        public SELoader(string[,] resouces)
            : base(resouces)
        {
            sound = GameDevice.Instance().GetSound();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // まず終了フラグを有効にして
            isEndFlag = true;
            // カウンタが最大に達していないか？
            if (counter < maxNum)
            {
                // BGMの読み込みの読み込み
                sound.LoadSE(resources[counter, 0], resources[counter, 1]);
                // カウンタを増やす
                counter += 1;
                // 読み込むものがあったので終了フラグを継続に設定
                isEndFlag = false;
            }
        }
    }
}
