using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IPowerUp
    {
        void Use(PlayerCharacter player);
    }
    
    public class HealthUp : IMonoBehaviour, IPowerUp
    {
        private GameObject m_gameObject;
        private RigidBody rb;
        private int speed=200;
        public void Awake(GameObject gameObject)
        {
            m_gameObject = gameObject;
            rb = gameObject.GetComponent<RigidBody>();
        }

        public void Update(float deltaTime)
        {
            rb.Velocity = new Vector2(0, speed);
        }

        public void Use(PlayerCharacter player)
        {
            player.Heal(1);
        }
    }
}
