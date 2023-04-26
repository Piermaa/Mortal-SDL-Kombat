using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class InputManager
    {
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
