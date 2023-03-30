using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace TestEngine
{
    public class GameObject
    {
        string name;
        string tag;

        List<IMonoBehaviour> Components = new List<IMonoBehaviour>();

        public void AddComponent(IMonoBehaviour component)
        {
            component.Start(this);
            Components.Add(component);
        }

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
            Console.WriteLine($"Tried getting component of type {nameof(T)} on object {name}, but there is no such component attached");
            return default(T);
        }

        public Transform transform = new Transform();


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
        public Vector2 scale = Vector2.Zero;

        public void Translate(Vector2 dir)
        {
            position.x += dir.x;
            position.y += dir.y;
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Start(GameObject gameObject)
        {
            
        }
        public void Update(float deltaTime)
        {

        }
    }

    public struct Vector2
    {
        public float x, y;

        public Vector2(float xPos, float yPos)
        {
            x = xPos;
            y = yPos;
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

    public interface IMonoBehaviour
    {
        void Start(GameObject gameObject);
        void Update(float deltaTime);
    }
}


