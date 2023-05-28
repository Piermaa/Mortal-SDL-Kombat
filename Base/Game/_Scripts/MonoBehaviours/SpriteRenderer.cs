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
        private int currentLayer;

        public SpriteRenderer()
        {
            currentLayer = 2;
        }

        public SpriteRenderer(int customLayer)
        {
            currentLayer= customLayer;
        }

        public void Awake(GameObject gameObject)
        {
            this.gameObject = gameObject;
            transform = gameObject.transform;

            GameManager.Instance.CurrentScene.LayersManager.AddSpriteToLayer(currentLayer,this);
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
            gameObject.OnDestroy -= Destroy;
            GameManager.Instance.CurrentScene.LayersManager.RemoveSprite(currentLayer, this);
        }
    }
}
