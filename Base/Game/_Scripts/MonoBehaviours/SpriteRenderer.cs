using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class SpriteRenderer : IMonoBehaviour
    {
        public bool Enabled
        {
            get { return enabled; }
            set
            { 
                enabled = value;
            }
        }
 
        private Scene scene;
        private Texture texture;
        private GameObject gameObject;
        private Transform transform;
        private bool enabled;
        private int layer = 2;

        public void Awake(GameObject gameObject)
        {
            this.gameObject = gameObject;
            transform = gameObject.transform;

            GameManager.Instance.CurrentScene.LayersManager.sprites.Add(this);
            gameObject.OnDestroy += Destroy;
        }

        public void Update(float deltaTime)
        {
          
        }

        public void Render()
        {
            if (texture != null && gameObject.IsEnabled)
            {
                Engine.Draw(texture, transform.position.x, transform.position.y,
                transform.scale.x, transform.scale.y, transform.rotation,
                texture.Width / 2 * transform.scale.x, texture.Height / 2 * transform.scale.y);
            }
        }

        public void SetTexture(Texture _texture)
        {
            texture = _texture;
        }

        /// <summary>
        /// Se saca de la Layer
        /// </summary>
        private void Destroy()
        {
            Engine.Debug("DEStroyed!!");
            // GameManager.Instance.CurrentScene.LayersManager.RemoveFromLayer(this, layer);
            GameManager.Instance.CurrentScene.LayersManager.sprites.Remove(this);
            gameObject.OnDestroy -= Destroy;
        }
    }
}
