using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class SpriteRenderer : IMonoBehaviour
    {
        private int layer=1;
        public bool Enabled
        {
            get { return enabled; }
            set
            { 
                enabled = value;
            }
        }
        public int Layer
        {
            set
            {
                GameManager.Instance.CurrentScene.LayersManager.RemoveFromLayer(this, layer); //lo saco de la layer en que esta
                layer = value;//le cambio el valor de layer
                GameManager.Instance.CurrentScene.LayersManager.AddToLayer(this, layer); //lo cambio de layer
            }
            get { return layer; } 
        }
        private Scene scene;
        private Texture texture;
        private GameObject gameObject;
        private Transform transform;
        private bool enabled;
        public void Awake(GameObject gameObject)
        {
            this.gameObject = gameObject;
            transform = gameObject.transform;

            scene=GameManager.Instance.CurrentScene; // para cachear y no tener que escribir todo esto devuelta 2 veces
            scene.LayersManager.AddToLayer(this);
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

        private void Destroy()
        {
            Engine.Debug("DEStroyed!!");
            scene.LayersManager.RemoveFromLayer(this, layer);
        }
    }
}
