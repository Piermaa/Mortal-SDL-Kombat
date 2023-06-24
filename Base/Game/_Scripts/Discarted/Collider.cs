using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Collider : Monobehaviour
    {
        public GameObject gameObject;

        private Vector2 position;
        private Vector2 scale;
        private float radius;

        public float Radius=>radius;
        public Vector2 Position => gameObject.transform.position;
        public Vector2 Scale => gameObject.transform.scale;  

        public Collider(float p_radius, GameObject _gameObject)
        {

            //ColliderManager.Instance.AddCollider();
            this.gameObject = _gameObject;
        }

        public override void Awake(GameObject gameObject)
        {
        
        }
        public override void Update(float deltaTime)
        {
    
        }
    }
}
