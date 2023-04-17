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
        public List<GameObject> EnemyColliders => enemyColliders;

        private List<GameObject> bulletColliders = new List<GameObject>();
        public List<GameObject> BulletColliders => bulletColliders;

        public void AddCollider(GameObject col)
        {
            enemyColliders.Add(col);
            Engine.Debug("Has been added");
        }


        //public bool IsBoxColliding(Transform p_objB)
        //{
        //    float distanceX = Math.Abs(transform.position.x - p_objB.position.x);
        //    float distanceY = Math.Abs(transform.position.y - p_objB.position.y);

        //    float sumHWidths = transform.scale.x / 2 + p_objB.scale.x / 2;
        //    float sumHHeights = transform.scale.y / 2 + p_objB.scale.y / 2;

        //    return distanceX <= sumHWidths && distanceY <= sumHHeights;

        //}
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

        public void Start()
        {
           
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < enemyColliders.Count; i++)
            {
                if (AreCircleColliding(playerCollider, enemyColliders[i]))
                {
                    Engine.Debug("HAS COLLIDED WITH PLAYER");
                }
            }

            if (bulletColliders.Count > 0)
            {
                for (int i = 0; i < enemyColliders.Count; i++)
                {
                    for (int j = 0; j < bulletColliders.Count; j++)
                    {
                        if (AreCircleColliding(enemyColliders[i], bulletColliders[j]))
                        {
                            Engine.Debug("HAS COLLIDED WITH ENEMY");
                        }
                    }
                }
            }
        }
    }
}
