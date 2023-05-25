using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //la clase level va a tener uno de estos y 
    class LayersManager
    {
        public List<SpriteRenderer> sprites;
        public LayersManager()
        {
            sprites = new List<SpriteRenderer>();
        }
        public void Render()
        {
            foreach (var s in sprites)
            {
                s.Render();
            }
        }
    }
}
