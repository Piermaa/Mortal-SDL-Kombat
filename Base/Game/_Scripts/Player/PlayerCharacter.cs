using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PlayerCharacter :BaseCharacter, IMonoBehaviour
    { 
        public GameObject gameObject
        { get { return m_GameObject; } set { m_GameObject = value; } }
        public Transform transform
        { get { return m_Transform; } set { m_Transform = value; } }

        Collider collider;
        RigidBody rb;
        float speed = 300;

        float shootCD=1;
        float shootTimer;
        //AL CREAR EL SCRIPT SE AGREGAN TODOS LOS COMPONENTES QUE USA PLAYERCHARACTER
        public PlayerCharacter(GameObject _gameObject, string textureName) : base(_gameObject, textureName)
        {
   
            // : base (_gameObject), significa que le pasa el gameObject del que hereda
            //no sobreescribir por las dudas no se si borra el new BaseCharacter(Go _go)
        }

        public void Awake(GameObject _gameObject)
        {
            rb = _gameObject.GetComponent<RigidBody>();
            transform.SetPosition(new Vector2(500,1000));
            transform.scale = new Vector2(3,3);
        }
        public void Start()
        { 
       
        }
        public void Update(float deltaTime)
        {
            Movement();
            Shoot(deltaTime);
        }

        private void Movement()
        {
            float x = Program.GetAxisRaw("Horizontal");
            float y = Program.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(x, y);
            dir = dir.Normalize();
            rb.velocity = dir * speed;
        }

        private void Shoot(float deltaTime)
        {
            shootTimer = shootTimer > 0 ? shootTimer - deltaTime : 0;
            if (Engine.GetKey(Keys.SPACE) && shootTimer == 0)
            {
                shootTimer = shootCD;
                var b = new GameObject("Bullet");
                Bullet bullet = new Bullet(b, true);
                b.transform.position = transform.position + Vector2.Up * 10;
            }
        }
    }

   
}
