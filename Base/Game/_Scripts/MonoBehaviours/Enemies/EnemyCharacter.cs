using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyCharacter: BaseCharacter, IMonoBehaviour, IDamagable
    {
        private float shootCD=2;
        private float shootTimer;
        private Animator animator = new Animator();
        private Animation deathAnimation;
        private const string EXPLOSIONANIMATION = "Explosion";
        private const string NORMAL_ENEMY_IDLE = "NormalEnemyIdle";

        //tipo HEAVY IDLE, NORMAL IDLE, BOSSIDLE

        public EnemyCharacter(GameObject _gameObject, string textureName, float attackSpeed, string texturePath) : base(_gameObject, textureName)
        {
            shootCD = attackSpeed;
            _gameObject.AddComponent(animator);
            //RESPECTO AL FACTORY: ACA SE SETEAN LOS SPRITES POR CULPA DEL ANIMATOR ENTONCES ACA TENES QUE HACER QUE EL 
            //PARAMETRO SEA EL STRING QUE VA EN SETANIMATION
            //LAS ANIMACIONES HACELAS ANTES DE INSTANCIAR EL ENEMIGO!!
            animator.CreateAnimation(NORMAL_ENEMY_IDLE, texturePath, 1, 0.1f,true);
            animator.SetAnimation(NORMAL_ENEMY_IDLE);

            //creas una animacion de muerte y la guardas
            deathAnimation = animator.CreateAnimation(EXPLOSIONANIMATION, "Textures/Animations/Engine/", 3, 0.1f,false);
            //a la animacion de muerte, le agregas como evento al terminar: Destroy
            deathAnimation.onAnimationFinish += Destroy;
        }

        public void Awake(GameObject gameObject)
        {
            gameObject.transform.rotation = 180;
        }

        public void Update(float deltaTime)
        {
            shootTimer = shootTimer > 0 ? shootTimer - deltaTime : 0;
            if (shootTimer == 0)
            {
                shootTimer = shootCD;
                Engine.Debug("Enemy shot");
                var bulletGameObject = GameManager.Instance.bullets.GetObjectFromPool();
                bulletGameObject.BulletReset(transform.position, 90, false);
            }
        }

        /// <summary>
        /// Recibe daño, no chequea inmunidad
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Death();
            }
        }

        public void Death()
        {
            animator.SetAnimation(EXPLOSIONANIMATION);
        }

        private void Destroy()
        {
            deathAnimation.onAnimationFinish -= Destroy;
            gameObject.Destroy();
        }
    }
}
