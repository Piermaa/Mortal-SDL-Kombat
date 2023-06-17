using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MenuScene : Scene
    {
        public override void SetupScene()
        {
            GameObject canvas = new GameObject();
            SpriteRenderer canvasImage = new SpriteRenderer();
            canvasImage.SetTexture(GetCanvasTexture());
            canvas.AddComponent(canvasImage);
            canvas.transform.SetPosition(new Vector2(GameManager.Instance.WindowDimensions.x/2, GameManager.Instance.WindowDimensions.y / 2));
        }

        private Texture GetCanvasTexture()
        {
            Texture texture=null;
            Engine.Debug(GameManager.Instance.GameState);
            switch (GameManager.Instance.GameState)//TODO: Cambiar numeros magicos por un enum
            {
                case (0):
                    texture = Engine.GetTexture("Textures/UI/PressEnter.png");
                    break;

                case (1):
                    texture= Engine.GetTexture("Textures/UI/Win.png");
                    break;

                case (2):
                    texture= Engine.GetTexture("Textures/UI/Fail.png");
                    break;
            }

            return texture;
        }
    }
}

