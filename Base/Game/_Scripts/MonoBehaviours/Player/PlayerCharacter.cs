using System;
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
        private Vector2 speed = new Vector2( 300,200);
        private float shootCD =0.3f;
        private float shootTimer;
        private float playerHalfWidth=50f;
        private const string ENGINEANIMATION = "Engine";
        private const string IDLE = "Idle";
        private const string IDLE2 = "Idle2";
        private const string IDLE3 = "Idle3";
        private const string IDLE4 = "Idle4";
        private const string EXPLOSIONANIMATION = "Explosion";

        // Al crear el script se agregan todos los componentes
        // 
        public PlayerCharacter(GameObject _gameObject, string textureName) : base(_gameObject, textureName) // : base hace como de "pasamanos", como la clase de la que hereda (BaseCharacter) necesita en su constructor estos parametros, PlayerCharacter los pide al ser construido y se los pasa
        {
            health = 4;
            _gameObject.AddComponent(animator);
            engineGameObject = new GameObject();
            engineGameObject.transform.scale = new Vector2(2.5f, 2.5f);
            SpriteRenderer engineSpriteRenderer = new SpriteRenderer(1);
           // engineSpriteRenderer.Layer = 1;
            Animator engineAnimator = new Animator();
            
            engineAnimator.CreateAnimation(ENGINEANIMATION,"Textures/Animations/Engine/",3,0.1f,true);
            engineAnimator.SetAnimation(ENGINEANIMATION);

            //creas una animacion de muerte y la guardas
            animator.CreateAnimation(IDLE, "Textures/Animations/Player/Idle1/", 1, 0.1f, true);
            animator.SetAnimation(IDLE);

            animator.CreateAnimation(IDLE2, "Textures/Animations/Player/Idle2/", 1, 0.1f, true);
            animator.CreateAnimation(IDLE3, "Textures/Animations/Player/Idle3/", 1, 0.1f, true);
            animator.CreateAnimation(IDLE4, "Textures/Animations/Player/Idle4/", 1, 0.1f, true);

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
            transform.scale = new Vector2(0.3f, 0.3f);
            metronome = GameManager.Instance.CurrentScene.FindObjectOfType<Metronome>();
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

            ConstraintMovement();
        }

        private void ConstraintMovement()
        {
            Vector2 newPos=transform.position;
            ClampAxis(ref newPos.x);
            ClampAxis(ref newPos.y);
            transform.SetPosition(newPos);
        }

        private void ClampAxis(ref float axis)
        {
            if (axis<0 + playerHalfWidth)
            {
                axis = 0 + playerHalfWidth;
            }
            if (axis > 720 - playerHalfWidth)
            {
                axis = 719 - playerHalfWidth;
            }
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
            if (immunityTime <= 0)
            {
                health -= amount;
                if (health <= 0)
                {
                    Death();
                }
            }

            switch (health)
            {
                case 3:
                    animator.SetAnimation(IDLE2);
                    break;

                case 2:
                    animator.SetAnimation(IDLE3);
                    break;

                case 1:
                    animator.SetAnimation(IDLE4);
                    break;
            }

        }
        /// <summary>
        /// Termina el juego
        /// </summary>
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
