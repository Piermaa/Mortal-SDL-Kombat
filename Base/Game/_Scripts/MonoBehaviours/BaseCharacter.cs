using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    #region Apuntes de la clase 
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
    }


    class Box : IDamageable
    {
        int m_hitPoints = 10;
        bool m_isDestroyed = false;
        public int HitPoints
        {
            get => m_hitPoints;
            set => m_hitPoints = value;
        }
        public bool IsDestroyed
        {
            get => m_isDestroyed;
            set => m_isDestroyed = value;
        }

        public event OnLifeChanged OnLifeChanged;
        public event OnDestroyed OnDestroyed;

        public void Death()
        {
            OnDestroyed?.Invoke(this);
        }

        public void TakeDamage(int amount)
        {
            OnLifeChanged?.Invoke(amount);
        }
    }
    #endregion
    /// <summary>
    /// PlayerCharacter y EnemyCharacter van a tener esta funcion, pero cada uno la implementa distinto, entonces usamos una interfaz
    /// </summary>
    public interface IDamagable
    {
        void TakeDamage(int amount);
        void Death();
    }


    class BaseCharacter
    {
        //Protected es privada pero todas las clases que hereden de BaseCharacter pueden acceder a esas propiedades
        protected GameObject gameObject;
        protected Transform transform;
        protected SpriteRenderer spriteRenderer;

        protected int health = 3;
        protected int damage = 1;
        protected float moveSpeed = 1;
        protected float immunityTime = 0f;

        // Constructor de la clase BaseCharacter
        public BaseCharacter(GameObject _gameObject, string textureName)
        {
            gameObject = _gameObject;
            transform = _gameObject.transform;

            RigidBody rb = new RigidBody();
            gameObject.AddComponent(rb);
            AddSprite(textureName);
        }

        /// <summary>
        /// Agrega el componente SpriteRenderer, y le establece la textura
        /// </summary>
        /// <param name="p_textureName">Nombre de la textura que se le establecera al SpriteRenderer</param>
        protected void AddSprite(string p_textureName)
        {
            spriteRenderer = new SpriteRenderer();
            spriteRenderer.SetTexture(Engine.GetTexture(p_textureName));
            gameObject.AddComponent(spriteRenderer);
        }
    }
}