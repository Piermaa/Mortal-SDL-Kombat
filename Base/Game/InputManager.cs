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


    }
}
