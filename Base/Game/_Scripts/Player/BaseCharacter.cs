using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    //ABSTRACTA PARA QUE SE LE PUEDAN PONER METODOS QUE SOBREESCRIBAN LOS QUE HEREDEN LA CLASE, TODAVIA NO IMPLEMENTADO
    class BaseCharacter 
    {
        protected GameObject m_GameObject;
        protected Transform m_Transform;
        // current texture 
        public string textureName="none";

        // variables 
        protected int health = 3;
        protected int damage = 1;
        protected float moveSpeed = 1;

        protected float immunityTime = 0f;

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

        public BaseCharacter(GameObject _gameObject, string textureName)
        {
            m_GameObject = _gameObject;
            m_Transform = _gameObject.transform;
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            spriteRenderer.SetTexture(Engine.GetTexture(textureName));
            RigidBody rb = new RigidBody();
            Collider collider= new Collider(5, m_GameObject);
            
            m_GameObject.AddComponent(spriteRenderer);
            m_GameObject.AddComponent(rb);

            //TODO: SOLO PARA ENEMIGOS
            //TODO: QUE SE AÑADAN A LA JERARQUIA TODOS LOS GAMEOBJECTS

        }


        public void TakeDamage(int amount)
        {
            if (immunityTime <= 0)
            {
                health -= amount;
                if (health<=0)
                {
                    Death();
                }
                Engine.Debug("Took Damage, acual life is: " + health);
            }
        }

        public virtual void Death()
        {
            if (health <= 0)
            {
                m_GameObject.Destroy();
            }
        }
    }
}


