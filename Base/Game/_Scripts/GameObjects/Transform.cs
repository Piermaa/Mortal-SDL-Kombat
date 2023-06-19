using System;


namespace Game
{
    public class Transform
    {
        // Private Variables
        public GameObject gameObject;

        public Vector2 position = Vector2.Zero;
        public float rotation;
        public Vector2 scale = new Vector2(1, 1);

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
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
                return Zero;
            }
            return new Vector2((float)(x / h), (float)(y / h));
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            t = Mathf.Clamp01(t); // Clamping t between 0 and 1

            float x = Mathf.Lerp(a.x, b.x, t);
            float y = Mathf.Lerp(a.y, b.y, t);

            return new Vector2(x, y);
        }

        public override string ToString()
        {
            return $"X: {x} / Y: {y}";
        }
    }

    public static class Mathf
    {
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        public static float Clamp01(float value)
        {
            return (value < 0f) ? 0f : (value > 1f) ? 1f : value;
        }
    }
}
