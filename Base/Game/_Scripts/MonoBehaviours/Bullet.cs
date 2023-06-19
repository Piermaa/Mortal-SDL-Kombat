using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bullet : IMonoBehaviour
    {
        public bool Ally
        {
            get { return ally; }
            set { ally = value; }
        }
        public RigidBody RigidBody
        {
            set { rb = value; }
        }
        private float _speed = 750;
        private float _enemySpeed = 500;

        // Si es ally va para arriba y no colisiona con el player
        // Si no es ally va hacia abajo y colisiona con el player
        private bool ally;
      

        private RigidBody rb;
        private BulletPrefab gameObject;

        // Asbjørn Thirslund (Brackeys, inspirarse para el juego Móvil)

        public void Awake(GameObject gameObject)
        {
            this.gameObject = (BulletPrefab)gameObject;
            Engine.Debug("fui aniadido");
            gameObject.transform.scale = new Vector2(0.1f, 0.1f);
           // 
        }

        public void Update(float deltaTime)
        {
            if (ally)
            {
                rb.Velocity = Vector2.Up * _speed;
            }

            else
            {
                rb.Velocity = Vector2.Down * _enemySpeed;
            }

            // Trigger para destruir las balas que se van de la pantalla

            //TODO: pull de objetos
            if (gameObject.transform.position.y <- 10 || gameObject.transform.position.y >= 800)
            {
                gameObject.Disable();
            }
        }
    }
}
