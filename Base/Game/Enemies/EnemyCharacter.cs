using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyCharacter: BaseCharacter, IMonoBehaviour
    {
        private float shootCD=2;
        private float shootTimer;
        private Animator explosionAnimator = new Animator();

        private const string EXPLOSIONANIMATION = "Explosion";
        private const string NORMAL_ENEMY_IDLE = "NormalEnemyIdle";
        //tipo HEAVY IDLE, NORMAL IDLE, BOSSIDLE

        public EnemyCharacter(GameObject _gameObject, string textureName, float attackSpeed) : base(_gameObject)
        {
            AddSprite(textureName);
            shootCD = attackSpeed;

            _gameObject.AddComponent(explosionAnimator);
            //RESPECTO AL FACTORY: ACA SE SETEAN LOS SPRITES POR CULPA DEL ANIMATOR ENTONCES ACA TENES QUE HACER QUE EL 
            //PARAMETRO SEA EL STRING QUE VA EN SETANIMATION
            //LAS ANIMACIONES HACELAS ANTES DE INSTANCIAR EL ENEMIGO!!
            explosionAnimator.CreateAnimation(EXPLOSIONANIMATION, "Textures/Animations/Engine/", 3, 0.1f);
            explosionAnimator.CreateAnimation(NORMAL_ENEMY_IDLE, "Animations/Enemy/", 1, 0.1f);
            explosionAnimator.SetAnimation(NORMAL_ENEMY_IDLE);
        }

        public void Awake(GameObject gameObject)
        {
            gameObject.transform.scale = new Vector2(3, 3);
            gameObject.transform.rotation = 180;
        }

        public void Update(float deltaTime)
        {
            shootTimer = shootTimer > 0 ? shootTimer - deltaTime : 0;
            if (shootTimer == 0)
            {
                shootTimer = shootCD;
                var bulletGameObject = Program.bullets.GetObjectFromPool();
                bulletGameObject.BulletReset(transform.position, 180, false);
            }
        }

        public override void Death()
        {
            explosionAnimator.SetAnimation(EXPLOSIONANIMATION);
        }
    }
}
