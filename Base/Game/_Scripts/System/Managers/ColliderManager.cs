using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    class ColliderManager : IMonoBehaviour
    {
        #region Singleton
        private static ColliderManager instance;

        public static ColliderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ColliderManager();
                }
                return instance;
            }
        }
        #endregion

        private GameObject playerCollider;
        public GameObject PlayerCollider
        {
            get { return playerCollider; }
            set { playerCollider = value; }
        }

        private List<GameObject> enemies = new List<GameObject>();
        public List<GameObject> EnemyColliders
        {
            get
            {
                List<GameObject> eCols = enemies;
                return eCols;
            }
        }

        private List<BulletPrefab> bullets = new List<BulletPrefab>();

        public void AddEnemyCollider(GameObject col)
        {
            enemies.Add(col);
        }

        public void AddBulletCollider(BulletPrefab col)
        {
            bullets.Add(col);
        }

        public void RemoveEnemyCollider(GameObject col)
        {
            enemies.Remove(col);
        }

        public void RemoveBulletCollider(BulletPrefab col)
        {
            bullets.Remove(col);
        }

        public void Reset()
        {
            bullets.Clear();
            enemies.Clear();
            playerCollider = null;
        }

        public bool AreCircleColliding(GameObject p_objA, GameObject p_objB)
        {
            float distanceX = p_objA.transform.position.x - p_objB.transform.position.x;
            float distanceY = p_objA.transform.position.y - p_objB.transform.position.y;

            float totalDistance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            return totalDistance < p_objA.Radius + p_objB.Radius;
        }

        public void Awake(GameObject gameObject)
        {

        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    // Por si se agregan balas antes de que se haga el chequeo de la función
                    if ((j >= enemies.Count || i >= bullets.Count))
                    {
                        return;
                    }
                    if (!enemies[j].IsEnabled || !bullets[i].IsEnabled)
                    {
                        return;
                    }
                    // Chequeamos la colisión entre la balla y el enemigo
                    if (AreCircleColliding(bullets[i], enemies[j]))
                    {
                        //Se guarda una referencia de la bullet
                        var b = bullets[i].GetComponent<Bullet>();
                        if (b.Ally)
                        {
                            var enemy = enemies[j].GetComponent<EnemyCharacter>();
                            enemy.TakeDamage(3);
                            bullets[i].Disable();
                        }
                    }

                    else if (AreCircleColliding(bullets[i], playerCollider))
                    {
                        var b = bullets[i].GetComponent<Bullet>();
                        if (!b.Ally)
                        {
                            var player = playerCollider.GetComponent<PlayerCharacter>();
                            player.TakeDamage(1);
                            bullets[i].Disable();
                        }
                    }
                }
            }
        }
    }
}