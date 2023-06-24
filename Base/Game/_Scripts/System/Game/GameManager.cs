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
        private const string MENU_KEY = "Menu";
        private const string GAME_KEY="Game";
        private const string GAMEOVER_KEY="GameOver";

        public string MENU_KEY_Getter=>MENU_KEY;
        

        private Dictionary<string,Scene> scenes=new Dictionary<string, Scene>();

        private Scene currentScene;
        public Scene CurrentScene
        {
            get {return currentScene; }
        }

        // Para dibujar sprites en pantalla
        private Vector2 windowDimensions;

        public Vector2 WindowDimensions
        {
            set {windowDimensions=value; }
        }

        private bool isPlaying;
        private int gameState;

        private List<GameObject> hierarchy = new List<GameObject>();

        // La lista es privada,por eso se crea una función pública para añadir o sacar elementos
        // Es mas seguro trabajar de esta forma
        public void AddGameObject(GameObject go)
        {
           currentScene.Hierarchy.Add(go);
        }
        public void RemoveGameObject(GameObject go)
        {
           currentScene.Hierarchy.Remove(go);
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
                Texture looseTexture = Engine.GetTexture("UI/Fail.png");

                // Textura a dibujar dependiendo del estado del juego (Menu, Ganar y Perder)

                switch (gameState)//TODO: Cambiar numeros magicos por un enum
                {
                    case (0):
                        Engine.Draw(menuTexture, windowDimensions.x / 2.2f - menuTexture.Width * 2, windowDimensions.y / 2 - menuTexture.Height * 2, 5, 5, 0, 0, 0);
                        break;

                    case (1):
                        Engine.Draw(winTexture, 100, windowDimensions.y / 4, 0.3f, 0.3f, 0, 0, 0);
                        break;

                    case (2):
                        Engine.Draw(looseTexture, 0, windowDimensions.y / 5, 0.5f, 0.5f, 0, 0, 0);
                        break;
                }
            }
            else
            {
                currentScene.Update();
                currentScene.Render();
            }
        }
        private void CreateScene(string sceneName)
        {
            Scene newScene = new Scene();
            scenes.Add(sceneName, newScene);
        }
        public void ScenesCreation()
        {
            CreateScene(MENU_KEY);
            CreateScene(GAME_KEY);
            CreateScene(GAMEOVER_KEY);
        }
        public void ChangeScene(string sceneToChange)
        {
            currentScene = scenes[sceneToChange];
        }
        
        private void InitializeMusic()
        {
            SoundPlayer soundPlayer = new SoundPlayer("Space Game Music.wav");
            soundPlayer.PlayLooping();
        }

        private void InitializeManagers()
        {
            GameObject colMngGo = new GameObject();

            colMngGo.AddComponent(ColliderManager.Instance);
        }

        public void Menu()
        {
            if (Engine.GetKey(Keys.RETURN) && !isPlaying)
            {
                isPlaying = true;
                ChangeScene(GAME_KEY);
                InitializeBackground();
                InitializeManagers();
                InitializePlayers();
                InitializeEnemies();
                InitializeMusic();
            }
        }
        private void InitializeBackground()
        {
            var background = new GameObject();
            var bg = new SpriteRenderer();
            bg.SetTexture(Engine.GetTexture("Textures/Backgrounds/bgSpace.png"));
            background.transform.SetPosition(new Vector2(0,200));
            background.AddComponent(bg);
        }

        private void InitializePlayers()
        {
            var engineGameObject = new GameObject();
            GameObject playerGameObject;
            playerGameObject = new GameObject("Player");
            
            PlayerCharacter player = new PlayerCharacter(playerGameObject, "Animations/Player/Player.png",engineGameObject);
            playerGameObject.AddComponent(player);
        }

        private void InitializeEnemies()
        {
            int posX = 75;
            for (int i = 0; i < 5; i++)
            {
                var enemy = new GameObject("Enemy");
                EnemyCharacter enemyCharacter = new EnemyCharacter(enemy, "Animations/Enemy/Kla'ed - Fighter - Base.png", Math.Abs(i * 2 - 3));
                enemy.AddComponent(enemyCharacter);
                enemy.transform.SetPosition(new Vector2((i * 140) + posX, 50));
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
            hierarchy.Clear();
        }

        public void GameOver()
        {
            isPlaying = false;
            gameState = 2;
            hierarchy.Clear();
        }
    }
}
