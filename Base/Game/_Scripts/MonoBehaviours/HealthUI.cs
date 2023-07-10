using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HealthUI : IMonoBehaviour
    {
        public string FilePathModifier { set {filePathModifier=value ; } }
        private string filePathModifier="";
        private PlayerCharacter player;
        private const string filePath = "Textures/UI/Health/";
        private SpriteRenderer spriteRenderer;
        public void Awake(GameObject gameObject)
        {
            player = GameManager.Instance.CurrentScene.FindObjectOfType<PlayerCharacter>();
            player.onLifeChanged += UpdateHealth;
            spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.SetTexture(Engine.GetTexture(filePath + filePathModifier+ 5 + ".png"));
        }

        public void Update(float deltaTime)
        {

        }

        private void UpdateHealth(int currenthealth)
        {
            spriteRenderer.SetTexture(Engine.GetTexture(filePath + filePathModifier + currenthealth + ".png"));
        }
    }
}
