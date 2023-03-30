using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    class Transform: IUpdatable
    {
        // Private Variables
        private Vector2 position = Vector2.Zero;
        private float rotation;
        private Vector2 scale = Vector2.Zero;

        // Public Variables
        public Vector2 Position => position;
        public Vector2 Scale => scale;

        public void Translate(Vector2 dir)
        {
            position.x += dir.x;
            position.y += dir.y;
        }

        public void Start()
        {

        }

        public void Update()
        {

        }
    }

    public interface IUpdatable
    {
        void Start();
        void Update();
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
}
