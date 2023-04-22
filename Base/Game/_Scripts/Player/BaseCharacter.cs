using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    class BaseCharacter 
    {
        //Protected es privada pero todas las clases que hereden de BaseCharacter pueden acceder

        protected GameObject gameObject;
        protected Transform transform;

        public string textureName="none";

        protected int health = 3;
        protected int damage = 1;
        protected float moveSpeed = 1;

        protected float immunityTime = 0f;

        // Constructor de la clase BaseCharacter
        public BaseCharacter (GameObject _gameObject)
        {
            gameObject = _gameObject;
            transform = _gameObject.transform;
           
            RigidBody rb = new RigidBody();
            gameObject.AddComponent(rb);
        }

        protected void AddSprite(string p_textureName)
        {
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            spriteRenderer.SetTexture(Engine.GetTexture(p_textureName));
            gameObject.AddComponent(spriteRenderer);
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
                gameObject.Destroy();
            }
        }
    }
}