using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    //ABSTRACTA PARA QUE SE LE PUEDAN PONER METODOS QUE SOBREESCRIBAN LOS QUE HEREDEN LA CLASE, TODAVIA NO IMPLEMENTADO
    abstract class BaseCharacter 
    {
        protected GameObject m_GameObject;
        protected Transform m_Transform;
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

        public BaseCharacter(GameObject _gameObject)
        {
            
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


