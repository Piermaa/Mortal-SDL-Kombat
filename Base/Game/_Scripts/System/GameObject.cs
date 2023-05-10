using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    public class GameObject : IMonoBehaviour
    {
        public event Action OnDestroy;

        public Transform transform;

        private string tag = "default";
        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        private float radius = 25;
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        List<IMonoBehaviour> Components = new List<IMonoBehaviour>();

        public GameObject()
        {
            // Se le asigna el transform
            transform = new Transform();

            // Se agrega a la jerarquía asi ya tiene la funcionalidad de Awake y Update
            GameManager.Instance.AddGameObject(this);
        }

        // Lo mismo que el otro constructor pero para identificar las colisiones
        public GameObject(string tag)
        {
            transform = new Transform();
            this.tag = tag;
            GameManager.Instance.AddGameObject(this);

            switch (tag)
            {
                case ("Player"):
                    ColliderManager.Instance.PlayerCollider = this;
                    break;

                case ("Enemy"):
                    ColliderManager.Instance.AddEnemyCollider(this);
                    break;

                case ("Bullet"):
                    ColliderManager.Instance.AddBulletCollider(this);
                    break;
            }
        }

        public void Destroy()
        {
            // Se le sacan los componentes
            Components = null;

            // Se sacan los objetos de la jerarquía
            GameManager.Instance.RemoveGameObject(this);
            

            // Se remueven de la lista de colliders (GameObjects)
            switch (tag)
            {
                case ("Enemy"):
                    ColliderManager.Instance.RemoveEnemyCollider(this);
                    break;

                case ("Bullet"):
                    ColliderManager.Instance.RemoveBulletCollider(this);
                    break;
            }
            OnDestroy?.Invoke();
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
            foreach (var component in Components)
            {
                component.Update(deltaTime);
            }
        }
    }


    //POSIBLEMENTE SEA MEJOR CAMBIAR POR UNA CLASE CON METODOS VIRTUAL, PORQUE HAY CLASES QUE NO NECESITAN USAR EL AWAKE Y/O RENDER
    //Estos son metodos que deben ser implementados obligatoriamente para que todos puedan ser llamados desde program compartiendo el nombre
    //Facilmente con un foreach/for se puede recorrer una lista de IMonobehaviours y llamar su update a cada frame
    public interface IMonoBehaviour
    {
        void Awake(GameObject gameObject);

        void Update(float deltaTime);

    }

    abstract class Monobehaviour
    {
        public virtual void Awake(GameObject gameObject)
        {
        }
        public virtual void Update(float deltaTime) 
        {

        }

        public virtual void Render()
        {

        }
    }
}