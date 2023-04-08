using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class SpriteRenderer : IMonoBehaviour
    {
        private Texture texture;
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
      
            Engine.Draw(texture, transform.position.x, transform.position.y,
              transform.scale.x, transform.scale.y, transform.rotation,
              texture.Width/2 * transform.scale.x, texture.Height / 2 * transform.scale.y);
           
        }

        public void SetTexture(Texture _texture)
        {
            texture = _texture;
        }
    }
}
