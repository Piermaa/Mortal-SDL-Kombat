using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Scene
    {
        private List<GameObject> hierarchy = new List<GameObject>();
        public List<GameObject> Hierarchy
        {
            get {return hierarchy; }
        }
        private LayersManager layersManager= new LayersManager();
        public LayersManager LayersManager => layersManager;
        
        public void Update()
        {
            for (int i = 0; i < hierarchy.Count; i++)
            {
                hierarchy[i].Update(Program.deltaTime);
            }
        }
        public void Render()
        {
            //actualizar todos los sprites de todas las layers y en orden!!!
            //osea el q este en la layer 0 se dibuja en la posicion 0 se dibujaria por abajo de todo
            //y lo que este en la layer 3 se dibuja por encima de todo
            //igualmente depende del orden que se haya agregado cada item a la lista
            foreach (var layer in layersManager.Layers)
            {
                foreach (var sprite in layer.SpritesInLayer)
                {
                    sprite.Render();
                }
            }
        }
    }
}
