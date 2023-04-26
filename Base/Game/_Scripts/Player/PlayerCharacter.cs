﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PlayerCharacter :BaseCharacter, IMonoBehaviour
    {
    

        private GameObject engineGameObject;
        private RigidBody rb;
        private float speed = 300;

        private float shootCD =1;
        private float shootTimer;
        private const string ENGINEANIMATION = "Engine";

        // Al crear el script se agregan todos los componentes
        public PlayerCharacter(GameObject _gameObject, string textureName,GameObject p_engineGameObject) : base(_gameObject)
        {
            engineGameObject= p_engineGameObject;
            engineGameObject.transform.scale = new Vector2(2.5f, 2.5f);

            SpriteRenderer engineSpriteRenderer = new SpriteRenderer();
            Animator engineAnimator = new Animator();
            engineAnimator.CreateAnimation(ENGINEANIMATION,"Textures/Animations/Engine/",3,0.1f);
            engineAnimator.SetAnimation(ENGINEANIMATION);

            engineGameObject.AddComponent(engineSpriteRenderer);
            engineGameObject.AddComponent(engineAnimator);

            AddSprite(textureName);
        }

        public void Awake(GameObject _gameObject)
        {
            rb = _gameObject.GetComponent<RigidBody>();
            transform.SetPosition(new Vector2(720/2,600));
            transform.scale = new Vector2(3, 3);
        }

        public void Update(float deltaTime)
        {
            engineGameObject.transform.SetPosition(new Vector2(transform.position.x, transform.position.y + 30));
            Movement();
            Shoot(deltaTime);
        }

        public void Render()
        {
       
        }


        private void Movement()
        {
            float x = InputManager.GetAxisRaw("Horizontal");
            float y = InputManager.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(x, y);
            dir = dir.Normalize();
            rb.Velocity = dir * speed;
        }

        private void Shoot(float deltaTime)
        {
            shootTimer = shootTimer > 0 ? shootTimer - deltaTime : 0;
            if (Engine.GetKey(Keys.SPACE) && shootTimer <= 0)
            {
                shootTimer = shootCD;
                var b = new GameObject("Bullet");

                // Se crea la bala como Ally asi sube y puede colisionar con los enemigos
                Bullet bullet = new Bullet(b, true);
                b.transform.position = transform.position + Vector2.Up * 10;
            }
        }

        // Se overridea la virtual void para que cumpla otra función
        public override void Death()
        {
            GameManager.Instance.GameOver();
        }
    }
}
