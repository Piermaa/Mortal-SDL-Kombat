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
            InitializeMusic();
            InitializeBPM();
            InitializeBackground();
            InitializeManagers();
            InitializePlayers();
            InitializeEnemyManager();
            InitializeUI();
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

        private void InitializeBPM()
        {
            GameObject metronome = new GameObject();
            metronome.AddComponent(new Metronome());
        }

        private void InitializeEnemyManager()
        {
            GameObject enemyManager = new GameObject();
            enemyManager.AddComponent(new EnemyManager());
        }

        private void InitializeMusic()
        {
            SoundPlayer soundPlayer = new SoundPlayer("8BitMusic.wav");
            soundPlayer.PlayLooping();
        }

        private void InitializeUI()
        {
            GameObject canvas = new GameObject();
            canvas.AddComponent(new SpriteRenderer(4));
            canvas.AddComponent(new BpmIcon());

            GameObject healthBar = new GameObject();
            healthBar.transform.position = new Vector2(402,700);
            healthBar.transform.scale = new Vector2(.5f, .9f);
            healthBar.AddComponent(new SpriteRenderer(4));
            healthBar.AddComponent(new HealthUI());

            //POR QUE HICISTE ESTO PIERMA??
            //PORQUE LA BARRA DE VIDA QUEDABA FEA SI SE LLENABA DE DERECHA A IQZ
            //ENTONCES ASI SON 2 BARRAS Q SE LLENAN PERO ESTAN INVERTIDAS ENTONCES QUEDA CENTRADO
            //SI NO ENTENDES DESP TE MUESTRO PARA MIQUEDA MEJOR UWU OWO EWE
            GameObject healthBar2 = new GameObject();
            healthBar2.transform.position = new Vector2(310, 700);
            healthBar2.transform.scale = new Vector2(.5f, .9f);
            healthBar2.AddComponent(new SpriteRenderer(4));
            HealthUI ui= new HealthUI();
            ui.FilePathModifier = "/inverse/";
            healthBar2.AddComponent(ui);
        }
    }
}
