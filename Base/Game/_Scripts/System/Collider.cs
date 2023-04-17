using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Collider
    {
        private Vector2 position;
        private float radius;

        public float Radius=>radius;
        public Vector2 Position => position;

        public Collider(Transform transform,float p_radius)
        {
            position = transform.position;
            radius = p_radius;

            ColliderManager.Instance.AddCollider(this);
        }
    }
}
