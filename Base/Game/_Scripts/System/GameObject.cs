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

        List<IMonoBehaviour> Components = new List<IMonoBehaviour>();

        public GameObject()
        {
            transform = new Transform();
        }
      
        public void AddComponent(IMonoBehaviour component)
        {
            component.Awake(this);
            Components.Add(component);
        }

        public T GetComponent<T>() where T : IMonoBehaviour
        {
            foreach (var item in Components)
            {
                var result = (T)item;
                return result;
                
            }
            
            //Console.WriteLine($"Tried getting component of type {nameof(T)} on object {name}, but there is no such component attached");
            return default(T);
        }
        public void Awake(GameObject go)
        {
            foreach (var component in Components)
            {
                component.Awake(go);
            }
        }
        public void Start()
        {

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
        public void Start()
        {

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
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        //Esto es para q se puedan sumar los vectores

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        public static Vector2 operator *(Vector2 a, float f)
        {
            return new Vector2(a.x * f, a.y * f);
        }

        public static Vector2 operator /(Vector2 a, float f)
        {
            return new Vector2(a.x / f, a.y / f);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }
        public Vector2 Normalize()
        {
            double dX = x;
            double dY = y;
            double h = Math.Sqrt((dX * dX + dY * dY));

            return new Vector2((float)(x / h), (float)(y / h));
        }
    }

    //Estos son metodos que deben ser implementados obligatoriamente para que todos puedan ser llamados desde program compartiendo el nombre
    //Facilmente con un foreach/for se puede recorrer una lista de IMonobehaviours y llamar su update a cada frame
    public interface IMonoBehaviour
    {
        //EN EL AWAKE PONER LOS ADDCOMPONENT
        void Awake(GameObject gameObject);
        //ENTONCES EN START  PODEMOS USAR LOS GETCOMPONENT
        void Start();
        void Update(float deltaTime);
    }


    //TODO: Cambiar esta interfaz por un componente, SpriteRenderer tal vez, cuyo update sea renderear la textura

}


