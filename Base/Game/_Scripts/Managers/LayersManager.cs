using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //la clase level va a tener uno de estos y 
    class Layer
    {
       public List<SpriteRenderer> sprites =new List<SpriteRenderer>();
    }
    public class LayersManager
    {
        private Layer[] spritesLayer= new Layer[5];
        private int defaultLayer=2;
        public LayersManager()
        {
            spritesLayer= new Layer[5];
            for (int i = 0; i < spritesLayer.Length; i++)
            {
                spritesLayer[i] = new Layer();
            }
        }
        public void AddSpriteToLayer(int index, SpriteRenderer sprite)
        {
            spritesLayer[index].sprites.Add(sprite);
        }
        public void RemoveSprite(int index, SpriteRenderer sprite)
        {
            spritesLayer[index].sprites.Remove(sprite);
        }

        public void Render()
        {
            for (int i = 0; i < spritesLayer.Length; i++)
            {
                foreach (var spriteRenderer in spritesLayer[i].sprites)
                {
                    spriteRenderer.Render();
                }
            }
        }
        public void Reset()
        {
            spritesLayer = new Layer[5];
            for (int i = 0; i < spritesLayer.Length; i++)
            {
                spritesLayer[i] = new Layer();
            }
        }
    }
}
