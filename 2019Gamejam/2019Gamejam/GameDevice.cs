using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;//リソースへのアクセス
using System.Diagnostics;//Assert用
using Microsoft.Xna.Framework.Graphics;


namespace _2019Gamejam
{
    sealed class GameDevice
    {
        //唯一のインスタンス
        private static GameDevice instance;

        private Render render;
        private ContentManager content;
        private GraphicsDevice graphics;
        private Sound sound;
        private GameDevice(ContentManager content,GraphicsDevice graphics)
        {
            render = new Render(content, graphics);
            sound = new Sound(content);
            this.content = content;
            this.graphics = graphics;
        }

        public static GameDevice Instance(ContentManager content, GraphicsDevice graphics)
        {
            //インスタンスがまだ生成されていなければ生成する
            if (instance == null)
            {
                instance = new GameDevice(content, graphics);
            }
            return instance;
        }
        public static GameDevice Instance()
        {
            //まだインスタンスが生成されていなければエラー文を出す
            Debug.Assert(instance != null, "Game1クラスのInitializeメソッド内で引数付きInstanceメソッドをよんでください");

            return instance;
        }
        public void Initialize()
        {

        }
        public void Update()
        {
        }
        public Render GetRender()
        {
            return render;
        }
        public ContentManager GetContentManager()
        {
            return content;
        }
        public GraphicsDevice GetGraphicsDevice()
        {
            return graphics;
        }
        public Sound GetSound()
        {
            return sound;
        }
    }
}
