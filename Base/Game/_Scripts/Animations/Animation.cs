using System.Collections.Generic;
using System;

namespace Game
{
    public class Animation
    {
        public event Action onAnimationFinish;

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
        /// <summary>
        /// Tiempo y frame en 0
        /// </summary>
        public void Reset()
        {
            this.currentFrame = 0;
            this.currentAnimationTime = 0;
        }
        /// <summary>
        /// Se corre la animacion, cambian los frames, loopea si llega al final y si tiene loop
        /// </summary>
        public void RunAnimation()
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
                        onAnimationFinish?.Invoke();
                        currentFrame = textures.Count - 1;
                    }
                }
            }
        }
    }
}
