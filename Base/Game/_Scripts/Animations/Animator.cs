using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            currentAnimation.RunAnimation();
        }

        /// <summary>
        /// Crea un objeto Animation y lo agrega a diccionario de animaciones del Animator
        /// </summary>
        /// <param name="p_animationID">Nombre de la animacion, se usa para despues acceder a ella y asignarla</param>
        /// <param name="p_path">Lugar donde  se guarda, sin el nombre de la textura</param>
        /// <param name="p_texturesAmount">Cantidad de frames de la animacion</param>
        /// <param name="p_animationSpeed">Velocidad en la que se pasa de frame</param>
        public Animation CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed, bool animationLoops)
        {
            List<Texture> animationFrames = new List<Texture>();

            //
            for (int i = 0; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, p_animationSpeed, animationFrames, animationLoops);
            animations.Add(p_animationID, animation);
            
            return animations[p_animationID];
        }
      
        /// <summary>
        /// Se setea la animacion actual del player
        /// </summary>
        /// <param name="animationName"></param>
        public void SetAnimation(string animationName)
        {
            currentAnimation = animations[animationName];
            currentAnimation.Reset();
        }
    }
}