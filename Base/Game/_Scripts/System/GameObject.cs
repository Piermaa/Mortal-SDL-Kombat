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

    public class Transform : IMonoBehaviour
    {
        // Private Variables
        public GameObject gameObject;

        public Vector2 position = Vector2.Zero;
        public float rotation;
        public Vector2 scale = new Vector2(1,1);

        public void Translate(Vector2 dir)
        {
            position.x += dir.x;
            position.y += dir.y;
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Awake(GameObject _gameObject)
        {
            gameObject = _gameObject;
        }
        public void Update(float deltaTime)
        {

        }
    }

    public struct Vector2
    {
        public float x, y;

        public Vector2(float p_x, float p_y)
        {
            x = p_x;
            y = p_y;
        }

        public static Vector2 Zero = new Vector2(0, 0);
        public static Vector2 Up = new Vector2(0, -1);
        public static Vector2 Down = new Vector2(0, 1);
        public static Vector2 Left = new Vector2(-1, 0);
        public static Vector2 Right = new Vector2(1, 0);

        //Suma de vectores
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        // Multiplicación de vectores
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        
        // Multiplicación de vector con float
        public static Vector2 operator *(Vector2 a, float f)
        {
            return new Vector2(a.x * f, a.y * f);
        }
        
        // División de vectores
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        // División de vector con float
        public static Vector2 operator /(Vector2 a, float f)
        {
            return new Vector2(a.x / f, a.y / f);
        }

        public float Distance()
        {
            double dX = x;
            double dY = y;
            double h = Math.Sqrt((dX * dX + dY * dY));

            return (float)h;
        }

        public Vector2 Normalize()
        {
            double dX = x;
            double dY = y;
            double h = Math.Sqrt((dX * dX + dY * dY));

            if (x==0 && y==0)
            {
                return Vector2.Zero;
            }
            return new Vector2((float)(x / h), (float)(y / h));
        }
    }

    //Estos son metodos que deben ser implementados obligatoriamente para que todos puedan ser llamados desde program compartiendo el nombre
    //Facilmente con un foreach/for se puede recorrer una lista de IMonobehaviours y llamar su update a cada frame
    public interface IMonoBehaviour
    {
        void Awake(GameObject gameObject);

        void Update(float deltaTime);
    }
}