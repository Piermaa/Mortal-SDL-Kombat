using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class SpriteRenderer : IMonoBehaviour
    {
        public Texture texture;
        GameObject gameObject;
        Transform transform;
        public void Awake(GameObject gameObject)
        {
            this.gameObject = gameObject;
            transform = gameObject.transform;
        }

        public void Start()
        {
           // throw new NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            Engine.Draw(texture,transform.position.x, transform.position.y, 0,0,0,0,0);
        }
    }
}
