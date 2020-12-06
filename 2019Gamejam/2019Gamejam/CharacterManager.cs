using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019Gamejam
{
    class CharacterManager
    {
        private Player player;
        private Item item;
        private List<ShotEnemy> enemyList;
        private List<Enemy> enemys;
        private Random rand;
        private bool deadFlag;
        private Sound sound;

        public CharacterManager(Player player, Item item, Sound sound)
        {
            this.player = player;
            this.item = item;
            this.sound = sound;
            enemyList = new List<ShotEnemy>();
            enemys = new List<Enemy>();
            rand = new Random();
            deadFlag = false;
        }
        public void Initialize()
        {
            enemyList.Clear();
            enemys.Clear();
        }
        public void Update(GameTime gameTime)
        {
            foreach (var e in enemyList)
            {
                e.Update();
            }
            foreach(var ee in enemys)
            {
                ee.Update(gameTime);
            }
            EnemyBorn();
            enemys.RemoveAll(enemys => enemys.IsDead() == true);
            enemyList.RemoveAll(e => e.IsDead() == true);
        }
        public void Draw(Render renderer)
        {
            foreach (var e in enemyList)
            {
                e.Draw(renderer);
            }
            foreach(var ee in enemys)
            {
                ee.Draw(renderer);
            }
        }
        void EnemyBorn()
        {
            if (rand.Next(250) == 0)
            {
                enemyList.Add(new ShotEnemy());
                enemys.Add(new Enemy(player));
            }
        }
        public List<ShotEnemy> GetEnemyes()
        {
            return enemyList;
        }
        public List<Enemy> GetEnemies()
        {
            return enemys;
        }
    }
}
