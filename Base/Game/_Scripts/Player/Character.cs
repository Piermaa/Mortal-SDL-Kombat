using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character
    {
        private float life = 100f;

        private Transform transform;

        private float speed = 0;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public Transform Transform => transform;
        
        Animation currentAnimation = null;
        Animation idle;

        //List<Animation> animations = new List<Animation>();

        public Character(Vector2 initialPos)
        {
            idle = CreateAnimation("Idle","",4,2);
          //  transform = new Transform(initialPos,0,new Vector2(1,1));

            currentAnimation = idle;// GetAnimation("Idle");
            currentAnimation.Reset();
        }

        public void Update()
        {
            currentAnimation.Update();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame,transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }
        public void DamageLife(int damage)
        {
            life -= damage;
        }
        public void Kill()
        {

        }

      /*  private Animation GetAnimation(string id)
        {
            for (int i = 0; i < animations.Count; i++)
            {
                if (animations[i].Id == id)
                {
                    return animations[i];
                }
            }

            Engine.Debug($"No se encontró la animación con el id: {id}");
            return null;
        }*/

        private Animation CreateAnimation(string p_animationID, string p_path,int p_texturesAmount,float p_animationSpeed)
        {
            // Idle Animation
            List<Texture> animationFrames = new List<Texture>();

            for (int i = 1; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, p_animationSpeed, animationFrames, true);

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

            Animation idleAnimation = new Animation("Idle", 0.2f, idleFrames, true);
            animations.Add(idleAnimation);

            return animations;
        }

        
        public bool IsBoxColliding(Character p_objB)
        {
            float distanceX = Math.Abs(transform.position.x - p_objB.transform.position.x);
            float distanceY = Math.Abs(transform.position.y - p_objB.transform.position.y);

            float sumHalfWidths = RealWidth /2 + p_objB.RealWidth /2;
            float sumHalfHeights = RealHeight /2 + p_objB.RealHeight/2;

            if(distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                return true;
            }
            return false;
        }


        public void AddMove(Vector2 pos)
        {
            transform.position.x += pos.x;
            transform.position.y += pos.y;
        }
    }
}
