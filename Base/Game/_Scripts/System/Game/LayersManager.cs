using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Layer
    {
        private List<SpriteRenderer> spritesInLayer; 
        public List<SpriteRenderer> SpritesInLayer
        {
            get { return spritesInLayer; }
        }
        public Layer()
        {
            spritesInLayer = new List<SpriteRenderer>();
        }

        public void AddSpriteToLayer(SpriteRenderer spriteRenderer)
        {
            spritesInLayer.Add(spriteRenderer);
        }
        public void RemoveSprite(SpriteRenderer spriteRenderer)
        {
            spritesInLayer.Remove(spriteRenderer);
        }
    }
    //la clase level va a tener uno de estos y 
    class LayersManager
    {
        private int defaultLayer = 1;
        private int layersCount = 5;
        private List<Layer> layers;
        public List<Layer> Layers=>layers;
       
        public LayersManager()
        {
            layers = new List<Layer>();
            for (int i = 0; i < layersCount; i++)
            {
                Layer l = new Layer();
                layers.Add(l);
            }
        }
      
        public void AddToLayer(SpriteRenderer spriteRenderer,int newLayer)
        {
            layers[newLayer].AddSpriteToLayer(spriteRenderer);
        }

        public void AddToLayer(SpriteRenderer spriteRenderer)
        {
            layers[defaultLayer].AddSpriteToLayer(spriteRenderer);//index is out of range
        }

        public void RemoveFromLayer(SpriteRenderer spriteRenderer, int currentLayer)
        {
            layers[currentLayer].RemoveSprite(spriteRenderer);
        }
    }
}
