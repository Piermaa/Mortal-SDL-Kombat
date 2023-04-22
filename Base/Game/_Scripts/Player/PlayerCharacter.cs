using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PlayerCharacter :BaseCharacter, IMonoBehaviour
    {
        public Transform Transform
        { 
            get 
            { 
                return base.transform; 
            } 

            set 
            { 
                base.transform = value; 
            } 
        }

        GameObject engineGameObject;
        RigidBody rb;
        float speed = 300;

        float shootCD=1;
        float shootTimer;

        // Al crear el script se agregan todos los componentes
        public PlayerCharacter(GameObject _gameObject, string textureName,GameObject p_engineGameObject) : base(_gameObject)
        {
            engineGameObject= p_engineGameObject;
            engineGameObject.transform.scale = new Vector2(2.5f, 2.5f);

            SpriteRenderer engineSpriteRenderer = new SpriteRenderer();
            Animator engineAnimator = new Animator();

            engineGameObject.AddComponent(engineSpriteRenderer);
            engineGameObject.AddComponent(engineAnimator);

            AddSprite(textureName);
        }

        public void Awake(GameObject _gameObject)
        {
            rb = _gameObject.GetComponent<RigidBody>();
            Transform.SetPosition(new Vector2(720/2,600));
            Transform.scale = new Vector2(3, 3);
        }

        public void Update(float deltaTime)
        {
            engineGameObject.transform.SetPosition(new Vector2(Transform.position.x, Transform.position.y + 30));
            Movement();
            Shoot(deltaTime);
        }

        private void Movement()
        {
            float x = Program.GetAxisRaw("Horizontal");
            float y = Program.GetAxisRaw("Vertical");

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
                b.transform.position = Transform.position + Vector2.Up * 10;
            }
        }

        // Se overridea la virtual void para que cumpla otra función
        public override void Death()
        {
            GameManager.Instance.GameOver();
        }
    }
}
