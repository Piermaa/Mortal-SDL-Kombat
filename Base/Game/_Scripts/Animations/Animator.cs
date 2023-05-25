using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 */
namespace Game
{
    class Animator : IMonoBehaviour
    {
        private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        private SpriteRenderer spriteRenderer;
        private GameObject gameObject;

        private Animation currentAnimation;

        public void Awake(GameObject gameObject)
        {
            this.gameObject = gameObject;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        public void Update(float deltaTime)
        {
            spriteRenderer.SetTexture(currentAnimation.CurrentFrame);
            currentAnimation.Update();
        }

        public void CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed)
        {
            List<Texture> animationFrames = new List<Texture>();

            //
            for (int i = 0; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, p_animationSpeed, animationFrames,  true);
            animations.Add(p_animationID, animation); 
        }

        public void SetAnimation(string animationName)
        {
            currentAnimation = animations[animationName];
        }

        public List<Animation> GetPlayerAnimations()
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