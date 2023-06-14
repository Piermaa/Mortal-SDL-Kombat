using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BulletPrefab : GameObject, IPooledObject
    {
        Bullet bulletBehaviour;
        SpriteRenderer spriteRenderer;

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
            IsEnabled = true;
            bulletBehaviour.Ally = isAlly;

            if (isAlly)
            {
                spriteRenderer.SetTexture(Engine.GetTexture("Textures/Player/Misil.png"));
                transform.scale = new Vector2(0.1f, 0.1f);
            }

            else
            {
                spriteRenderer.SetTexture(Engine.GetTexture("Textures/Player/Misil2.png"));
                transform.scale = new Vector2(0.2f, 0.2f);

            }

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
