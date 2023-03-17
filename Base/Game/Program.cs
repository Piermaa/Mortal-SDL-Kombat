using System;
using System.Collections.Generic;

namespace TestEngine
{
    public class Player
    {
        // current texture 
        public string textureName;
        public  Vector2 position=new Vector2(0,0);
        public  Vector2 velocity=Vector2.Zero;
        public Vector2 acceleration= Vector2.Zero;
        public bool isGrounded=false;
        public float mass=65;
       // float movementSpeed=1;

       // Vector2 scale;

        public Player(Vector2 startPos, string textureNameString)
        {
            position = new Vector2(startPos.x,startPos.y);
            textureName = textureNameString;
        }
    }

    public class Program
    {
        const int WIDTH = 1280;
        const int HEIGHT = 720;
        const float GRAVITY = 980f;
        static Player player1;
        static Player player2;
        static Vector2 position = new Vector2(0, 0);

        public static float deltaTime;
        public static DateTime startTime = DateTime.Now;
        public static float endTime;
        static float movementVelocity = 250f;

        static float jumpForce=700;
        static float xOffset = 0;

        //If main is static all functions must be static
        static void Main(string[] args)
        {
            Game.Initialize("Mortal Kombat XXX",WIDTH,HEIGHT,false);
            InitializePlayers();
            while (true)
            {
                Render();
            }
        }
        private static void InitializePlayers()
        {
            player1 = new Player(new Vector2(0, 200),"subzero.png");
            player2 = new Player(new Vector2(1000, 200),"skorpion.png");


        }
        private static void Render()
        {
            //First, it clears
            Game.Clear();

            //Then we draw what we want to show
            GetTime();
            InputMovement();

            Game.Draw("bg.png", 0, 0, 1, 1, 0, 550+xOffset, 0);
         
            Game.Draw(player1.textureName, player1.position.x, player1.position.y, 0.5f, 0.5f, 0,0, 0);
            Game.Draw(player2.textureName, player2.position.x, player2.position.y, 0.5f, 0.5f, 0,0, 0);

      

            //Finally, we show it
            Game.Show();
        }
        /// <summary>
        /// Se calcula el movimiento de los jugadores
        /// </summary>
        private static void InputMovement()
        {
            float x1 = GetAxisRaw("Horizontal");
            float y1 = GetAxisRaw("Vertical");

            float x2 = GetAxisRaw("Horizontal2");
            float y2 = GetAxisRaw("Vertical2");

            if (y1<0 && player1.isGrounded)
            {
                player1.velocity += Vector2.Up *jumpForce;
                player1.isGrounded=false;
            }
            if (y2<0 && player2.isGrounded)
            {
          
                player2.velocity += Vector2.Up* jumpForce;
                player2.isGrounded = false;
            }

            RigidBody.Move(player1, x1,movementVelocity);
            RigidBody.Move(player2, x2, movementVelocity);

            RigidBody.UpdateRigidBody(player1,GRAVITY,deltaTime);
            RigidBody.UpdateRigidBody(player2,GRAVITY,deltaTime);
        }

        /// <summary>
        /// Se obtiene el valor bruto de un eje de movimiento dependiendo de la Input actual 
        /// </summary>
        /// <param name="axis">Nombre del eje, pej: Horizontal. Horizontal2 es para las ArrowKeys, input del player 2</param>
        /// <returns>Un valor que puede ser -1, 0 o 1 dependiendo del Input del jugador</returns>
        static int GetAxisRaw(string axis)
        {

            
            switch (axis)
            {
                case "Horizontal":
                    if (Game.GetKey(Keys.A))
                    {
                        return -1;
                    }
                    if (Game.GetKey(Keys.D))
                    {
                        return 1;
                    }
                    break;

                case "Vertical":
                    if (Game.GetKey(Keys.W))
                    {
                        return -1;
                    }
                    if (Game.GetKey(Keys.S))
                    {
                        return 1; // para abajo positivo
                    }
                    break;



                case "Horizontal2":
                    if (Game.GetKey(Keys.LEFT))
                    {
                        return -1;
                    }
                    if (Game.GetKey(Keys.RIGHT))
                    {
                        return 1;
                    }
                    break;

                case "Vertical2":
                    if (Game.GetKey(Keys.UP))
                    {
                        return -1;
                    }
                    if (Game.GetKey(Keys.DOWN))
                    {
                        return 1; // para abajo positivo
                    }
                    break;
            }
            return 0;
        }

        

        /// <summary>
        /// Se obtiene el valor de deltaTime
        /// </summary>
        static void GetTime()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - endTime;
            endTime = currentTime;
        }

       
    }
}