using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BulletPrefab : GameObject, IPooledObject
    {
        SpriteRenderer spriteRenderer;
        Bullet bulletBehaviour;
        public BulletPrefab()
        {
            Engine.Debug("NON POOLED, CREATED!!!!!!!!------");
            ColliderManager.Instance.AddBulletCollider(this);
            bulletBehaviour = new Bullet(this, false);
            AddComponent(bulletBehaviour);
            spriteRenderer = GetComponent<SpriteRenderer>();               
        }
        public void Reset(Vector2 resetPosition, float rot)
        {
            transform.position = resetPosition;
            transform.rotation = rot;
        }
        public void BulletReset(Vector2 resetPosition, float rot, bool isAlly)
        {
            ColliderManager.Instance.AddBulletCollider(this);
            IsEnabled = true;
            bulletBehaviour.Ally = isAlly;
            Reset(resetPosition,rot);
        }

        public void Disable()
        {
            IsEnabled=false;
            ColliderManager.Instance.RemoveBulletCollider(this);
            Program.bullets.AddToPool(this);
        }
    }
}
