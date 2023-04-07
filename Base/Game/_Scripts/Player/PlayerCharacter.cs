using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PlayerCharacter : BaseCharacter, IMonoBehaviour
    {

        float speed = 30;
        public GameObject gameObject
        { get { return m_GameObject; } set { m_GameObject = value; } }
        public Transform transform
        { get { return m_Transform; } set { m_Transform = value; } }
        RigidBody rb;

        //AL CREAR EL SCRIPT SE AGREGAN TODOS LOS COMPONENTES QUE USA PLAYERCHARACTER
        public PlayerCharacter(GameObject _gameObject) : base(_gameObject)
        {
            // : base (_gameObject), significa que le pasa el gameObject del que hereda

            m_GameObject = _gameObject;
            m_Transform = _gameObject.transform;
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            spriteRenderer.texture = Engine.GetTexture("ship.png");
            rb = new RigidBody();
            m_GameObject.AddComponent(spriteRenderer);
            m_GameObject.AddComponent(rb);
        }

        public void Awake(GameObject _gameObject)
        {
          
        }
        public void Start()
        { 
       
        }
        public void Update(float deltaTime)
        {
            float x = Program.GetAxisRaw("Horizontal");
            float y = Program.GetAxisRaw("Vertical");

            Vector2 dir= new Vector2(x, y);
          
            rb.velocity = dir*speed;
        }
     
        public Vector2 Position
        {
            get { return transform.position; }

            set { transform.position = value; }
        }

     
        //esto tendria que ir en un manager de colisiones supongo
        public bool IsBoxColliding(Transform p_objB)
        {
            float distanceX = Math.Abs(transform.position.x - p_objB.position.x);
            float distanceY = Math.Abs(transform.position.y - p_objB.position.y);

            float sumHWidths = transform.scale.x/2 + p_objB.scale.x/2;   
            float sumHHeights = transform.scale.y/2 + p_objB.scale.y/2;

            return distanceX <= sumHWidths && distanceY <= sumHHeights;
        
        }
        public bool IsBoxCircleColliding(Transform p_objB)
        {
            float distanceX = Math.Abs(transform.position.x - p_objB.position.x);
            float distanceY = Math.Abs(transform.position.y - p_objB.position.y);

            float sumHWidths = transform.scale.x / 2 + p_objB.scale.x / 2;
            float sumHHeights = transform.scale.y / 2 + p_objB.scale.y / 2;

            return distanceX <= sumHWidths && distanceY <= sumHHeights;

        }

    
    }

   
}
