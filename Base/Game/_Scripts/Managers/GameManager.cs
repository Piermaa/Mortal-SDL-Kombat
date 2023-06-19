using System;
using System.Collections.Generic;
using System.Media;
namespace Game
{
    public class GameManager
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

        private void Win()
        {
            gameState = 1;
            SetMenuScene();
        }

        private void ResetGame()
        {
            currentScene.Reset();
        }

        public void Update()
        {
            if (currentScene == levelScene)
            {
                if (CheckGameOver())
                {
                    //Win();
                }
            }
            else
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

        public void GameOver()
        {
            gameState = 2;
            SetMenuScene();
        }
    }
}
