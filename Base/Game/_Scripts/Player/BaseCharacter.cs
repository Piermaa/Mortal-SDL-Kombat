using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    //otra interfas
    public interface IRendereable
    {
        //requiere tranform y el 
        void Render(Texture p_texture, Vector2 p_position, Vector2 p_scale,float p_rotation,Vector2 p_offset);
    }


    //m_ para variables locales
    //parametros p_
    //le pone On porque sabe que van a ser eventos
    public delegate void OnLifeChanged(int p_actualLife);
    public delegate void OnDestroyed(IDamageable p_IDamageable);
    public interface IDamageable
    {
        int HitPoints { get; set; }
        bool IsDestroyed { get; set; }

        event OnLifeChanged OnLifeChanged;
        event OnDestroyed OnDestroyed;

        void TakeDamage(int amount);
        void Death();
    }
    class Box : IDamageable
    {
        int m_hitPoints = 10;
        bool m_isDestroyed = false;
        public int HitPoints 
        {
            get => m_hitPoints;
            set => m_hitPoints=value;
        }
        public bool IsDestroyed
        {
            get => m_isDestroyed;
            set => m_isDestroyed=value;
        }

        public event OnLifeChanged OnLifeChanged;
        public event OnDestroyed OnDestroyed;

        public void Death()
        {
            OnDestroyed?.Invoke(this);
        }

        public void TakeDamage(int amount)
        {
   
        }
    }
    class BaseCharacter // : IDamageable
    {
        //Protected es privada pero todas las clases que hereden de BaseCharacter pueden acceder a esas propiedades

        protected GameObject gameObject;
        protected Transform transform;

        private string textureName="none";

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