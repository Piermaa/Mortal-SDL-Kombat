using System.Collections.Generic;

namespace Game
{
    public class Animation
    {
        private string id;
        private bool isLoop;
        private List<Texture> textures;
        private float speed = 0;
        private float currentAnimationTime = 0;
        private int currentFrame = 0;

        public string Id => id;
        public Texture CurrentFrame => textures[currentFrame];

        public Animation(string name, float speed, List<Texture> textures,  bool isLoop)
        {
            this.id = name;
            this.speed = speed;
            this.isLoop = isLoop;
            this.currentFrame = 0;

            if (textures != null)
            {
                this.textures = textures;
            }
        }

        public void Reset()
        {
            this.currentFrame = 0;
            this.currentAnimationTime = 0;
        }

        public void Update()
        {
            currentAnimationTime += Program.deltaTime;

            if (currentAnimationTime >= speed)
            {
                currentFrame++;
                currentAnimationTime = 0;

                if (currentFrame >= textures.Count)
                {
                    if (isLoop)
                    {
                        currentFrame = 0;
                    }

                    else
                    {
                        currentFrame = textures.Count - 1;
                    }
                }
            }
        }
    }
}
