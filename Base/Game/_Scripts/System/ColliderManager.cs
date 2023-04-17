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

        private List<Collider> colliders = new List<Collider>();

        public List<Collider> Colliders => colliders;

        public void AddCollider(Collider col)
        {
            colliders.Add(col);

        }


        //public bool IsBoxColliding(Transform p_objB)
        //{
        //    float distanceX = Math.Abs(transform.position.x - p_objB.position.x);
        //    float distanceY = Math.Abs(transform.position.y - p_objB.position.y);

        //    float sumHWidths = transform.scale.x / 2 + p_objB.scale.x / 2;
        //    float sumHHeights = transform.scale.y / 2 + p_objB.scale.y / 2;

        //    return distanceX <= sumHWidths && distanceY <= sumHHeights;

        //}
        public bool AreCircleColliding(Collider p_objA, Collider p_objB)
        {
            float distanceX = Math.Abs(p_objA.Position.x - p_objB.Position.x);
            float distanceY = Math.Abs(p_objA.Position.y - p_objB.Position.y);

            Vector2 dir = new Vector2(distanceX, distanceY);

            return dir.Distance() <= p_objA.Radius+p_objB.Radius;

        }

        public void Awake(GameObject gameObject)
        {
     
        }

        public void Start()
        {
           
        }

        public void Update(float deltaTime)
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                for (int j = 0; j < colliders.Count; j++)
                {
                    if (AreCircleColliding(colliders[i], colliders[j]))
                    {
                        //Engine.Debug("collided:" + i + " and " + j);
                    }
                }
            }
        }
    }
}
