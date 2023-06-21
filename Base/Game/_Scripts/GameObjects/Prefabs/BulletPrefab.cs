using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BulletPrefab : GameObject, IPooledObject
    {
        private Bullet bulletBehaviour;
        private SpriteRenderer spriteRenderer= new SpriteRenderer(1);

        public BulletPrefab()
        {
            bulletBehaviour = new Bullet();
            AddComponent(bulletBehaviour);
            var rb = new RigidBody();
            AddComponent(rb);
            bulletBehaviour.RigidBody = rb; //AGREGAR EL RB ANTES ROMPE TODO DESCONOZCO
            AddComponent(spriteRenderer);
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
        /// y se mete en la Pool de balas de la escena del nivel
        /// </summary>

        public void Disable()
        {
            IsEnabled=false;
            ColliderManager.Instance.RemoveBulletCollider(this);
            GameManager.Instance.AddBullet(this);
        }
    }
}
