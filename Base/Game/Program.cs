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


        //If main is static all functions must be static
        static void Main(string[] args)
        {
            Game.Initialize("Moirtal Kombat XXX",WIDTH,HEIGHT,false);
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

            Game.Draw("bg.png", 0, 0, 1, 1, 0, 550, 0);
            Game.Draw(player1.textureName, player1.position.x, player1.position.y, 0.5f, 0.5f, 0, 0);
            Game.Draw(player2.textureName, player2.position.x, player2.position.y, 0.5f, 0.5f, 0, 0);



            //Finally, we show it
            Game.Show();
        }

        private static void InputMovement()
        {
            float x = GetAxisRaw("Horizontal");
            float y = GetAxisRaw("Vertical");

            if (y<0)
            {
                player1.velocity.y = -500;
            }

            player1.velocity = new Vector2(x*movementVelocity,player1.velocity.y);
            
       

            RigidBody(player1);
            RigidBody(player2);
  
        }

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
            }
            return 0;
        }

    

        static void GetTime()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - endTime;
            endTime = currentTime;
        }


        static void RigidBody(Player b)
        {
            AddForce(b, new Vector2(0, GRAVITY*b.mass));


            b.velocity.x += b.acceleration.x * deltaTime;
            b.velocity.y += b.acceleration.y * deltaTime;

            b.position.x += b.velocity.x * deltaTime;
            b.position.y += b.velocity.y * deltaTime;

            b.acceleration.x = 0;
            b.acceleration.y = 0;

            if (b.position.y>200)
            {
                b.position.y = 200;
            }
        }

        //---------------------------------------agregar fuerza------------------------------------------
        static void AddForce(Player b, Vector2 direction)
        {
            b.acceleration.x += direction.x / b.mass;
            b.acceleration.y += direction.y / b.mass;

        }
    }
}