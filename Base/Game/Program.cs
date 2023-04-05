using System;
using System.Collections.Generic;

namespace TestEngine
{
    class PlayerCharacter : CharacterData
    {
        public Transform Transform {
            get {return transform; }
            set {transform= value; }
        }
        public Vector2 Position 
        {   
            get { return transform.position; }

            set { transform.position = value;}
        }
 
        public PlayerCharacter(string textureNameString)
        {
            textureName = textureNameString;
        }
    }

     class Program
    {
        public static List<GameObject> Hierarchy= new List<GameObject>();
        public static List<IRendereable> rendereables = new List<IRendereable>();

        private const int playerWidth = 493 / 2;
        private const int WIDTH = 1280;
        private const int HEIGHT = 720;
        public static float gravity = 980f;



        static Vector2 position = new Vector2(0, 0);

        public static float deltaTime;
        public static DateTime startTime = DateTime.Now;
        public static float endTime;
        static float movementVelocity = 250f;

        static float jumpForce=700;


        static float xOffset = 960 - 640;
        static float maxXOffset = xOffset * 2;

        static GameObject player;

        //If main is static all functions must be static
        static void Main(string[] args)
        {
            Game.Initialize("Rombai de fiesta",WIDTH,HEIGHT,false);
            InitializePlayers();

            foreach (var go in Hierarchy)
            {
                go.Start(go);
            }
           
            while (true)
            {
                Update();
                Render();
            }
        }
       
        private static void InitializePlayers()
        {
            player = new GameObject();
            PlayerCharacter playerData= new PlayerCharacter("Main Ship - Base - Full health.png");
            player.AddComponent(playerData);
            rendereables.Add(playerData);
        }
        private static void Update()
        {
            GetTime();

            //Then we draw what we want to show

            InputMovement();
        
            foreach (var go in Hierarchy)
            {
                go.Update(deltaTime);
            }

            
        }

        private static void Render()
        {
            Game.Clear();
            Game.Draw("bg.png", 0, 0, 1, 1, 0, xOffset, 0);
            foreach (var go in rendereables)
            {
                go.Render();
            }

            //Game.Debug("dibuje la nave");
            Game.Show();
        }


        /// <summary>
        /// El GameObject creado es agregado a la jerarquia y se le asigna una posicion
        /// </summary>
        /// <param name="newGo"></param>
        /// <param name="position"></param>
        private static void Instantiate(GameObject newGo, Vector2 position)
        {
            Hierarchy.Add(newGo);
            newGo.transform.SetPosition(position);
         
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