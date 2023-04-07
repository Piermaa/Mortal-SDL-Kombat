using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    class BaseCharacter : IMonoBehaviour, IRendereable
    {
        protected GameObject gameObject;
        protected Transform transform;
        // current texture 
        public string textureName="none";

        // variables 
        protected int health = 3;
        protected int damage = 1;
        protected float moveSpeed = 1;

        protected float immunityTime = 2f;

        public int Health
        {
            get { return health; }

            set { health = value; }
        }

        public int Damage
        {
            get { return damage; }

            set { damage = value; }
        }

        public float Speed
        {
            get { return moveSpeed; }

            set { moveSpeed = value; }
        }

        public void Start(GameObject _gameObject)
        {
            this.gameObject = _gameObject;
            transform = gameObject.transform;
        }

        public void Update(float deltaTime)
        {
            Death();

            if (immunityTime <= 0)
            {
                immunityTime = 0;
            }

            immunityTime -= deltaTime;

            //Debug keys

            if (Engine.GetKey(Keys.P))
            {
                TakeDamage(damage);
            }
        }

        public void Render()
        {
            Engine.Draw(textureName, 0, 0, 1, 1, 0, 0, 0);
        }

        public void TakeDamage(int amount)
        {
            if (immunityTime <= 0)
            {
                health -= amount;
                immunityTime = 2f;
                Engine.Debug("Took Damage, acual life is: " + health);
            }
        }

        public void Death()
        {
            if (health <= 0)
            {
                Engine.Debug("Has died");
            }
        }
    }
}


