using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyCharacter: BaseCharacter, IMonoBehaviour, IDamagable
    {
        Metronome metronome;

        private RigidBody rb = new RigidBody();
        private float speed = 100f;
        private int shootCD;
        private Animator animator = new Animator();
        private Animation deathAnimation;
        private const string EXPLOSIONANIMATION = "Explosion";
        private const string NORMAL_ENEMY_IDLE = "NormalEnemyIdle";
        private int score = 0;
        private bool isDead;

        //tipo HEAVY IDLE, NORMAL IDLE, BOSSIDLE

        public EnemyCharacter(GameObject _gameObject, int score,string textureName, int attackSpeed, int health, float speed, string texturePath) : base(_gameObject, textureName)
        {
            this.score = score;
            _gameObject.AddComponent(rb);
            shootCD = attackSpeed;
            this.Health = health;
            this.speed = speed;
            _gameObject.AddComponent(animator);

            animator.CreateAnimation(NORMAL_ENEMY_IDLE, texturePath, 1, 0.1f,true);
            animator.SetAnimation(NORMAL_ENEMY_IDLE);

            //creas una animacion de muerte y la guardas
            deathAnimation = animator.CreateAnimation(EXPLOSIONANIMATION, "Textures/Animations/Explosion/", 6, 0.1f,false);
            //a la animacion de muerte, le agregas como evento al terminar: Destroy
            deathAnimation.onAnimationFinish += Destroy;
        }

        public void Awake(GameObject gameObject)
        {
            metronome = GameManager.Instance.CurrentScene.FindObjectOfType<Metronome>();

            metronome.onBPMTick += Shoot;
            gameObject.transform.rotation = 180;
        }

        public void Update(float deltaTime)
        {
            Movement();
            if (gameObject.transform.position.y>1000)
            {
                Destroy();
            }
        }

        private void Shoot()
        {
            if (metronome.Ticks % shootCD == 0 && !isDead)
            {
                var bulletGameObject = GameManager.Instance.GetBullet();
                bulletGameObject.BulletReset(transform.position, 90, false);
            }
        }

        /// <summary>
        /// Recibe daño, no chequea inmunidad
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            if (!isDead)
            {
                health -= amount;
                if (health <= 0)
                {
                    Death();
                }
            }
        }

        private void Movement()
        {
            if (!isDead)
            {
                rb.Velocity = Vector2.Down * speed;
            }
        }

        public void Death()
        {
            isDead = true;
            rb.Velocity = Vector2.Zero;
            gameObject.transform.scale = new Vector2(0.75f, 0.75f);
            animator.SetAnimation(EXPLOSIONANIMATION);
            GameManager.Instance.Score = GameManager.Instance.Score+score;
        }

        private void Destroy()
        {
            deathAnimation.onAnimationFinish -= Destroy;
            metronome.onBPMTick -= Shoot;
            gameObject.Destroy();
        }
    }
}
