using System;
using System.Collections.Generic;
using System.Media;
namespace Game
{
    class GameManager
    {
        #region Singleton
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        #endregion
        private Vector2 windowDimensions;

        public Vector2 WindowDimensions
        {
            set {windowDimensions=value; }
        }

        private bool isPlaying;
        private int gameState;

        private static List<GameObject> hierarchy = new List<GameObject>();
        public void AddGameObject(GameObject go)
        {
            hierarchy.Add(go);
        }
        public void RemoveGameObject(GameObject go)
        {
            hierarchy.Remove(go);
        }

        public void Update()
        {
            Menu();
            if (CheckGameOver())
            {
                Win();
            }
            if (!isPlaying)
            {
                Texture menuTexture = Engine.GetTexture("UI/PressEnter.png");
                Texture winTexture = Engine.GetTexture("UI/Win.png");

                switch (gameState)
                {
                    case (0):
                        
                        Engine.Draw(menuTexture, windowDimensions.x / 2 - menuTexture.Width * 2, windowDimensions.y / 2 - menuTexture.Height * 2, 5, 5, 0, 0, 0);
                        break;

                    case (1):
                        Engine.Draw(winTexture, 0, windowDimensions.y / 4, 0.5f, 0.5f, 0, 0, 0);
                        break;

                    case (2):
                        Engine.Debug("perdiste wn");
                        break;
                }
            }
            else
            {
                for (int i = 0; i < hierarchy.Count; i++)
                {
                    hierarchy[i].Update(Program.deltaTime);
                }

            }
        }

        private static void InitializeMusic()
        {
            SoundPlayer soundPlayer = new SoundPlayer("Space Game Music.wav");
            soundPlayer.PlayLooping();
        }

        private static void InitializeManagers()
        {
            GameObject colMngGo = new GameObject();

            colMngGo.AddComponent(ColliderManager.Instance);
        }

        public void Menu()
        {
            if (Engine.GetKey(Keys.RETURN) && !isPlaying)
            {
                isPlaying = true;
                InitializeManagers();
                InitializePlayers();
                InitializeEnemies();
                InitializeMusic();
               
            }
        }

        private static void InitializePlayers()
        {
            GameObject playerGameObject;
            playerGameObject = new GameObject("Player");

            PlayerCharacter player = new PlayerCharacter(playerGameObject, "Animations/Player/Player.png");
            playerGameObject.AddComponent(player);
        }

        private static void InitializeEnemies()
        {
            int posX = 100;
            for (int i = 0; i < 5; i++)
            {
                var enemy = new GameObject("Enemy");
                EnemyCharacter enemyCharacter = new EnemyCharacter(enemy, "Animations/Enemy/Kla'ed - Fighter - Base.png", Math.Abs(i * 2 - 3));
                enemy.AddComponent(enemyCharacter);
                enemy.transform.SetPosition(new Vector2((i * 200) + posX, 50));
            }
        }

        public bool CheckGameOver()
        {
            return (ColliderManager.Instance.EnemyColliders.Count <= 0 && isPlaying);
       
        }

        public void Win()
        {
            isPlaying = false;
            gameState = 1;
        }
        public void GameOver()
        {
            isPlaying = false;
            gameState = 2;
        }
    }
}
