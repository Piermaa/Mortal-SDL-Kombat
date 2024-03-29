﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class RigidBody : IMonoBehaviour
    {
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }

            set
            {
                velocity = value;
            }
        }

        private GameObject gameObject;
        private Vector2 velocity = Vector2.Zero;
        private Vector2 acceleration = Vector2.Zero;
        private float mass = 10;

        public void Awake(GameObject _gameObject)
        {
            this.gameObject = _gameObject;
        }

        public void Update(float deltaTime)
        {
            velocity.x += acceleration.x * deltaTime;
            velocity.y += acceleration.y * deltaTime;

            gameObject.transform.position.x += velocity.x * deltaTime;
            gameObject.transform.position.y += velocity.y * deltaTime;

            acceleration.x = 0;
            acceleration.y = 0;
        }

        #region NO USADO
        /// <summary>
        /// Se suma una fuerza al Vector de aceleración del jugador. Esta fuerza depende de la masa del objeto
        /// </summary>
        /// <param name="b">Cuerpo rigido al que se le aplica la fuerza</param>
        /// <param name="direction">Direccion de la fuerza</param>



        //    public void AddForce(Vector2 direction)
        //    {
        //        acceleration.x += direction.x / mass;
        //        acceleration.y += direction.y / mass;
        //    }

        //    /// <summary>
        //    /// Se suma una fuerza al Vector de aceleración del jugador. Esta fuerza depende de la masa del objeto
        //    /// </summary>
        //    /// <param name="b">Cuerpo rigido al que se le aplica la fuerza</param>
        //    /// <param name="direction">Direccion de la fuerza</param>
        //    public void AddForce(Vector2 direction, ForceMode forceMode)
        //    {
        //        switch (forceMode)
        //        {
        //            case ForceMode.Impulse:
        //                velocity.x += direction.x / mass;
        //                velocity.y += direction.y / mass;
        //                break;

        //            case ForceMode.Force:
        //                acceleration.x += direction.x / mass;
        //                acceleration.y += direction.y / mass;
        //                break;
        //        }
        //    }
        //}
        //public enum ForceMode
        //{
        //    Force,Impulse
        //}
        #endregion
    }
}