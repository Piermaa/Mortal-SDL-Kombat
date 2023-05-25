using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Scene
    {
        private List<GameObject> hierarchy;
        public List<GameObject> Hierarchy => hierarchy;
      
        private LayersManager layersManager;
        public LayersManager LayersManager => layersManager;

        public Scene()
        {
            layersManager = new LayersManager();
            hierarchy = new List<GameObject>();
        }

        public void Update()
        {
            for (int i = 0; i < hierarchy.Count; i++)
            {
                hierarchy[i].Update(Program.deltaTime);
            }
        }
        public void Render()
        {
            LayersManager.Render();
        }

        public void Reset()
        {
            foreach (var go in hierarchy)
            {
                go.Destroy();
            }
        }
    }
}
