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

        private List<GameObject> enemyColliders = new List<GameObject>();
        public List<GameObject> EnemyColliders
        {
            get { 
               List<GameObject> eCols= enemyColliders; 
               return eCols;
            }
        } 

        private List<GameObject> bulletColliders = new List<GameObject>();

       
        public void RemoveEnemyCollider(GameObject col)
        {
            enemyColliders.Remove(col);
        }
        public void RemoveBulletCollider(GameObject col)
        {
            bulletColliders.Remove(col);
        }


        public void AddEnemyCollider(GameObject col)
        {
            enemyColliders.Add(col);
        }
        public void AddBulletCollider(GameObject col)
        {
            bulletColliders.Add(col);
        }

        public bool AreCircleColliding(GameObject p_objA, GameObject p_objB)
        {
            float distanceX = p_objA.transform.position.x - p_objB.transform.position.x;
            float distanceY = p_objA.transform.position.y - p_objB.transform.position.y;

            //float sumHalfWidths = p_objA.Scale.x / 2 + p_objA.Scale.x / 2;
            //float sumHalfHeight = p_objA.Scale.y / 2 + p_objB.Scale.y / 2;

            //Vector2 dir = new Vector2(distanceX, distanceY);

            float totalDistance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            return totalDistance < p_objA.Radius + p_objB.Radius;
        }

        public void Awake(GameObject gameObject)
        {
        }


        public void Update(float deltaTime)
        {
          
            if (bulletColliders.Count > 0)
            {
                for (int i = 0; i < bulletColliders.Count; i++)
                {

                    for (int j= 0; j < enemyColliders.Count; j++)
                    {
                        if (j>= enemyColliders.Count || i >= bulletColliders.Count)
                        {
                            return;
                        }
                        if (AreCircleColliding(bulletColliders[i], enemyColliders[j]))
                        {
                            var b = bulletColliders[i].GetComponent<Bullet>();
                            if (b.Ally)
                            {
                                var enemy = enemyColliders[j].GetComponent<EnemyCharacter>();
                                enemy.TakeDamage(3);
                                bulletColliders[i].Destroy();
                    
                            }
                        }
                        else if (AreCircleColliding(bulletColliders[i], playerCollider))
                        {
                            var b = bulletColliders[i].GetComponent<Bullet>();
                            if (!b.Ally)
                            {
                                var player = playerCollider.GetComponent<PlayerCharacter>();
                                player.TakeDamage(1);
                                bulletColliders[i].Destroy();

                            }
                        }
                    }
                }
            }
        }



    }
}
