using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Transform : IMonoBehaviour
    {
        // Private Variables
        public GameObject gameObject;

        public Vector2 position = Vector2.Zero;
        public float rotation;
        public Vector2 scale = new Vector2(1, 1);

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

            if (x == 0 && y == 0)
            {
                return Vector2.Zero;
            }
            return new Vector2((float)(x / h), (float)(y / h));
        }
    }


}
