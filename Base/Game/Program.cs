using System;
using System.Collections.Generic;

namespace TestEngine
{
    public class Player
    {
        // current texture 
        private string textureName;

        private int health = 10;
        private int damage = 1;
        private float speed = 1;

        private Vector2 position = new Vector2(0, 0);
        private Vector2 velocity = Vector2.Zero;
        private Vector2 acceleration = Vector2.Zero;

        private bool isGrounded = false;
        public bool IsGrounded => isGrounded;

        private static float mass = 65;

        public int Health
        {
            get { return health; }

            set { health = value; }
        }
        public void SetPosition(Vector2 pos)
        {
            position = pos;
        }

        public Vector2 Position 
        {   
            get { return position; }

            set { position = value;}
        }
        public float PosX
        {
            get { return position.x; }

            set { position.x = value; }
            
        }
        public float PosY
        {
            get { return position.y; }

            set { position.y = value; }

        }

       
       // float movementSpeed=1;

       // Vector2 scale;

        public Player(string textureNameString, Vector2 startPos)
        {
            position = startPos;
            textureName = textureNameString;
        }

        public void UpdatePosition()
        {
            AddForce(new Vector2(0, Program.gravity * mass));


            velocity.x += acceleration.x * Program.deltaTime;
            velocity.y += acceleration.y * Program.deltaTime;

            position.x += velocity.x * Program.deltaTime;
            position.y += velocity.y * Program.deltaTime;

            acceleration.x = 0;
            acceleration.y = 0;

            if (position.y > 200)
            {
                position.y = 200;
                isGrounded = true;
                velocity.y = 0;
            }
        }
        public void AddForce(Vector2 direction)
        {
            acceleration = direction / mass;
        }

        public void Render()
        {
            Game.Draw(textureName, position.x, position.y, 0.5f, 0.5f, 0, 0, 0);
        }

        public void Move(float x, float movementVelocity)
        {
            if (IsGrounded)
            {
                velocity = new Vector2(x * movementVelocity, velocity.y);
            }

            // p.velocity *= movementVelocity;

        }

        public void Jump(float jumpMultiplier)
        {
            velocity += Vector2.Up*jumpMultiplier;
            isGrounded= false;
        }
        
    }

     class Program
    {
        public static List<GameObject> Hierarchy= new List<GameObject>();

        private const int playerWidth = 493 / 2;
        private const int WIDTH = 1280;
        private const int HEIGHT = 720;
        public static float gravity = 980f;
        private static Player player;


        static List<Player> players = new List<Player>();
        //static Player[] players= { player1, player2};

        static Vector2 position = new Vector2(0, 0);

        public static float deltaTime;
        public static DateTime startTime = DateTime.Now;
        public static float endTime;
        static float movementVelocity = 250f;

        static float jumpForce=700;


        static float xOffset = 960 - 640;
        static float maxXOffset = xOffset * 2;


        //If main is static all functions must be static
        static void Main(string[] args)
        {
            Game.Initialize("Mortal Kombat XXX",WIDTH,HEIGHT,false);
            InitializePlayers();
            
            while (true)
            {
                Update();
                Render();
            }
        }
        private static void InitializePlayers()
        {
     
   
        }
        private static void Update()
        {
            GetTime();

            //Then we draw what we want to show

            InputMovement();
         
            foreach (var p in players)
            {
                p.UpdatePosition();
              
            }
        }

        private static void Render()
        {
            Game.Clear();
            Game.Draw("bg.png", 0, 0, 1, 1, 0, xOffset, 0);
          

            foreach (var character in players)
            {
                character.Render();
            }

            //Game.Debug("dibuje la nave");
            Game.Show();
        }

        /// <summary>
        /// Se calcula el movimiento de los jugadores
        /// </summary>
        private static void InputMovement()
        {
            float x = GetAxisRaw("Horizontal");
            float y = GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(x, y);
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

        #region Outdated
        //static void CameraAdjust()
        //{
        //    //LA CAMARA TIENE QUE ACOMODARSE CUANDO UN JUGADOR SE MUEVA HACIA EL BORDE DE LA PANTALLA Y HAYA FONDO PARA MOVER. PERO SOLO PUEDE MOVERSE
        //    //SI EL OTRO JUGADOR QUEDA DENTRO DE LA PANTALLA
        //    //EL FONDO TIENE 1920 Y ARRANCA CON UN OFFSET DE 320, porque es la differencia entre el centro de la pantalla y de la imagen
        //    LeftAdjust(player1, player2);
        //    LeftAdjust(player2, player1);
        //    RightAdjust(player1, player2);
        //    RightAdjust(player2, player1);

        //}
        //static void LeftAdjust(Player a,Player b)
        //{


        //    if (player1.Position.x < 0)
        //    {
        //        player1.PosX = 0;
        //        if (xOffset > 0 && b.Position.x < 1280 - playerWidth)
        //        {
        //            xOffset--;
        //            player1.PosX++;
        //        }

        //    }

        //}
        //static void RightAdjust(Player a, Player b)
        //{
        //    if (player1.Position.x > 1280 - playerWidth)
        //    {
        //        player1.PosX = 1280-playerWidth;
        //        if (xOffset < 640 && player1.PosX > 0)
        //        {
        //            xOffset++;
        //            player1.PosX--;
        //        }
        //    }
        //}
        #endregion
    }
}