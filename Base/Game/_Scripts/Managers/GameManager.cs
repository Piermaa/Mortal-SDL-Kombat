using System;
using System.Collections.Generic;
using System.Media;
namespace Game
{
    public class GameManager
    {
        public int Score 
        {
            get => score;
            set { score = value; }
        }

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
        public Scene CurrentScene
        {
            get { return currentScene; }
        }

        public Vector2 WindowDimensions
        {
            set { windowDimensions = value; }
            get { return windowDimensions; } 
        }

        public int GameState => gameState;
        private int gameState;

        private Scene currentScene;
        private LevelScene levelScene=new LevelScene();
        private MenuScene menuScene=new MenuScene();

        private Vector2 windowDimensions;
        private int score;

        private const string SCORE_TEXT = "============================= \n Score: ";

        public void GameOver()
        {
            gameState = 2;
            Engine.Debug(SCORE_TEXT + score);
            SetMenuScene();
        }

        public void Win()
        {
            gameState = 1;
            Engine.Debug(SCORE_TEXT+score);
            SetMenuScene();
        }

        private void ResetGame()
        {
            score = 0;
            currentScene.Reset();
        }

        public void Update()
        {
          
            if(currentScene==menuScene)
            {
                if (Engine.GetKeyDown(Keys.RETURN))
                {
                    SetLevelScene();
                }
            }

            currentScene.Update();
            currentScene.Render();
        }

        public void AddGameObject(GameObject go)
        {
           currentScene.Hierarchy.Add(go);
        }

        public void RemoveGameObject(GameObject go)
        {
           currentScene.Hierarchy.Remove(go);
        }

        public BulletPrefab GetBullet()
        {
            return levelScene.bullets.GetObject();
        }

        public void AddBullet(BulletPrefab bulletToAdd)
        {
            levelScene.bullets.AddToPool(bulletToAdd);
        }
       
        public void SetLevelScene()
        {
            currentScene = levelScene;
            ResetGame();
            currentScene.SetupScene();
        }

        public void SetMenuScene()
        {
            currentScene = menuScene;
            ResetGame();
            currentScene.SetupScene();
        }

        public bool CheckGameOver()
        {
            return (ColliderManager.Instance.EnemyColliders.Count <= 0);
        }

      
    }
}
