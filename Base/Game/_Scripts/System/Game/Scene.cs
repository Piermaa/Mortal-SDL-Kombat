using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Scene
    {
        public LayersManager LayersManager => layersManager;
        public List<GameObject> Hierarchy => hierarchy;

        protected List<GameObject> hierarchy = new List<GameObject>();
        protected LayersManager layersManager = new LayersManager();

        abstract public void SetupScene();

        public virtual void Update()
        {
            for (int i = 0; i < hierarchy.Count; i++)
            {
                hierarchy[i].Update(Program.deltaTime);
            }
        }
        public void Render()
        {
            layersManager.Render();
        }
        public void Reset()
        {
            layersManager.Reset();
            hierarchy.Clear();
        }
    }
}
