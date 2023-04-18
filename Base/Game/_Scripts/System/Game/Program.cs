using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    #region 12/4 Singletones
    //SOLO GUARDA UNA REF AL PLAYER, LOS DEMAS CHARACTERS SE MANEJAN CON EL MANAGER
    //Manager de characters hacer un metodo para tener una copia de la lista que usa y otro para .Add un elemento, es por seguridad
    // como la lista tiene muchos metodos no se debe permitir el acceso asi tan facil
    #endregion
    class Program
    {
        public static float deltaTime;
        static DateTime startTime = DateTime.Now;
        static float endTime;

        private const int WIDTH = 1000;
        private const int HEIGHT = 1000;
        //If main is static all functions/vars must be static
        static void Main(string[] args)
        {
            StartEngine();
            while (true)
            {
                Update();
            }
        }
        private static void StartEngine()
        {
            GameManager.Instance.WindowDimensions= new Vector2(WIDTH,HEIGHT);
            Engine.Initialize("Rythm Galaga", WIDTH, HEIGHT, false);
     
        }
        static void GetTime()
        {
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - endTime;
            endTime = currentTime;
        }

        private static void Update()
        {
            Engine.Clear();
     
            GetTime();
            GameManager.Instance.Update();
            Engine.Show();
        }

     

    



        //private static void LooseCondition()
        //{
        //    if ( playerLife <= 0)
        //    {
        //        isPlaying = false;
        //        gameState = 2;
        //    }
        //}

        //TODO: INPUT.CS
        /// <summary>
        /// Se obtiene el valor bruto de un eje de movimiento dependiendo de la Input actual 
        /// </summary>
        /// <param name="axis">Nombre del eje, pej: Horizontal. Horizontal2 es para las ArrowKeys, input del player 2</param>
        /// <returns>Un valor que puede ser -1, 0 o 1 dependiendo del Input del jugador</returns>
        public static int GetAxisRaw(string axis)
        {
            switch (axis)
            {
                case "Horizontal":
                    if (Engine.GetKey(Keys.A))
                    {
                        return -1;
                    }
                    if (Engine.GetKey(Keys.D))
                    {
                        return 1;
                    }
                    break;

                case "Vertical":
                    if (Engine.GetKey(Keys.W))
                    {
                        return -1;
                    }
                    if (Engine.GetKey(Keys.S))
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
        
     
    }
}
//    public class Program
//    {
//        //variables deltatime
//        public static float deltaTime;
//        static DateTime lastFrameTime = DateTime.Now;

//        static float _posY = 305;
//        static float _posX = 305;
//        static float _speed = 100;

//        static float _rot = 0;

//        static Character ship;
//        static Character pp;

//        static List<Bullet> bullets = new List<Bullet>();

//        static Animation currentAnimation = null;
//        static Animation idle;

//        static List<Character> characters = new List<Character>();

//        void Main(string[] args)
//        {
//            Engine.Initialize();
//            pp = new Character(new Vector2(100,100));
//            ship = new Character(new Vector2(150,100));
//            idle = CreateAnimation();
//            currentAnimation = idle;

//            characters.Add(pp);
//            characters.Add(ship);

//            SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
//            //myplayer.PlayLooping();

//            while (true)
//            {
//                calcDeltatime();

//                Update();
//                Draw();
//            }
//        }

//        static void Update()
//        {
//            if (Engine.GetKey(Keys.SPACE))
//            {
//               pp.AddMove(new Vector2(10 * deltaTime, 10 * deltaTime));
//            }

//            for (int i = 0; i < bullets.Count; i++)
//            {
//                bullets[i].Update();
//            }


//            foreach (var character in characters)
//            {
//                for (int i = 0; i < characters.Count; i++)
//                {
//                    if(character != characters[i])
//                        if (character.IsBoxColliding(characters[i]))
//                        {
//                            Engine.Debug("ESTOY COLISIONANDO");
//                        }
//                }
//            }

//            //currentAnimation.Update();
//            ship.Update();
//            pp.Update();
//        }

//        static void Draw()
//        {
//            Engine.Clear();

           
//            ship.Render();
//            pp.Render();
//            for (int i = 0; i < bullets.Count; i++)
//            {
//                if (!bullets[i].Draw)
//                {
//                    bullets.RemoveAt(i);
//                }
//            }

//            for (int i = 0; i < bullets.Count; i++)
//            {
//                bullets[i].DrawBullet();
//            }

//            Engine.Show();
//        }

//        static void calcDeltatime()
//        {
//            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
//            deltaTime = (float)deltaSpan.TotalSeconds;
//            lastFrameTime = DateTime.Now;
//        }


//        static void Shoot()
//        {
//            bullets.Add(new Bullet(_posX + 230, _posY + 60, _rot));
//        }

//        private static Animation CreateAnimation()
//        {
//            // Idle Animation
//            List<Texture> idleFrames = new List<Texture>();

//            for (int i = 0; i < 4; i++)
//            {
//                idleFrames.Add(Engine.GetTexture($"{i}.png"));
//            }

//            Animation idleAnimation = new Animation("Idle", idleFrames, 2, true);

//            return idleAnimation;
//        }
//    }
//}