using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BulletPrefab : GameObject, IPooledObject
    {
        Bullet bulletBehaviour;

        public BulletPrefab()
        {
            Engine.Debug("NON POOLED, CREATED!!!!!!!!------");
            ColliderManager.Instance.AddBulletCollider(this);
            bulletBehaviour = new Bullet(this, false);
            AddComponent(bulletBehaviour);           
        }
        public void Reset(Vector2 resetPosition, float rot)
        {
            transform.position = resetPosition;
            transform.rotation = rot;
        }
        public void BulletReset(Vector2 resetPosition, float rot, bool isAlly)
        {
            IsEnabled = true;
            bulletBehaviour.Ally = isAlly;

            Reset(resetPosition,rot);
            ColliderManager.Instance.AddBulletCollider(this);
        }

        /// <summary>
        /// Se borra del collider manager este gameobject para que no sea tomado en cuenta en las colisiones
        /// </summary>

        public void Disable()
        {
            IsEnabled=false;
            ColliderManager.Instance.RemoveBulletCollider(this);
            GameManager.Instance.bullets.AddToPool(this);
        }
    }
}
