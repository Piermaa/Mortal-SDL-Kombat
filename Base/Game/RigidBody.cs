using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestEngine
{
    class RigidBody : IMonoBehaviour
    {
        GameObject gameObject;
        Transform transform;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 acceleration = Vector2.Zero;

        float mass=10;

        public void Start(GameObject gameObject)
        {
            this.gameObject = gameObject;
            transform = gameObject.GetComponent<Transform>();
        }

        public void Update(float deltaTime)
        {

            velocity.x += acceleration.x * deltaTime;
            velocity.y += acceleration.y * deltaTime;

            transform.position.x += velocity.x * deltaTime+ 1/2 * acceleration.x * deltaTime * deltaTime;
            transform.position.y += velocity.y * deltaTime+ 1/2 * acceleration.y * deltaTime * deltaTime;

            acceleration.x = 0;
           
        }

        /// <summary>
        /// Se suma una fuerza al Vector de aceleración del jugador. Esta fuerza depende de la masa del objeto
        /// </summary>
        /// <param name="b">Cuerpo rigido al que se le aplica la fuerza</param>
        /// <param name="direction">Direccion de la fuerza</param>
        public void AddForce(Vector2 direction)
        {
            acceleration.x += direction.x / mass;
            acceleration.y += direction.y / mass;

        }

        /// <summary>
        /// Se suma una fuerza al Vector de aceleración del jugador. Esta fuerza depende de la masa del objeto
        /// </summary>
        /// <param name="b">Cuerpo rigido al que se le aplica la fuerza</param>
        /// <param name="direction">Direccion de la fuerza</param>
        public void AddForce(Vector2 direction, ForceMode forceMode)
        {
            switch (forceMode)
            {
                case ForceMode.Impulse:
                    velocity.x += direction.x / mass;
                    velocity.y += direction.y / mass;
                    break;

                case ForceMode.Force:
                    acceleration.x += direction.x / mass;
                    acceleration.y += direction.y / mass;
                    break;
            }
     

        }

    }
    public enum ForceMode
    {
        Force,Impulse
    }
}