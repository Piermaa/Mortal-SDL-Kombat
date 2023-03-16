using System;
using System.Collections.Generic;

namespace TestEngine
{
    public class Player
    {
        string textureName;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 acceleration;

        public float mass=1;
        float movementSpeed=1;

        Vector2 scale;
    }

    public class Program
    {
        static Player player1;
        static Player player2;
        static Vector2 position = new Vector2(0, 0);

        public static float deltaTime;
        public static DateTime startTime = DateTime.Now;
        public static float endTime;
        static float movementVelocity = 5f;


        //If main is static all functions must be static
        static void Main(string[] args)
        {
            Game.Initialize();
            InitializePlayers();
            while (true)
            {
                Render();
            }
        }
        private static void InitializePlayers()
        {
           player1 = new Player();
           player2 = new Player();
        }
        private static void Render()
        {
            //First, it clears
            Game.Clear();

            //Then we draw what we want to show
            Game.Draw("bg.png", 0, 0, 1, 1, 0, 550, 0);
            Game.Draw("otacon.png", player1.position.x, player1.position.y, 0.2f, 0.2f, 0, 0);

            GetTime();
            InputMovement();


            //Finally, we show it
            Game.Show();
        }

        private static void InputMovement()
        {
            if (Game.GetKey(Keys.D) || Game.GetKey(Keys.RIGHT))
            {
                //ProcessMovement(movementVelocity, 0);
            }

            if (Game.GetKey(Keys.A) || Game.GetKey(Keys.LEFT))
            {
                //ProcessMovement(-movementVelocity, 0);
            }

            if (Game.GetKey(Keys.W) || Game.GetKey(Keys.UP))
            {
                //ProcessMovement(0, -movementVelocity);
            }

            if (Game.GetKey(Keys.S) || Game.GetKey(Keys.DOWN))
            {
                AddForce(player1, new Vector2(0, movementVelocity));
              //player1.velocity = new Vector2(0, movementVelocity);
                //ProcessMovement(0, movementVelocity);
            }

            RigidBody( player1);
            RigidBody( player2);
            //player1.velocity = Vector2.Zero;
        }

        static void ProcessMovement(float xMovement, float yMovement)
        {
            position.x += xMovement;
            position.y += yMovement;
        }

        static void ProcessMovementWithVector(Vector2 positionAddition)
        {
            position.x += positionAddition.x;
            position.y += positionAddition.y;
        }

        static void GetTime()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - endTime;
            endTime = currentTime;
        }


        static void RigidBody(Player b)
        {
            b.velocity.x += b.acceleration.x * deltaTime;
            b.velocity.y += b.acceleration.y * deltaTime;

            b.position.x += b.velocity.x * deltaTime;
            b.position.y += b.velocity.y * deltaTime;

            b.acceleration.x = 0;
            b.acceleration.y = 0;
        }

        //---------------------------------------agregar fuerza------------------------------------------
        static void AddForce(Player b, Vector2 direction)
        {
            b.acceleration.x += direction.x / b.mass;
            b.acceleration.y += direction.y / b.mass;

        }
    }
}