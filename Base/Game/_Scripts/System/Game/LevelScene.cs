using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class LevelScene : Scene
    {
        private GameObject playerGameObject;
        public Pool<BulletPrefab> bullets; //TODO: ENCAPSULAR

        public override void SetupScene()
        {
            InitializeBackground();
            InitializeManagers();
            InitializeBPM();
            InitializePlayers();
            InitializeEnemies();
            InitializeMusic();
        }

        private void InitializeBackground()
        {
            var background = new GameObject();
            var bg = new SpriteRenderer(0);
            bg.SetTexture(Engine.GetTexture("Textures/Backgrounds/bgSpace.png"));
            background.transform.SetPosition(new Vector2(0, 200));
            background.AddComponent(bg);
        }

        private void InitializeManagers()
        {
            GameObject colMngGo = new GameObject();
            ColliderManager.Instance.Reset();
            bullets = new Pool<BulletPrefab>();
            colMngGo.AddComponent(ColliderManager.Instance);
        } 

        private void InitializePlayers()
        {
            playerGameObject = new GameObject("Player");
            PlayerCharacter player = new PlayerCharacter(playerGameObject, "Textures/Player/Player.png");
            playerGameObject.AddComponent(player);
        }

        private void InitializeEnemies()
        {
            int posX = 75;
            for (int i = 0; i < 5; i++)
            {
                var enemyGameObject = new GameObject("Enemy");
                EnemyCharacter enemyCharacter = EnemyFactory.CreateEnemy(enemyGameObject, TypeOfEnemy.Normal);
                enemyGameObject.AddComponent(enemyCharacter);
                enemyGameObject.transform.SetPosition(new Vector2((i * 140) + posX, 50));
            }
        }
        private void InitializeBPM()
        {
            GameObject metronome = new GameObject();
            metronome.AddComponent(new Metronome());
        }
        private void InitializeMusic()
        {
            SoundPlayer soundPlayer = new SoundPlayer("music.wav");
            soundPlayer.PlayLooping();
        }
    }
}
