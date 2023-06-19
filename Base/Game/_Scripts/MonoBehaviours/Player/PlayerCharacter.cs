﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PlayerCharacter : BaseCharacter, IMonoBehaviour, IDamagable
    {
        private Metronome metronome;

        private Animator animator = new Animator();
        private Animation idleAnimation;
        private Animation deathAnimation;
        private GameObject engineGameObject;
        private RigidBody rb;
        private float speed = 300;

        private float shootCD =0.3f;
        private float shootTimer;
        private const string ENGINEANIMATION = "Engine";
        private const string IDLE = "Idle";
        private const string EXPLOSIONANIMATION = "Explosion";

        // Al crear el script se agregan todos los componentes
        // 
        public PlayerCharacter(GameObject _gameObject, string textureName) : base(_gameObject, textureName) // : base hace como de "pasamanos", como la clase de la que hereda (BaseCharacter) necesita en su constructor estos parametros, PlayerCharacter los pide al ser construido y se los pasa
        {
            _gameObject.AddComponent(animator);
            engineGameObject = new GameObject();
            engineGameObject.transform.scale = new Vector2(2.5f, 2.5f);
            SpriteRenderer engineSpriteRenderer = new SpriteRenderer(1);
           // engineSpriteRenderer.Layer = 1;
            Animator engineAnimator = new Animator();
            
            engineAnimator.CreateAnimation(ENGINEANIMATION,"Textures/Animations/Engine/",3,0.1f,true);
            engineAnimator.SetAnimation(ENGINEANIMATION);

            //creas una animacion de muerte y la guardas
            animator.CreateAnimation(IDLE, "Textures/Animations/Player/", 1, 0.1f, true);
            animator.SetAnimation(IDLE);

            //creas una animacion de muerte y la guardas
            deathAnimation = animator.CreateAnimation(EXPLOSIONANIMATION, "Textures/Animations/Explosion/", 6, 0.1f, false);
            //a la animacion de muerte, le agregas como evento al terminar: Destroy
            deathAnimation.onAnimationFinish += Destroy;
            
            engineGameObject.AddComponent(engineSpriteRenderer);
            engineGameObject.AddComponent(engineAnimator);
        }

        public void Awake(GameObject _gameObject)
        {
            rb = _gameObject.GetComponent<RigidBody>();
            transform.SetPosition(new Vector2(720/2,600));
            transform.scale = new Vector2(3, 3); //esto lo dejamos asi?
            metronome= GameManager.Instance.CurrentScene.FindObjectOfType<Metronome>();
        }

        public void Update(float deltaTime)
        {
            engineGameObject.transform.SetPosition(new Vector2(transform.position.x, transform.position.y + 30));
            Movement();
            Shoot(deltaTime);
        }

        /// <summary>
        /// Se mueve al jugador con fuerzas en base las inputs
        /// </summary>
        private void Movement()
        {
            float x = InputManager.GetAxisRaw("Horizontal");
            float y = InputManager.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(x, y);
            dir = dir.Normalize();
            rb.Velocity = dir * speed;
        }

        /// <summary>
        /// Detecta si se pulsa Espacio, en caso de que si, se dispara. Tiene cooldown. Usa ObjectPooler
        /// </summary>
        /// <param name="deltaTime"></param>
        private void Shoot(float deltaTime)
        {
            shootTimer = shootTimer > 0 ? shootTimer - deltaTime : 0;

            if (Engine.GetKeyDown(Keys.SPACE) && metronome.CanShoot())
            {
                var bulletGameObject=GameManager.Instance.GetBullet();
                bulletGameObject.BulletReset(transform.position, 270, true);
            }
        }

        /// <summary>
        /// Se resta vida al character si no esta invulnerable
        /// </summary>
        /// <param name="amount">Cantidad de daño que tomara</param>
        public void TakeDamage(int amount)
        {
            Engine.Debug($"Player took {amount} damage");
            if (immunityTime <= 0)
            {
                health -= amount;
                if (health <= 0)
                {
                    Death();
                }
            }
        }
        /// <summary>
        /// Termina el juego
        /// </summary>
        /// 

        public void Death()
        {
            engineGameObject.Destroy();
            gameObject.transform.scale = new Vector2(0.75f, 0.75f);
            animator.SetAnimation(EXPLOSIONANIMATION);
        }

        public void Destroy()
        {
            deathAnimation.onAnimationFinish -= Destroy;
            GameManager.Instance.GameOver();
        }
    }
}
