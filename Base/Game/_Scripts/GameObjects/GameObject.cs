using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    //para descartar errores de tipeo
    public static class TagManager
    {
        public const string PLAYER_TAG = "Player";
        public const string ENEMY_TAG = "Enemy";
        public const string BULLET_TAG = "Bullet";
    }

    public interface IMonoBehaviour
    {
        void Awake(GameObject gameObject);

        void Update(float deltaTime);
    }

    public class GameObject
    {
        public Transform transform;
        public event Action OnDestroy;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set {isEnabled=value; }
        }
        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        private List<IMonoBehaviour> Components = new List<IMonoBehaviour>();

        private string tag = "default";
        private bool isEnabled = true;
        private float radius = 25;
    
        public GameObject()
        {
            // Se le asigna el transform
            transform = new Transform();

            // Se agrega a la jerarquía asi ya tiene la funcionalidad de Awake y Update
#if TEST
            Engine.Debug("Test");
#else
            GameManager.Instance.AddGameObject(this);
#endif
        }

        // Lo mismo que el otro constructor pero para identificar las colisiones
        public GameObject(string tag)
        {
            transform = new Transform();
            this.tag = tag;
#if TEST
            Engine.Debug("Test");
#else
              GameManager.Instance.AddGameObject(this);
#endif

            switch (tag)
            {
                case (TagManager.PLAYER_TAG):
                    ColliderManager.Instance.PlayerCollider = this;
                    break;

                case (TagManager.ENEMY_TAG):
                    ColliderManager.Instance.AddEnemyCollider(this);
                    break;
            }
        }

        public void Destroy()
        {
            // Se le sacan los componentes

            OnDestroy?.Invoke();
            Components.Clear();

            // Se sacan los objetos de la jerarquía
            GameManager.Instance.RemoveGameObject(this);

            // Se remueven de la lista de colliders (GameObjects)

            //TODO: PREFABS DE ENEMIGOS
            if(tag == TagManager.ENEMY_TAG)
            {
                ColliderManager.Instance.RemoveEnemyCollider(this);
            }
        }

        public void AddComponent(IMonoBehaviour component)
        {
            component.Awake(this);

            // Se agrega a la lista de componentes del GameObject
            Components.Add(component);
        }

        /* T es cualquiera tipo de dato pero tiene que heredar si o si de la interfaz IMonoBehaviour
           Para cada elemento en la lista de componentes va a intentar convertirlo al tipo de objeto que se pide

           Te pide GetComponent Rigidbody, va a chequear si T es un Rigidbody (Downcasting)
           Si el downcasting se puede realizar, se devuelve el Rigidbody, sino se devuelve null

           Si falla el downcasting tira una excepción y se interrumpe el programa
           Try intentará ejecutar las instrucciones entre llaves sin que el programa se interrumpa
           Catch hará que si hay una excepción, que pase algo si es que la haya
         */ 

        public T GetComponent<T>() where T : IMonoBehaviour
        {
            foreach (var item in Components)
            {
                try
                {
                    var result = (T)item;
                    return result;
                }

                catch (Exception e)
                {
                   //Engine.Debug($"{e} Tried to convert ");
                }
            }
            return default(T);
        }

        public void Awake(GameObject go)
        {
            foreach (var component in Components)
            {
                component.Awake(go);
            }
        }

        public void Update(float deltaTime)
        {
            if (isEnabled)
            {
                for (int i = 0; i < Components.Count; i++)
                {
                    Components[i].Update(deltaTime);
                }
            }
        }
    }
}