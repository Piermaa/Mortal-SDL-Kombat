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
        public GameObject gameObject
        { get { return m_GameObject; } set { m_GameObject = value; } }
        public Transform transform
        { get { return m_Transform; } set { m_Transform = value; } }
        RigidBody rb;
        float speed = 300;

        //AL CREAR EL SCRIPT SE AGREGAN TODOS LOS COMPONENTES QUE USA PLAYERCHARACTER
        public PlayerCharacter(GameObject _gameObject) : base(_gameObject)
        {
            // : base (_gameObject), significa que le pasa el gameObject del que hereda
            //no sobreescribir por las dudas no se si borra el new BaseCharacter(Go _go)
        }

        public void Awake(GameObject _gameObject)
        {
            rb = _gameObject.GetComponent<RigidBody>();
            transform.SetPosition(new Vector2(500,1000));
        }
        public void Start()
        { 
       
        }
        public void Update(float deltaTime)
        {
        
        }

        private void Movement()
        {
            float x = Program.GetAxisRaw("Horizontal");
            float y = Program.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(x, y);

            rb.velocity = dir * speed;
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
