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
        private static DateTime startTime = DateTime.Now;
        private static float endTime;

        private const int WIDTH = 720;
        private const int HEIGHT = 720;

        public static Pool<Bullet> bullets = new Pool<Bullet>();

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
            // Singleton del GameManager

            GameManager.Instance.WindowDimensions= new Vector2(WIDTH,HEIGHT);
            Engine.Initialize("Rythm Galaga", WIDTH, HEIGHT, false);
            GameManager.Instance.ScenesCreation();
            GameManager.Instance.ChangeScene(GameManager.Instance.MENU_KEY_Getter);
        }
        static void GetTime()
        {
            // Calcular el DeltaTime
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - endTime;
            endTime = currentTime;
        }

        private static void Update()
        {
            // Limpia elcanvas
            Engine.Clear();
     
            
            // Calcula el tiempo
            GetTime();

            // Muestra lo que tiene que mostrar en ese nuevo frame
            GameManager.Instance.Update();
            Engine.Show();
        }

        //TODO: poner en INPUT.CS
        /// <summary>
        /// Se obtiene el valor bruto de un eje de movimiento dependiendo de la Input actual 
        /// </summary>
        /// <param name="axis">Nombre del eje, pej: Horizontal. Horizontal2 es para las ArrowKeys, input del player 2</param>
        /// <returns>Un valor que puede ser -1, 0 o 1 dependiendo del Input del jugador</returns>
    }
}