using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MenuScene : Scene
    {
        GameObject canvas;
        public override void SetupScene()
        {
            canvas= new GameObject();
            SpriteRenderer canvasImage = new SpriteRenderer();
            canvasImage.SetTexture(GetCanvasTexture());
            canvas.AddComponent(canvasImage);
            canvas.transform.SetPosition(new Vector2(GameManager.Instance.WindowDimensions.x/2, GameManager.Instance.WindowDimensions.y / 2));
            InitializeBackground();
        }

        private Texture GetCanvasTexture()
        {
            Texture texture=null;
            switch (GameManager.Instance.GameState)//TODO: Cambiar numeros magicos por un enum
            {
                case (0):
                    texture = Engine.GetTexture("Textures/UI/PressEnterToPlay.png");
                    canvas.transform.scale = new Vector2(0.8f, 0.8f);
                    break;

                case (1):
                    texture = Engine.GetTexture("Textures/UI/Win.png");
                    canvas.transform.scale = new Vector2(0.35f, 0.35f);
                    break;

                case (2):
                    texture= Engine.GetTexture("Textures/UI/Fail.png");
                    canvas.transform.scale = new Vector2(0.6f, 0.6f);
                    break;
            }

            return texture;
        }
        private void InitializeBackground()
        {
            var background = new GameObject();
            var bg = new SpriteRenderer(0);
            bg.SetTexture(Engine.GetTexture("Textures/Backgrounds/bgSpace.png"));
            background.transform.SetPosition(new Vector2(0, 200));
            background.AddComponent(bg);
        }
    }

}

