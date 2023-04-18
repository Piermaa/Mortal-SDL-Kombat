using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Animator : IMonoBehaviour
    {
        public Dictionary<string, Animation> animations;

        SpriteRenderer spriteRenderer;
        GameObject gameObject;

        Animation engineAnimation;
        Animation currentAnimation;

        public Animator ()
        {
            var engineTextures = new List<Texture>();

            for (int i = 0; i < 3; i++)
            {
                engineTextures.Add(Engine.GetTexture("Textures/Animations/Engine/" + i + ".png"));
            }

            engineAnimation = new Animation("EngineAnimation", 0.1f, engineTextures, true);

            currentAnimation = engineAnimation;
        }

        public void Awake(GameObject gameObject)
        {
            this.gameObject = gameObject;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            animations = new Dictionary<string, Animation>();
        }
        public void Update(float deltaTime)
        {
            spriteRenderer.SetTexture(currentAnimation.CurrentFrame);

            currentAnimation.Update();
        }

        private void CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed, string key)
        {
            // Idle Animation
            List<Texture> animationFrames = new List<Texture>();

            for (int i = 1; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, p_animationSpeed, animationFrames,  true);
            //animations.Add(key, animation);
            //return animation;

            
        }

        private List<Animation> GetPlayerAnimations()
        {
            List<Animation> animations = new List<Animation>();

            // Idle Animation
            List<Texture> idleFrames = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                idleFrames.Add(Engine.GetTexture($"Textures/Animations/Idle/{i}.png"));
            }

            Animation idleAnimation = new Animation("Idle", 0.2f, idleFrames, true);
            animations.Add(idleAnimation);

            return animations;
        }

    }
}