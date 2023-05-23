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
        //Animator explosionAnimator = new Animator();
        //SpriteRenderer explosionSpriteRenderer = new SpriteRenderer();

        private const string EXPLOSIONANIMATION = "Explosion";

        public EnemyCharacter(GameObject _gameObject, string textureName, float attackSpeed) : base(_gameObject)
        {
            // Usé las mismas que el de los engines porque me quedé sin internet y no pude buscar otras xd
            //explosionAnimator.CreateAnimation(EXPLOSIONANIMATION, "Textures/Animations/Engine/", 3, 0.1f);
            //_gameObject.AddComponent(explosionAnimator);
            //_gameObject.AddComponent(explosionSpriteRenderer);

            AddSprite(textureName);
            shootCD = attackSpeed;
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

        //public override void Death()
        //{
        //    explosionAnimator.SetAnimation(EXPLOSIONANIMATION);
        //    base.Death();
        //}
    }
}
