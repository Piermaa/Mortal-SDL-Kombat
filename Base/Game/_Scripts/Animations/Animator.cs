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
        Animation currentAnimation;
        public void Awake(GameObject gameObject)
        {
            animations = new Dictionary<string, Animation>();
        }
        public void Start()
        {

        }

        public void Update(float deltaTime)
        {
            currentAnimation.Update();
        }


        private Animation CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed, string key)
        {
            // Idle Animation
            List<Texture> animationFrames = new List<Texture>();

            for (int i = 1; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, animationFrames, p_animationSpeed, true);
            animations.Add(key,animation);
            return animation;
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

            Animation idleAnimation = new Animation("Idle", idleFrames, 0.2f, true);
            animations.Add(idleAnimation);

            return animations;
        }

    }
}