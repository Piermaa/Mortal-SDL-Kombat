using System;
using System.Collections.Generic;

namespace TestEngine
{
    public class Program
    {
        static Vector2 position= new Vector2(0,0);
        static float xPosition = 0f;
        static float yPosition = 0f;
        public static float deltaTime;
        public static DateTime startTime=DateTime.Now;
        public static float endTime;
        static float movementVelocity = 5f;


        //If main is static all functions must be static
        static void Main(string[] args)
        {
            Game.Initialize();

            while(true)
            {
                Render();
            }
        }

        private static void Render()
        {
            //First, it clears
            Game.Clear();

            //Then we draw what we want to show
            Game.Draw("bg.png", 0, 0, 1, 1, 0, 550, 0);
            Game.Draw("otacon.png",position.x, position.y, 0.2f, 0.2f, 0, 0);
            
            GetTime();
            InputMovement();
            

            //Finally, we show it
            Game.Show();
        }

        private static void InputMovement()
        {
            if (Game.GetKey(Keys.D) || Game.GetKey(Keys.RIGHT))
            {
                ProcessMovement(movementVelocity, 0);
            }

            if (Game.GetKey(Keys.A) || Game.GetKey(Keys.LEFT))
            {
                ProcessMovement(-movementVelocity, 0);
            }

            if (Game.GetKey(Keys.W) || Game.GetKey(Keys.UP)) 
            {
                ProcessMovement(0, -movementVelocity);
            }

            if (Game.GetKey(Keys.S) || Game.GetKey(Keys.DOWN))
            {
                ProcessMovement(0, movementVelocity);
            }

            //switch (key)
            //{
            //    case (Keys.A):
            //        xPosition++;
            //            break;

            //    case (Keys.D):

            //}
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
            var currentTime=(float)(DateTime.Now-startTime).TotalSeconds;
            deltaTime = currentTime - endTime;
            endTime=currentTime;
        }
    }
}