﻿using System;
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
        public static double cooldownDebugger = 0.50847457;

        private const int WIDTH = 720;
        private const int HEIGHT = 720;

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
            GameManager.Instance.SetMenuScene();
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

        static void GetTime()
        {
            // Calcular el DeltaTime
            var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentTime - endTime;
            endTime = currentTime;
        }
        //TODO: clASS====================================================
        public static void GetBPM() 
        {
            cooldownDebugger -= deltaTime;

            if (cooldownDebugger < 0.25f) 
            {
                if (cooldownDebugger <= 0)
                {
                    cooldownDebugger = 0.50847457;
                    Console.WriteLine("Has ended the bpm");
                }
            }
        }

        public static bool AbleToShoot()
        {
            return cooldownDebugger < 0.25f;
        }
        //==============================================================
    }
}