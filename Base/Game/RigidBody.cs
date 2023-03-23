using System;
using System.Collections.Generic;

namespace TestEngine
{
    public class RigidBody 
    {

        ///// <summary>
        ///// Le establece al jugador cual es su velocidad en X, mientras que mantiene la velocidad en Y para seguir siendo afectado por la aceleracion de la gravedad o el impulso de un salto
        ///// </summary>
        ///// <param name="p">Jugador a mover</param>
        ///// <param name="x">Float que debe depender del Axis de movimiento horizontal</param>
        //public static void Move(Player p, float x,float movementVelocity)
        //{
        //    if (p.isGrounded)
        //    {
        //        p.velocity = new Vector2(x * movementVelocity, p.velocity.y);
        //    }

        //    // p.velocity *= movementVelocity;
          
        //}


        ///// <summary>
        ///// Convierte la aceleración en velocidad y la velocidad en la nueva posicion del jugador. Aplica fuerza de gravedad
        ///// </summary>
        ///// <param name="b"></param>
        //public static void UpdateRigidBody(Player b, float gravity, float deltaTime)
        //{
        //    AddForce(b, new Vector2(0, gravity * b.mass));


        //    b.velocity.x += b.acceleration.x * deltaTime;
        //    b.velocity.y += b.acceleration.y * deltaTime;

        //    b.position.x += b.velocity.x * deltaTime;
        //    b.position.y += b.velocity.y * deltaTime;

        //    b.acceleration.x = 0;
        //    b.acceleration.y = 0;

        //    if (b.position.y > 200)
        //    {
        //        b.position.y = 200;
        //        b.isGrounded = true;
        //        b.velocity.y = 0;
        //    }
        //}

        ///// <summary>
        ///// Se suma una fuerza al Vector de aceleración del jugador. Esta fuerza depende de la masa del objeto
        ///// </summary>
        ///// <param name="b">Cuerpo rigido al que se le aplica la fuerza</param>
        ///// <param name="direction">Direccion de la fuerza</param>
        //public static void AddForce(Player b, Vector2 direction)
        //{
        //    b.acceleration.x += direction.x / b.mass;
        //    b.acceleration.y += direction.y / b.mass;

        //}
        ///// <summary>
        ///// Se suma una fuerza al Vector de aceleración del jugador. Esta fuerza depende de la masa del objeto
        ///// </summary>
        ///// <param name="b">Cuerpo rigido al que se le aplica la fuerza</param>
        ///// <param name="direction">Direccion de la fuerza</param>
        ///// <param name="forceMult">Multiplicador de la fuerza</param>
        //public static void AddForce(Player b, Vector2 direction, float forceMult)
        //{
        //    b.acceleration.x += direction.x * forceMult / b.mass;
        //    b.acceleration.y += direction.y * forceMult / b.mass;

        //}



    }
}