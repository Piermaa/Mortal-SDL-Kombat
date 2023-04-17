using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet : IMonoBehaviour
    {
        private float _speed = 750;
        //bool draw = true;
        private bool ally;
        public bool Ally => ally;
        //public bool Draw => draw;
        private RigidBody rb;
        public Bullet(GameObject p_gameObject, bool isAlly)
        {
            

            p_gameObject.AddComponent(this);
            ally = isAlly;
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            spriteRenderer.SetTexture(Engine.GetTexture("Animations/Player/Bullet.png"));
 
            p_gameObject.AddComponent(spriteRenderer);

            rb = new RigidBody();
            p_gameObject.AddComponent(rb);

            Collider collider = new Collider(5, p_gameObject);
        }

        public void Awake(GameObject gameObject)
        {
           
        }

        public void Start()
        {
        }

       
        public void Update(float deltaTime)
        {
           rb.velocity = Vector2.Up*_speed;
        }

        //public void DrawBullet()
        //{
        //    if (draw)
        //        Engine.Draw("0.png", _posX, _posY, .25f, .25f, _rot, 145.5f, 86.5f);
        //}

    }
}
