using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Scene
    {
        public LayersManager LayersManager => layersManager;
        public List<GameObject> Hierarchy => hierarchy;

        private List<GameObject> hierarchy;
        private LayersManager layersManager;

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
            layersManager.Reset();
            hierarchy.Clear();
        }
    }
}
