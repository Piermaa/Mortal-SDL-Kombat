using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PlayerCharacter : BaseCharacter
    {
        public Transform m_Transform
        {
            get { return transform; }
            set { transform = value; }
        }
        public Vector2 Position
        {
            get { return transform.position; }

            set { transform.position = value; }
        }

        public PlayerCharacter(string textureNameString)
        {
            textureName = textureNameString;
        }

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
