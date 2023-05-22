﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bullet : IMonoBehaviour
    {
        private float _speed = 750;
        private float _enemySpeed = 500;

        // Si es ally va para arriba y no colisiona con el player
        // Si no es ally va hacia abajo y colisiona con el player
        private bool ally;
        public bool Ally
        {
            get { return ally; }    
            set { ally = value; }
        } 

        private RigidBody rb = new RigidBody();
        private BulletPrefab gameObject;

        public Bullet(BulletPrefab p_gameObject, bool isAlly)
        {
            gameObject = p_gameObject;
            p_gameObject.AddComponent(this);
            ally = isAlly;

            SpriteRenderer spriteRenderer = new SpriteRenderer();
            spriteRenderer.SetTexture(Engine.GetTexture("Animations/Player/Bullet.png"));

            // Añadimos los componentes al GameObject
            p_gameObject.AddComponent(spriteRenderer);
            p_gameObject.AddComponent(rb);

            //OnDie += Program.bullets.AddToPool;
        }

        // Asbjørn Thirslund (Brackeys, inspirarse para el juego Móvil)

        public void Awake(GameObject gameObject)
        {
           
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
