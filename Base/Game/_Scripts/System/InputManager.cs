using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class InputManager
    {
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
                    if (Engine.GetKey(Keys.A) || Engine.GetKey(Keys.LEFT))
                    {
                        return -1;
                    }
                    if (Engine.GetKey(Keys.D) || Engine.GetKey(Keys.RIGHT))
                    {
                        return 1;
                    }
                    break;

                case "Vertical":
                    if (Engine.GetKey(Keys.W) || Engine.GetKey(Keys.UP))
                    {
                        return -1;
                    }
                    if (Engine.GetKey(Keys.S) || Engine.GetKey(Keys.DOWN))
                    {
                        return 1; // para abajo positivo
                    }
                    break;

            }

            return 0;
        }


    }
}
